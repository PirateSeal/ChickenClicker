#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public abstract class Building
    {
        protected Building( BuildingCollection ctx, int xCoord, int yCoord )
        {
            Ctx = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            XCoord = xCoord;
            YCoord = yCoord;
        }

        private BuildingCollection Ctx { get; }
        public int XCoord { get; }
        public int YCoord { get; }
    }
}