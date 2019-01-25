using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChickenFarmer.UI
{
   public class ChickenCollectionUI
    {
        public ChickenCollectionUI(FarmUI farmUi)
        {
            CtxfarmUI = farmUi;
            ChickenList = new List<ChickenUI>();
            //LoadChickens();
        }

        public FarmUI CtxfarmUI { get; }
        public List<ChickenUI> ChickenList { get; set; }

        internal void LoadChickens ()
        {
            this.ChickenList = new List<ChickenUI>();

            int increment = 0;
            for (int i = 0; i < CtxfarmUI.listChicken.Count(); i++)
            {
                ChickenUI chicken = new ChickenUI(CtxfarmUI, CtxfarmUI.listChicken[i], increment);

                ChickenList.Add(chicken);
                increment += 50;

            }

        }

        public void Draw(IRenderTarget target, in RenderStates states)
        {
            foreach (ChickenUI item in ChickenList)
            {
                target.Draw(item);
            }
        }
    }
}

