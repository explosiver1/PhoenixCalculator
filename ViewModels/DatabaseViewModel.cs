using PhoenixCalculator_Avallon.Models;
using ReactiveUI;
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
            if (model.TestDBConn())
            {
                connStatus = "Up";
                //woodPanels = model.LoadPanelCostCalcWoodMaterials(woodPanels);
                Refresh();

            }
            else
            {
                connStatus = "False";
                woodPanels = new ObservableCollection<WoodPanel>();
                woodPanels.Add(new WoodPanel());
                laminates = new ObservableCollection<LaminateSiding>();
                laminates.Add(new LaminateSiding());
            }
        }

        public void Refresh()
        {
            woodPanels = new ObservableCollection<WoodPanel>(model.GetWoodPanelTable());
            laminates = new ObservableCollection<LaminateSiding>(model.GetLaminateTable());
        }

    }
}
