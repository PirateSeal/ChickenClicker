using SFML.Audio;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChickenFarmer.UI
{
    public class ChickenCollectionUI
    {
        public ChickenCollectionUI(FarmUI farmUi)
        {
            CtxfarmUI = farmUi;
            ChickenList = new List<ChickenUI>();
            //LoadChickens();
            MusicHenHouse = new Music("../../../../Data/SoundEffect/ChickenSound.ogg");

        }

        public FarmUI CtxfarmUI { get; }
        public List<ChickenUI> ChickenList { get; set; }
        public Music MusicHenHouse { get; set; }
      
        internal void LoadChickens ()
        {
            this.ChickenList = new List<ChickenUI>();

            int incrementX = 0;
            int incrementY = 0;
            int countChickenSpawn = 0;
            for (int i = 0; i < CtxfarmUI.listChicken.Count(); i++)
            {
                
                ChickenUI chicken = new ChickenUI(CtxfarmUI, CtxfarmUI.listChicken[i], incrementX,incrementY, countChickenSpawn);

                ChickenList.Add(chicken);
                incrementX += 50;
                countChickenSpawn++;

                if(countChickenSpawn > 3)
                {
                    countChickenSpawn = 1;
                    incrementX = 0;
                    incrementY += 50;
                }
            }

        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            foreach (ChickenUI item in ChickenList)
            {
                target.Draw(item);
            }
        }

        public void Update()
        {
            foreach (ChickenUI item in ChickenList)
            {
                item.AnimationLoop();
                item.AnimFrame++;
            }
        }
    }
}

