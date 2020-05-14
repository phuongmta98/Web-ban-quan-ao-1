namespace CNW_WebBanQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANH")]
    public partial class ANH
    {
        public int MaMH { get; set; }

        public string UrlAnh { get; set; }

        public int? MaMau { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaAnh { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual MAU MAU { get; set; }
    }
}
