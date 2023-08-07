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

    //Spaghetti of backing and public fields. The public fields have a special setter that calls a notification function from ReactiveUI that enables Bindings to work correctly
    private string[] _addItemTypes = { "Wood Panel", "Laminate", "Special Finish" };
    public string[] addItemTypes
    {
        get => _addItemTypes;
    }

    private string _selectedAddItemType = "";
    public string selectedAddItemType
    {
        get => _selectedAddItemType;
        set => this.RaiseAndSetIfChanged(ref _selectedAddItemType, value);
    }
    private string _addItemType = "";
    public string addItemType
    {
        get => _addItemType;
        set => this.RaiseAndSetIfChanged(ref _addItemType, value);
    }
    private string _addItemThickness = "";
    public string addItemThickness
    {
        get => _addItemThickness;
        set => this.RaiseAndSetIfChanged(ref _addItemThickness, value);
    }
    private string _addItemWidth = "";
    public string addItemWidth
    {
        get => _addItemWidth;
        set => this.RaiseAndSetIfChanged(ref _addItemWidth, value);
    }
    private string _addItemHeight = "";
    public string addItemHeight
    {
        get => _addItemHeight;
        set => this.RaiseAndSetIfChanged(ref _addItemHeight, value);
    }
    private string _addItemPrice = "";
    public string addItemPrice
    {
        get => _addItemPrice;
        set => this.RaiseAndSetIfChanged(ref _addItemPrice, value);
    }
    private string _addItemLastUpdatedBy = "";
    public string addItemLastUpdatedBy
    {
        get => _addItemLastUpdatedBy;
        set => this.RaiseAndSetIfChanged(ref _addItemLastUpdatedBy, value);
    }
    private string[] _woodMaterialTypes = new string[1];
    private string _addItemStatus = "";
    public string addItemStatus
    {
        get => _addItemStatus;
        set => this.RaiseAndSetIfChanged(ref _addItemStatus, value);
    }
    public string[] woodMaterialTypes
    {
        get => _woodMaterialTypes;
        set => this.RaiseAndSetIfChanged(ref _woodMaterialTypes, value);
    }

    private string _selectedWoodMaterialType = "";
    public string selectedWoodMaterialType
    {
        get => _selectedWoodMaterialType;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedWoodMaterialType, value);
            UpdatePanelThicknesses();
        }
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
    private string[] _thicknesses = new string[1];
    public string[] thicknesses
    {
        get => _thicknesses;
        set { 
            this.RaiseAndSetIfChanged(ref _thicknesses, value);   
        }
    }
    private string _selectedThickness = "";
    public string selectedThickness
    {
        get => _selectedThickness;
        set { 
            this.RaiseAndSetIfChanged(ref _selectedThickness, value);
            UpdatePanelDimensions();
        }
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
    private string[] _panelDimensions = new string[1];
    public string[] panelDimensions
    {
        get => _panelDimensions;
        set { 
            this.RaiseAndSetIfChanged(ref _panelDimensions, value);
        }
    }

    private string _selectedPanelDimensions = "";
    public string selectedPanelDimensions
    {
        get => _selectedPanelDimensions;
        set { 
            this.RaiseAndSetIfChanged(ref _selectedPanelDimensions, value);
            SplitPanelDimensions();
        }
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
            selectedLaminateSidingType1 = "None";
            selectedLaminateSidingType2 = "None";
            selectedSpecialFinishType = "None";
            specialFinishSideNum = "0";

        } else
        {
            connStatus = "False";
        }
    }

    public void SplitPanelDimensions()
    {
        if (selectedPanelDimensions != null && selectedPanelDimensions != "")
        {
            string[] pd = selectedPanelDimensions.Split('x');
            if (pd[0] != null && pd[1] != null)
            {
                panelWidth = pd[0];
                panelHeight = pd[1];
            }
        }

    }
    public void UpdatePanelDimensions()
    {
        panelDimensions = model.GetWoodPanelDimensions(selectedWoodMaterialType, selectedThickness);
    }

    public void UpdatePanelThicknesses()
    {
        thicknesses = model.GetWoodPanelThicknesses(selectedWoodMaterialType);
    }
   public void UpdatePanelCost() {
        Console.WriteLine("UpdatePanelCost Called");
        WoodPanel wp = model.GetWoodPanel(selectedWoodMaterialType, selectedThickness, panelHeight, panelWidth);
        LaminateSiding lp1 = model.GetLaminateSiding(selectedLaminateSidingType1, panelHeight, panelWidth);
        LaminateSiding lp2 = model.GetLaminateSiding(selectedLaminateSidingType2, panelHeight, panelWidth);
        SpecialtyFinish sf = model.GetSpecialtyFinish(selectedSpecialFinishType);
        SpecialtyFinish layupCharge;
        if (selectedLaminateSidingType1=="None" && selectedLaminateSidingType2=="None"){
            layupCharge = new SpecialtyFinish();
            layupCharge.sqftPrice = 0f;
        }
        else if (isPlywood){
            layupCharge = model.GetSpecialtyFinish("Layup Charge Plywood");
        } else {
            layupCharge = model.GetSpecialtyFinish("Layup Charge Not Plywood");
        }
        float sNum;
        try{
            sNum = System.Convert.ToSingle(specialFinishSideNum);
        } catch (Exception e){
            Console.WriteLine(e.ToString());
            sNum = 0f;
        }
        float cpc = wp.price + lp1.price + lp2.price + layupCharge.sqftPrice + sf.sqftPrice * sNum * wp.panelWidth * wp.panelHeight;
        calculatedPanelCost = cpc.ToString();
    }

    public void AddPanelCostItem() {

        if (selectedAddItemType == "Wood Panel"){
            if (addItemType == "" || (addItemHeight != "8" && addItemHeight != "12") || (addItemWidth != "4" && addItemWidth != "5") || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else{
                if (model.AddPanelCostWoodMaterial(addItemType, addItemThickness, addItemWidth, addItemHeight, addItemPrice, "1-1-1900", addItemLastUpdatedBy)) { 
                    addItemStatus = "Entry added to calculator database";
                    woodMaterialTypes = model.GetWoodPanelMaterialTypes();    
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        } else if (selectedAddItemType == "Laminate"){
            if (addItemType == "" || (addItemHeight != "8" && addItemHeight != "12") || (addItemWidth != "4" && addItemWidth != "5") || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else{
                if (model.AddPanelCostLaminateMaterial(addItemType, addItemWidth, addItemHeight, addItemPrice, "1-1-1900", addItemLastUpdatedBy)) { 
                    addItemStatus = "Entry added to calculator database"; 
                    laminateSidingTypes1 = model.GetLaminateSidingTypes();
                    laminateSidingTypes2 = model.GetLaminateSidingTypes();
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        } else if (selectedAddItemType == "Special Finish") {
            if (addItemType == "" || (addItemHeight != "8" && addItemHeight != "12") || (addItemWidth != "4" && addItemWidth != "5") || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else{
                if (model.AddPanelCostSpecialFinish(addItemType, addItemPrice, "1-1-1900", addItemLastUpdatedBy)) { 
                    addItemStatus = "Entry added to calculator database"; 
                    specialFinishTypes = model.GetSpecialFinishTypes();
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        } else {
            addItemStatus = "Invalid Type";
        }
    }
}