namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Truong
    {
        [Key]
        public int MaTruong { get; set; }

        [StringLength(250)]
        public string TenTruong { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Website { get; set; }
    }
}
