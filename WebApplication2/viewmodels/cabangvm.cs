using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication2.viewmodels
{
    public class cabangvm
    {
        public int id { get; set; }
        [Remote("IsAlreadySigned", "validation", HttpMethod = "POST", ErrorMessage = "Cabang sudah ada.", AdditionalFields = "id")]
        public string nama_cab_ { get; set; }
        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [Required(ErrorMessage = "Required")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Maximum 3 characters")]
        public string kode_cab { get; set; }
        public bool aktif { get; set; }

        public bool cabang_id { get; set; }
        //public karyawanvm karyawanm { get; set; }


    }
}