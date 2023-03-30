using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.viewmodels
{
    public class karyawanvm
    {
        public int id_karyawan { get; set; }
        public Nullable<int> cabang_id { get; set; }

        
        [Remote("kodekar", "validation", HttpMethod = "POST", ErrorMessage = "kode sudah terdaftar.", AdditionalFields = "id_karyawan")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "kode karyawan tidak boleh kurang dari 5 digit")]
        [Required(ErrorMessage = "Required")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "kode karyawan tidak boleh lebih dari 5 digit")]
        public string kode_kar { get; set; }
        [Required(ErrorMessage = "Required")]
        public string nama { get; set; }
        public bool aktif { get; set; }

        public string nama_cabang { get; set; }


        [RegularExpression(@"^(?!0|62|\+62)\d{7,12}\S+$", ErrorMessage = "Nomor tidak valid")]
        //[Remote("notelp", "validation", HttpMethod = "POST", ErrorMessage = "No telepon tidak valid", AdditionalFields = "id_karyawan")]
        //[StringLength(12, MinimumLength = 12, ErrorMessage = "Nomor telepon tidak boleh lebih dari 12 digit")]
        public string no_telp { get; set; }
        //public virtual cabangvm cabang { get; set; }


    }
}