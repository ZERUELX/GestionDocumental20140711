using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SyncService.Server.DAL.POCOS;

namespace SyncService.Server.DAL.Repository
{
    public class JsonRepository
    {
        public string GetJsonDownload(string maxJson, string nombreTable)
        {
            string result = null;

            List<string> deserialize = GetDeserialize(maxJson);

            if (deserialize.Count != 0 && !string.IsNullOrEmpty(nombreTable))
                result = GetSerealizeJson(deserialize, nombreTable);

            return result;
        }

        private string GetSerealizeJson(List<string> deserialize, string nombreTable)
        {
            string resultJson = null;
            try
            {
                using (SyncServiceServerEntity entity = new SyncServiceServerEntity())
                {
                    entity.CommandTimeout = 1147483647;

                    string query = this.GetExecStoreProcedure(deserialize.First(), deserialize.Last(), nombreTable);
                    switch (nombreTable)
                    {
                        case "APP_MENU":
                            var resultMenu = entity.ExecuteStoreQuery<Model.SynPocos.APP_MENU>(query, null).ToList();
                            if (resultMenu.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultMenu);
                            break;
                        case "APP_ROL":
                            var resultRol = entity.ExecuteStoreQuery<Model.SynPocos.APP_ROL>(query, null).ToList();
                            if (resultRol.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultRol);
                            break;
                        case "APP_ROL_MENU":
                            var resultRolMenu = entity.ExecuteStoreQuery<Model.SynPocos.APP_ROL_MENU>(query, null).ToList();
                            if (resultRolMenu.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultRolMenu);
                            break;
                        case "APP_USUARIO":
                            var resultUsuario = entity.ExecuteStoreQuery<Model.SynPocos.APP_USUARIO>(query, null).ToList();
                            if (resultUsuario.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultUsuario);
                            break;
                        case "APP_USUARIO_ROL":
                            var resultUsuarioRol = entity.ExecuteStoreQuery<Model.SynPocos.APP_USUARIO_ROL>(query, null).ToList();
                            if (resultUsuarioRol.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultUsuarioRol);
                            break;
                        case "CAT_DETERMINANTE":
                            var resultDeterminante = entity.ExecuteStoreQuery<Model.SynPocos.CAT_DETERMINANTE>(query, null).ToList();
                            if (resultDeterminante.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultDeterminante);
                            break;
                        case "CAT_INSTRUCCION":
                            var resultInstruccion = entity.ExecuteStoreQuery<Model.SynPocos.CAT_INSTRUCCION>(query, null).ToList();
                            if (resultInstruccion.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultInstruccion);
                            break;
                        case "CAT_ORGANIGRAMA":
                            var resultOrganigrama = entity.ExecuteStoreQuery<Model.SynPocos.CAT_ORGANIGRAMA>(query, null).ToList();
                            if (resultOrganigrama.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultOrganigrama);
                            break;
                        case "CAT_PRIORIDAD":
                            var resultPrioridad = entity.ExecuteStoreQuery<Model.SynPocos.CAT_PRIORIDAD>(query, null).ToList();
                            if (resultPrioridad.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultPrioridad);
                            break;
                        case "CAT_STATUS_ASUNTO":
                            var resultStatusAsunto = entity.ExecuteStoreQuery<Model.SynPocos.CAT_STATUS_ASUNTO>(query, null).ToList();
                            if (resultStatusAsunto.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultStatusAsunto);
                            break;
                        case "CAT_STATUS_TURNO":
                            var resultStatusTurno = entity.ExecuteStoreQuery<Model.SynPocos.CAT_STATUS_TURNO>(query, null).ToList();
                            if (resultStatusTurno.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultStatusTurno);
                            break;
                        case "CAT_TIPO_DETERMINANTE":
                            var resultTipoDeterminante = entity.ExecuteStoreQuery<Model.SynPocos.CAT_TIPO_DETERMINANTE>(query, null).ToList();
                            if (resultTipoDeterminante.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultTipoDeterminante);
                            break;
                        case "CAT_TIPO_DOCUMENTO":
                            var resultTipoDocumento = entity.ExecuteStoreQuery<Model.SynPocos.CAT_TIPO_DOCUMENTO>(query, null).ToList();
                            if (resultTipoDocumento.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultTipoDocumento);
                            break;
                        case "CAT_TIPO_EXTENCION":
                            var resultTipoExtencion = entity.ExecuteStoreQuery<Model.SynPocos.CAT_TIPO_EXTENCION>(query, null).ToList();
                            if (resultTipoExtencion.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultTipoExtencion);
                            break;
                        case "CAT_TIPO_UNIDAD_NORMATIVA":
                            var resultTipoUnidadNormativa = entity.ExecuteStoreQuery<Model.SynPocos.CAT_TIPO_UNIDAD_NORMATIVA>(query, null).ToList();
                            if (resultTipoUnidadNormativa.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultTipoUnidadNormativa);
                            break;
                        case "CAT_UBICACION":
                            var resultUbicacion = entity.ExecuteStoreQuery<Model.SynPocos.CAT_UBICACION>(query, null).ToList();
                            if (resultUbicacion.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultUbicacion);
                            break;
                        case "GET_ASUNTO":
                            var resultAsunto = entity.ExecuteStoreQuery<Model.SynPocos.GET_ASUNTO>(query, null).ToList();
                            if (resultAsunto.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultAsunto);
                            break;
                        case "GET_DOCUMENTOS":
                            var resultDocumentos = entity.ExecuteStoreQuery<Model.SynPocos.GET_DOCUMENTOS>(query, null).ToList();
                            if (resultDocumentos.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultDocumentos);
                            break;
                        case "GET_EXPEDIENTE":
                            var resultExpediente = entity.ExecuteStoreQuery<Model.SynPocos.GET_EXPEDIENTE>(query, null).ToList();
                            if (resultExpediente.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultExpediente);
                            break;
                        case "GET_FECHA_VENCIMIENTO":
                            var resultFechaVencimiento = entity.ExecuteStoreQuery<Model.SynPocos.GET_FECHA_VENCIMIENTO>(query, null).ToList();
                            if (resultFechaVencimiento.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultFechaVencimiento);
                            break;
                        case "GET_TURNO":
                            var resultTurno = entity.ExecuteStoreQuery<Model.SynPocos.GET_TURNO>(query, null).ToList();
                            if (resultTurno.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultTurno);
                            break;
                        case "REL_DESTINATARIO":
                            var resultRelDestinatario = entity.ExecuteStoreQuery<Model.SynPocos.REL_DESTINATARIO>(query, null).ToList();
                            if (resultRelDestinatario.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultRelDestinatario);
                            break;
                        case "REL_DESTINATARIO_CCP":
                            var resultRelDestinatarioCcp = entity.ExecuteStoreQuery<Model.SynPocos.REL_DESTINATARIO_CCP>(query, null).ToList();
                            if (resultRelDestinatarioCcp.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultRelDestinatarioCcp);
                            break;
                        case "REL_SIGNATARIO":
                            var resultRelSignatario = entity.ExecuteStoreQuery<Model.SynPocos.REL_SIGNATARIO>(query, null).ToList();
                            if (resultRelSignatario.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultRelSignatario);
                            break;
                        case "REL_SIGNATARIO_EXTERNO":
                            var resultRelSignatarioExterno = entity.ExecuteStoreQuery<Model.SynPocos.REL_SIGNATARIO_EXTERNO>(query, null).ToList();
                            if (resultRelSignatarioExterno.Count > 0)
                                resultJson = SerializerJson.SerializeParametros(resultRelSignatarioExterno);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultJson = ex.Message;
            }
            return resultJson;
        }

        public string GetExecStoreProcedure(string lastModifiedDate, string serverLastModifiedDate, string nombreTable)
        {
            string sqlStmt;
            //Cadena que ejeucta sp
            sqlStmt = "EXEC SP_GetJsonMaxsServer " + "@lastModifiedDate = N'@@par1', "
                                                  + "@serverLastModifiedDate = N'@@par2', "
                                                  + "@tblName = N'@@par3';";

            sqlStmt = sqlStmt.Replace("@@par1", lastModifiedDate);
            sqlStmt = sqlStmt.Replace("@@par2", serverLastModifiedDate);
            sqlStmt = sqlStmt.Replace("@@par3", nombreTable);


            return sqlStmt;
        }

        public List<string> GetDeserialize(string maxJson)
        {
            List<string> result = new List<string>();
            try
            {
                //[{LastModifiedDate:'0', ServerLastModifiedDate:'0'}]
                string[] stringSeparators = new string[] { "[{LastModifiedDate:'", "'", ",", "ServerLastModifiedDate:'", "}]", " ", };
                string[] resultSplit;

                resultSplit = maxJson.Split(stringSeparators, StringSplitOptions.None);

                resultSplit.Where(w => w != "").ToList().ForEach(p => result.Add(p));
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
