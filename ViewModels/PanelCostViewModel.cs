using Avalonia.Interactivity;
using PhoenixCalculator_Avallon.Models;
using System;
using System.Reactive;
using System.Linq;
using ReactiveUI;

namespace PhoenixCalculator_Avallon.ViewModels;

public class PanelCostViewModel : ReactiveObject
{
    //
    public DBModel model;
    public WoodPanel[] woodPanels;


    private string _test = "";
    public string test
    {
            get => _test;
            set => this.RaiseAndSetIfChanged(ref _test, value);
       
    }

    private string _woodMaterialType = "";
    public string woodMaterialType
    {
        get => _woodMaterialType;
        set => this.RaiseAndSetIfChanged(ref _woodMaterialType, value);
    }

    private string _thickness = "";
    public string thickness
    {
        get => _thickness;
        set => this.RaiseAndSetIfChanged(ref _thickness, value);
    }

    private string _panelWidth = "";
    public string panelWidth
    {
        get => _panelWidth;
        set => this.RaiseAndSetIfChanged(ref _panelWidth, value);
    }

    private string _panelHeight = "";
    public string panelHeight
    {
        get => _panelHeight;
        set => this.RaiseAndSetIfChanged(ref _panelHeight, value);
    }

    private string _price = "";
    public string price
    {
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value);
    }

    private string _date = "";
    public string date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private string _lastUpdatedBy = "";
    public string lastUpdatedBy
    {
        get => _lastUpdatedBy;
        set => this.RaiseAndSetIfChanged(ref _lastUpdatedBy, value);
    }

    private string _connStatus = "";
    public string connStatus
    {
        get => _connStatus;
        set => this.RaiseAndSetIfChanged(ref _connStatus, value);
    }


    
    public PanelCostViewModel() 
    {
        test = "Burrito";
        model = DBModel.GetInstance();
        woodPanels = new WoodPanel[1000];
        for (int i = 0; i < woodPanels.Length; i++) { woodPanels[i] = new WoodPanel(); }
        if (model.TestDBConn())
        {
            connStatus = "Up";
            //woodPanels = model.SetupPanelCostCalcWoodPanels();

            //test = woodPanels[0].type + " " + woodPanels[0].thickness.ToString() + " " + woodPanels[0].panelWidth.ToString() + " " + woodPanels[0].panelHeight.ToString() + " " + woodPanels[0].price.ToString() + " " + woodPanels[0].date.ToString() + " " + woodPanels[0].lastUpdatedBy;
        } else
        {
            connStatus = "False";
        }
    }
   public void UpdatePanelCost()
    {
        Console.WriteLine("UpdatePanelCost Called");
        //I'm modifying the values of existing objects rather than instantiating new ones to fill in the array.
        //This prevents it from becoming null after returning from the querying function. 
        //I'm clearly not understanding something about how the C# garbage collector handles objects in methods. 
        model.LoadPanelCostCalcWoodMaterials(woodPanels);
        test = woodPanels[0].type + " " + woodPanels[0].thickness.ToString() + " " + woodPanels[0].panelWidth.ToString() + " " + woodPanels[0].panelHeight.ToString() + " " + woodPanels[0].price.ToString() + " " + woodPanels[0].date + " " + woodPanels[0].lastUpdatedBy;
        woodMaterialType = woodPanels[0].type;
        thickness = woodPanels[0].thickness.ToString();
        panelWidth = woodPanels[0].panelWidth.ToString();
        panelHeight = woodPanels[0].panelHeight.ToString();
        price = woodPanels[0].price.ToString();
        date = woodPanels[0].date;
        lastUpdatedBy = woodPanels[0].lastUpdatedBy;
    }
}