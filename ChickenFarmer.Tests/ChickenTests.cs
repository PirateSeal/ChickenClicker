#region Usings

using ChickenFarmer.Model;
using NUnit.Framework;

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
            farm.Buildings.Build<StorageEgg>(1, 3);
            farm.Buildings.Build<Builder>(1, 4);
            farm.Buildings.Build<ChickenStore>(1, 5);

            farm.Buildings.FindBuilding<Builder>(1, 4).
                BuyBuilding<Henhouse>(1, 2);
            farm.Buildings.FindBuilding<ChickenStore>(1, 5).
                BuyChicken(1, Chicken.Breed.Tier1);
            for (int i = 0; i < 2000; i++) farm.Update();

            Assert.That(farm.Buildings.ChickenCount(), Is.EqualTo(0));
        }

        [Test]
        public void Feed_All_Chicken_In_One_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageEgg>(1, 1);
            farm.Buildings.Build<ChickenStore>(1, 2);
            farm.Buildings.Build<StorageSeed>(1, 3);
            farm.Buildings.Build<Henhouse>(1, 4);

            ChickenStore store = farm.Buildings.FindBuilding<ChickenStore>(1, 2);
            store.BuyFood<StorageSeed>(500);
            store.BuyChicken(1, Chicken.Breed.Tier1);
            for (int i = 0; i < 850; i++)
            {
                farm.Update();
            }
            Assert.That(farm.Buildings.FindBuilding<Henhouse>(1, 4).CountDyingChickens, Is.EqualTo(1));

            farm.Buildings.FindBuilding<Henhouse>(1, 4).
                FeedAllChicken();
            Assert.That(farm.Buildings.FindBuilding<Henhouse>(1, 4).CountDyingChickens, Is.EqualTo(0));
            foreach (Chicken chicken in farm.Buildings.FindBuilding<Henhouse>(1, 4).Chikens)
            {
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            }
        }

        [Test]
        public void Feed_All_Dying_Chicken_In_One_Henhouse()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageEgg>(1, 1);
            farm.Buildings.Build<ChickenStore>(1, 2);
            farm.Buildings.Build<StorageSeed>(1, 3);
            farm.Buildings.Build<Henhouse>(1, 4);

            ChickenStore store = farm.Buildings.FindBuilding<ChickenStore>(1, 2);
            store.BuyFood<StorageSeed>(500);
            store.BuyChicken(1, Chicken.Breed.Tier1);
            for (int i = 0; i < 850; i++)
            {
                farm.Update();
            }
            Assert.That(farm.Buildings.FindBuilding<Henhouse>(1, 4).CountDyingChickens, Is.EqualTo(1));

            farm.Buildings.FindBuilding<Henhouse>(1, 4).
                FeedAllDyingChicken();
            Assert.That(farm.Buildings.FindBuilding<Henhouse>(1, 4).CountDyingChickens, Is.EqualTo(0));
            foreach (Chicken chicken in farm.Buildings.FindBuilding<Henhouse>(1, 4).Chikens)
            {
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            }
        }

        [Test]
        public void Chicken_Peck()
        {
            Farm farm = new Farm { Money = 5000 };
            farm.Buildings.Build<StorageEgg>(1, 1);
            farm.Buildings.Build<StorageSeed>(1, 2);
            farm.Buildings.Build<Builder>(1, 3);
            farm.Buildings.Build<ChickenStore>(1, 4);

            farm.Buildings.FindBuilding<Builder>(1, 3).BuyBuilding<Henhouse>(1, 5);
            farm.Buildings.FindBuilding<ChickenStore>(1, 4).BuyFood<StorageSeed>(500);
            farm.Buildings.FindBuilding<Henhouse>(1, 5).FillRack<RackSeed>(500);
            farm.Update();

            foreach (Chicken chicken in farm.Buildings.FindBuilding<Henhouse>(1, 5).Chikens)
            {
                Assert.That(chicken.Hunger, Is.EqualTo(100f));
            }
            Assert.That(farm.Buildings.FindBuilding<Henhouse>(1, 5).Racks.Find(rack => rack is RackSeed).Capacity,Is.LessThan(500));
        }
    }
}