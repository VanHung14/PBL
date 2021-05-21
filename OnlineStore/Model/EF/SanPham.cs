namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public long MaSach { get; set; }

        [StringLength(10)]
        public string MaTacGia { get; set; }

        [StringLength(10)]
        public string MaLoaiSach { get; set; }

        public string TenSach { get; set; }

        public string NoiDung { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public int? DonGia { get; set; }

        public int? SoLuong { get; set; }

        public DateTime NgayTao { get; set; }

        public bool TrangThai { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual TacGia TacGia { get; set; }

        public static bool Compare_MaSach(SanPham u1, SanPham u2)
        {
            return (u1.MaSach>= u2.MaSach);
        }
        public static bool Compare_MaTG(SanPham u1, SanPham u2)
        {
            return (string.Compare(u1.MaTacGia, u2.MaTacGia) >= 0);
        }
        public static bool Compare_MaLS(SanPham u1, SanPham u2)
        {
            return (string.Compare(u1.MaLoaiSach, u2.MaLoaiSach) >= 0);
        }
        public static bool Compare_TenSach(SanPham u1, SanPham u2)
        {
            return (string.Compare(u1.TenSach, u2.TenSach) >= 0);
        }
        public static bool Compare_DonGia(SanPham u1, SanPham u2)
        {
            return (u1.DonGia>= u2.DonGia);
        }
        public static bool Compare_SoLuong(SanPham u1, SanPham u2)
        {
            return (u1.SoLuong >= u2.SoLuong);
        }
        public static bool Compare_NgayTao(SanPham u1, SanPham u2)
        {
            int test = DateTime.Compare(u1.NgayTao, u2.NgayTao);
            if (test <= 0) return true;
            return false;
        }
        public static bool Compare_TrangThai(SanPham u1, SanPham u2)
        {
            return (Convert.ToInt32(u1.TrangThai) < Convert.ToInt32(u2.TrangThai));
        }
    }
}
