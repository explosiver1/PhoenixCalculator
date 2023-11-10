using Avalonia;
using DynamicData.Kernel;
using PhoenixCalculator_Avallon.Models;
using ReactiveUI;
using SkiaSharp;
using System;
using System.ComponentModel;

namespace PhoenixCalculator_Avallon.ViewModels;

public class PanelCostViewModel : ReactiveObject
{
    //Constants
    int EXPIRATION_DATE = 30;

    public DBModel model;
    // public WoodPanel[] woodPanels = new WoodPanel[1000];

    //Spaghetti of backing and public fields. The public fields have a special setter that calls a notification function from ReactiveUI that enables Bindings to work correctly

    private string _addItemHeight = "";
    public string addItemHeight
    {
        get => _addItemHeight;
        set => this.RaiseAndSetIfChanged(ref _addItemHeight, value);
    }

    private string _addItemLastUpdatedBy = "";
    public string addItemLastUpdatedBy
    {
        get => _addItemLastUpdatedBy;
        set => this.RaiseAndSetIfChanged(ref _addItemLastUpdatedBy, value);
    }

    private string _addItemPrice = "";
    public string addItemPrice
    {
        get => _addItemPrice;
        set => this.RaiseAndSetIfChanged(ref _addItemPrice, value);
    }

    private string _addItemThickness = "";
    public string addItemThickness
    {
        get => _addItemThickness;
        set => this.RaiseAndSetIfChanged(ref _addItemThickness, value);
    }

    private string[] _addItemTypes = { "Wood Panel", "Laminate" };
    public string[] addItemTypes
    {
        get => _addItemTypes;
    }

    private string _addItemType = "";
    public string addItemType
    {
        get => _addItemType;
        set => this.RaiseAndSetIfChanged(ref _addItemType, value);
    }

    private string _addItemStatus = "";
    public string addItemStatus
    {
        get => _addItemStatus;
        set => this.RaiseAndSetIfChanged(ref _addItemStatus, value);
    }

    private string _addItemWidth = "";
    public string addItemWidth
    {
        get => _addItemWidth;
        set => this.RaiseAndSetIfChanged(ref _addItemWidth, value);
    }

    private string _connStatus = "";
    public string connStatus
    {
        get => _connStatus;
        set => this.RaiseAndSetIfChanged(ref _connStatus, value);
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

    private string _dateLam2LastUpdated = "";
    public string dateLam2LastUpdated
    {
        get => _dateLam2LastUpdated;
        set
        {
            this.RaiseAndSetIfChanged(ref _dateLam2LastUpdated, value);
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

    private string _lam1Dimensions = "";
    public string lam1Dimensions
    {
        get => _lam1Dimensions;
        set
        {
            this.RaiseAndSetIfChanged(ref _lam1Dimensions, value);
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

    private string _lam1Price = "";
    //This is used to check for overrides. 
    private float lam1StoredPrice = 0.0f;
    public string lam1Price
    {
        get => _lam1Price;
        set
        {
            this.RaiseAndSetIfChanged(ref _lam1Price, value);
        }
    }

    private string _lam2Dimensions = "";
    public string lam2Dimensions
    {
        get => _lam2Dimensions;
        set
        {
            this.RaiseAndSetIfChanged(ref _lam2Dimensions, value);
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

    private string _lam2Price = "";
    private float lam2StoredPrice = 0.0f;
    public string lam2Price
    {
        get => _lam2Price;
        set
        {
            this.RaiseAndSetIfChanged(ref _lam2Price, value);
        }
    }

    private string[] _laminateSidingTypes1 = new string[1];
    public string[] laminateSidingTypes1
    {
        get => _laminateSidingTypes1;
        set => this.RaiseAndSetIfChanged(ref _laminateSidingTypes1, value);
    }

    private string[] _laminateSidingTypes2 = new string[1];
    public string[] laminateSidingTypes2
    {
        get => _laminateSidingTypes2;
        set => this.RaiseAndSetIfChanged(ref _laminateSidingTypes2, value);
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

    private string[] _panelDimensions = new string[1];
    public string[] panelDimensions
    {
        get => _panelDimensions;
        set
        {
            this.RaiseAndSetIfChanged(ref _panelDimensions, value);
        }
    }

    private string _panelHeight = "";
    public string panelHeight
    {
        get => _panelHeight;
        set => this.RaiseAndSetIfChanged(ref _panelHeight, value);
    }

    private string _panelWidth = "";
    public string panelWidth
    {
        get => _panelWidth;
        set => this.RaiseAndSetIfChanged(ref _panelWidth, value);
    }

    private string _removeItemStatus = "";
    public string removeItemStatus
    {
        get => _removeItemStatus;
        set => this.RaiseAndSetIfChanged(ref _removeItemStatus, value);
    }

    private string _selectedAddItemType = "";
    public string selectedAddItemType
    {
        get => _selectedAddItemType;
        set => this.RaiseAndSetIfChanged(ref _selectedAddItemType, value);
    }

    private string _selectedLaminateSidingType1 = "";
    public string selectedLaminateSidingType1
    {
        get => _selectedLaminateSidingType1;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedLaminateSidingType1, value);
            UpdateLamSide1();
        }
    }

    private string _selectedLaminateSidingType2 = "";
    public string selectedLaminateSidingType2
    {
        get => _selectedLaminateSidingType2;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedLaminateSidingType2, value);
            UpdateLamSide2();
        }
    }

    private string _selectedPanelDimensions = "";
    public string selectedPanelDimensions
    {
        get => _selectedPanelDimensions;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedPanelDimensions, value);
            SplitPanelDimensions();
            UpdateWP();
        }
    }

    private string _selectedThickness = "";
    public string selectedThickness
    {
        get => _selectedThickness;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedThickness, value);
            UpdatePanelDimensions();
            UpdateWP();
        }
    }

    private string _selectedWoodMaterialType = "";
    public string selectedWoodMaterialType
    {
        get => _selectedWoodMaterialType;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedWoodMaterialType, value);
            UpdatePanelThicknesses();
            UpdateWP();
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
        set
        {
            this.RaiseAndSetIfChanged(ref _thicknesses, value);
        }
    }

    private string[] _woodMaterialTypes = new string[1];
    public string[] woodMaterialTypes
    {
        get => _woodMaterialTypes;
        set => this.RaiseAndSetIfChanged(ref _woodMaterialTypes, value);
    }

    private string _woodPanelPrice = "";
    private float woodPanelStoredPrice = 0.0f;
    public string woodPanelPrice
    {
        get => _woodPanelPrice;
        set
        {
            this.RaiseAndSetIfChanged(ref _woodPanelPrice, value);
        }
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



    //Remove Item Panel 
    
    private string[] _removeTypes;
    public string[] removeTypes
    {
        get { return _removeTypes; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeTypes, value);
        }
    }

    private string _selectedRemoveType;
    public string selectedRemoveType
    {
        get { return _selectedRemoveType; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedRemoveType, value);
            UpdateRemoveItemNames();
        }
    }
    private string[] _removeItemNames;
    public string[] removeItemNames
    {
        get { return _removeItemNames; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeItemNames, value);
        }
    }
    private string _selectedRemoveItemName;
    public string selectedRemoveItemName
    {
        get { return _selectedRemoveItemName; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedRemoveItemName, value);
            if (_selectedRemoveItemName != "")
            {
                if (selectedRemoveType == "Wood Panel") UpdateRemoveThicknesses();
                else UpdateRemoveLaminate();
            }
            
        }
    }
    private string[] _removeThicknesses;
    public string[] removeThicknesses
    {
        get { return _removeThicknesses; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeThicknesses, value);
            selectedRemoveThickness = "";
        }
    }
    private string _selectedRemoveThickness;
    public string selectedRemoveThickness
    {
        get { return _selectedRemoveThickness; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedRemoveThickness, value);
            if (selectedRemoveType == "Wood Panel") UpdateRemoveDimensions();
        }
    }
    private string[] _removeDimensions;
    public string[] removeDimensions
    {
        get { return _removeDimensions; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeDimensions, value);
            selectedRemoveDimension = "";
        }
    }
    private string _selectedRemoveDimension;
    public string selectedRemoveDimension
    {
        get { return _selectedRemoveDimension; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedRemoveDimension, value);
            if (selectedRemoveType == "Wood Panel") UpdateRemoveItemMiscInfo();
        }
    }

    private string _removePrice;
    public string removePrice
    {
        get { return _removePrice; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removePrice, value);
        }
    }

    private string _removeDateLastUpdated;
    public string removeDateLastUpdated
    {
        get { return _removeDateLastUpdated; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeDateLastUpdated, value);
        }
    }

    private string _removeLastUpdatedBy;
    public string removeLastUpdatedBy
    {
        get { return _removeLastUpdatedBy; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeLastUpdatedBy, value);
        }
    }




    public PanelCostViewModel()
    {
        removeTypes = new string[] { "Wood Panel", "Laminate" };
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
        }
    }

    public void Refresh()
    {
        woodMaterialTypes = model.GetWoodPanelMaterialTypes();
        laminateSidingTypes1 = model.GetLaminateSidingTypes();
        laminateSidingTypes2 = model.GetLaminateSidingTypes();
        //selectedLaminateSidingType1 = "None";
        //selectedLaminateSidingType2 = "None";
        //specialFinishPrice = "0";
    }
    public void SplitPanelDimensions()
    {
        try {
            if (selectedPanelDimensions != null && selectedPanelDimensions != "")
            {
                string[] pd = selectedPanelDimensions.Split('x');
                if (pd[0] != null && pd[1] != null)
                {
                    panelWidth = pd[0];
                    panelHeight = pd[1];
                }
            }
        } catch (Exception e) {
            calculatedPanelCost = "There was an error splitting the panel dimensions. Panel width and height set to 0.";
            panelWidth = "0";
            panelHeight = "0";
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


        UpdateWP();
        UpdateLamSide1();
        UpdateLamSide2();
    }

    public void UpdateWP()
    {
        if (selectedWoodMaterialType != null && selectedThickness != null && selectedPanelDimensions != null)
        {
            WoodPanel wp = model.GetWoodPanel(selectedWoodMaterialType, selectedThickness, panelHeight, panelWidth);
            dateLastUpdated = wp.date;
            lastUpdatedBy = wp.lastUpdatedBy;
            woodPanelPrice = wp.price.ToString();
            woodPanelStoredPrice = wp.price;
        }
        else
        {
            dateLastUpdated = "";
            lastUpdatedBy = "";
            woodPanelStoredPrice = 0.0f;
        }
    }

    public void UpdateLamSide1()
    {
        if (selectedLaminateSidingType1 != null)
        {
            LaminateSiding lp = model.GetLaminateSiding(selectedLaminateSidingType1);
            dateLam1LastUpdated = lp.date;
            lam1LastUpdatedBy = lp.lastUpdatedBy;
            lam1Price = lp.price.ToString();
            lam1StoredPrice = lp.price;
            lam1Dimensions = lp.sidingWidth.ToString() + "x" + lp.sidingHeight.ToString();
        }
        else
        {
            dateLam1LastUpdated = "";
            lam1LastUpdatedBy = "";
            lam1Price = "";
            lam1StoredPrice = 0.0f;
            lam1Dimensions = "";
        }
    }

    public void UpdateLamSide2()
    {
        if (selectedLaminateSidingType2 != null)
        {
            LaminateSiding lp = model.GetLaminateSiding(selectedLaminateSidingType2);
            dateLam2LastUpdated = lp.date;
            lam2LastUpdatedBy = lp.lastUpdatedBy;
            lam2Price = lp.price.ToString();
            lam2StoredPrice = lp.price;
            lam2Dimensions = lp.sidingWidth.ToString() + "x" + lp.sidingHeight.ToString();
        }
        else
        {
            dateLam2LastUpdated = "";
            lam2LastUpdatedBy = "";
            lam2Price = "";
            lam2StoredPrice = 0.0f;
            lam2Dimensions = "";
        }
    }
    public void UpdatePanelCost()
    {
        Console.WriteLine("UpdatePanelCost Called");
        try
        {
            if (Convert.ToSingle(woodPanelPrice) <= 0.01) throw new ArgumentException("Core material should not cost less than $0.01.", woodPanelPrice);
            float wpOverrideCheck = woodPanelStoredPrice - Convert.ToSingle(woodPanelPrice);
            if (DateTime.Today.Subtract(Convert.ToDateTime(dateLastUpdated)).TotalDays > EXPIRATION_DATE && !(wpOverrideCheck < (-0.01) || wpOverrideCheck > 0.01)) throw new ArgumentException("Core material has expired. Lookup a new value.", dateLastUpdated);
            LaminateSiding layupCharge;
            float lp1 = 0f;
            float layup = 0f;
            string[] lam1Dims = lam1Dimensions.Split('x');
            int lam1Height = Convert.ToInt32(lam1Dims[0]);
            int lam1Width = Convert.ToInt32(lam1Dims[1]);
            float lp2 = 0f;
            string[] lam2Dims = lam1Dimensions.Split('x');
            int lam2Height = Convert.ToInt32(lam2Dims[0]);
            int lam2Width = Convert.ToInt32(lam2Dims[1]);
            if (lam1Price != null) {
                lp1 = Convert.ToSingle(lam1Price) / (lam1Height * lam1Width);
                float l1OverrideCheck = lam1StoredPrice - Convert.ToSingle(lam1Price);
                if (DateTime.Today.Subtract(Convert.ToDateTime(dateLam1LastUpdated)).TotalDays > EXPIRATION_DATE && !(l1OverrideCheck < (-0.01) || l1OverrideCheck > 0.01)) throw new ArgumentException("Laminate material 1 has expired. Lookup a new value.", dateLam1LastUpdated);
            }
            if (lam2Price != null) {
                lp2 = Convert.ToSingle(lam2Price) / (lam2Height * lam2Width);
                float l2OverrideCheck = lam2StoredPrice - Convert.ToSingle(lam2Price);
                if (DateTime.Today.Subtract(Convert.ToDateTime(dateLam2LastUpdated)).TotalDays > EXPIRATION_DATE && !(l2OverrideCheck < (-0.01) || l2OverrideCheck > 0.01)) throw new ArgumentException("Laminate material 2 has expired. Lookup a new value.", dateLam2LastUpdated);
            }
            if (isPlywood)
            {
                layupCharge = model.GetLaminateSiding("Layup Charge Plywood");
            }
            else
            {
                layupCharge = model.GetLaminateSiding("Layup Charge Not Plywood");
            }
            if (lp1 > 0 || lp2 > 0) {
                layup =  layupCharge.price / (layupCharge.sidingHeight * layupCharge.sidingWidth);
            } 
            if (Convert.ToInt32(panelWidth) == 0 || Convert.ToInt32(panelHeight) == 0) {
                calculatedPanelCost = "Error: Panel Dimension not correctly set";
                calculatedSQFTPanelCost = "";
            } else {
                float corePriceSQFT = Convert.ToSingle(woodPanelPrice) / (Convert.ToSingle(panelWidth) * Convert.ToSingle(panelHeight));
                float cpcs = corePriceSQFT + lp1 + lp2 + layup + System.Convert.ToSingle(specialFinishPrice);
                float cpc = cpcs * Convert.ToSingle(panelWidth) * Convert.ToSingle(panelHeight);
                calculatedPanelCost = cpc.ToString();
                calculatedSQFTPanelCost = cpcs.ToString();
            }
        } catch (IndexOutOfRangeException e) {
            calculatedPanelCost = "Error: Laminate dimensions did not split correctly. Please check your inputs.";
            calculatedSQFTPanelCost = "";
        }
        catch (Exception e)
        {
            calculatedPanelCost = "Error: " + e.Message;
        }
    }

    public void UpdateRemoveItemNames()
    {
        if (selectedRemoveType == "Wood Panel") removeItemNames = model.GetWoodPanelMaterialTypes();
        else if (selectedRemoveType == "Laminate") removeItemNames = model.GetLaminateSidingTypes();
        else removeItemNames = new string[0];
    }

    public void UpdateRemoveThicknesses()
    {
        if (selectedRemoveItemName != null)
        {
            if (selectedRemoveType == "Wood Panel") removeThicknesses = model.GetWoodPanelThicknesses(selectedRemoveItemName);
        }
    }

    public void UpdateRemoveDimensions()
    {
        if (selectedRemoveType == "Wood Panel" && selectedRemoveThickness != null && selectedRemoveItemName != null)
        {
            removeDimensions = model.GetWoodPanelDimensions(selectedRemoveItemName, selectedRemoveThickness);
        }
    }

    public void UpdateRemoveItemMiscInfo()
    {
        if (selectedRemoveDimension != null && selectedRemoveThickness != null && selectedRemoveThickness != "" && selectedRemoveDimension != "")
        {
            string[] s = selectedRemoveDimension.Split('x');
            if (selectedRemoveType == "Wood Panel" && s.Length == 2 && selectedRemoveItemName != null && selectedRemoveThickness != null)
            {
                WoodPanel wp = model.GetWoodPanel(selectedRemoveItemName, selectedRemoveThickness, s[1], s[0]);
                removeDateLastUpdated = wp.date;
                removeLastUpdatedBy = wp.lastUpdatedBy;
                removePrice = wp.price.ToString();
            }
            else
            {
                removeDateLastUpdated = "";
                removeLastUpdatedBy = "";
                removePrice = "";
            }
        }
    }

    public void UpdateRemoveLaminate()
    {
        if (selectedRemoveItemName != null && selectedRemoveType == "Laminate")
        {
            LaminateSiding ls = model.GetLaminateSiding(selectedRemoveItemName);
            removeDimensions = new string[1];
            removeDimensions[0] = ls.sidingWidth + "x" + ls.sidingHeight;
            selectedRemoveDimension = removeDimensions[0];
            removePrice = ls.price.ToString();
            removeLastUpdatedBy = ls.lastUpdatedBy.ToString();
        }
    }

    public void AddPanelCostItem()
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        if (selectedAddItemType == "Wood Panel")
        {
            if (addItemType == "" || (addItemHeight != "8" && addItemHeight != "12") || (addItemWidth != "4" && addItemWidth != "5") || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else
            {
                addItemType.Trim();
                if (model.AddPanelCostWoodMaterial(addItemType, addItemThickness, addItemWidth, addItemHeight, addItemPrice, date, addItemLastUpdatedBy))
                {
                    addItemStatus = "Entry added to calculator database";
                    woodMaterialTypes = model.GetWoodPanelMaterialTypes();
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        }
        else if (selectedAddItemType == "Laminate")
        {
            if (addItemType == "" || addItemHeight == "" || addItemWidth == "" || addItemPrice == "" || addItemLastUpdatedBy == "") addItemStatus = "Invalid Input. Please check your values.";
            else
            {
                if (model.AddPanelCostLaminateMaterial(addItemType, addItemWidth, addItemHeight, addItemPrice, date, addItemLastUpdatedBy))
                {
                    addItemStatus = "Entry added to calculator database";
                    laminateSidingTypes1 = model.GetLaminateSidingTypes();
                    laminateSidingTypes2 = model.GetLaminateSidingTypes();
                }
                else addItemStatus = "Item could not be added. Please check SQL connection and input values.";
            }
        }
        else
        {
            addItemStatus = "Invalid Type";
        }
    }
    //Buttons with slightly different criteria. 

    public void RemoveSelectedItem()
    {
       try
        {
            string[] s = selectedRemoveDimension.Split('x');
            if (s.Length == 2 && selectedRemoveType == "Wood Panel" && selectedRemoveThickness != null && selectedRemoveItemName != null)
            {
                if (model.RemovePanelCostWoodMaterial(selectedRemoveItemName, selectedRemoveThickness, s[0], s[1]))
                {
                    removeItemStatus = "Entry removed from calculator database";
                    woodMaterialTypes = model.GetWoodPanelMaterialTypes();
                }
                else removeItemStatus = "Item could not be Removed. Please check SQL connection and input values.";
            }
            else if (selectedRemoveType == "Laminate" && selectedRemoveItemName != null)
            {
                if (model.RemovePanelCostLaminateMaterial(selectedRemoveItemName))
                {
                    removeItemStatus = "Entry removed from calculator database";
                    laminateSidingTypes1 = model.GetLaminateSidingTypes();
                    laminateSidingTypes2 = model.GetLaminateSidingTypes();
                }
                else removeItemStatus = "Item could not be removed. Please check SQL connection and input values.";
            } else
            {
                removeItemStatus = "Item could not be removed. Please check SQL connection and input value.";
            }
        } catch (Exception e)
        {
            removeItemStatus = "Error: " + e.Message;
        }
        

    }
    public void RemovePanelCostItem(string selection, string type, string width, string height, string thickness)
    {
        if (selection == "Wood Panel")
        {
            if (model.RemovePanelCostWoodMaterial(type, thickness, width, height))
            {
                removeItemStatus = "Entry removed from calculator database";
                woodMaterialTypes = model.GetWoodPanelMaterialTypes();
            }
            else removeItemStatus = "Item could not be Removed. Please check SQL connection and input values.";

        }
        else if (selection == "Laminate")
        {
            if (model.RemovePanelCostLaminateMaterial(type))
            {
                addItemStatus = "Entry removed from calculator database";
                laminateSidingTypes1 = model.GetLaminateSidingTypes();
                laminateSidingTypes2 = model.GetLaminateSidingTypes();
            }
            else removeItemStatus = "Item could not be removed. Please check SQL connectin and input values.";
        }
        else
        {
            removeItemStatus = "Invalid Type";
        }
    }
}