using PhoenixCalculator_Avallon.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhoenixCalculator_Avallon.ViewModels
{

    public class DatabaseViewModel : ReactiveObject
    {
        private DBModel model;

        private string _connStatus = "";
        public string connStatus
        {
            get => _connStatus;
            set => this.RaiseAndSetIfChanged(ref _connStatus, value);
        }

        public ObservableCollection<WoodPanel> woodPanels { get; set; }
        public ObservableCollection<LaminateSiding> laminates { get; set; }

        public DatabaseViewModel()
        {
            model = DBModel.GetInstance();
            Refresh();
        }

        public void Refresh()
        {
            Console.WriteLine("DatabaseViewModel.Refresh() Called");
            if (model.TestDBConn())
            {
                connStatus = "Up";
                //woodPanels = model.LoadPanelCostCalcWoodMaterials(woodPanels);
                woodPanels = new ObservableCollection<WoodPanel>(model.GetWoodPanelTable());
                laminates = new ObservableCollection<LaminateSiding>(model.GetLaminateTable());

            }
            else
            {
                connStatus = "False";
                AssignDefaults();
            }
        }

        public void AssignDefaults() {
            Console.WriteLine("DatabaseViewModel.AssignDefaults Called");
            woodPanels = new ObservableCollection<WoodPanel>();
            woodPanels.Add(new WoodPanel());
            laminates = new ObservableCollection<LaminateSiding>();
            laminates.Add(new LaminateSiding());
        }

    }
}
