using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.v2;

namespace GestorDocument.DAL.Repository.v2
{
    public class AsuntoRepository:IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public List<AsuntosDataGridModel> getAsuntosOfiPart(string tipoAsunto)
        {
            List<AsuntosDataGridModel> items = new List<AsuntosDataGridModel>();
            try
            {
                using (var entity=new GestorDocumentEntities())
                {
                    entity.spGetAsuntosOfiPart(tipoAsunto).ToList().ForEach(i => {
                        items.Add(new AsuntosDataGridModel() {
                            IdAsunto=i.IdAsunto,
                            PrioridadName=i.PrioridadName,
                            PathImagen=i.PathImagen,
                            Titulo=i.Titulo,
                            Folio=i.Folio,
                            Signatarios=i.Signatarios,
                            Destinatarios=i.Destinatarios,
                            Respuesta=i.Respuesta,
                            FechaRecibido=i.FechaRecibido,
                            FechaVencimiento=i.FechaVencimiento
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ;                
            }
            return items;
        }


    }
}
