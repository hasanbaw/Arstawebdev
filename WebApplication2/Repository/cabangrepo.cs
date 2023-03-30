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
    public class cabangrepo
    {
        private TestinterviewEntities context;
        string Con;
        public cabangrepo(TestinterviewEntities context)
        {
            this.context = context;
            Con = context.Database.Connection.ConnectionString;
        }

        public IQueryable<cabangvm> datacabang
        {
            get
            {
                return context.cabangs.Select(x => new cabangvm
                {
                    nama_cab_ = x.nama_cab,
                    kode_cab = x.kode_cab,
                    aktif = x.aktif,
                    id = x.id
                });

            }
        }


        public Returnvalue SaveData(cabangvm _cabang, string action)
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
                    com.CommandText = "Save_cabang"; // SP Name
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", _cabang.id);
                    com.Parameters.AddWithValue("@nama_cab", _cabang.nama_cab_);
                    com.Parameters.AddWithValue("@kode_cab", _cabang.kode_cab);
                    com.Parameters.AddWithValue("@aktif", (object)_cabang.aktif ?? DBNull.Value);
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