using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.viewmodels
{
    public class transaksivm
    {
        public int id { get; set; }
        public Nullable<int> id_kar { get; set; }
        public Nullable<short> tax_id { get; set; }
        public decimal total_pem { get; set; }
        public decimal price { get; set; }
        public double qty { get; set; }
        public string nama_karya { get; set; }
        public string tax_name { get; set; }
        public virtual karyawan karyawan { get; set; }
        public virtual tax tax { get; set; }

    }
}