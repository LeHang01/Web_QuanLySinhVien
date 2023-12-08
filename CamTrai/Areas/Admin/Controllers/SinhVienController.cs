using CamTrai.Common;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CamTrai.Areas.Admin.Controllers
{
    public class SinhVienController : AllController
    {
        // GET: Admin/SinhVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SinhVienDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var sv = new SinhVienDao().ViewDetail(id);
            return View(sv);
        }

        [HttpPost]


        public ActionResult Create(tb_SinhVien SV)
        {
          

            if (ModelState.IsValid)
            {
                var dao = new SinhVienDao();
                long id = dao.Insert(SV);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Sinh Viên thành công");
                }
            }
            return View(SV);
        }
        [HttpPost]
        public ActionResult Edit(tb_SinhVien SV)
        {


            if (ModelState.IsValid)
            {
                var dao = new SinhVienDao();
                var result = dao.Update(SV);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Sinh Viên thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SinhVienDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}