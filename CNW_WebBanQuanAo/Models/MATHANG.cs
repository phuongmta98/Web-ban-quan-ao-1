namespace CNW_WebBanQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATHANG")]
    public partial class MATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATHANG()
        {
            ANH = new HashSet<ANH>();
            SANPHAM = new HashSet<SANPHAM>();
        }

        [Key]
        public int MaMH { get; set; }

        [StringLength(50)]
        public string TenMH { get; set; }

        public string UrlAnh { get; set; }

        public string KieuDang { get; set; }

        public string ChatLieu { get; set; }

        public int? MaNSX { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANH> ANH { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }

        public virtual NHASANXUAT NHASANXUAT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAM { get; set; }
    }
}
