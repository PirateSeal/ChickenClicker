#region Usings

using ChickenFarmer.Model;
using NUnit.Framework;
using System.Linq;

#endregion

namespace ChickenFarmer.Tests
{
    [TestFixture]
    internal class ChickenTests
    {
        [Test]
        public void Chicken_Starve_To_Death()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageSeed>(1, 1);
            farm.Buildings.Build<StorageEgg>(1, 3);
            farm.Buildings.Build<ChickenStore>(1, 5);
            farm.Buildings.Build<Henhouse>(1, 4);

            farm.Buildings.FindBuilding<ChickenStore>(1, 5).
                BuyChicken(1, Chicken.Breed.Tier1);
            for (int i = 0; i < 2000; i++)
            {
                farm.Update();
            }

            Assert.That(farm.Buildings.ChickenCount(), Is.EqualTo(0));
        }

        [Test]
        public void ChickenPeck()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageSeed>(1, 1);
            farm.Buildings.Build<StorageEgg>(1, 10);
            farm.Buildings.Build<ChickenStore>(1, 2);
            farm.Buildings.Build<Henhouse>(1, 3);

            farm.Buildings.FindBuilding<ChickenStore>(1, 2).
                BuyChicken(1, Chicken.Breed.Tier1);
            farm.Buildings.FindBuilding<ChickenStore>(1, 2).
                BuyFood<StorageSeed>(500);
            farm.Buildings.FindBuilding<Henhouse>(1, 3).
                FillRack<RackSeed>(500);
            farm.Update();

            foreach (Chicken chicken in farm.Buildings.FindBuilding<Henhouse>(1, 3).
                Chickens)
            {
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            }
        }

        [Test]
        public void Create_Chicken()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<Henhouse>(1, 1);
            farm.Buildings.Build<ChickenStore>(1, 2);
            farm.Buildings.FindBuilding<ChickenStore>(1, 2).
                BuyChicken(5, Chicken.Breed.Tier1);

            Assert.That(farm.Buildings.ChickenCount(), Is.EqualTo(5));
            Assert.That(farm.Money, Is.EqualTo(5000 - FarmOptions.DefaultChickenCost[0] * 5));
        }

        [Test]
        public void Feed_All_Chicken_In_One_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageSeed>(1, 1);
            farm.Buildings.Build<StorageEgg>(1, 2);
            farm.Buildings.Build<Henhouse>(1, 3);
            farm.Buildings.Build<ChickenStore>(1, 4);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 3);

            farm.Buildings.FindBuilding<ChickenStore>(1, 4).
                BuyFood<StorageSeed>(500);
            farm.Buildings.FindBuilding<ChickenStore>(1, 4).
                BuyChicken(5, Chicken.Breed.Tier1);
            foreach ( Chicken houseChicken in house.Chickens )
            {
                houseChicken.Hunger = 23;
            }

            house.FeedAllChicken();

            foreach (Chicken chicken in house.Chickens)
            {
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            }

            Assert.That(farm.Buildings.FindStorage<StorageSeed>().
                Capacity, Is.Not.EqualTo(500));
        }

        [Test]
        public void Feed_All_Dying_Chicken_In_One_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageSeed>(1, 1);
            farm.Buildings.Build<StorageEgg>(1, 3);
            farm.Buildings.Build<Henhouse>(1, 2);
            farm.Buildings.Build<ChickenStore>(1, 4);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 2);

            farm.Buildings.FindBuilding<ChickenStore>(1, 4).
                BuyFood<StorageSeed>(500);
            farm.Buildings.FindBuilding<ChickenStore>(1, 4).
                BuyChicken(1, Chicken.Breed.Tier1);
            foreach ( Chicken houseChicken in house.Chickens )
            {
                houseChicken.Hunger = 23;
            }

            house.FeedAllDyingChicken();

            foreach (Chicken chicken in house.Chickens)
            {
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            }

            Assert.That(house.DyingChickens.Count(), Is.EqualTo(0));
            Assert.That(farm.Buildings.FindStorage<StorageSeed>().
                Capacity, Is.Not.EqualTo(500));
        }

        [Test]
        public void PredateChicken()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageEgg>(1, 3);
            farm.Buildings.Build<Henhouse>(1, 2);
            farm.Buildings.Build<ChickenStore>(1, 4);
            Henhouse house = farm.Buildings.FindBuilding<Henhouse>(1, 2);

            farm.Buildings.FindBuilding<ChickenStore>(1, 4).
                BuyChicken(1, Chicken.Breed.Tier1);
            house.Chickens.First().
                PredateChance = 1;

            for (int i = 0; i < 100; i++)
            {
                farm.Update();
            }

            Assert.That(farm.Buildings.ChickenCount(), Is.EqualTo(0));
        }
    }
}