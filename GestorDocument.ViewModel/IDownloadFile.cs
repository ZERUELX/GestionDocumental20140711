using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.ViewModel
{
    public interface IDownloadFile
    {
        string Msg
        {
            get;
            set;
        }

        bool Response
        {
            get;
            set;
        }

        void ShowOk();

        void Show(TrancingAsuntoViewModel viewModel);

        void Show(TrancingAsuntoTurnoViewModel viewModel);

        void Show(TrancingAsuntoTurnoReadViewModel viewModel);

        void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);

    }
}
