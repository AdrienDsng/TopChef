using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Model
{
    class Stock
    {
        public Recipe.Recipe Recipe { get; set;}
        public DataSet DataSet { get ; set ; }
        public SqlDataAdapter DataAdapter { get ; set ; }
        public SqlConnection Connection { get ; set ; }
        public SqlCommand Command { get ; set ; }
        public SqlDataReader ReaderRecipe { get; set; }
        public SqlDataReader ReaderSteps { get; set; }
        public SqlDataReader ReaderStep_Tool { get; set; }
        public SqlDataReader Readertools { get; set; }
        public SqlDataReader ReaderRecipe_Resource { get; set; }
        public SqlDataReader ReaderResource { get; set; }
        public SqlDataReader ReaderStock { get; set; }
        public string Cnx { get ; set; }
        public string Rq_sql { get; set ; }
        public string Id { get; set; }
       
        void UpdateStock()
        {

        }
    }
}
