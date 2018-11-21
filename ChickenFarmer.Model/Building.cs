#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public abstract class Building
    {
        protected Building( BuildingCollection ctx, Vector posVector)
        {
            CtxCollection = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            PosVector = posVector;
        }

        internal BuildingCollection CtxCollection { get; set; }
        public Vector PosVector { get; internal set; }
    }
}