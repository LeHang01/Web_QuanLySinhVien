namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_HocKy
    {
        [Key]
        public int MaHK { get; set; }

        [StringLength(50)]
        public string TenHK { get; set; }
    }
}
