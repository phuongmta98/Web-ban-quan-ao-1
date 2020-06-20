using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CNW_WebBanQuanAo.Models
{
    public class CTHOADON
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaQA { get; set; }

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

        public int SoLuong { get; set; }

        public int? MaMH { get; set; }

        [StringLength(10)]
        public string MaSize { get; set; }

        public int? MaMau { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual MAU MAU { get; set; }

        public virtual SIZE SIZE { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}