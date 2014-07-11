using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.v2;

namespace GestorDocument.DAL.Repository.v2
{
    public class BusquedaRepository
    {

        public IEnumerable<Model.v2.AsuntosDataGridModel> GetBusqueda(string prioridad, string statusAsunto, string destinatario, string signatario, DateTime? rangofechadesde, DateTime? rangofechahasta, string folio, string tituloAsunto, string descripcionAsunto, string nombreDocumento, Model.RolModel rol)
        {
            ObservableCollection<Model.v2.AsuntosDataGridModel> items = new ObservableCollection<Model.v2.AsuntosDataGridModel>();

            using (var entity = new GestorDocumentEntities())
            {
                 entity.GetAsuntosBusqueda(prioridad, statusAsunto,
                                                destinatario, signatario,
                                                rangofechadesde, rangofechahasta,
                                                folio, tituloAsunto, descripcionAsunto,
                                                nombreDocumento).ToList().ForEach(i =>
                                                {
                                                    items.Add(new Model.v2.AsuntosDataGridModel()
                                                    {
                                                        PrioridadName = i.PrioridadName,
                                                        IdAsunto = i.IdAsunto,
                                                        Titulo = i.Titulo,
                                                        Folio = i.Folio,
                                                        Signatarios = i.DeterminanteName,
                                                        Destinatarios = i.JerarquiaName,
                                                        Respuesta = "",
                                                        FechaRecibido = i.FechaRecibido,
                                                        FechaVencimiento = i.FechaVencimiento
                                                    });
                                                });
            }

            return items;

        }
    }
}
