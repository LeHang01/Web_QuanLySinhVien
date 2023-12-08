namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Lop
    {
        [Key]
        public int MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public int? SapXep { get; set; }

        public int? MaTruong { get; set; }
        public object ID { get; internal set; }
    }
}
