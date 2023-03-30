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
    public class karyawanrepo
    {
        private TestinterviewEntities context;
        string Con;
        public karyawanrepo(TestinterviewEntities context)
        {
            this.context = context;
            Con = context.Database.Connection.ConnectionString;
        }

        public IQueryable<karyawanvm> datakaryawan
        {
            get
            {
                return context.karyawans.Select(x => new karyawanvm
                {
                    cabang_id= x.cabang_id,
                    kode_kar = x.kode_kar,
                    nama    = x.nama,
                    aktif = x.aktif,
                    id_karyawan = x.id_karyawan,
                    nama_cabang = x.cabang.nama_cab,
                    no_telp =   x.no_telp
                
                });

            }



        }


        public Returnvalue SaveData(karyawanvm _karyawan, string action)
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
                    com.CommandText = "Save_Karyawan"; // SP Name
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id_karyawan", _karyawan.id_karyawan);
                    com.Parameters.AddWithValue("@cabang_id", _karyawan.cabang_id);
                    com.Parameters.AddWithValue("@kode_kar", _karyawan.kode_kar);
                    com.Parameters.AddWithValue("@nama", _karyawan.nama);
                    com.Parameters.AddWithValue("@aktif", (object)_karyawan.aktif ?? DBNull.Value);
                    com.Parameters.AddWithValue("@no_telp", _karyawan.no_telp);
                    com.Parameters.AddWithValue("@Action", action);
                 

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

        //internal Returnvalue SaveData(cabangrepo cabang, string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}