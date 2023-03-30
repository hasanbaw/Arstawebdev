using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Controllers;
using WebApplication2.Models;
using WebApplication2.viewmodels;

namespace WebApplication2.Repository
{
    public class transaksirepository
    {
        private TestinterviewEntities context;
        string Con;
        public transaksirepository(TestinterviewEntities context)
        {
            this.context = context;
            Con = context.Database.Connection.ConnectionString;
        }

        public IQueryable<transaksivm> transaksis_
        {
            get
            {
                return context.transaksis.Select(x => new transaksivm
                {
                    nama_karya = x.karyawan.nama,
                    tax_name = x.tax.nama, 
                    id_kar = x.id_kar,
                    tax_id = x.tax_id,
                    price = x.price,
                    total_pem = x.total_pem,
                    qty = x.qty,
                    id = x.id
                });

            }
        }

        //public IQueryable<tax> tax_
        //{
        //    get
        //    {
        //        return context.taxes.Select(x => new tax
        //        {
        //           nama = x.nama,
        //           multiply = x.multiply
        //        });

        //    }
        //}

        public Returnvalue SaveData(transaksivm _transaksi/*, string action*/)
        {
            Returnvalue ret = new Returnvalue();
            SqlDataReader dr = null;
            SqlConnection con = new SqlConnection(Con);
            try
            {
                con.Open();
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Save_transaksi"; // SP Name
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", _transaksi.id);
                    com.Parameters.AddWithValue("@tax_id", _transaksi.tax_id);
                    com.Parameters.AddWithValue("@id_kar" ,_transaksi.id_kar);
                    com.Parameters.AddWithValue("@total_pem", _transaksi.total_pem);
                    com.Parameters.AddWithValue("@price", _transaksi.price);
                    //com.Parameters.AddWithValue("@aktif", (object)_transaksi.aktif ?? DBNull.Value);
                    com.Parameters.AddWithValue("@qty", _transaksi.qty);

                    dr = com.ExecuteReader();
                    dr.Close();
                }
                ret.Success = "Berhasil";
                ret.Error = null;
            }
            catch (Exception e)
            {
                ret.Success = null;
                ret.Error = string.Format("System Error : {0}, {1}", e.Message, e.StackTrace);
            }
            finally { con.Close(); }
            return ret;
        }

    }
}