using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface ISesion
    {
        /// <summary>
        /// Obtiene la sesion. Si no se ha guardado sesion retorna null
        /// </summary>
        /// <returns></returns>
        SesionModel GetSesion();

        /// <summary>
        /// Guarda la ultima sesión exitosa
        /// </summary>
        /// <param name="sesion"></param>
        void SetSesion(SesionModel sesion);

        /// <summary>
        /// actualiza la ultima sesión 
        /// </summary>
        /// <param name="sesion"></param>
        void UpdateSesion(SesionModel sesion);
    }
}
