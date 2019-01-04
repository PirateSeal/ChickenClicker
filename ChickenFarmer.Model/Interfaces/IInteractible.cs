namespace ChickenFarmer.Model
{
    internal interface IInteractible
    {
        InteractionZone InteractionZone { get; set; }
        bool CheckIfInside(InteractionZone interactionZone);
    }
}