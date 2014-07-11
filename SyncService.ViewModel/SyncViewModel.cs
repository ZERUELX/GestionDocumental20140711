using System;
using System.Collections.Generic;
using SyncService.Repository;
using System.Configuration;
using RestSharp;
using System.Windows.Threading;
using GestorDocument.ViewModel.PantallaInicio;
using GestorDocument.ViewModel.SyncDocs;
using Actualizador.WebService.ViewModel;
using System.Net.NetworkInformation;
using System.Threading;

namespace SyncService.ViewModel
{
    public class SyncViewModel:ViewModelBase
    {

        public Dispatcher _Dispatcher;
        public PantallaInicioViewModel _PantallaInicioViewModel;
        private string VersionAssembly = "";
        private string IdUsuario = "";
        private int Count;
        private bool IsActualizando = false;
        #region Instancias.
        static BroadCastRepository _BroadCast = new BroadCastRepository();
        static ReciverRepository _Reciver = new ReciverRepository();
        #endregion

        #region Propiedades y Metodos Hilo
        public static bool IsRunning = false;
        System.Timers.Timer t;

        public string Message
        {
            get { return _message; }
            set
            {
                if (value != _message)
                {
                    this._message = value;
                    OnPropertyChanged("Message");
                }
            }
        }
        string _message;

        public bool JobDone
        {
            get { return _jobDone; }
            set
            {
                if (value != _jobDone)
                {
                    this._jobDone = value;
                    OnPropertyChanged("JobDone");
                }
            }
        }
        bool _jobDone;

        public void start()
        {
            this.JobDone = false;
            this.OnPropertyChanged("JobDone");
            SyncViewModel.IsRunning = true;
            //t.Start();
            Thread sync = new Thread(() => this.SyncService());
            sync.IsBackground = true;
            sync.Start();
        }
        #endregion

        #region Propiedades Servicios web
        string routeServiceDownLoad;
        string routeServiceUpLoad;
        string basicAuthUser;
        string basicAuthPass;

        #endregion

        #region Constructor
        public SyncViewModel(Dispatcher dispatcher, PantallaInicioViewModel pantallaInicioViewModel,string Assembly)
        {
            this.LoadPropiedades();  
            this._Dispatcher = dispatcher;
            this._PantallaInicioViewModel = pantallaInicioViewModel;
            this.Message = "Sincronizando...";
            this._jobDone = false;
            this.VersionAssembly = Assembly;
            this.IdUsuario = _PantallaInicioViewModel.Usuario.IdUsuario.ToString();
        }
        #endregion

        #region Metodo carga propiedades.
        private void LoadPropiedades()
        {
            this.Message = "Cargando Propiedades.";
            routeServiceDownLoad = ConfigurationManager.AppSettings["BroadCast"].ToString();
            routeServiceUpLoad = ConfigurationManager.AppSettings["Reciver"].ToString();
            basicAuthUser = ConfigurationManager.AppSettings["basicAuthUser"].ToString();
            basicAuthPass = ConfigurationManager.AppSettings["basicAuthPass"].ToString();
        }
        #endregion

        #region BroadCast (Descarga)
        public bool CallModifiedData()
        {
            this.Message = "Descargando...";
            bool responseSevice = false;            
            string nameService = "GetModifiedData";
            var client = new RestClient(routeServiceDownLoad);
            client.Authenticator = new HttpBasicAuthenticator(basicAuthUser, basicAuthPass);
            var request = new RestRequest(Method.POST);
            request.Resource = nameService;
            this.Message = "Obteniendo el metodo "+ nameService;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Content-type", "application/json");
            try
            {
                this.Message = "Obteniendo respuesta..";
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                this.Message = content.ToString();
                int inicio = content.IndexOf(":", 0) + 2;
                int fin = content.IndexOf("]", inicio) + 1;
                content = content.Substring(inicio, content.Length - (inicio + 2));
                List<string> lstTablas = null;
                lstTablas = _BroadCast.GetTableNameModifiedData(content);
                if (lstTablas != null & lstTablas.Count > 0)
                {                    
                    foreach (var item in lstTablas)
                    {
                        try
                        {
                            string jsonMax = _BroadCast.GetMaxTableLocal(item);
                            if (!String.IsNullOrEmpty(jsonMax))
                            {
                                string jsonTable = this.CallGetTablesUpdate(item, jsonMax);
                                if (!string.IsNullOrEmpty(jsonTable))
                                {
                                    _BroadCast.SP_UpdateModifiedDataLocal(item, content);
                                    responseSevice = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
                
            }
            catch (Exception ex )
            {
                //throw;
            }
            return responseSevice;
        }

        public string CallGetTablesUpdate(string _tableName, string _maxJson)
        {
            string MSJ = "";
            string nameService = "GetTablesUpdate";
            var client = new RestClient(routeServiceDownLoad);
            client.Authenticator = new HttpBasicAuthenticator(basicAuthUser, basicAuthPass);
            var request = new RestRequest(Method.POST);
            request.Resource = nameService;
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Content-type", "application/json");
            request.AddBody(new { tableName = _tableName, maxJson = _maxJson });
            try
            {
                IRestResponse response = client.Execute(request);
                var content = response.Content;

                JsonRepository _JsonRepository = new JsonRepository();
                Dictionary<string, string> resx = _JsonRepository.GetResponseDictionary(response.Content);

                //inserta o actualiza los registros correspondientes
                MSJ = _JsonRepository.GetDeserialize(resx["GetTablesUpdateResult"], _tableName);

            }
            catch (Exception)
            {

                throw;
            }
            return MSJ;
        }
        #endregion

        #region Reciver (Subida)
        public bool CallService()
        {
            bool responseSevice = false;
            
            string nameService = "LoadCatGeneric";

            List<string> lstIsModified =_Reciver.GetIsModified();
            if (lstIsModified != null)
            {
                int i = 0;
                foreach (var NombreTabla in lstIsModified)
                {
                    string json = _Reciver.GetJsonTable(NombreTabla);
                    if (json != null & json!="")
                    {
                        var client = new RestClient(routeServiceUpLoad);
                        client.Authenticator = new HttpBasicAuthenticator(basicAuthUser, basicAuthPass);
                        var request = new RestRequest(Method.POST);
                        request.Resource = nameService;
                        request.RequestFormat = RestSharp.DataFormat.Json;
                        request.AddHeader("Content-type", "application/json");
                        request.AddBody(new { listPocos = json, dataUser = "", tableName = NombreTabla });
                        try
                        {
                            IRestResponse response = client.Execute(request);
                            var content = response.Content;

                            int inicio = content.IndexOf(":", 0) + 2;
                            int fin = content.IndexOf("]", inicio) + 1;
                            content = content.Substring(inicio, content.Length - (inicio + 2));
                            this.Message = "Sincronizando " + NombreTabla;
                            _Reciver._SpConfirmSincRows(content, NombreTabla);
                            this.Message = NombreTabla + " ha sido actualizada.";
                            i++;
                            responseSevice = true;
                        }
                        catch (Exception ex)
                        {
                            responseSevice = false;
                        }
                    }
                }
            }
            else
            {
                this.Message = "La base de datos está actualizada.";
            }
            return responseSevice;
        }

        #endregion

        #region Actualizar

        public bool GetVersion()
        {
            IsActualizando = true;

            try
            {
                ActualizadorViewModel Actualizador = new ActualizadorViewModel();
                string Path = ConfigurationManager.AppSettings["ActualizadorPath"].ToString();
                string IdAPP = ConfigurationManager.AppSettings["IdAPP"].ToString();
                string CadenaConexion = ConfigurationManager.AppSettings["ConnectionApplication"].ToString();
                string Ip = Actualizador.GetIP();
                string PcName = Environment.MachineName;
                int i = int.Parse(ConfigurationManager.AppSettings["IsUpdate"]);
                string act = Actualizador.GetVersion(VersionAssembly, IdAPP, this.IdUsuario, Path, CadenaConexion, PcName, Ip);

                
                IsActualizando = false;
            }
            catch (Exception)
            {
                ;
            }
            return true;
        }

        #endregion

        #region SyncService (Sincronización)
        public void SyncService()
        {
            this.Message = "Iniciando descarga de información...";
            //Descarga de información
            try
            {
                if (this.GetStatusConexion())
                {
                    int i = int.Parse(ConfigurationManager.AppSettings["IsUpdate"]);
                    if (i == 0)
                    {
                        this.GetVersion();
                        this.CallModifiedData();
                        this.Message = "Datos actualizados.";
                        this._Dispatcher.BeginInvoke(new Action(() =>
                        {
                            this.Message = "Refrescando datos..";
                            this._PantallaInicioViewModel.LoadInfoGrid();
                        }));
                        this.CallService();
                        this.Message = "Iniciando subida de información...";
                        SyncDocsViewModel syncDocs = new SyncDocsViewModel();

                        this.Message = "Enviando documentos al servidor...";
                        syncDocs.UploadSyncDocs();
                        this.Message = "Fin de la sincronización.";
                    }
                }
                else
                    this.Message = "No hay conexión a Internet.";
            }
            catch (Exception ex)
            {
                this.Message = "No hay conexión con el servidor.";
            }
            this.JobDone = true;
            SyncViewModel.IsRunning = false;
        }
        #endregion

        #region Validar conexion.
        private bool GetStatusConexion()
        {
            bool x = false;
            try
            {
                x = NetworkInterface.GetIsNetworkAvailable();
                if (!x)
                    this.Message = "No hay conexión con el servidor.";
            }
            catch (Exception)
            {
                x = false;
            }
            return x;
        }
        #endregion        
    }
}
