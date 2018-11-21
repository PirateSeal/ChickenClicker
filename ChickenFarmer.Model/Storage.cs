#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public class Storage : Building
    {
        public Storage( BuildingCollection ctx, Vector posVector ) : base( ctx, posVector )
        {
            CtxCollection = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            PosVector = posVector;

            SeedCapacity = ctx.CtxFarm.Options.DefaultSeedCapacity;
            SeedMaxCapacity = ctx.CtxFarm.Options.DefaultSeedMaxCapacity;
            SeedCapacityLevel = ctx.CtxFarm.Options.DefaultStorageLevel;

            VegetableCapacity = ctx.CtxFarm.Options.DefaultVegetableCapacity;
            VegetableMaxCapacity = ctx.CtxFarm.Options.DefaultVegetableMaxCapacity;
            VegetableCapacityLevel = ctx.CtxFarm.Options.DefaultStorageLevel;

            MeatCapacity = ctx.CtxFarm.Options.DefaultMeatCapacity;
            MeatMaxCapacity = ctx.CtxFarm.Options.DefaultMeatMaxCapacity;
            MeatCapacityLevel = ctx.CtxFarm.Options.DefaultStorageLevel;

            TotalEggs = ctx.CtxFarm.Options.DefaultEggCapacity;
            EggMaxCapacity = ctx.CtxFarm.Options.DefaultEggMaxCapacity;
            EggCapacityLevel = ctx.CtxFarm.Options.DefaultStorageLevel;
        }

        #region Seed Properties

        public int SeedCapacity { get; set; }
        public int SeedMaxCapacity { get; set; }
        public int SeedCapacityLevel { get; set; }

        #endregion

        #region Vegetable Properties

        public int VegetableCapacity { get; set; }
        public int VegetableMaxCapacity { get; set; }
        public int VegetableCapacityLevel { get; set; }

        #endregion

        #region Meat Properties

        public int MeatCapacity { get; set; }
        public int MeatMaxCapacity { get; set; }
        public int MeatCapacityLevel { get; set; }

        #endregion

        #region Egg Properties

        public int TotalEggs { get; set; }
        public int EggMaxCapacity { get; set; }
        public int EggCapacityLevel { get; set; }

        #endregion
    }
}