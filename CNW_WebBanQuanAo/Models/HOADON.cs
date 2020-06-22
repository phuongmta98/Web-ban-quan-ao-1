namespace CNW_WebBanQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            GIAODICH = new HashSet<GIAODICH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hóa Đơn")]
        public int MaHD { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [DisplayName("Ngày Đặt")]
        public DateTime? NgayDat { get; set; }

        public DateTime? NgayGiao { get; set; }

        [StringLength(50)]
        public string NguoiChot { get; set; }

        [StringLength(50)]
        [DisplayName("Trạng Thái")]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string TenKhach { get; set; }

        [StringLength(50)]
        public string DiaChiKhach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAODICH> GIAODICH { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
