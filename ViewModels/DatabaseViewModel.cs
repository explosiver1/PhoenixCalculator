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
        private ObservableCollection<WoodPanel> newPanels {get; set;}
        public ObservableCollection<LaminateSiding> laminates { get; set; }
        private ObservableCollection<LaminateSiding> newlaminates { get; set; }

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
                if (woodPanels == null && laminates == null) {
                woodPanels = new ObservableCollection<WoodPanel>(model.GetWoodPanelTable());
                laminates = new ObservableCollection<LaminateSiding>(model.GetLaminateTable());
                } else {
                    //This is a massive klooge to get around ObservableCollections not recognizing when the whole collection is replaced.
                    //Changes need to happen through adds and removes for the binding to see it.
                    //It honestly may be faster to clear the table and readd everything. That's at least in the order of N.
                    //Depends on how slow add and remove operations are compared to the Contains function.
                    bool dummyBool;
                    newPanels = new ObservableCollection<WoodPanel>(model.GetWoodPanelTable());
                    foreach (WoodPanel wp in newPanels) {
                        if (!woodPanels.Contains(wp)) woodPanels.Add(wp);
                    }
                    //Apparently modifying the list you ran a foreach on inside of the foreach block will throw errors.
                    //I'm caching an array and doing the removal in another loop.
                    //I hate this.
                    WoodPanel[] WPS = new WoodPanel[woodPanels.Count];
                    int i = 0;
                    foreach (WoodPanel wp in woodPanels) {
                        if (!newPanels.Contains(wp)) {
                        WPS[i] = wp;
                        i++;
                        }
                    }
                    for (int j = 0; j < i; j++) {
                        dummyBool = woodPanels.Remove(WPS[j]);
                    }

                    newlaminates = new ObservableCollection<LaminateSiding>(model.GetLaminateTable());
                    foreach (LaminateSiding ls in newlaminates) {
                        if (!laminates.Contains(ls)) laminates.Add(ls);
                    }
                    LaminateSiding[] LSS = new LaminateSiding[laminates.Count];
                    int k = 0;
                    foreach (LaminateSiding ls in laminates) {
                        if (!newlaminates.Contains(ls)) {LSS[k] = ls;
                        k++;}
                    }
                    for (int l = 0; l < k; l++) {
                        dummyBool = laminates.Remove(LSS[l]);
                    }
                }

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
