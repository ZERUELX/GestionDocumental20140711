using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;

namespace GestorDocument.DAL.Repository
{
    public class UsuarioRepository : IUsuario
    {
        public void InsertUsuario(Model.UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.UsuarioModel> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Model.UsuarioModel GetUsuarioID(Model.UsuarioModel usuario)
        {
            Model.UsuarioModel result = new Model.UsuarioModel();
            using (var entity = new GestorDocumentEntities())
            {
                //APP_USUARIO result = null;
                try
                {
                   var res = (from o in entity.APP_USUARIO
                        join ur in entity.APP_USUARIO_ROL
                        on o.IdUsuario equals ur.IdUsuario
                        join r in entity.APP_ROL
                        on ur.IdRol equals r.IdRol
                        join or in entity.CAT_ORGANIGRAMA
                        on r.IdRol equals or.IdRol
                        where o.UsuarioCorreo == usuario.UsuarioCorreo
                        select new {o, r , or}).FirstOrDefault();

                   if (res !=null)
                   {
                       result.IdUsuario = res.o.IdUsuario;
                       result.UsuarioCorreo = res.o.UsuarioCorreo;
                       result.UsuarioPwd = res.o.UsuarioPwd;
                       result.Nombre = res.o.Nombre;
                       result.Apellido = res.o.Apellido;
                       result.Area = res.o.Area;
                       result.Puesto = res.o.Puesto;
                       result.IsActive = res.o.IsActive;
                       result.LastModifiedDate = res.o.LastModifiedDate;
                       result.IsModified = res.o.IsModified;
                       result.IsNuevoUsuario = res.o.IsNuevoUsuario;
                       result.IsActivado = res.o.IsActivado;
                       result.IsFlag = res.o.IsFlag;
                       result.IsFlagPass = res.o.IsFlagPass;
                       result.ServerLastModifiedDate = res.o.ServerLastModifiedDate;
                       result.Rol = new Model.RolModel()
                       {
                           IdRol = res.r.IdRol
                           ,
                           RolName = res.r.RolName
                           ,
                           Organigrama = new Model.OrganigramaModel()
                           {
                               IdJerarquia = res.or.IdJerarquia
                               ,
                               IdJerarquiaParent = res.or.IdJerarquiaParent
                               ,
                               IdRol = res.or.IdRol
                               ,
                               JerarquiaName = res.or.JerarquiaName
                               ,
                               IdTipoUnidadNormativa = res.or.IdTipoUnidadNormativa
                               ,
                               TipoUnidadNormativa = new Model.TipoUnidadNormativaModel() 
                               {
                                   IdTipoUnidadNormativa = res.or.CAT_TIPO_UNIDAD_NORMATIVA.IdTipoUnidadNormativa
                                   ,
                                   TipoUnidadNormativaName = res.or.CAT_TIPO_UNIDAD_NORMATIVA.TipoUnidadNormativaName
                               }
                           }

                       };
                   }
                    
                }
                catch (Exception )
                {
                    ;
                }
            }
            return result;
        }

        public Model.UsuarioModel GetUsuarioAdd(Model.UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public Model.UsuarioModel GetUsuarioMod(Model.UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna el usuario en base a un mail y un password. Retorna null si el usuario y pass no coinciden
        /// </summary>
        /// <param name="userMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Model.UsuarioModel GetUsuario(string userMail, string password)
        {
            Model.UsuarioModel um = null;

            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    var res = (from o in entity.APP_USUARIO
                               where o.UsuarioCorreo == userMail && o.UsuarioPwd == password
                               select o).First<APP_USUARIO>();

                    um = new Model.UsuarioModel()
                    {
                        IdUsuario = res.IdUsuario,
                        UsuarioCorreo = res.UsuarioCorreo,
                        Apellido = res.Apellido,
                        Area = res.Area,
                        Nombre = res.Nombre,
                        Puesto = res.Puesto,
                        UsuarioPwd = res.UsuarioPwd,
                        IsActive = res.IsActive
                    };
                }
                catch (Exception ex)
                {
                    ;
                }
            }

            return um;
        }

        /// <summary>
        /// En base al nombre del usuario obtener su informacion
        /// </summary>
        /// <param name="userMail"></param>
        /// <returns></returns>
        public Model.UsuarioModel GetUsuario(string userMail)
        {
            Model.UsuarioModel um = null;

            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    var res = (from o in entity.APP_USUARIO
                               where o.UsuarioCorreo == userMail
                               select o).First<APP_USUARIO>();

                    um = new Model.UsuarioModel()
                    {
                        IdUsuario = res.IdUsuario,
                        Nombre = res.Nombre,
                        Area = res.Area,
                        Apellido = res.Apellido,
                        Puesto = res.Puesto,
                        UsuarioCorreo = res.UsuarioCorreo,
                        UsuarioPwd = res.UsuarioPwd,
                        IsActive = res.IsActive
                    };

                }
                catch (Exception ex)
                {
                    ;
                }
            }

            return um;
        }

        public void UpdateUsuario(Model.UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(IEnumerable<Model.UsuarioModel> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
