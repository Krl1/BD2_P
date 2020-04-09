using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BazyDanychProj
{
    public class DBHelper
    {

        List<string> dataItems = new List<string>();
        String[] dataItemsTable;
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        string connstring;
         public DBHelper(string connstr)
        {
            this.connstring = connstr;
        }
        public void ConnectToDataBase()
        {
            conn = new NpgsqlConnection(connstring);
        }
        public NpgsqlConnection GetConn()
        {
            return conn;
        }
        public NpgsqlDataReader SELECT(string rows, string table_name)
        {
            conn.Open();
            cmd = new NpgsqlCommand("SELECT " + rows + " FROM " + table_name + ";", conn);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            //conn.Close();
            return rdr;
        }
        public NpgsqlDataReader SELECT_WHERE(string rows, string table_name, string constraint)
        {
            conn.Open();
            cmd = new NpgsqlCommand("SELECT " + rows + " FROM " + table_name + " WHERE " + constraint +";", conn);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            //conn.Close();
            return rdr;
        }
        public NpgsqlDataReader PROCEDURE(string funName)
        {
            conn.Open();
            cmd = new NpgsqlCommand( funName, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            //conn.Close();
            return rdr;
        }

        public List<String> FULL_QUESTION(string funName)
        {
            conn.Open();
            dataItems.Clear();
            cmd = new NpgsqlCommand(funName, conn);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            for(int i=0; dataReader.Read(); i++)
            {
                String line = "";
                for(int j=0; j<dataReader.FieldCount-1; j++)
                {
                    line += dataReader[j].ToString() + ",";
                }
                line += dataReader[dataReader.FieldCount - 1];
                dataItems.Add(line);
            }
            conn.Close();
            return dataItems;
        }

        public void QUERY_NO_OUTPUT(string funName)
        {
            conn.Open();
            cmd = new NpgsqlCommand(funName, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

}
