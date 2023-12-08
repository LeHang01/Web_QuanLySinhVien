using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class CamTraiDbContext : DbContext
    {
        public CamTraiDbContext()
            : base("name=CamTraiDbContext")
        {
        }

        public virtual DbSet<tb_HocKy> tb_HocKy { get; set; }
        public virtual DbSet<tb_Lop> tb_Lop { get; set; }
        public virtual DbSet<tb_NamHoc> tb_NamHoc { get; set; }
        public virtual DbSet<tb_SinhVien> tb_SinhVien { get; set; }
        public virtual DbSet<tb_Truong> tb_Truong { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();
        }

       
    }
}
