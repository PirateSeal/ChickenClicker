#region Usings

using System.Xml.Linq;

#endregion

namespace ChickenFarmer.Model
{
    public interface IRack
    {
        Henhouse CtxHenhouse { get; set; }
        int Capacity { get; set; }
        int MaxCapacity { get; set; }
        int Lvl { get; set; }
        int UpgrageCost { get; }

        /// <summary>
        ///     Fill method will return remaining food into inventory if too much were given
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        int Fill(int amount);

        void     Upgrade();
        XElement ToXml();
    }
}