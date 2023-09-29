using Avalonia;
using PhoenixCalculator_Avallon.Models;
using ReactiveUI;
using System;

namespace PhoenixCalculator_Avallon.ViewModels;

public class PanelCostViewModel : ReactiveObject
{
    //
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
            UpdateRemoveThicknesses();
        }
    }
    private string[] _removeThicknesses;
    public string[] removeThicknesses
    {
        get { return _removeThicknesses; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeThicknesses, value);
        }
    }
    private string _selectedRemoveThickness;
    public string selectedRemoveThickness
    {
        get { return _selectedRemoveThickness; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedRemoveThickness, value);
            UpdateRemoveDimensions();
        }
    }
    private string[] _removeDimensions;
    public string[] removeDimensions
    {
        get { return _removeDimensions; }
        set
        {
            this.RaiseAndSetIfChanged(ref _removeDimensions, value);
        }
    }
    private string _selectedRemoveDimension;
    public string selectedRemoveDimension
    {
        get { return _selectedRemoveDimension; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedRemoveDimension, value);
            UpdateRemoveItemMiscInfo();
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
        }
        else
        {
            dateLastUpdated = "";
            lastUpdatedBy = "";
            
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
            lam1Dimensions = lp.sidingWidth.ToString() + "x" + lp.sidingHeight.ToString();
        }
        else
        {
            dateLam1LastUpdated = "";
            lam1LastUpdatedBy = "";
            lam1Price = "";
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
            lam2Dimensions = lp.sidingWidth.ToString() + "x" + lp.sidingHeight.ToString();
        }
        else
        {
            dateLam2LastUpdated = "";
            lam2LastUpdatedBy = "";
            lam2Price = "";
            lam2Dimensions = "";
        }
    }
    public void UpdatePanelCost()
    {
        Console.WriteLine("UpdatePanelCost Called");
        /* WoodPanel wp = model.GetWoodPanel(selectedWoodMaterialType, selectedThickness, panelHeight, panelWidth);
         if (wp.price != Convert.ToSingle(woodPanelPrice))
         {
             wp.price = Convert.ToSingle(woodPanelPrice);

         }
         LaminateSiding lp1 = model.GetLaminateSiding(selectedLaminateSidingType1);
         if (lp1.price != Convert.ToSingle(lam1Price) || lp1.sidingWidth + "x" + lp1.sidingHeight != lam1Dimensions)
         {
             lp1.price = Convert.ToSingle(lam1Price);
             int num1, num2;
             string[] str = lam1Dimensions.Split('x');
             if (str.Length == 2 && int.TryParse(str[0], out num1) && int.TryParse(str[1], out num2))
             {
                 lp1.sidingWidth = num1;
                 lp1.sidingHeight = num2;
             } else
             {
                 lp1.sidingHeight = 1;
                 lp1.sidingWidth = 1;
             }

         }
         LaminateSiding lp2 = model.GetLaminateSiding(selectedLaminateSidingType2);
         if (lp2.price != Convert.ToSingle(lam1Price) || lp2.sidingWidth + "x" + lp2.sidingHeight != lam2Dimensions)
         {
             lp2.price = Convert.ToSingle(lam1Price);
             int num1, num2;
             string[] str = lam2Dimensions.Split('x');
             if (str.Length == 2 && int.TryParse(str[0], out num1) && int.TryParse(str[1], out num2))
             {
                 lp2.sidingWidth = num1;
                 lp2.sidingHeight = num2;
             }
             else
             {
                 lp2.sidingHeight = 1;
                 lp2.sidingWidth = 1;
             }

         } 


         LaminateSiding layupCharge;
         if (selectedLaminateSidingType1 == "None" && selectedLaminateSidingType2 == "None")
         {
             layupCharge = new LaminateSiding();
             layupCharge.price = 0f;
         }
         else if (isPlywood)
         {
             layupCharge = model.GetLaminateSiding("Layup Charge Plywood");
         }
         else
         {
             layupCharge = model.GetLaminateSiding("Layup Charge Not Plywood");
         }

         if (wp.price > 900)
         {
             calculatedPanelCost = "Error, this panel material does not exist in this size.";
         }
         else if (lp1.price > 900)
         {
             calculatedPanelCost = "Error, Side 1 Laminate does not exist for this panel size.";
         }
         else if (lp2.price > 900)
         {
             calculatedPanelCost = "Error, Side 2 Laminate does not exist for this panel size.";
         }
         else if (layupCharge.price > 900)
         {
             calculatedPanelCost = "Error, Layup Charge out of range.";
         }
         else
         {
             //Adjusts prices to square foot. If the dimensions are 1x1, then it's already in square feet and remains the same.
             float lamPrice1 = lp1.price / ((float)lp1.sidingWidth * (float)lp1.sidingHeight);
             float lamPrice2 = lp2.price / (lp2.sidingWidth * lp2.sidingHeight);
             float layup = layupCharge.price / (layupCharge.sidingWidth * layupCharge.sidingHeight);
             float corePriceSQFT = wp.price / (wp.panelWidth * wp.panelHeight);
             float cpc = wp.price + ((lamPrice1 + lamPrice2 + System.Convert.ToSingle(specialFinishPrice) + layup) * wp.panelHeight * wp.panelWidth);
             float cpcs = corePriceSQFT + lamPrice1 + lamPrice2 + layup + System.Convert.ToSingle(specialFinishPrice);
             //Final cost is per square foot.
             calculatedPanelCost = String.Format("{0:N2}", cpc);
             calculatedSQFTPanelCost = String.Format("{0:N2}", cpcs);
         } */
        try
        {
            LaminateSiding layupCharge;
            float lp1 = 0;
            float lp2 = 0;
            string[] lam1Dims = lam1Dimensions.Split('x');
            int lam1Height = Convert.ToInt32(lam1Dims[0]);
            int lam1Width = Convert.ToInt32(lam1Dims[1]);
            string[] lam2Dims = lam1Dimensions.Split('x');
            int lam2Height = Convert.ToInt32(lam2Dims[0]);
            int lam2Width = Convert.ToInt32(lam2Dims[1]);
            if (lam1Price != null) lp1 = Convert.ToSingle(lam1Price) / (lam1Height * lam1Width);
            if (lam2Price != null) lp2 = Convert.ToSingle(lam2Price) / (lam2Height * lam2Width);

            if (lp1 > 0 || lp2 > 0)
            {
                layupCharge = new LaminateSiding();
                layupCharge.price = 0f;
            }
            else if (isPlywood)
            {
                layupCharge = model.GetLaminateSiding("Layup Charge Plywood");
            }
            else
            {
                layupCharge = model.GetLaminateSiding("Layup Charge Not Plywood");
            }
            float layup = layupCharge.price / (layupCharge.sidingWidth * layupCharge.sidingHeight);
            float corePriceSQFT = Convert.ToSingle(woodPanelPrice) / (Convert.ToSingle(panelWidth) * Convert.ToSingle(panelHeight));
            float cpc = (corePriceSQFT + lp1 + lp2 + System.Convert.ToSingle(specialFinishPrice)) * Convert.ToSingle(panelWidth) * Convert.ToSingle(panelHeight) + layup;
            float cpcs = corePriceSQFT + lp1 + lp2 + layup + System.Convert.ToSingle(specialFinishPrice);

            calculatedPanelCost = cpc.ToString();
            calculatedSQFTPanelCost = cpcs.ToString();
        } catch (Exception e)
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
            removeThicknesses = model.GetWoodPanelThicknesses(selectedRemoveItemName);
        }
    }

    public void UpdateRemoveDimensions()
    {
        if (selectedThickness != null && selectedRemoveItemName != null)
        {
            removeDimensions = model.GetWoodPanelDimensions(selectedRemoveItemName, selectedRemoveThickness);
        }
    }

    public void UpdateRemoveItemMiscInfo()
    {
        string[] s = selectedRemoveDimension.Split('x');
        if (selectedRemoveType == "Wood Panel" && s.Length == 2 && selectedRemoveItemName != null && selectedRemoveThickness != null)
        {
            WoodPanel wp = model.GetWoodPanel(selectedRemoveItemName, selectedRemoveThickness, s[1], s[0]);
            removeDateLastUpdated = wp.date;
            removeLastUpdatedBy = wp.lastUpdatedBy;
            removePrice = wp.price.ToString();
        }
        else if (selectedRemoveType == "Laminate" && selectedRemoveItemName != null)
        {
            LaminateSiding ls = model.GetLaminateSiding(selectedRemoveItemName);
            removeDateLastUpdated = ls.date;
            removeLastUpdatedBy = ls.lastUpdatedBy;
            removePrice = ls.price.ToString();
        }
        else
        {
            removeDateLastUpdated = "";
            removeLastUpdatedBy = "";
            removePrice = "";
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
        string[] s = selectedRemoveDimension.Split('x');


        if (s.Length == 2 && selectedRemoveType == "Wood Panel" && selectedRemoveThickness != null && selectedRemoveItemName != null)
        {
            if (model.RemovePanelCostWoodMaterial(selectedRemoveItemName, selectedRemoveThickness, s[0], s[1]))
            {
                removeItemStatus = "Entry removed from calculator database";
                woodMaterialTypes = model.GetWoodPanelMaterialTypes();
            }
            else removeItemStatus = "Item could not be Removed. Please check SQL connection and input values.";
        } else if (selectedRemoveType == "Laminate" && selectedRemoveItemName != null)
        {
            if (model.RemovePanelCostLaminateMaterial(selectedRemoveItemName))
            {
                addItemStatus = "Entry removed from calculator database";
                laminateSidingTypes1 = model.GetLaminateSidingTypes();
                laminateSidingTypes2 = model.GetLaminateSidingTypes();
            }
            else removeItemStatus = "Item could not be removed. Please check SQL connectin and input values.";
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