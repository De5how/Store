using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareShop
{
    class BD
    {
        public SqlConnection _con1;
        public BD()
        {
            _con1 = new SqlConnection("Data Source = LAPTOP-EEO6FENT\\SQLEXPRESS; Database = HardwareStore; " +
    "Integrated Security = true; ");

        }

        public void openConnection()
        {
            if (_con1.State == System.Data.ConnectionState.Closed)
                _con1.Open();
        }
        public void closeConnection()
        {
            if (_con1.State == System.Data.ConnectionState.Open)
                _con1.Close();
        }
        public SqlConnection getConnection()
        {
            return _con1;
        }
    }
}
