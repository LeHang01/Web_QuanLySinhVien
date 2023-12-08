namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_NamHoc
    {
        [Key]
        public int MaNamHoc { get; set; }

        [StringLength(50)]
        public string TenNamHoc { get; set; }
    }
}
