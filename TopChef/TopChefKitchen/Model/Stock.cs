using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TopChefKitchen.Model
{
    class Stock
    {

        public DataSet DataSet { get ; set ; }
        public SqlDataAdapter DataAdapter { get ; set ; }
        public SqlConnection Connection { get ; set ; }
        public SqlCommand Command { get ; set ; }
        public string Cnx1 { get ; set; }
        public string Rq_Sql { get; set ; }

        void UpdateStock()
        {

        }
    }
}
