namespace ChickenFarmer.Model
{
    internal interface IInteractible
    {
        InteractionZone EntryZone { get; set; }
        InteractionZone LeaveZone { get; set; }
        bool CheckIfInside(InteractionZone interactionZone);
    }
}