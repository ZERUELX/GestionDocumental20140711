using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IUsuario
    {
        // Create.
        void InsertUsuario(UsuarioModel usuario);

        // Read.
        IEnumerable<UsuarioModel> GetUsuarios();
        UsuarioModel GetUsuarioID(UsuarioModel usuario);
        UsuarioModel GetUsuarioAdd(UsuarioModel usuario);
        UsuarioModel GetUsuarioMod(UsuarioModel usuario);

        /// <summary>
        /// Retorna el usuario en base a un mail y un password. Retorna null si el usuario y pass no coinciden
        /// </summary>
        /// <param name="userMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UsuarioModel GetUsuario(string userMail, string password);

        /// <summary>
        /// En base al nombre del usuario obtener su informacion
        /// </summary>
        /// <param name="userMail"></param>
        /// <returns></returns>
        UsuarioModel GetUsuario(string userMail);

        // Update.
        void UpdateUsuario(UsuarioModel usuario);

        // Delete.
        void DeleteUsuario(IEnumerable<UsuarioModel> usuarios);
    }
}
