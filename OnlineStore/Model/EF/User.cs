namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            DonHangs = new HashSet<DonHang>();
            GopY_KH = new HashSet<GopY_KH>();
        }

        [Key]
        public long IdUser { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string PassWord { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public DateTime NgayTao { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY_KH> GopY_KH { get; set; }
        public static bool Compare_HoTen(User u1,User u2)
        {
            return (string.Compare(u1.HoTen, u2.HoTen) >= 0);
        }
        public static bool Compare_UserName(User u1, User u2)
        {
            return (string.Compare(u1.UserName, u2.UserName) >= 0);
        }
        public static bool Compare_GioiTinh(User u1, User u2)
        {
            return (Convert.ToInt32(u1.GioiTinh)<Convert.ToInt32(u2.GioiTinh));
        }
        public static bool Compare_NgaySinh(User u1, User u2)
        {
            int test=DateTime.Compare(u1.NgayTao,u2.NgayTao);
            if (test <= 0) return true;
            return false;
        }
        public static bool Compare_TrangThai(User u1, User u2)
        {
            return (Convert.ToInt32(u1.TrangThai) < Convert.ToInt32(u2.TrangThai));
        }
    }
}
