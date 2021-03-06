﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SyncService.Server.DAL.Repository
{
    public class SerializerJson
    {
        /// <summary>
        /// Método que regresa un Json
        /// </summary>
        /// <returns></returns>
        public static string SerializeParametros(object parametros)
        {
            try
            {
                string json = JsonConvert.SerializeObject(parametros);

                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
