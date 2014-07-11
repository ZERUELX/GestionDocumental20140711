using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using GestorDocument.Model;

namespace GestorDocument.Model.IRepository
{
    public interface IDashBoard
    {
        ObservableCollection<AnioModel> GetAnio();
        ObservableCollection<MesModel> GetMes();
        PendienteIndicadorModel GetPendientes(ObservableCollection<DeterminanteModel> Determinantes);
        AtendidoIndicadorModel GetAtendidos(ObservableCollection<DeterminanteModel> Determinantes);
        ObservableCollection<DeterminanteModel> GetDeterminante();
        ObservableCollection<DashBoardTableModel> GetDT();


        Model.DashBoardModel.DashBoardTableModel GetDTOcavmUrgente(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes);
        Model.DashBoardModel.DashBoardTableModel GetDTOcavmTodos(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes);
        Model.DashBoardModel.DashBoardTableModel GetDTOcavmPrioritarioOrdinario(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes);
        ObservableCollection<Model.DashBoardModel.DashBoardTableModel> GetDTDirecciones(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes, string Prioridades);
        ObservableCollection<Model.DashBoardModel.DashBoardTableModel> GetDTDireccionesTodos(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes);
        ObservableCollection<Model.DashBoardModel.DashBoardGraphModel> GetGraphData(Model.DashBoardModel.AnioModel Anio, Model.DashBoardModel.MesModel Mes, ObservableCollection<Model.DeterminanteModel> Determinantes, string Prioridades, string Organigrama);

    }
}
