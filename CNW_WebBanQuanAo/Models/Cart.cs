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
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();
        public List<CartItem> LineCollection {
            get { return lineCollection; } 
        }

        public void AddItem(MATHANG sp, int quant)
        {
            CartItem line = lineCollection.Where(x => x.mATHANG.MaMH == sp.MaMH).FirstOrDefault();

            if (line is null)
            {
                lineCollection.Add(new CartItem { mATHANG = sp, Quantity = quant });
            }
            else
            {
                line.Quantity += quant;
                //if (line.Quantity <= 0)
                //{

                //}
            }
        }
    }
}