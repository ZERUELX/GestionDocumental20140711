using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;

namespace GestorDocument.DAL.Repository
{
    public class SesionRepository : ISesion
    {
        public SesionModel GetSesion()
        {
            SesionModel sesion = null;

            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    var s = (from o in entity.CAT_SESION.Include("APP_USUARIO")                             
                             select o).First<CAT_SESION>();

                    sesion = new SesionModel();
                    sesion.User = new UsuarioModel()
                    {
                        IdUsuario = s.IdUsuario,
                        Nombre = s.APP_USUARIO.Nombre,
                        UsuarioCorreo = s.APP_USUARIO.UsuarioCorreo,
                        Puesto = s.APP_USUARIO.Puesto,
                        Apellido = s.APP_USUARIO.Apellido,
                        Area = s.APP_USUARIO.Area,
                        UsuarioPwd = s.APP_USUARIO.UsuarioCorreo,
                        IsActive = s.APP_USUARIO.IsActive,                        
                    };
                    sesion.NoCerrarSesion = s.IsSaveSesion;

                }
                catch (Exception ex)
                {

                }
            }

            return sesion;
        }

        public void SetSesion(SesionModel sesion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    var s = (from o in entity.CAT_SESION.Include("APP_USUARIO")
                             select o).FirstOrDefault();

                    if (s != null)
                    {
                        s.IdUsuario = sesion.User.IdUsuario;
                        s.IsSaveSesion = sesion.NoCerrarSesion;
                    }
                    else
                    {
                        entity.CAT_SESION.AddObject(new CAT_SESION()
                        {
                            IdSesion = 1,
                            IdUsuario = sesion.User.IdUsuario,
                            IsSaveSesion = sesion.NoCerrarSesion
                        });
                    }

                    entity.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void UpdateSesion(SesionModel sesion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    var s = (from o in entity.CAT_SESION.Include("APP_USUARIO")
                             select o).FirstOrDefault();

                    if (s != null)
                    {
                        s.IdUsuario = sesion.User.IdUsuario;
                        s.IsSaveSesion = sesion.NoCerrarSesion;
                    }
                    entity.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
