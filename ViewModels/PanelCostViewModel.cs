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
    private string[] _addItemTypes = { "Wood Panel", "Laminate"};
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
            UpdateLastUpdateInfo();
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
        set { this.RaiseAndSetIfChanged(ref _selectedLaminateSidingType1, value);
            UpdateLastUpdateInfo() ;
        }
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
        set { this.RaiseAndSetIfChanged(ref _selectedLaminateSidingType2, value); 
            UpdateLastUpdateInfo();
        }
    }
    private string _specialFinishPrice = "0";
    public string specialFinishPrice
    {
        get => _specialFinishPrice;
        set => this.RaiseAndSetIfChanged(ref _specialFinishPrice, value);
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
            UpdateLastUpdateInfo();
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
            UpdateLastUpdateInfo();
        }
    }

    private string _dateLastUpdated = "";
    public string dateLastUpdated
    {
        get => _dateLastUpdated;
        set
        {
            this.RaiseAndSetIfChanged(ref _dateLastUpdated, value);
        }
    }

    private string _lastUpdatedBy = "";
    public string lastUpdatedBy
    {
        get => _lastUpdatedBy;
        set
        {
            this.RaiseAndSetIfChanged(ref _lastUpdatedBy, value);
        }
    }

    private string _dateLam1LastUpdated = "";
    public string dateLam1LastUpdated
    {
        get => _dateLam1LastUpdated;
        set
        {
            this.RaiseAndSetIfChanged(ref _dateLam1LastUpdated, value);
        }
    }

    private string _lam1LastUpdatedBy = "";
    public string lam1LastUpdatedBy
    {
        get => _lam1LastUpdatedBy;
        set
        {
            this.RaiseAndSetIfChanged(ref _lam1LastUpdatedBy, value);
        }
    }
    private string _dateLam2LastUpdated = "";
    public string dateLam2LastUpdated
    {
        get => _dateLam2LastUpdated;
        set
        {
            this.RaiseAndSetIfChanged(ref _dateLam2LastUpdated, value);
        }
    }

    private string _lam2LastUpdatedBy = "";
    public string lam2LastUpdatedBy
    {
        get => _lam2LastUpdatedBy;
        set
        {
            this.RaiseAndSetIfChanged(ref _lam2LastUpdatedBy, value);
        }
    }

    private string _connStatus = "";
    public string connStatus
    {
        get => _connStatus;
        set => this.RaiseAndSetIfChanged(ref _connStatus, value);
    }

    private string _calculatedPanelCost = "";
    public string calculatedPanelCost
    {
        get => _calculatedPanelCost;
        set => this.RaiseAndSetIfChanged(ref _calculatedPanelCost, value);
    }

    private string _calculatedSQFTPanelCost = "";
    public string calculatedSQFTPanelCost
    {
        get => _calculatedSQFTPanelCost;
        set => this.RaiseAndSetIfChanged(ref _calculatedSQFTPanelCost, value);
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
            Refresh();
   
        } else
        {
            connStatus = "False";
        }
    }

    public void Refresh()
    {
        woodMaterialTypes = model.GetWoodPanelMaterialTypes();
        laminateSidingTypes1 = model.GetLaminateSidingTypes();
        laminateSidingTypes2 = model.GetLaminateSidingTypes();
        selectedLaminateSidingType1 = "None";
        selectedLaminateSidingType2 = "None";
        specialFinishPrice = "0";
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
    public void UpdateLastUpdateInfo()
    {
        //This should probably be separated into 3 different update functions where the relevant one is called when it's needed. 
        //I'll get around to it if it becomes a performance issue. I'll have to rewrite a handful of references.
        if (selectedWoodMaterialType != null && selectedThickness != null && selectedPanelDimensions != null)
        {
            WoodPanel wp = model.GetWoodPanel(selectedWoodMaterialType, selectedThickness, panelHeight, panelWidth);
            dateLastUpdated = wp.date;
            lastUpdatedBy = wp.lastUpdatedBy;
        } else
        {
            dateLastUpdated = "";
            lastUpdatedBy = "";
        }

        if (selectedLaminateSidingType1 != null)
        {
            LaminateSiding lp = model.GetLaminateSiding(selectedLaminateSidingType1);
            dateLam1LastUpdated = lp.date;
            lam1LastUpdatedBy = lp.lastUpdatedBy;
        } else
        {
            dateLam1LastUpdated = "";
            lam1LastUpdatedBy = "";
        }
        if (selectedLaminateSidingType2 != null)
        {
            LaminateSiding lp = model.GetLaminateSiding(selectedLaminateSidingType2);
            dateLam2LastUpdated = lp.date;
            lam2LastUpdatedBy = lp.lastUpdatedBy;
        }
        else
        {
            dateLam2LastUpdated = "";
            lam2LastUpdatedBy = "";
        }
    }
   public void UpdatePanelCost() {
        Console.WriteLine("UpdatePanelCost Called");
        WoodPanel wp = model.GetWoodPanel(selectedWoodMaterialType, selectedThickness, panelHeight, panelWidth);
        LaminateSiding lp1 = model.GetLaminateSiding(selectedLaminateSidingType1);
        LaminateSiding lp2 = model.GetLaminateSiding(selectedLaminateSidingType2);
        LaminateSiding layupCharge;
        if (selectedLaminateSidingType1=="None" && selectedLaminateSidingType2=="None"){
            layupCharge = new LaminateSiding();
            layupCharge.price = 0f;
        }
        else if (isPlywood){
            layupCharge = model.GetLaminateSiding("Layup Charge Plywood");
        } else {
            layupCharge = model.GetLaminateSiding("Layup Charge Not Plywood");
        }
        
        if (wp.price > 900) { 
            calculatedPanelCost = "Error, this panel material does not exist in this size.";
        } else if (lp1.price > 900){
            calculatedPanelCost = "Error, Side 1 Laminate does not exist for this panel size.";
        } else if (lp2.price > 900){
            calculatedPanelCost = "Error, Side 2 Laminate does not exist for this panel size.";
        } else if (layupCharge.price > 900){
            calculatedPanelCost = "Error, Layup Charge out of range.";
        } else{
            //Adjusts prices to square foot. If the dimensions are 1x1, then it's already in square feet and remains the same.
            float lamPrice1 = lp1.price / ((float) lp1.sidingWidth * (float)lp1.sidingHeight);
            float lamPrice2 = lp2.price / (lp2.sidingWidth * lp2.sidingHeight);
            float layup = layupCharge.price / (layupCharge.sidingWidth * layupCharge.sidingHeight);
            float corePriceSQFT = wp.price / (wp.panelWidth * wp.panelHeight);
            float cpc = wp.price + ((lamPrice1 + lamPrice2 + System.Convert.ToSingle(specialFinishPrice) + layup) * wp.panelHeight * wp.panelWidth);
            float cpcs = corePriceSQFT + lamPrice1 + lamPrice2 + layup + System.Convert.ToSingle(specialFinishPrice);
            //Final cost is per square foot.
            calculatedPanelCost = String.Format("{0:N2}",cpc);
            calculatedSQFTPanelCost = String.Format("{0:N2}", cpcs);
        }
    }

    public void AddPanelCostItem() {
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        if (selectedAddItemType == "Wood Panel"){
            if (addItemType == "" || (addItemHeight != "8" && addItemHeight != "12") || (addItemWidth != "4" && addItemWidth != "5") || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else{
                if (model.AddPanelCostWoodMaterial(addItemType, addItemThickness, addItemWidth, addItemHeight, addItemPrice, date, addItemLastUpdatedBy)) { 
                    addItemStatus = "Entry added to calculator database";
                    woodMaterialTypes = model.GetWoodPanelMaterialTypes();    
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        } else if (selectedAddItemType == "Laminate"){
            if (addItemType == "" || addItemHeight=="" || addItemWidth=="" || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else{
                if (model.AddPanelCostLaminateMaterial(addItemType, addItemWidth, addItemHeight, addItemPrice, date, addItemLastUpdatedBy)) { 
                    addItemStatus = "Entry added to calculator database"; 
                    laminateSidingTypes1 = model.GetLaminateSidingTypes();
                    laminateSidingTypes2 = model.GetLaminateSidingTypes();
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        } else {
            addItemStatus = "Invalid Type";
        }
    }
}