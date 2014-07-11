using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace GestorDocument.UI
{
    public interface IContentControl
    {
        ContentControl GetContentPane();
        void Nuevo();
    }
}
