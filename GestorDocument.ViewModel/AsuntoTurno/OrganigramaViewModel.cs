using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class OrganigramaViewModel : ViewModelBase
    {
        // Repository.
        private IOrganigrama _OrganigramaRepository;
        // ***************************** ***************************** *****************************
        public AddOrganigramaAsuntoViewModel AddOrganigramaAsuntoViewModel
        {
            get { return _AddOrganigramaAsuntoViewModel; }
            set
            {
                if (_AddOrganigramaAsuntoViewModel != value)
                {
                    _AddOrganigramaAsuntoViewModel = value;
                    OnPropertyChanged(TreeViewPropertyName);
                }
            }
        }
        private AddOrganigramaAsuntoViewModel _AddOrganigramaAsuntoViewModel;
        public const string TreeViewPropertyName = "AddOrganigramaAsuntoViewModel";

        public ObservableCollection<AddOrganigramaAsuntoViewModel> Organigramas
        {
            get { return _Organigramas; }
            set
            {
                if (_Organigramas != value)
                {
                    _Organigramas = value;
                    OnPropertyChanged(OrganigramasPropertyName);
                }
            }
        }
        private ObservableCollection<AddOrganigramaAsuntoViewModel> _Organigramas;
        public const string OrganigramasPropertyName = "Organigramas";

        public OrganigramaViewModel()
        {
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this.Organigramas = new ObservableCollection<AddOrganigramaAsuntoViewModel>();
            this.LoadInfoGrid();

        }

        public void LoadInfoGrid()
        {
            //obtengo el arborol
            OrganigramaModel res = this._OrganigramaRepository.GetOrganigramaID();
        }

        private void GetChildren(AddOrganigramaAsuntoViewModel papa)
        {
            OrganigramaModel parent = papa.Parent;
            if (parent != null)
            {
                List<long> auxUnidsJerarquia = new List<long>();
                ObservableCollection<OrganigramaModel> res = new ObservableCollection<OrganigramaModel>();
                res = this._OrganigramaRepository.GetOrganigramaParent(parent) as ObservableCollection<OrganigramaModel>;
                if (res != null)
                {
                    //validación de que si ya se cargaron los hijos no volverlos a cargar
                    (from o in parent.ChildrenJerarquia
                     select o).ToList<OrganigramaModel>().ForEach(o => auxUnidsJerarquia.Add(o.IdJerarquia));

                    (from o in res
                     where !auxUnidsJerarquia.Contains(o.IdJerarquia)
                     select o).ToList<OrganigramaModel>().ForEach(o =>
                     {
                         o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
                         {
                             if (args.PropertyName == "IsSelected")
                             {
                                 if ((sender as AddOrganigramaAsuntoViewModel).TreeView.IsSelected)
                                 {
                                     GetChildren((sender as AddOrganigramaAsuntoViewModel));
                                 }
                             };
                         };
                         parent.ChildrenJerarquia.Add(o);
                     });
                }
            }
        }
    }
}
