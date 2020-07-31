﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace restaurant
{
    class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _ID;
        private int _PersonelId;
        private string _Islem;
        private DateTime _Tarih;
        private bool _Durum;
        #endregion

        #region Properties
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public int PersonelId
        {
            get
            {
                return _PersonelId;
            }

            set
            {
                _PersonelId = value;
            }
        }

        public string Islem
        {
            get
            {
                return _Islem;
            }

            set
            {
                _Islem = value;
            }
        }

        public DateTime Tarih
        {
            get
            {
                return _Tarih;
            }

            set
            {
                _Tarih = value;
            }
        }

        public bool Durum
        {
            get
            {
                return _Durum;
            }

            set
            {
                _Durum = value;
            }
        } 
        #endregion

        public bool _PersonelActionSave(cPersonelHareketleri ph) {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into personelHareketleri(PERSONELID,ISLEM,TARIH)Values(@personelId,@islem,@tarih)", con);
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@personelId", SqlDbType.Int).Value = ph.PersonelId;
                cmd.Parameters.Add("@islem", SqlDbType.VarChar).Value = ph.Islem;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ph.Tarih;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;

        }
    }
}
