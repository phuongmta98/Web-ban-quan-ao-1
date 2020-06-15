using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_WebBanQuanAo.Models
{
    [Serializable]
    public class CartItem
    {
        public MATHANG mATHANG { get; set; }
        public TTSANPHAM tTSANPHAM { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private readonly List<CartItem> lineCollection = new List<CartItem>();
        private double totalMoney;
        public double TotalMoney { get { return totalMoney; } set { totalMoney = value; } }
        public List<CartItem> LineCollection
        {
            get { return lineCollection; }
        }

        public void AddItem(TTSANPHAM sp, int quant)
        {
            CartItem line = lineCollection.Where(x => x.tTSANPHAM.MaMH == sp.MaMH).FirstOrDefault();

            if (line is null)
            {
                lineCollection.Add(new CartItem { tTSANPHAM = sp, Quantity = quant });
            }
            else
            {
                line.Quantity += quant;
                //if (line.Quantity <= 0)
                //{

                //}
            }

            double sum = 0;
            foreach (var i in lineCollection)
            {
                sum += (double) (i.tTSANPHAM.GiaBan * i.Quantity);
            }
            totalMoney = sum;
        }
    }
}