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
        public List<ChickenUI> ChickenList { get; }

        internal void LoadChickens ()
        {

            for (int i = 0; i < CtxfarmUI.listChicken.Count(); i++)
            {
                ChickenUI chicken = new ChickenUI(CtxfarmUI, CtxfarmUI.listChicken[i]);

                ChickenList.Add(chicken);

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

