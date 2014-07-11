using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.IRepository;
using GestorDocument.Model.DashBoardModel;
using GestorDocument.Model;
using System.Globalization;

namespace GestorDocument.DAL.Repository
{
    public class DashBoardRepository:IDashBoard
    {
        const long PRIORIDAD_URGENTE = 20130611175650143;
        const long PRIORIDAD_ORDINARIO = 20130611175614758;
        const long PRIORIDAD_PRIORITARIO = 20130611175614758;

        public System.Collections.ObjectModel.ObservableCollection<AnioModel> GetAnio()
        {
            ObservableCollection<AnioModel> ocAnio = new ObservableCollection<AnioModel>();            
            try
            {
                for (int i = 0; i <= 2; i++)
                {
                    ocAnio.Add(new AnioModel() { Anio = (DateTime.Now.Year-i) });
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
            return ocAnio;
        }

        public System.Collections.ObjectModel.ObservableCollection<Model.DashBoardModel.MesModel> GetMes()
        {
            ObservableCollection<MesModel> ocMes = new ObservableCollection<MesModel>();            
            CultureInfo cultura = null;
            try
            {
                int index = 1;
                cultura = new CultureInfo("es-ES");                               
                (from m in cultura.DateTimeFormat.MonthNames
                          select m).ToList().ForEach(i=>
                              {
                                  ocMes.Add(new MesModel()
                                  {
                                      Mes=index,
                                      MesName = cultura.TextInfo.ToTitleCase(i)
                                  });
                                  index++;                          
                              });
            }
            catch (Exception)
            {                
                throw;
            }
            return ocMes;
        }

        /// <summary>
        /// Obtiene  el cálculo de asuntos pendientes por vencer y vencidos en base a la fecha de sistema y signatarios
        /// </summary>
        /// <param name="Determinantes">Lista de signatarios (determinantes externos)</param>
        /// <returns>PendienteIndicadorModel calculo de los pendientes vencidos y por vencer</returns>
        public Model.DashBoardModel.PendienteIndicadorModel GetPendientes(ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            Model.DashBoardModel.PendienteIndicadorModel Pendiente = null;

            //Obtener CSV
            string signatarios = this.GetSignatariosCSV(Determinantes);

            try
            {
                using (var entity = new GestorDocumentEntities())
                {
                    var pend = entity.SpDashboardPendientesIndicador(signatarios).FirstOrDefault();
                    if (pend != null)
                    {
                        Pendiente = new PendienteIndicadorModel()
                        {
                            PorVencer = (int)pend.PorVencer,
                            Vencidos = (int)pend.Vencidos
                        };
                    }
                }
            }
            catch (Exception)
            {
                //TODO Log
            }
            return Pendiente;
        }

        /// <summary>
        /// Ejecuta el stored SP_DASHBOARD_ATENDIDOS_INDICADOR que trae el calculo de los asuntos atendidos dentro y fuera de tiempo
        /// </summary>
        /// <param name="Determinantes">Lista de signatarios (determinantes externos)</param>
        /// <returns>AtendidoIndicadorModel con la cantidad de asuntos atendidos dentro y fueta de tiempo en base a la fecha actual (sistema)</returns>
        public Model.DashBoardModel.AtendidoIndicadorModel GetAtendidos(ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            Model.DashBoardModel.AtendidoIndicadorModel Atendido = null;

            //Obtener CSV
            string signatarios = this.GetSignatariosCSV(Determinantes);

            try
            {
                using (var entity = new GestorDocumentEntities())
                {
                    var atend = entity.SpDashboardAtendidosIndicador(signatarios).FirstOrDefault();
                    if (atend != null)
                    {
                        Atendido = new AtendidoIndicadorModel()
                        {
                            Dentro = (int)atend.AtendidosDentroVencimiento,
                            Fuera = (int)atend.AtendidosFueraVencimiento
                        };
                    }
                }
            }
            catch (Exception)
            {
                //TODO Log
            }
            return Atendido;
        }

        

        public System.Collections.ObjectModel.ObservableCollection<DeterminanteModel> GetDeterminante()
        {
            ObservableCollection<Model.DeterminanteModel> filtroSignatarios = new ObservableCollection<Model.DeterminanteModel>();
            try
            {
                using (var entity = new GestorDocumentEntities())
                {
                    (from d in entity.CAT_DETERMINANTE
                     orderby d.DeterminanteName ascending
                     select d).ToList().ForEach(row =>
                     {
                         Model.DeterminanteModel d = new Model.DeterminanteModel()
                         {
                             IdDeterminante = row.IdDeterminante,
                             DeterminanteName = row.DeterminanteName,
                             IsActive = false
                         };
                         filtroSignatarios.Add(d);
                     });
                }
            }
            catch (Exception)
            {
                filtroSignatarios = null;
            }
            return filtroSignatarios;
        }

        

        public Model.DashBoardModel.DashBoardTableModel GetDTOcavmUrgente(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            string prioridadUrgente = "20130611175650143";
            Model.DashBoardModel.DashBoardTableModel ocavmTableData = null;
            ocavmTableData = this.GetDTOcavm(Anio, Mes, Determinantes, prioridadUrgente);
            return ocavmTableData;
        }

        public Model.DashBoardModel.DashBoardTableModel GetDTOcavmTodos(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            string prioridadUrgente = "20130611175614758,20130611175650143,20130611175702903";
            Model.DashBoardModel.DashBoardTableModel ocavmTableData = null;
            ocavmTableData = this.GetDTOcavm(Anio, Mes, Determinantes, prioridadUrgente);
            return ocavmTableData;
        }

        public Model.DashBoardModel.DashBoardTableModel GetDTOcavmPrioritarioOrdinario(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            string prioridadUrgente = "20130611175614758,20130611175702903";
            Model.DashBoardModel.DashBoardTableModel ocavmTableData = null;
            ocavmTableData = this.GetDTOcavm(Anio, Mes, Determinantes, prioridadUrgente);
            return ocavmTableData;
        }

        public System.Collections.ObjectModel.ObservableCollection<Model.DashBoardModel.DashBoardTableModel> GetDT()
        {
            ObservableCollection<DashBoardTableModel> ocDashBordTable = new ObservableCollection<DashBoardTableModel>();
            try
            {
                ocDashBordTable.Add(new DashBoardTableModel()
                {
                    Organigrama = new OrganigramaModel() { JerarquiaName = "OCAVAM" },
                    Productividad = 80.5,
                    SemaforoImgPath = "../Imagenes/semaforo_verde.png",
                    Eficiencia = 90
                });
            }
            catch (Exception)
            {
                
                throw;
            }
            return ocDashBordTable;
        }
                

        /// <summary>
        /// Obtiene la productividad y eficiencia por signatario,prioridad y dirección del primer mes del año hasta el recibido en el parámetro
        /// </summary>
        /// <param name="Anio">Año</param>
        /// <param name="Mes">Numero de mes entre 1 y 12</param>
        /// <param name="Determinantes">Colección de determinantes (signatarios). Por lo menos debe estar lleno el id de cada elemento en la colección</param>
        /// <param name="Prioridades">Cadena CSV de ids de las prioridades</param>
        /// <param name="Organigrama">Cadena CSV de ids de jerarquia (deben ser direcciones)</param>
        /// <returns></returns>
        public ObservableCollection<Model.DashBoardModel.DashBoardGraphModel> GetGraphData(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes, string Prioridades, string Organigrama)
        {
            ObservableCollection<Model.DashBoardModel.DashBoardGraphModel> graphData = new ObservableCollection<Model.DashBoardModel.DashBoardGraphModel>();

            if (Anio != null && Mes != null && Determinantes != null && Determinantes.Count > 0 && !String.IsNullOrEmpty(Prioridades))
            {
                //Obtener CSV
                string signatarios = this.GetSignatariosCSV(Determinantes);

                try
                {
                    //Mes.Mes = 12;
                    using (var entity = new GestorDocumentEntities())
                    {
                        entity.SpDashboardMesGraphData(Anio.Anio, Mes.Mes, signatarios, Prioridades,Organigrama).ToList().ForEach(r =>
                        {
                            graphData.Add(new DashBoardGraphModel()
                            {
                                Anio=Anio,
                                Mes=new MesModel()
                                {
                                    Mes=(int)r.IdMes ,                                   
                                    MesName=r.MesName
                                },
                                Eficiencia=(double)r.Eficiencia,
                                Productividad = (double)r.Productividad
                            });
                        }
                            );
                    }
                }
                catch (Exception)
                {
                    //TODO log
                    graphData = null;
                }
            }
            return graphData;
        }

        /// <summary>
        /// Obtiene en base a año,mes,signatarios y prioridad el cálculo de productividad y eficiencia desglozado por dirección
        /// </summary>
        /// <param name="Anio">Año</param>
        /// <param name="Mes">Numero de mes entre 1 y 12</param>
        /// <param name="Determinantes">Colección de determinantes (signatarios). Por lo menos debe estar lleno el id de cada elemento en la colección</param>
        /// <param name="Prioridades">Cadena CSV de ids de las prioridades</param>
        /// <returns>Cálculo de productividad y eficiencia por direccion de todas las direcciones</returns>
        public ObservableCollection<Model.DashBoardModel.DashBoardTableModel> GetDTDirecciones(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes, string Prioridades)
        {
            ObservableCollection<Model.DashBoardModel.DashBoardTableModel> dirTableData = new ObservableCollection<Model.DashBoardModel.DashBoardTableModel>();

            if (Anio != null && Mes != null && Determinantes != null && Determinantes.Count > 0 && !String.IsNullOrEmpty(Prioridades))
            {
                //Obtener CSV
                string signatarios = this.GetSignatariosCSV(Determinantes);

                try
                {
                    using (var entity = new GestorDocumentEntities())
                    {
                        entity.SpDashboardDireccionesTableData(Anio.Anio, Mes.Mes, signatarios, Prioridades).ToList().ForEach(r =>
                            {
                                dirTableData.Add(new DashBoardTableModel()
                                {
                                    Organigrama = new OrganigramaModel()
                                    {
                                        IdJerarquia = r.IdRol,
                                        JerarquiaName = r.RolName
                                    },
                                    Eficiencia = (double)r.Eficiencia,
                                    Productividad = (double)r.Productividad,
                                    SemaforoImgPath = r.RutaSemaforo
                                });
                            }
                            );
                    }
                }
                catch (Exception)
                {
                    //TODO log
                    dirTableData = null;
                }
            }
            return dirTableData;
        }

        //
        public ObservableCollection<Model.DashBoardModel.DashBoardTableModel> GetDTDireccionesTodos(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            ObservableCollection<Model.DashBoardModel.DashBoardTableModel> dirTableData = new ObservableCollection<Model.DashBoardModel.DashBoardTableModel>();
            dirTableData= this.GetDTDirecciones(Anio, Mes, Determinantes, "20130611175614758,20130611175650143,20130611175702903");
            return dirTableData;
        }

        /// <summary>
        /// Obtiene en base a año,mes,signatarios y prioridad el cálculo de productividad y eficiencia de todo el organismo
        /// </summary>
        /// <param name="Anio">Año</param>
        /// <param name="Mes">Numero de mes entre 1 y 12</param>
        /// <param name="Determinantes">Colección de determinantes (signatarios). Por lo menos debe estar lleno el id de cada elemento en la colección</param>
        /// <param name="Prioridades">Cadena CSV de ids de las prioridades</param>
        /// <returns>Cálculo de productividad y eficiencia de todo el organimo</returns>
        private Model.DashBoardModel.DashBoardTableModel GetDTOcavm(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes, string Prioridades)
        {
            Model.DashBoardModel.DashBoardTableModel ocavmTableData = new DashBoardTableModel();

            if (Anio != null && Mes != null && Determinantes != null && Determinantes.Count > 0 && !String.IsNullOrEmpty(Prioridades))
            {
                //Obtener CSV
                string signatarios = this.GetSignatariosCSV(Determinantes);


                try
                {
                    using (var entity = new GestorDocumentEntities())
                    {
                        var r = entity.SpDashboardOcavmTableData(Anio.Anio, Mes.Mes, signatarios, Prioridades).FirstOrDefault();

                        ocavmTableData = (new DashBoardTableModel()
                        {
                            Organigrama = new OrganigramaModel()
                            {
                                IdJerarquia = r.IdRol,
                                JerarquiaName = r.RolName
                            },
                            Eficiencia = (double)r.Eficiencia,
                            Productividad = (double)r.Productividad,
                            SemaforoImgPath = r.Semaforo
                        });
                    }
                }
                catch (Exception)
                {
                    //TODO log
                    ocavmTableData = null;
                }
            }

            return ocavmTableData;
        }

        /// <summary>
        /// Convierte un ObsercableCollection<DeterminanateModel> en una cadena separada por comas del IdDeterminante
        /// </summary>
        /// <param name="Determinantes">Coleccion de determinantes</param>
        /// <returns>String vacio si viene vacia o es nula la coleccion o cadena separada por comas CSV de los ids de los determinantes</returns>
        private string GetSignatariosCSV(ObservableCollection<Model.DeterminanteModel> Determinantes)
        {
            string signatarios = "";

            try
            {
                Determinantes.ToList().ForEach(p =>
                    {
                        signatarios += p.IdDeterminante.ToString() + ",";
                    });
                signatarios = signatarios.Substring(0, signatarios.Length - 1);
            }
            catch (Exception)
            {
                //TODO log
            }

            return signatarios;
        }
        
    }
}
