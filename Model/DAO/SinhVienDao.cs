using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.DAO
{
    public class SinhVienDao
    {
        CamTraiDbContext db = null;
        public SinhVienDao()
        {
            db = new CamTraiDbContext();
        }
        public long Insert(tb_SinhVien SV)
        {
            db.tb_SinhVien.Add(SV);
            db.SaveChanges();
            return SV.ID;
        }
        public bool Update(tb_SinhVien entity)
        {
            try
            {
                var sv = db.tb_SinhVien.Find(entity.ID);
                sv.Ho = entity.Ho;
                sv.Ten = entity.Ten;
                sv.Image = entity.Image;
                sv.Mssv = entity.Mssv;
                sv.MaLop = entity.MaLop;
                sv.NgaySinh = entity.NgaySinh;
                sv.GioiTinh = entity.GioiTinh;
                sv.DiaChi = entity.DiaChi;  
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }

        }
        public tb_SinhVien ViewDetail(int id)
        {
            return db.tb_SinhVien.Find(id);
        }

        public IEnumerable<tb_SinhVien> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<tb_SinhVien> model = db.tb_SinhVien;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ho.Contains(searchString) || x.Ten.Contains(searchString));
            }

            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var Sv = db.tb_SinhVien.Find(id);
                db.tb_SinhVien.Remove(Sv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public tb_SinhVien GetById(string userName)
        {
            return db.tb_SinhVien.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.tb_SinhVien.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == passWord)
                    return 1;
                else
                    return -2;
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.tb_SinhVien.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.tb_SinhVien.Count(x => x.Email == email) > 0;
        }
        public int InsertForFacebook(tb_SinhVien entity)
        {            
                db.tb_SinhVien.Add(entity);
                db.SaveChanges();
                return entity.ID;
        }
        public List<string> ListName(string keyword)
        {
            return db.tb_SinhVien.Where(x => x.UserName.Contains(keyword)).Select(x => x.UserName).ToList();
        }
        public List<tb_SinhVien> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.tb_SinhVien.Where(x => x.Ten == keyword).Count();
            var model = (from a in db.tb_SinhVien
                         join b in db.tb_SinhVien
                         on a.ID equals b.ID
                         where a.UserName.Contains(keyword)
                         select new
                         {
                             ho = b.Ho,
                             ten = b.Ten,
                             username = b.UserName ,                        
                             gioitinh = b.GioiTinh,                             
                             mssv = a.Mssv,
                             diachi = a.DiaChi,
                             ngaysinh = a.NgaySinh,
                             sdt = a.Phone,
                             email = a.Email,
                             lop = a.MaLop
                         }).AsEnumerable().Select(x => new tb_SinhVien()
                         {
                             Ho = x.ho,
                             Ten = x.ten,                         
                             UserName = x.username,
                             GioiTinh = x.gioitinh,
                             Mssv = x.mssv,
                             DiaChi = x.diachi,
                             NgaySinh = x.ngaysinh,
                             Phone = x.sdt,
                             Email = x.email,
                             MaLop = x.lop
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
