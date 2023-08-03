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
    // public WoodPanel[] woodPanels = new WoodPanel[1000];

    private string[] _woodMaterialTypes = new string[1];
    public string[] woodMaterialTypes
    {
        get => _woodMaterialTypes;
        set => this.RaiseAndSetIfChanged(ref _woodMaterialTypes, value);
    }

    private string _selectedWoodMaterialType = "";
    public string selectedWoodMaterialType
    {
        get => _selectedWoodMaterialType;
        set => this.RaiseAndSetIfChanged(ref _selectedWoodMaterialType, value);
    }
    private string[] _laminateSidingTypes1 = new string[1];
    public string[] laminateSidingTypes1
    {
        get => _laminateSidingTypes1;
        set => this.RaiseAndSetIfChanged(ref _laminateSidingTypes1, value);
    }
    private string _selectedLaminateSidingType1 = "";
    public string selectedLaminateSidingType1
    {
        get => _selectedLaminateSidingType1;
        set => this.RaiseAndSetIfChanged(ref _selectedLaminateSidingType1, value);
    }

    private string[] _laminateSidingTypes2 = new string[1];
    public string[] laminateSidingTypes2
    {
        get => _laminateSidingTypes2;
        set => this.RaiseAndSetIfChanged(ref _laminateSidingTypes2, value);
    }
    private string _selectedLaminateSidingType2 = "";
    public string selectedLaminateSidingType2
    {
        get => _selectedLaminateSidingType2;
        set => this.RaiseAndSetIfChanged(ref _selectedLaminateSidingType2, value);
    }
    private string[] _specialFinishTypes = new string[1];
    public string[] specialFinishTypes
    {
        get => _specialFinishTypes;
        set => this.RaiseAndSetIfChanged(ref _specialFinishTypes, value);
    }
    private string _selectedSpecialFinishType = "";
    public string selectedSpecialFinishType
    {
        get => _selectedSpecialFinishType;
        set => this.RaiseAndSetIfChanged(ref _selectedSpecialFinishType, value);
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

    private string _connStatus = "";
    public string connStatus
    {
        get => _connStatus;
        set => this.RaiseAndSetIfChanged(ref _connStatus, value);
    }

    private string _specialFinishSideNum = "";
    public string specialFinishSideNum
    {
        get => _specialFinishSideNum;
        set => this.RaiseAndSetIfChanged(ref _specialFinishSideNum, value);
    }

    private string _calculatedPanelCost = "";
    public string calculatedPanelCost
    {
        get => _calculatedPanelCost;
        set => this.RaiseAndSetIfChanged(ref _calculatedPanelCost, value);
    }

    private bool _isPlywood = false;
    public bool isPlywood
    {
        get => _isPlywood;
        set => this.RaiseAndSetIfChanged(ref _isPlywood, value);
    }

    public PanelCostViewModel() 
    {
        model = DBModel.GetInstance();
        
        if (model.TestDBConn())
        {
            connStatus = "Up";
            //woodPanels = model.LoadPanelCostCalcWoodMaterials(woodPanels);
            woodMaterialTypes = model.GetWoodPanelMaterialTypes();
            laminateSidingTypes1 = model.GetLaminateSidingTypes();
            laminateSidingTypes2 = model.GetLaminateSidingTypes();
            specialFinishTypes = model.GetSpecialFinishTypes();

        } else
        {
            connStatus = "False";
        }
    }
   public void UpdatePanelCost()
    {
        Console.WriteLine("UpdatePanelCost Called");
        WoodPanel wp = model.GetWoodPanel(selectedWoodMaterialType, thickness, panelHeight, panelWidth);
        LaminateSiding lp1 = model.GetLaminateSiding(selectedLaminateSidingType1, panelHeight, panelWidth);
        LaminateSiding lp2 = model.GetLaminateSiding(selectedLaminateSidingType2, panelHeight, panelWidth);
        SpecialtyFinish sf = model.GetSpecialtyFinish(selectedSpecialFinishType);
        float sNum;
        try
        {
            sNum = System.Convert.ToSingle(specialFinishSideNum);
        } catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            sNum = 0;
        }
        float layupCharge = 0f;
        float cpc = wp.price + lp1.price + lp2.price + layupCharge + sf.sqftPrice * sNum;

        calculatedPanelCost = cpc.ToString();
    }
}