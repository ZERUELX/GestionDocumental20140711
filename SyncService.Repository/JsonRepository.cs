using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SyncService.Dal.Pocos;

namespace SyncService.Repository
{
    public class JsonRepository
    {

        public Dictionary<string, string> GetResponseDictionary(string response)
        {
            try
            {
                Dictionary<string, string> resx = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                return resx;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que Deserializa JSon a List object
        /// </summary>
        /// <returns>Regresa List object </returns>
        /// <returns>Si no regresa null</returns>
        public string GetDeserialize(string listPocos, string nombreTabla)
        {
            string result = null;
            try
            {
                if (!string.IsNullOrEmpty(listPocos) && !string.IsNullOrEmpty(nombreTabla))
                {
                    switch (nombreTabla)
                    {
                        case "APP_MENU":
                            List<Model.SynPocos.APP_MENU> listMenu = new List<Model.SynPocos.APP_MENU>();
                            listMenu = JsonConvert.DeserializeObject<List<Model.SynPocos.APP_MENU>>(listPocos);
                            if (listMenu.Count() > 0)
                                this.LoadMenu(listMenu);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "APP_ROL":
                            List<Model.SynPocos.APP_ROL> listRol = new List<Model.SynPocos.APP_ROL>();
                            listRol = JsonConvert.DeserializeObject<List<Model.SynPocos.APP_ROL>>(listPocos);
                            if (listRol.Count() > 0)
                                this.LoadRol(listRol);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "APP_ROL_MENU":
                            List<Model.SynPocos.APP_ROL_MENU> listRolMenu = new List<Model.SynPocos.APP_ROL_MENU>();
                            listRolMenu = JsonConvert.DeserializeObject<List<Model.SynPocos.APP_ROL_MENU>>(listPocos);
                            if (listRolMenu.Count() > 0)
                                this.LoadRolMenu(listRolMenu);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "APP_USUARIO":
                            List<Model.SynPocos.APP_USUARIO> listUsuario = new List<Model.SynPocos.APP_USUARIO>();
                            listUsuario = JsonConvert.DeserializeObject<List<Model.SynPocos.APP_USUARIO>>(listPocos);
                            if (listUsuario.Count() > 0)
                                this.LoadUsuario(listUsuario);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "APP_USUARIO_ROL":
                            List<Model.SynPocos.APP_USUARIO_ROL> listUsuarioRol = new List<Model.SynPocos.APP_USUARIO_ROL>();
                            listUsuarioRol = JsonConvert.DeserializeObject<List<Model.SynPocos.APP_USUARIO_ROL>>(listPocos);
                            if (listUsuarioRol.Count() > 0)
                                this.LoadUsuarioRol(listUsuarioRol);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_DETERMINANTE":
                            List<Model.SynPocos.CAT_DETERMINANTE> listDeterminante = new List<Model.SynPocos.CAT_DETERMINANTE>();
                            listDeterminante = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_DETERMINANTE>>(listPocos);
                            if (listDeterminante.Count() > 0)
                                this.LoadDeterminante(listDeterminante);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_INSTRUCCION":
                            List<Model.SynPocos.CAT_INSTRUCCION> listInstruccion = new List<Model.SynPocos.CAT_INSTRUCCION>();
                            listInstruccion = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_INSTRUCCION>>(listPocos);
                            if (listInstruccion.Count() > 0)
                                this.LoadInstruccion(listInstruccion);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_ORGANIGRAMA":
                            List<Model.SynPocos.CAT_ORGANIGRAMA> listOrganigrama = new List<Model.SynPocos.CAT_ORGANIGRAMA>();
                            listOrganigrama = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_ORGANIGRAMA>>(listPocos);
                            if (listOrganigrama.Count() > 0)
                                this.LoadOrganigrama(listOrganigrama);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_PRIORIDAD":
                            List<Model.SynPocos.CAT_PRIORIDAD> listPrioridad = new List<Model.SynPocos.CAT_PRIORIDAD>();
                            listPrioridad = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_PRIORIDAD>>(listPocos);
                            if (listPrioridad.Count() > 0)
                                this.LoadPrioridad(listPrioridad);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_STATUS_ASUNTO":
                            List<Model.SynPocos.CAT_STATUS_ASUNTO> listStatusAsunto = new List<Model.SynPocos.CAT_STATUS_ASUNTO>();
                            listStatusAsunto = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_STATUS_ASUNTO>>(listPocos);
                            if (listStatusAsunto.Count() > 0)
                                this.LoadStatusAsunto(listStatusAsunto);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_STATUS_TURNO":
                            List<Model.SynPocos.CAT_STATUS_TURNO> listStatusTurno = new List<Model.SynPocos.CAT_STATUS_TURNO>();
                            listStatusTurno = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_STATUS_TURNO>>(listPocos);
                            if (listStatusTurno.Count() > 0)
                                this.LoadStatusTurno(listStatusTurno);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_TIPO_DETERMINANTE":
                            List<Model.SynPocos.CAT_TIPO_DETERMINANTE> listTipoDeterminante = new List<Model.SynPocos.CAT_TIPO_DETERMINANTE>();
                            listTipoDeterminante = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_TIPO_DETERMINANTE>>(listPocos);
                            if (listTipoDeterminante.Count() > 0)
                                this.LoadTipoDeterminante(listTipoDeterminante);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_TIPO_DOCUMENTO":
                            List<Model.SynPocos.CAT_TIPO_DOCUMENTO> listTipoDocumento = new List<Model.SynPocos.CAT_TIPO_DOCUMENTO>();
                            listTipoDocumento = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_TIPO_DOCUMENTO>>(listPocos);
                            if (listTipoDocumento.Count() > 0)
                                this.LoadTipoDocumento(listTipoDocumento);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_TIPO_EXTENCION":
                            List<Model.SynPocos.CAT_TIPO_EXTENCION> listTipoExtencion = new List<Model.SynPocos.CAT_TIPO_EXTENCION>();
                            listTipoExtencion = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_TIPO_EXTENCION>>(listPocos);
                            if (listTipoExtencion.Count() > 0)
                                this.LoadTipoExtencion(listTipoExtencion);
                            result = "Actualización e Inserción de: "+ nombreTabla +" correctamente.";
                            break;
                        case "CAT_TIPO_UNIDAD_NORMATIVA":
                            List<Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA> listTipoUnidadNormativa = new List<Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA>();
                            listTipoUnidadNormativa = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA>>(listPocos);
                            if (listTipoUnidadNormativa.Count() > 0)
                                this.LoadTipoUnidadNormativa(listTipoUnidadNormativa);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "CAT_UBICACION":
                            List<Model.SynPocos.CAT_UBICACION> listUbicacion = new List<Model.SynPocos.CAT_UBICACION>();
                            listUbicacion = JsonConvert.DeserializeObject<List<Model.SynPocos.CAT_UBICACION>>(listPocos);
                            if (listUbicacion.Count() > 0)
                                this.LoadUbicacion(listUbicacion);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "GET_ASUNTO":
                            List<Model.SynPocos.GET_ASUNTO> listAsunto = new List<Model.SynPocos.GET_ASUNTO>();
                            listAsunto = JsonConvert.DeserializeObject<List<Model.SynPocos.GET_ASUNTO>>(listPocos);
                            if (listAsunto.Count() > 0)
                                this.LoadAsunto(listAsunto);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "GET_DOCUMENTOS":
                            List<Model.SynPocos.GET_DOCUMENTOS> listDocumento = new List<Model.SynPocos.GET_DOCUMENTOS>();
                            listDocumento = JsonConvert.DeserializeObject<List<Model.SynPocos.GET_DOCUMENTOS>>(listPocos);
                            if (listDocumento.Count() > 0)
                                this.LoadDocumento(listDocumento);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "GET_EXPEDIENTE":
                            List<Model.SynPocos.GET_EXPEDIENTE> listExpediente = new List<Model.SynPocos.GET_EXPEDIENTE>();
                            listExpediente = JsonConvert.DeserializeObject<List<Model.SynPocos.GET_EXPEDIENTE>>(listPocos);
                            if (listExpediente.Count() > 0)
                                this.LoadExpediente(listExpediente);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "GET_FECHA_VENCIMIENTO":
                            List<Model.SynPocos.GET_FECHA_VENCIMIENTO> listFechaVencimiento = new List<Model.SynPocos.GET_FECHA_VENCIMIENTO>();
                            listFechaVencimiento = JsonConvert.DeserializeObject<List<Model.SynPocos.GET_FECHA_VENCIMIENTO>>(listPocos);
                            if (listFechaVencimiento.Count() > 0)
                                this.LoadFechaVencimiento(listFechaVencimiento);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "GET_TURNO":
                            List<Model.SynPocos.GET_TURNO> listTurno = new List<Model.SynPocos.GET_TURNO>();
                            listTurno = JsonConvert.DeserializeObject<List<Model.SynPocos.GET_TURNO>>(listPocos);
                            if (listTurno.Count() > 0)
                                this.LoadTurno(listTurno);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "REL_DESTINATARIO":
                            List<Model.SynPocos.REL_DESTINATARIO> listRelDestinatario = new List<Model.SynPocos.REL_DESTINATARIO>();
                            listRelDestinatario = JsonConvert.DeserializeObject<List<Model.SynPocos.REL_DESTINATARIO>>(listPocos);
                            if (listRelDestinatario.Count() > 0)
                                this.LoadRelDestinatario(listRelDestinatario);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "REL_DESTINATARIO_CCP":
                            List<Model.SynPocos.REL_DESTINATARIO_CCP> listRelDestinatarioCcp = new List<Model.SynPocos.REL_DESTINATARIO_CCP>();
                            listRelDestinatarioCcp = JsonConvert.DeserializeObject<List<Model.SynPocos.REL_DESTINATARIO_CCP>>(listPocos);
                            if (listRelDestinatarioCcp.Count() > 0)
                                this.LoadRelDestinatarioCcp(listRelDestinatarioCcp);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "REL_SIGNATARIO":
                            List<Model.SynPocos.REL_SIGNATARIO> listRelSignatario = new List<Model.SynPocos.REL_SIGNATARIO>();
                            listRelSignatario = JsonConvert.DeserializeObject<List<Model.SynPocos.REL_SIGNATARIO>>(listPocos);
                            if (listRelSignatario.Count() > 0)
                                this.LoadRelSiganatario(listRelSignatario);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                        case "REL_SIGNATARIO_EXTERNO":
                            List<Model.SynPocos.REL_SIGNATARIO_EXTERNO> listRelSignatarioExterno = new List<Model.SynPocos.REL_SIGNATARIO_EXTERNO>();
                            listRelSignatarioExterno = JsonConvert.DeserializeObject<List<Model.SynPocos.REL_SIGNATARIO_EXTERNO>>(listPocos);
                            if (listRelSignatarioExterno.Count() > 0)
                                this.LoadRelSiganatarioExterno(listRelSignatarioExterno);
                            result = "Actualización e Inserción de: " + nombreTabla + " correctamente.";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        #region MENU
        public void LoadMenu(List<Model.SynPocos.APP_MENU> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.APP_MENU
                                         where p.IdMenu == cust.IdMenu
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateMenu(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertMenu(p, entity);

                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateMenu(Model.SynPocos.APP_MENU element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.APP_MENU update = element;
                        var modified = entity.APP_MENU.First(p => p.IdMenu == update.IdMenu);

                        modified.IdMenu = update.IdMenu;
                        modified.IdMenuParent = update.IdMenuParent;
                        modified.MenuName = update.MenuName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;
                        modified.PathMenu = update.PathMenu;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertMenu(Model.SynPocos.APP_MENU element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        APP_MENU insert = new APP_MENU()
                        {
                            IdMenu = element.IdMenu,
                            IdMenuParent = element.IdMenuParent,
                            MenuName = element.MenuName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate,
                            PathMenu = element.PathMenu              
                        };
                        entity.APP_MENU.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ROL
        public void LoadRol(List<Model.SynPocos.APP_ROL> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.APP_ROL
                                         where p.IdRol == cust.IdRol
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateRol(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertRol(p, entity);

                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRol(Model.SynPocos.APP_ROL element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.APP_ROL update = element;
                        var modified = entity.APP_ROL.First(p => p.IdRol == update.IdRol);

                        modified.IdRol = update.IdRol;
                        modified.RolName = update.RolName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRol(Model.SynPocos.APP_ROL element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        APP_ROL insert = new APP_ROL()
                        {
                            IdRol = element.IdRol,
                            RolName = element.RolName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.APP_ROL.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ROL_MENU
        public void LoadRolMenu(List<Model.SynPocos.APP_ROL_MENU> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.APP_ROL_MENU
                                         where p.IdRolMenu == cust.IdRolMenu
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateRolMenu(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertRolMenu(p, entity);

                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRolMenu(Model.SynPocos.APP_ROL_MENU element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.APP_ROL_MENU update = element;
                        var modified = entity.APP_ROL_MENU.First(p => p.IdRolMenu == update.IdRolMenu);

                        modified.IdRolMenu = update.IdRolMenu;
                        modified.IdRol = update.IdRol;
                        modified.IdMenu = update.IdMenu;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRolMenu(Model.SynPocos.APP_ROL_MENU element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        APP_ROL_MENU insert = new APP_ROL_MENU()
                        {
                            IdRolMenu = element.IdRolMenu,
                            IdRol = element.IdRol,
                            IdMenu = element.IdMenu,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.APP_ROL_MENU.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region USUARIO
        public void LoadUsuario(List<Model.SynPocos.APP_USUARIO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.APP_USUARIO
                                         where p.IdUsuario == cust.IdUsuario
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateUsuario(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertUsuario(p, entity);

                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUsuario(Model.SynPocos.APP_USUARIO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.APP_USUARIO update = element;
                        var modified = entity.APP_USUARIO.First(p => p.IdUsuario == update.IdUsuario);

                        modified.IdUsuario = update.IdUsuario;
                        modified.UsuarioCorreo = update.UsuarioCorreo;
                        modified.UsuarioPwd = update.UsuarioPwd;
                        modified.Nombre = update.Nombre;
                        modified.Apellido = update.Apellido;
                        modified.Area = update.Area;
                        modified.Puesto = update.Puesto;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.IsNuevoUsuario = update.IsNuevoUsuario;
                        modified.IsActivado = update.IsActivado;
                        modified.IsFlag = update.IsFlag;
                        modified.IsFlagPass = update.IsFlagPass;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertUsuario(Model.SynPocos.APP_USUARIO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        APP_USUARIO insert = new APP_USUARIO()
                        {
                            IdUsuario = element.IdUsuario,
                            UsuarioCorreo = element.UsuarioCorreo,
                            UsuarioPwd = element.UsuarioPwd,
                            Nombre = element.Nombre,
                            Apellido = element.Apellido,
                            Area = element.Area,
                            Puesto = element.Puesto,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            IsNuevoUsuario = element.IsNuevoUsuario,
                            IsActivado = element.IsActivado,
                            IsFlag = element.IsFlag,
                            IsFlagPass = element.IsFlagPass,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.APP_USUARIO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region USUARIO_ROL
        public void LoadUsuarioRol(List<Model.SynPocos.APP_USUARIO_ROL> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.APP_USUARIO_ROL
                                         where p.IdUsuarioRol == cust.IdUsuarioRol
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateUsuarioRol(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertUsuarioRol(p, entity);

                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUsuarioRol(Model.SynPocos.APP_USUARIO_ROL element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.APP_USUARIO_ROL update = element;
                        var modified = entity.APP_USUARIO_ROL.First(p => p.IdUsuarioRol == update.IdUsuarioRol);

                        modified.IdUsuarioRol = update.IdUsuarioRol;
                        modified.IdUsuario = update.IdUsuario;
                        modified.IdRol = update.IdRol;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertUsuarioRol(Model.SynPocos.APP_USUARIO_ROL element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        APP_USUARIO_ROL insert = new APP_USUARIO_ROL()
                        {
                            IdUsuarioRol = element.IdUsuarioRol,
                            IdUsuario = element.IdUsuario,
                            IdRol = element.IdRol,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.APP_USUARIO_ROL.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DETERMINANTE
        public void LoadDeterminante(List<Model.SynPocos.CAT_DETERMINANTE> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_DETERMINANTE
                                         where p.IdDeterminante == cust.IdDeterminante
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateDeterminante(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertDeterminante(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDeterminante(Model.SynPocos.CAT_DETERMINANTE element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_DETERMINANTE update = element;
                        var modified = entity.CAT_DETERMINANTE.First(p => p.IdDeterminante == update.IdDeterminante);

                        modified.IdDeterminante = update.IdDeterminante;
                        modified.CveDeterminante = update.CveDeterminante;
                        modified.Area = update.Area;
                        modified.PrefijoFolio = update.PrefijoFolio;
                        modified.DeterminanteName = update.DeterminanteName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.IdTipoDeterminante = update.IdTipoDeterminante;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertDeterminante(Model.SynPocos.CAT_DETERMINANTE element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_DETERMINANTE insert = new CAT_DETERMINANTE()
                        {
                            IdDeterminante = element.IdDeterminante,
                            CveDeterminante = element.CveDeterminante,
                            Area = element.Area,
                            PrefijoFolio = element.PrefijoFolio,
                            DeterminanteName = element.DeterminanteName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            IdTipoDeterminante = element.IdTipoDeterminante,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_DETERMINANTE.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region INSTRUCCION
        public void LoadInstruccion(List<Model.SynPocos.CAT_INSTRUCCION> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_INSTRUCCION
                                         where p.IdInstruccion == cust.IdInstruccion
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateInstruccion(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertInstruccion(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateInstruccion(Model.SynPocos.CAT_INSTRUCCION element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_INSTRUCCION update = element;
                        var modified = entity.CAT_INSTRUCCION.First(p => p.IdInstruccion == update.IdInstruccion);

                        modified.IdInstruccion = update.IdInstruccion;
                        modified.CveInstruccion = update.CveInstruccion;
                        modified.InstruccionName = update.InstruccionName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertInstruccion(Model.SynPocos.CAT_INSTRUCCION element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_INSTRUCCION insert = new CAT_INSTRUCCION()
                        {
                            IdInstruccion = element.IdInstruccion,
                            CveInstruccion = element.CveInstruccion,
                            InstruccionName = element.InstruccionName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_INSTRUCCION.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ORGANIGRAMA
        public void LoadOrganigrama(List<Model.SynPocos.CAT_ORGANIGRAMA> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_ORGANIGRAMA
                                         where p.IdJerarquia == cust.IdJerarquia
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateOrganigrama(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertOrganigrama(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateOrganigrama(Model.SynPocos.CAT_ORGANIGRAMA element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_ORGANIGRAMA update = element;
                        var modified = entity.CAT_ORGANIGRAMA.First(p => p.IdJerarquia == update.IdJerarquia);

                        modified.IdJerarquia = update.IdJerarquia;
                        modified.IdJerarquiaParent = update.IdJerarquiaParent;
                        modified.JerarquiaName = update.JerarquiaName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.IdRol = update.IdRol;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;
                        modified.IdTipoUnidadNormativa = update.IdTipoUnidadNormativa;
                        modified.JerarquiaTitular = update.JerarquiaTitular;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertOrganigrama(Model.SynPocos.CAT_ORGANIGRAMA element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_ORGANIGRAMA insert = new CAT_ORGANIGRAMA()
                        {
                            IdJerarquia = element.IdJerarquia,
                            IdJerarquiaParent = element.IdJerarquiaParent,
                            JerarquiaName = element.JerarquiaName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            IdRol = element.IdRol,
                            ServerLastModifiedDate = element.ServerLastModifiedDate,
                            IdTipoUnidadNormativa = element.IdTipoUnidadNormativa,
                            JerarquiaTitular = element.JerarquiaTitular      
                        };
                        entity.CAT_ORGANIGRAMA.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region PRIORIDAD
        public void LoadPrioridad(List<Model.SynPocos.CAT_PRIORIDAD> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_PRIORIDAD
                                         where p.IdPrioridad == cust.IdPrioridad
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdatePrioridad(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertPrioridad(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdatePrioridad(Model.SynPocos.CAT_PRIORIDAD element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_PRIORIDAD update = element;
                        var modified = entity.CAT_PRIORIDAD.First(p => p.IdPrioridad == update.IdPrioridad);

                        modified.IdPrioridad = update.IdPrioridad;
                        modified.PrioridadName = update.PrioridadName;
                        modified.PathImagen = update.PathImagen;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertPrioridad(Model.SynPocos.CAT_PRIORIDAD element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_PRIORIDAD insert = new CAT_PRIORIDAD()
                        {
                            IdPrioridad = element.IdPrioridad,
                            PrioridadName = element.PrioridadName,
                            PathImagen = element.PathImagen,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_PRIORIDAD.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region STATUS_ASUNTO
        public void LoadStatusAsunto(List<Model.SynPocos.CAT_STATUS_ASUNTO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_STATUS_ASUNTO
                                         where p.IdStatusAsunto == cust.IdStatusAsunto
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateStatusAsunto(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertStatusAsunto(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateStatusAsunto(Model.SynPocos.CAT_STATUS_ASUNTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_STATUS_ASUNTO update = element;
                        var modified = entity.CAT_STATUS_ASUNTO.First(p => p.IdStatusAsunto == update.IdStatusAsunto);

                        modified.IdStatusAsunto = update.IdStatusAsunto;
                        modified.StatusName = update.StatusName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertStatusAsunto(Model.SynPocos.CAT_STATUS_ASUNTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_STATUS_ASUNTO insert = new CAT_STATUS_ASUNTO()
                        {
                            IdStatusAsunto = element.IdStatusAsunto,
                            StatusName = element.StatusName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_STATUS_ASUNTO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region STATUS_TURNO
        public void LoadStatusTurno(List<Model.SynPocos.CAT_STATUS_TURNO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_STATUS_TURNO
                                         where p.IdStatusTurno == cust.IdStatusTurno
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateStatusTurno(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertStatusTurno(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateStatusTurno(Model.SynPocos.CAT_STATUS_TURNO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_STATUS_TURNO update = element;
                        var modified = entity.CAT_STATUS_TURNO.First(p => p.IdStatusTurno == update.IdStatusTurno);

                        modified.IdStatusTurno = update.IdStatusTurno;
                        modified.StatusName = update.StatusName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertStatusTurno(Model.SynPocos.CAT_STATUS_TURNO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_STATUS_TURNO insert = new CAT_STATUS_TURNO()
                        {
                            IdStatusTurno = element.IdStatusTurno,
                            StatusName = element.StatusName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_STATUS_TURNO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TIPO_DETERMINANTE
        public void LoadTipoDeterminante(List<Model.SynPocos.CAT_TIPO_DETERMINANTE> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_TIPO_DETERMINANTE
                                         where p.IdTipoDeterminante == cust.IdTipoDeterminante
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateTipoDeterminante(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertTipoDeterminante(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTipoDeterminante(Model.SynPocos.CAT_TIPO_DETERMINANTE element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_TIPO_DETERMINANTE update = element;
                        var modified = entity.CAT_TIPO_DETERMINANTE.First(p => p.IdTipoDeterminante == update.IdTipoDeterminante);

                        modified.IdTipoDeterminante = update.IdTipoDeterminante;
                        modified.TipoDeterminanteName = update.TipoDeterminanteName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertTipoDeterminante(Model.SynPocos.CAT_TIPO_DETERMINANTE element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_TIPO_DETERMINANTE insert = new CAT_TIPO_DETERMINANTE()
                        {
                            IdTipoDeterminante = element.IdTipoDeterminante,
                            TipoDeterminanteName = element.TipoDeterminanteName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_TIPO_DETERMINANTE.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TIPO_DOCUMENTO
        public void LoadTipoDocumento(List<Model.SynPocos.CAT_TIPO_DOCUMENTO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_TIPO_DOCUMENTO
                                         where p.IdTipoDocumento == cust.IdTipoDocumento
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateTipoDocumento(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertTipoDocumento(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTipoDocumento(Model.SynPocos.CAT_TIPO_DOCUMENTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_TIPO_DOCUMENTO update = element;
                        var modified = entity.CAT_TIPO_DOCUMENTO.First(p => p.IdTipoDocumento == update.IdTipoDocumento);

                        modified.IdTipoDocumento = update.IdTipoDocumento;
                        modified.TipoDocumentoName = update.TipoDocumentoName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertTipoDocumento(Model.SynPocos.CAT_TIPO_DOCUMENTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_TIPO_DOCUMENTO insert = new CAT_TIPO_DOCUMENTO()
                        {
                            IdTipoDocumento = element.IdTipoDocumento,
                            TipoDocumentoName = element.TipoDocumentoName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_TIPO_DOCUMENTO   .AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TIPO_EXTENCION
        public void LoadTipoExtencion(List<Model.SynPocos.CAT_TIPO_EXTENCION> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_TIPO_EXTENCION
                                         where p.IdTipoExtencion == cust.IdTipoExtencion
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateTipoExtencion(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertTipoExtencion(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTipoExtencion(Model.SynPocos.CAT_TIPO_EXTENCION element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_TIPO_EXTENCION update = element;
                        var modified = entity.CAT_TIPO_EXTENCION.First(p => p.IdTipoExtencion == update.IdTipoExtencion);

                        modified.IdTipoExtencion = update.IdTipoExtencion;
                        modified.Extencion = update.Extencion;
                        modified.Path = update.Path;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertTipoExtencion(Model.SynPocos.CAT_TIPO_EXTENCION element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_TIPO_EXTENCION insert = new CAT_TIPO_EXTENCION()
                        {
                            IdTipoExtencion = element.IdTipoExtencion,
                            Extencion = element.Extencion,
                            Path = element.Path,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_TIPO_EXTENCION.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TIPO_UNIDAD_NORMATIVA
        public void LoadTipoUnidadNormativa(List<Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_TIPO_UNIDAD_NORMATIVA
                                         where p.IdTipoUnidadNormativa == cust.IdTipoUnidadNormativa
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateTipoUnidadNormativa(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertTipoUnidadNormativa(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTipoUnidadNormativa(Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA update = element;
                        var modified = entity.CAT_TIPO_UNIDAD_NORMATIVA.First(p => p.IdTipoUnidadNormativa == update.IdTipoUnidadNormativa);

                        modified.IdTipoUnidadNormativa = update.IdTipoUnidadNormativa;
                        modified.TipoUnidadNormativaName = update.TipoUnidadNormativaName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertTipoUnidadNormativa(Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_TIPO_UNIDAD_NORMATIVA insert = new CAT_TIPO_UNIDAD_NORMATIVA()
                        {
                            IdTipoUnidadNormativa = element.IdTipoUnidadNormativa,
                            TipoUnidadNormativaName = element.TipoUnidadNormativaName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_TIPO_UNIDAD_NORMATIVA.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region UBICACION
        public void LoadUbicacion(List<Model.SynPocos.CAT_UBICACION> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.CAT_UBICACION
                                         where p.IdUbicacion == cust.IdUbicacion
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateUbicacion(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertUbicacion(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUbicacion(Model.SynPocos.CAT_UBICACION element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.CAT_UBICACION update = element;
                        var modified = entity.CAT_UBICACION.First(p => p.IdUbicacion == update.IdUbicacion);

                        modified.IdUbicacion = update.IdUbicacion;
                        modified.UbicacionName = update.UbicacionName;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertUbicacion(Model.SynPocos.CAT_UBICACION element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        CAT_UBICACION insert = new CAT_UBICACION()
                        {
                            IdUbicacion = element.IdUbicacion,
                            UbicacionName = element.UbicacionName,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.CAT_UBICACION.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ASUNTO
        public void LoadAsunto(List<Model.SynPocos.GET_ASUNTO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.GET_ASUNTO
                                         where p.IdAsunto == cust.IdAsunto
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateAsunto(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertAsunto(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAsunto(Model.SynPocos.GET_ASUNTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.GET_ASUNTO update = element;
                        var modified = entity.GET_ASUNTO.First(p => p.IdAsunto == update.IdAsunto);

                        modified.IdAsunto = update.IdAsunto;
                        modified.FechaCreacion = update.FechaCreacion;
                        modified.FechaRecibido = update.FechaRecibido;
                        modified.FechaDocumento = update.FechaDocumento;
                        modified.ReferenciaDocumento = update.ReferenciaDocumento;
                        modified.Titulo = update.Titulo;
                        modified.Descripcion = update.Descripcion;
                        modified.Alcance = update.Alcance;
                        modified.IdUbicacion = update.IdUbicacion;
                        modified.IdInstruccion = update.IdInstruccion;
                        modified.IdPrioridad = update.IdPrioridad;
                        modified.IdStatusAsunto = update.IdStatusAsunto;
                        modified.FechaVencimiento = update.FechaVencimiento;
                        modified.Folio = update.Folio;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.FechaAtendido = update.FechaAtendido;
                        modified.Ubicacion = update.Ubicacion;
                        modified.IsBorrador = update.IsBorrador;
                        modified.Contacto = update.Contacto;
                        modified.Anexos = update.Anexos;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertAsunto(Model.SynPocos.GET_ASUNTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        GET_ASUNTO insert = new GET_ASUNTO()
                        {
                            IdAsunto = element.IdAsunto,
                            FechaCreacion = element.FechaCreacion,
                            FechaRecibido = element.FechaRecibido,
                            FechaDocumento = element.FechaDocumento,
                            ReferenciaDocumento = element.ReferenciaDocumento,
                            Titulo = element.Titulo,
                            Descripcion = element.Descripcion,
                            Alcance = element.Alcance,
                            IdUbicacion = element.IdUbicacion,
                            IdInstruccion = element.IdInstruccion,
                            IdPrioridad = element.IdPrioridad,
                            IdStatusAsunto = element.IdStatusAsunto,
                            FechaVencimiento = element.FechaVencimiento,
                            Folio = element.Folio,
                            ServerLastModifiedDate = element.ServerLastModifiedDate,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            FechaAtendido = element.FechaAtendido,
                            Ubicacion = element.Ubicacion,
                            IsBorrador = element.IsBorrador,
                            Contacto = element.Contacto,
                            Anexos = element.Anexos
                        };
                        entity.GET_ASUNTO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DOCUMENTO
        public void LoadDocumento(List<Model.SynPocos.GET_DOCUMENTOS> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.GET_DOCUMENTOS
                                         where p.IdDocumento == cust.IdDocumento
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateDocumento(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertDocumento(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDocumento(Model.SynPocos.GET_DOCUMENTOS element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.GET_DOCUMENTOS update = element;
                        var modified = entity.GET_DOCUMENTOS.First(p => p.IdDocumento == update.IdDocumento);

                        modified.IdDocumento = update.IdDocumento;
                        modified.DocumentoName = update.DocumentoName;
                        modified.DocumentoPath = update.DocumentoPath;
                        modified.Extencion = update.Extencion;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.IdTurno = update.IdTurno;
                        modified.Fecha = update.Fecha;
                        modified.IdExpediente = update.IdExpediente;
                        modified.IdTipoDocumento = update.IdTipoDocumento;
                        modified.IsDocumentoOriginal = update.IsDocumentoOriginal;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertDocumento(Model.SynPocos.GET_DOCUMENTOS element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        GET_DOCUMENTOS insert = new GET_DOCUMENTOS()
                        {
                            IdDocumento = element.IdDocumento,
                            DocumentoName = element.DocumentoName,
                            DocumentoPath = element.DocumentoPath,
                            Extencion = element.Extencion,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            IdTurno = element.IdTurno,
                            Fecha = element.Fecha,
                            IdExpediente = element.IdExpediente,
                            IdTipoDocumento = element.IdTipoDocumento,
                            IsDocumentoOriginal = element.IsDocumentoOriginal,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.GET_DOCUMENTOS.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region EXPEDIENTE
        public void LoadExpediente(List<Model.SynPocos.GET_EXPEDIENTE> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.GET_EXPEDIENTE
                                         where p.IdExpediente == cust.IdExpediente
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateExpediente(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertExpediente(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateExpediente(Model.SynPocos.GET_EXPEDIENTE element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.GET_EXPEDIENTE update = element;
                        var modified = entity.GET_EXPEDIENTE.First(p => p.IdExpediente == update.IdExpediente);

                        modified.IdExpediente = update.IdExpediente;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.IdAsunto = update.IdAsunto;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertExpediente(Model.SynPocos.GET_EXPEDIENTE element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        GET_EXPEDIENTE insert = new GET_EXPEDIENTE()
                        {
                            IdExpediente = element.IdExpediente,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            IdAsunto = element.IdAsunto,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.GET_EXPEDIENTE.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region FECHA_VENCIMIENTO
        public void LoadFechaVencimiento(List<Model.SynPocos.GET_FECHA_VENCIMIENTO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.GET_FECHA_VENCIMIENTO
                                         where p.IdFechaVencimiento == cust.IdFechaVencimiento
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateFechaVencimiento(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertFechaVencimiento(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateFechaVencimiento(Model.SynPocos.GET_FECHA_VENCIMIENTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.GET_FECHA_VENCIMIENTO update = element;
                        var modified = entity.GET_FECHA_VENCIMIENTO.First(p => p.IdFechaVencimiento == update.IdFechaVencimiento);

                        modified.IdFechaVencimiento = update.IdFechaVencimiento;
                        modified.IdAsunto = update.IdAsunto;
                        modified.FechaVencimiento = update.FechaVencimiento;
                        modified.FechaCreacion = update.FechaCreacion;
                        modified.IsActual = update.IsActual;
                        modified.IsActive = update.IsActive;
                        modified.IsModified = update.IsModified;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertFechaVencimiento(Model.SynPocos.GET_FECHA_VENCIMIENTO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        GET_FECHA_VENCIMIENTO insert = new GET_FECHA_VENCIMIENTO()
                        {
                            IdFechaVencimiento = element.IdFechaVencimiento,
                            IdAsunto = element.IdAsunto,
                            FechaVencimiento = element.FechaVencimiento,
                            FechaCreacion = element.FechaCreacion,
                            IsActual = element.IsActual,
                            IsActive = element.IsActive,
                            IsModified = element.IsModified,
                            LastModifiedDate = element.LastModifiedDate,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.GET_FECHA_VENCIMIENTO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TURNO
        public void LoadTurno(List<Model.SynPocos.GET_TURNO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.GET_TURNO
                                         where p.IdTurno == cust.IdTurno
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateTurno(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertTurno(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTurno(Model.SynPocos.GET_TURNO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.GET_TURNO update = element;
                        var modified = entity.GET_TURNO.First(p => p.IdTurno == update.IdTurno);

                        modified.IdTurno = update.IdTurno;
                        modified.IdTurnoAnt = update.IdTurnoAnt;
                        modified.FechaCreacion = update.FechaCreacion;
                        modified.FechaEnvio = update.FechaEnvio;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.IdAsunto = update.IdAsunto;
                        modified.IdStatusTurno = update.IdStatusTurno;
                        modified.IdRol = update.IdRol;
                        modified.IdUsuario = update.IdUsuario;
                        modified.Comentario = update.Comentario;
                        modified.Respuesta = update.Respuesta;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;
                        modified.IsAtendido = update.IsAtendido;
                        modified.IsTurnado = update.IsTurnado;
                        modified.IsBorrador = update.IsBorrador;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertTurno(Model.SynPocos.GET_TURNO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        GET_TURNO insert = new GET_TURNO()
                        {
                            IdTurno = element.IdTurno,
                            IdTurnoAnt = element.IdTurnoAnt,
                            FechaCreacion = element.FechaCreacion,
                            FechaEnvio = element.FechaEnvio,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            IdAsunto = element.IdAsunto,
                            IdStatusTurno = element.IdStatusTurno,
                            IdRol = element.IdRol,
                            IdUsuario = element.IdUsuario,
                            Comentario = element.Comentario,
                            Respuesta = element.Respuesta,
                            ServerLastModifiedDate = element.ServerLastModifiedDate,
                            IsAtendido = element.IsAtendido,
                            IsTurnado = element.IsTurnado,
                            IsBorrador = element.IsBorrador
                        };
                        entity.GET_TURNO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region REL_DESTINATARIO
        public void LoadRelDestinatario(List<Model.SynPocos.REL_DESTINATARIO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.REL_DESTINATARIO
                                         where p.IdDestinatario == cust.IdDestinatario
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateRelDestinatario(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertRelDestinatario(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRelDestinatario(Model.SynPocos.REL_DESTINATARIO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.REL_DESTINATARIO update = element;
                        var modified = entity.REL_DESTINATARIO.First(p => p.IdDestinatario == update.IdDestinatario);

                        modified.IdRol = update.IdRol;
                        modified.IdTurno = update.IdTurno;
                        modified.IdDestinatario = update.IdDestinatario;
                        modified.IsPrincipal = update.IsPrincipal;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRelDestinatario(Model.SynPocos.REL_DESTINATARIO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        REL_DESTINATARIO insert = new REL_DESTINATARIO()
                        {
                            IdRol = element.IdRol,
                            IdTurno = element.IdTurno,
                            IdDestinatario = element.IdDestinatario,
                            IsPrincipal = element.IsPrincipal,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.REL_DESTINATARIO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region REL_DESTINATARIO_CCP
        public void LoadRelDestinatarioCcp(List<Model.SynPocos.REL_DESTINATARIO_CCP> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.REL_DESTINATARIO_CCP
                                         where p.IdDestinatarioCcp == cust.IdDestinatarioCcp
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateRelDestinatarioCcp(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertRelDestinatarioCcp(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRelDestinatarioCcp(Model.SynPocos.REL_DESTINATARIO_CCP element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.REL_DESTINATARIO_CCP update = element;
                        var modified = entity.REL_DESTINATARIO_CCP.First(p => p.IdDestinatarioCcp == update.IdDestinatarioCcp);

                        modified.IdDestinatarioCcp = update.IdDestinatarioCcp;
                        modified.IdRol = update.IdRol;
                        modified.IdAsunto = update.IdAsunto;
                        modified.IsActive = update.IsActive;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.IsModified = update.IsModified;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRelDestinatarioCcp(Model.SynPocos.REL_DESTINATARIO_CCP element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        REL_DESTINATARIO_CCP insert = new REL_DESTINATARIO_CCP()
                        {
                            IdDestinatarioCcp = element.IdDestinatarioCcp,
                            IdRol = element.IdRol,
                            IdAsunto = element.IdAsunto,
                            IsActive = element.IsActive,
                            LastModifiedDate = element.LastModifiedDate,
                            IsModified = element.IsModified,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.REL_DESTINATARIO_CCP.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region REL_SIGNATARIO
        public void LoadRelSiganatario(List<Model.SynPocos.REL_SIGNATARIO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.REL_SIGNATARIO
                                         where p.IdSignatario == cust.IdSignatario
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateRelSiganatario(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertRelSignatario(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRelSiganatario(Model.SynPocos.REL_SIGNATARIO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.REL_SIGNATARIO update = element;
                        var modified = entity.REL_SIGNATARIO.First(p => p.IdSignatario == update.IdSignatario);

                        modified.IdAsunto = update.IdAsunto;
                        modified.IdDeterminante = update.IdDeterminante;
                        modified.IdSignatario = update.IdSignatario;
                        modified.Fecha = update.Fecha;
                        modified.IsActive = update.IsActive;
                        modified.IsModified = update.IsModified;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRelSignatario(Model.SynPocos.REL_SIGNATARIO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        REL_SIGNATARIO insert = new REL_SIGNATARIO()
                        {
                            IdAsunto = element.IdAsunto,
                            IdDeterminante = element.IdDeterminante,
                            IdSignatario = element.IdSignatario,
                            Fecha = element.Fecha,
                            IsActive = element.IsActive,
                            IsModified = element.IsModified,
                            LastModifiedDate = element.LastModifiedDate,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.REL_SIGNATARIO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region REL_SIGNATARIO_EXTERNO
        public void LoadRelSiganatarioExterno(List<Model.SynPocos.REL_SIGNATARIO_EXTERNO> element)
        {
            try
            {
                if (element != null)
                {
                    using (SyncServiceEntity entity = new SyncServiceEntity())
                    {
                        element.ToList().ForEach(p =>
                        {
                            var query = (from cust in entity.REL_SIGNATARIO_EXTERNO
                                         where p.IdSignatarioExterno == cust.IdSignatarioExterno
                                         select cust).ToList();
                            //Actualización
                            if (query.Count > 0)
                            {
                                var aux = query.First();
                                if (aux.LastModifiedDate < p.LastModifiedDate)
                                    this.UpdateRelSiganatarioExterno(p, entity);
                            }
                            //Inserción
                            else
                                this.InsertRelSignatarioExterno(p, entity);
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRelSiganatarioExterno(Model.SynPocos.REL_SIGNATARIO_EXTERNO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {

                        Model.SynPocos.REL_SIGNATARIO_EXTERNO update = element;
                        var modified = entity.REL_SIGNATARIO_EXTERNO.First(p => p.IdSignatarioExterno == update.IdSignatarioExterno);

                        modified.IdAsunto = update.IdAsunto;
                        modified.IdDeterminante = update.IdDeterminante;
                        modified.IdSignatarioExterno = update.IdSignatarioExterno;
                        modified.Fecha = update.Fecha;
                        modified.IsActive = update.IsActive;
                        modified.IsModified = update.IsModified;
                        modified.LastModifiedDate = update.LastModifiedDate;
                        modified.ServerLastModifiedDate = update.ServerLastModifiedDate;

                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRelSignatarioExterno(Model.SynPocos.REL_SIGNATARIO_EXTERNO element, System.Data.Objects.ObjectContext context)
        {
            try
            {
                if (element != null && context != null)
                {
                    SyncServiceEntity entity = context as SyncServiceEntity;
                    if (entity != null)
                    {
                        REL_SIGNATARIO_EXTERNO insert = new REL_SIGNATARIO_EXTERNO()
                        {
                            IdAsunto = element.IdAsunto,
                            IdDeterminante = element.IdDeterminante,
                            IdSignatarioExterno = element.IdSignatarioExterno,
                            Fecha = element.Fecha,
                            IsActive = element.IsActive,
                            IsModified = element.IsModified,
                            LastModifiedDate = element.LastModifiedDate,
                            ServerLastModifiedDate = element.ServerLastModifiedDate
                        };
                        entity.REL_SIGNATARIO_EXTERNO.AddObject(insert);
                        entity.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
