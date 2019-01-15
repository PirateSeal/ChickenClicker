namespace ChickenFarmer.Model
{
    public interface IInteractible
    {
        InteractionZone EntryZone { get; set; }
        InteractionZone LeaveZone { get; set; }
    }
}