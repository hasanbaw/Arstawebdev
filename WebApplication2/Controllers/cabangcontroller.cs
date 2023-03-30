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

namespace WebApplication2.Controllers
{
    public class cabangcontroller : Controller
    {

          // GET: DataProfil
        private cabangrepo cabangrepo;
        private karyawanrepo karyawanrepo;
        //private customerRepo customerRepo1;
        private TestinterviewEntities db = new TestinterviewEntities();

        public int? id { get; private set; }

        //private object cus;

        public cabangcontroller()
        {
            this.cabangrepo = new cabangrepo(new TestinterviewEntities());
            this.karyawanrepo = new karyawanrepo(new TestinterviewEntities());
        }


        // GET: cabangcontroller

        //[Authorize]
        //[CustomAuthorize("datacabangs")]
        public ActionResult Index()
        {

            //var listcabang = cabangrepo.datacabang.Where(x => x.aktif == true).OrderBy(x => x.id);
            return View();
        }


        //[Authorize]
        [HttpPost]
        public ActionResult Listcabang([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            //var username = User.Identity.Name;
            //var Ho = AccountRepo.GetHo(CabangId);
            IQueryable<cabangvm> query;
            IEnumerable<cabangvm> data;
            var DatatableSearch = requestModel.Search.Value.Trim();
            var Orderby = requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).Data == "" ? "Id" : requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).Data;
            var AscDesc = requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).SortDirection.ToString() == "Ascendant" ? "asc" : "desc";

            var cariby = "Default";
            var searchby = "";
            if (requestModel.Search.Value.Split('#').Count() > 1)
            {
                cariby = requestModel.Search.Value.Split('#')[0];
                searchby = requestModel.Search.Value.Split('#')[1];
            }

            if (cariby == "Default")
            {

                query = cabangrepo.datacabang.Where(x => x.aktif == true && (x.nama_cab_.Contains(searchby) || (x.kode_cab.Contains(searchby)))).OrderBy(Orderby + " " + AscDesc);

            }
            else
            {
                query = cabangrepo.datacabang.Where(x => x.aktif == false && (x.nama_cab_.Contains(searchby) || (x.kode_cab.Contains(searchby)))).OrderBy(Orderby + " " + AscDesc);

            }
          
            data = query;
            var pagedData = data.Skip(requestModel.Start).Take(requestModel.Length);
            return Json(new DataTablesResponse(requestModel.Draw, pagedData, data.Count(), data.Count()), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            cabangvm cabang_ = new cabangvm();
            return View(cabang_);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cabangvm cabang)
        {

            Returnvalue ret = new Returnvalue();
            if (ModelState.IsValid)
            {
                ret = cabangrepo.SaveData(cabang, "CREATE");
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

            return View(cabang);
        }

        //private static cabangrepo GetCabang(cabangvm cabang)
        //{
        //    return cabang;
        //}

        [HttpGet]
        public ActionResult Detail(int? Id)
        {
            cabangvm cabang_x = cabangrepo.datacabang.FirstOrDefault(x => x.id == Id);

            //ViewBag.cabang_id = id;
            //Session["cabang_id"] = id;

         
            //TempData["id"] = HttpContext.Session.id;
            return View(cabang_x);
        }




        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            cabangvm cabang_ = cabangrepo.datacabang.FirstOrDefault(x => x.id == Id);
           
            return View(cabang_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cabangvm cabang)
        {

            Returnvalue ret = new Returnvalue();
            if (ModelState.IsValid)
            {
                ret = cabangrepo.SaveData(cabang, "EDIT");
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
            return View(cabang);
        }


        public ActionResult Delete(int? Id)
        {
            cabangvm cabang1 = cabangrepo.datacabang.FirstOrDefault(x => x.id == Id);
            Returnvalue ret = new Returnvalue();
            if (ModelState.IsValid)
            {
                ret = cabangrepo.SaveData(cabang1, "DELETE");
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
            return View(cabang1);
        }

        //Digunakan Di Menu AdjusmentUnit, SO PDI, ARBBN
        [HttpPost]
        public ActionResult liscabang([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {


            //var kodeid = customerRepo1.dataCustomer.FirstOrDefault(x => x.id == id).id;
            IEnumerable<cabangvm> data;



            var DatatableSearch = requestModel.Search.Value;
            var Orderby = requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).Data == "" ? "Id" : requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).Data;
            var AscDesc = requestModel.Columns.FirstOrDefault(x => x.IsOrdered == true).SortDirection.ToString() == "Ascendant" ? "asc" : "desc";

            data = cabangrepo.datacabang.Where(x => x.aktif == true && (x.nama_cab_.Contains(DatatableSearch) || x.kode_cab.Contains(DatatableSearch))).OrderBy(Orderby + " " + AscDesc);


            var pagedData = data.Skip(requestModel.Start).Take(requestModel.Length);
            return Json(new DataTablesResponse(requestModel.Draw, pagedData, data.Count(), data.Count()), JsonRequestBehavior.AllowGet);



            //data = kodeposrepo.datakodepos.Where(x => x.aktif == true && (x.Kodepos_.Contains(DatatableSearch) || x.kota.Contains(DatatableSearch))).OrderBy(Orderby + " " + AscDesc);
        }


       

    }
}