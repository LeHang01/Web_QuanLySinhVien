namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SinhVien
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name ="Họ")]
        public string Ho { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [StringLength(50)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [StringLength(20)]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        [Display(Name = "MSSV")]
        public string Mssv { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Display(Name = "SĐT")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Lớp")]
        public string MaLop { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        public bool? Status { get; set; } 
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
