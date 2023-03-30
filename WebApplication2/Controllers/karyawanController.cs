using System.Data;
using System.Data.Entity;
using DataTables.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.viewmodels;
using System.Net;
using System.Text.RegularExpressions;

namespace WebApplication2.Controllers
{
    public class karyawanController : Controller
    {
        // GET: karyawan
        private karyawanrepo karyawanrepo;
        //private cabangrepo cabangrepo;
        private TestinterviewEntities db = new TestinterviewEntities();

        public int? id { get; private set; }

        public  karyawanController()
        {
            this.karyawanrepo = new karyawanrepo(new TestinterviewEntities());
            //this.cabangrepo = new cabangrepo(new testconncetion());

        }

        public ActionResult Index()
        {
      
            //var liskar = db.karyawans.Where(x => x.aktif == true).OrderBy(x => x.id_karyawan);
            var liskar = karyawanrepo.datakaryawan.Where(x => x.aktif == true).OrderBy(x => x.id_karyawan);
            return View(liskar);
        }

        public ActionResult Create()
        {
            karyawanvm karyawan_ = new karyawanvm();

            return View(karyawan_);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(karyawanvm karyawan)
        {
            Returnvalue ret = new Returnvalue();
            //string a = karyawan.no_telp;
            //string reg = @"[-.,;]";
            //string replace = "";
            //string hasil = Regex.Replace(a, reg, replace);

            //karyawan.no_telp = hasil;

            if (ModelState.IsValid)
            {
                
                ret = karyawanrepo.SaveData(karyawan, "CREATE");
                if (string.IsNullOrEmpty(ret.Error))
                {
                    TempData["Sukses"] = ret.Success;
                }
                else
                {
                    TempData["Error"] = ret.Error;
                }
                return RedirectToAction("Index");
            }
            return View(karyawan);

            //Returnvalue ret = new Returnvalue();
            //if (ModelState.IsValid)
            //{
            //    ret = karyawanrepo.SaveData(karyawan, "CREATE");
            //    if (string.IsNullOrEmpty(ret.Error))
            //    {
            //        TempData["Sukses"] = ret.Success;
            //    }
            //    else
            //    {
            //        TempData["Error"] = ret.Error;
            //    }
            //    return RedirectToAction("Index");
            //}
            //ViewBag.cabang_id = cabangrepo.datacabang.FirstOrDefault(x => x.id == karyawan.cabang_id).nama_cab_;

        }

        private static string GetResult(string result)
        {
            return result;
        }


        //public ActionResult Detail(int? Id)
        //{

        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //karyawanvm kar = karyawanrepo.datakaryawan.FirstOrDefault(x => x.id_karyawan == Id);
        //    //if (kar == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(kar);



        //    //ViewBag.cabang_id = id;
        //    //Session["cabang_id"] = id;


        //    //TempData["id"] = HttpContext.Session.id;

        //}

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            karyawanvm karyawan_ = karyawanrepo.datakaryawan.FirstOrDefault(x => x.id_karyawan == Id);

            return View(karyawan_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(karyawanvm karyawan)
        {

            Returnvalue ret = new Returnvalue();
            if (ModelState.IsValid)
            {
                ret = karyawanrepo.SaveData(karyawan, "EDIT");
                if (string.IsNullOrEmpty(ret.Error))
                {
                    TempData["Sukses"] = ret.Success;
                }
                else
                {
                    TempData["Error"] = ret.Error;
                }
                return RedirectToAction("Index");
            }
            return View(karyawan);
        }


        public ActionResult Delete(int? Id)
        {
            karyawanvm kar1 = karyawanrepo.datakaryawan.FirstOrDefault(x => x.id_karyawan == Id);
            Returnvalue ret = new Returnvalue();
            if (ModelState.IsValid)
            {
                ret = karyawanrepo.SaveData(kar1, "DELETE");
                if (string.IsNullOrEmpty(ret.Error))
                {
                    TempData["Sukses"] = ret.Success;
                }
                else
                {
                    TempData["Error"] = ret.Error;
                }
                return RedirectToAction("Index");
            }
            return View(kar1);
        }



        public ActionResult Getkaryawan([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int cabang_id)
        {
            //IQueryable<SOFinanceHistoryApprovalVM> query;
            IEnumerable<karyawanvm> data;
            var DatatableSearch = requestModel.Search.Value.Trim();
            var Orderby = requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).Data == "" ? "CreatedDate" : requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).Data;
            var AscDesc = requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).SortDirection.ToString() == "Ascendant" ? "asc" : "desc";
            //var cabang_id = Convert.ToInt32(Session["cabang_id"] ?? 0);

            data = karyawanrepo.datakaryawan.Where(x => x.aktif == true && x.cabang_id == cabang_id && (x.nama.Contains(DatatableSearch) || x.kode_kar.Contains(DatatableSearch))).OrderBy(Orderby + " " + AscDesc);
            //data = karyawanrepo.datakaryawan(cabang_id).ls.OrderBy(x => x.OrderMappingRole_Id).Skip(requestModel.Start).Take(requestModel.Length);

            var pagedData = data;
            //var pagedDataExt = new List<karyawanvm>();

            return Json(new DataTablesResponse(requestModel.Draw, pagedData, data.Count(), data.Count()), JsonRequestBehavior.AllowGet);
        }



    }
}