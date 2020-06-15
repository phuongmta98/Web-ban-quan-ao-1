using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_WebBanQuanAo.Models
{
    public class CTMATHANG
    {
        public MATHANG mATHANG { get; set; }
        private List<TTSANPHAM> spList = new List<TTSANPHAM>();

        public List<TTSANPHAM> SpList { get { return spList; } set { spList = value; } }

    }
}