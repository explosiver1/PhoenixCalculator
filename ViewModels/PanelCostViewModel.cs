using Avalonia.Interactivity;
using System.Linq;

namespace PhoenixCalculator_Avallon.ViewModels;

public class PanelCostViewModel : ViewModelBase
{
    //Declarations
    //Public variables set by the user
    public int PanelCost4by8Total;
    public int PanelCost4by8sqft;
    public int PanelCost5x12Total;
    public int PanelCost5x12sqft;
    public string WoodMaterialType = "";
    public string Side1LaminateType = "";
    public string Side2LaminateType = "";
    public bool IsPlywood;
    public string SpecialFinish = "";
    public int SpecialFinishNum;

    //private variables set from queries
    private int Wood4by8Cost;
    private int Side14by8Cost;
    private int Side24by8Cost;
    private int LayupCharge4by8;
    private int SpecialFinish4by8Cost;

    public void UpdatePanelCost()
    {
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