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

    //Public variables set by the user
    public int PanelCost4by8Total;
    public int PanelCost4by8sqft;
    public int PanelCost5x12Total;
    public int PanelCost5x12sqft;
    public string WoodMaterialType = "Burrito";
    public string Side1LaminateType = "";
    public string Side2LaminateType = "";
    public bool IsPlywood;
    public string SpecialFinish = "";
    public int SpecialFinishNum;


    private string test = "";
    public string Test
    {
            get => test;
            set => this.RaiseAndSetIfChanged(ref test, value);
       
    }

    private string connStatus = "";
    public string ConnectionStatus
    {
        get => connStatus;
        set => this.RaiseAndSetIfChanged(ref connStatus, value);
    }

    //private variables set from queries
    private int Wood4by8Cost;
    private int Side14by8Cost;
    private int Side24by8Cost;
    private int LayupCharge4by8;
    private int SpecialFinish4by8Cost;
    
    public PanelCostViewModel() 
    {
        Test = "Burrito";
        model = DBModel.GetInstance();
        if(model.TestDBConn())
        {
            ConnectionStatus = "Up";
        } else
        {
            ConnectionStatus = "False";
        }
    }
   public void UpdatePanelCost()
    {
        Console.WriteLine("UpdatePanelCost Called");
        PanelQuery();
        PanelCost4by8Total = CalculatePanelCost4by8Total();
        PanelCost4by8sqft = CalculatePanelCost4by8sqft();
        PanelCost5x12Total = CalculatePanelCost5by12Total();
        PanelCost5x12sqft = CalculatePanelCost5by12sqft();
    }

    private void PanelQuery()
    {

    }

    private int CalculatePanelCost4by8Total()
    {
        return Wood4by8Cost + Side14by8Cost + Side24by8Cost + LayupCharge4by8 + SpecialFinish4by8Cost;
    }

    private int CalculatePanelCost4by8sqft()
    {
        return PanelCost4by8Total / 42;
    }

    private int CalculatePanelCost5by12Total()
    {
        return 0;
    }

    private int CalculatePanelCost5by12sqft()
    {
        return PanelCost5x12Total / 60;
    }
}