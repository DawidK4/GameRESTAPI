namespace Kolos2.ResponseModels;

public class GetCharacterWithBackpackSlotsModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }
    public int money { get; set; }
    public IEnumerable<GetBackpackSlotsModel> backpackSlots { get; set; }
    public IEnumerable<GetTitleModel> titles { get; set; }
}