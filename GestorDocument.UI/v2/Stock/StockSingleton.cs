using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace GestorDocument.UI.v2.Stock
{
    public sealed class StockSingleton : ViewModelBase
    {
        private static readonly Lazy<StockSingleton> lazy = new Lazy<StockSingleton>(() => new StockSingleton());
        public static StockSingleton Instance { get { return lazy.Value; } }

        public StockSingleton()
        {
            DictionaryControl = new Dictionary<string, UserControl>();
            StackControls = new Stack<string>();
        }

        #region Propiedades.

        public Dictionary<string, UserControl> DictionaryControl
        {
            get { return _DictionaryControl; }
            set
            {
                if (_DictionaryControl != value)
                {
                    _DictionaryControl = value;
                    OnPropertyChanged(DictionaryControlPropertyName);
                }
            }
        }
        private Dictionary<string, UserControl> _DictionaryControl;
        public const string DictionaryControlPropertyName = "DictionaryControl";

        public UserControl SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged(SelectedItemPropertyName);
                }
            }
        }
        private UserControl _SelectedItem;
        public const string SelectedItemPropertyName = "SelectedItem";

        public Stack<string> StackControls
        {
            get { return _StackControls; }
            set
            {
                if (_StackControls != value)
                {
                    _StackControls = value;
                    OnPropertyChanged(StackControlsPropertyName);
                }
            }
        }
        private Stack<string> _StackControls;
        public const string StackControlsPropertyName = "StackControls";


        public void AddStack(string Key, UserControl Control)
        {
            if (!StackControls.Contains(Key))
                StackControls.Push(Key);

        }

        public void GetLastItem()
        {
            if (StackControls.Count > 0)
            {
                SelectedItem = DictionaryControl[StackControls.Last()];
                StackControls.Pop();
            }
        }

        public void RemoveStack(string Key)
        {

        }

        public UserControl QuitarPila()
        {
            //BORRA EL ULTIMO y REGRESA EL PENULTIMO AHORA.
            //StockSingleton.Instance.StackControls.Pop();
            UserControl ucUltimo = StockSingleton.Instance.DictionaryControl[StockSingleton.Instance.StackControls.First()];
            return ucUltimo;
        }

        public void AgregarAPila(string keyUserControl)
        {
           StockSingleton.Instance.StackControls.Push(keyUserControl);
        }


        #endregion
    }
}
