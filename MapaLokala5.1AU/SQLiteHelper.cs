using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MapaLokala5._1AU
{
    public class SQLiteHelper
    {
        public SQLiteConnection dbConn
        {
            get;
            set;
        }

        public SQLiteHelper(string dbname)
        {
           // SQLiteConnection.CreateFile(dbname);
            dbConn = new SQLiteConnection("Data Source="+ dbname + ";Version=3;");
            dbConn.Open();
        }

        public void createTable(string sqlTable)
        {
            SQLiteCommand tableCreation = new SQLiteCommand(sqlTable, dbConn);
            tableCreation.ExecuteNonQuery();
        }


        public SQLiteDataReader Select(string sqlSelect)
        {
            SQLiteCommand commandSelect = new SQLiteCommand(sqlSelect, dbConn);
            SQLiteDataReader reader = commandSelect.ExecuteReader();

            return reader;
        }
    }
}
