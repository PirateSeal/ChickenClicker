#region Usings

using System;

#endregion

namespace ChickenFarmer.Model
{
    public class Storage : Building
    {
        public Storage( BuildingCollection ctx, int xCoord, int yCoord ) : base( ctx, xCoord,
            yCoord )
        {
            Ctx = ctx ?? throw new ArgumentNullException( nameof(ctx) );
            XCoord = xCoord;
            YCoord = yCoord;

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

        private BuildingCollection Ctx { get; }
        private int XCoord { get; }
        private int YCoord { get; }

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

        private int TotalEggs { get; }
        public int EggMaxCapacity { get; set; }
        public int EggCapacityLevel { get; set; }

        #endregion
    }
}