using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.viewmodels;

namespace WebApplication2.Controllers
{
    public class validationcontroller : Controller
    {
        // GET: validationcontroller
       
        // GET: DataProfil
        private cabangrepo cabangrepo;
        private karyawanrepo karyawanrepo;
        //private customerRepo customerRepo1;
        private TestinterviewEntities db = new TestinterviewEntities();



        public validationcontroller()
    
        {
            this.cabangrepo = new cabangrepo(new TestinterviewEntities());
            this.karyawanrepo = new karyawanrepo(new TestinterviewEntities());
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string nama_cab_,int id)
      {

            return Json(IsUserAvailable(nama_cab_, id));

            //return cabangrepo.datacabang.Any(x => x.nama_cab_ == nama_cabang_.Trim() && x.id != id)
            // ? Json(string.Format("{0} already exists.", nama_cabang_),
            //                           JsonRequestBehavior.AllowGet)
            // : Json(true, JsonRequestBehavior.AllowGet);
        }


        public bool IsUserAvailable(string nama_cab_, int id)
        {
            bool status;
            //status = true;
            if (id == 0)
            {
                IQueryable<cabangvm> query = cabangrepo.datacabang.Where(x => x.nama_cab_ == nama_cab_).OrderByDescending(x => x.id).Take(1);
                if (query.Count() > 0)
                {
                    var aktif_ = cabangrepo.datacabang.OrderByDescending(x => x.id).FirstOrDefault(x => x.nama_cab_ == nama_cab_).aktif;
                    if (aktif_ == true)
                    {
                        status = false;
                    } else {
                        status = true;
                    }   
                }
                else
                {
                    status = true;
                }
             }
            else
            {
                var caba = cabangrepo.datacabang.FirstOrDefault(x => x.id == id).nama_cab_;
                if (caba == nama_cab_)
                {
                    status = true;
                }
                else
                {
                    IQueryable<cabangvm> query = cabangrepo.datacabang.Where(x => x.nama_cab_ == nama_cab_).OrderByDescending(x => x.id).Take(1); if (query.Count() > 0)
                    {
                        var aktif_ = cabangrepo.datacabang.OrderByDescending(x => x.id).FirstOrDefault(x => x.nama_cab_ == nama_cab_).aktif;
                        if (aktif_ == true)
                        {
                            status = false;
                        }
                        else {
                            status = true;
                        }
                    }
                    else
                    {
                        status = true;
                    }
                }
            }

            return status;
        }

        [HttpPost]
        public JsonResult kodekar(string kode_kar, int id_karyawan)
        {
            return Json(iskodekar(kode_kar, id_karyawan));
        }

        public bool iskodekar(string kode_kar, int id_karyawan)
        {
            bool status;
            //status = true;
            if (id_karyawan == 0)
            {
                IQueryable<karyawanvm> query = karyawanrepo.datakaryawan.Where(x => x.kode_kar == kode_kar).OrderByDescending(x => x.id_karyawan).Take(1);
                if (query.Count() > 0)
                {
                    var aktif_ = karyawanrepo.datakaryawan.OrderByDescending(x => x.id_karyawan).FirstOrDefault(x => x.kode_kar == kode_kar).aktif;
                    if (aktif_ == true)
                    {
                        status = false;
                    }
                    else {
                        status = true;
                    }
                }
                else
                {
                    status = true;
                }
            }
            else
            {
                var caba = karyawanrepo.datakaryawan.FirstOrDefault(x => x.id_karyawan == id_karyawan).kode_kar;
                if (caba == kode_kar)
                {
                    status = true;
                }
                else
                {
                    IQueryable<karyawanvm> query = karyawanrepo.datakaryawan.Where(x => x.kode_kar == kode_kar).OrderByDescending(x => x.id_karyawan).Take(1);
                    if (query.Count() > 0)
                    {
                        var aktif_ = karyawanrepo.datakaryawan.OrderByDescending(x => x.id_karyawan).FirstOrDefault(x => x.kode_kar == kode_kar).aktif;
                        if (aktif_ == true)
                        {
                            status = false;
                        }
                        else {
                            status = true;
                        }
                    }
                    else
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        //    //validationmanual no telp 
        //[HttpPost]
        //public JsonResult notelp(string no_telp, int id_karyawan)
        //{
        //    return Json(isnotelp(no_telp, id_karyawan));
        //}

        //public bool isnotelp(string no_telp, int id_karyawan)
        //{
            
        //    bool status;
        //    string notlp = karyawanrepo.datakaryawan.FirstOrDefault(x => x.id_karyawan == id_karyawan).no_telp;
        //    string regex1 = @"^(?!0)\d{7,12}\S+$";
        //    string regex2 = @"^(?!62)\d{7,12}\S+$";
        //    string regex3 = @"^(?!+62)\d{7,12}\S+$";
        //    var hasil1 = Regex.Matches(notlp, regex1);
        //    var hasil2 = Regex.Matches(notlp, regex2);
        //    var hasil3 = Regex.Matches(notlp, regex3);

        //    return notlp;
        //}
        //    //public bool isnotelp(string no_telp, int id_karyawan)

        //    //{
        //    //    bool regex = 




        //    //}


    }
}