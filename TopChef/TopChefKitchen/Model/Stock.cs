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
       

        public Stock()
        {
            Rq_sql = null;
            Cnx = @"Data Source=DESKTOP-OR03K2O\SQLEXPRESS;Initial Catalog=DB_A2_WS2;Integrated Security=True";
            Connection = new System.Data.SqlClient.SqlConnection(Cnx);
            DataSet = new System.Data.DataSet();
            DataAdapter = null;
            Command = null;
        }

        public string SelectAll()
        {
            Rq_sql = "SELECT * FROM *";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            string all = DataSet.ToString();
            return all;
        }

        public void SelectRecipe(string name)
        {

            if (CheckIfResourceAvailable(name) == true)
            { 
            Recipe = CreateRecipe(name);
            
            Rq_sql = "SELECT * FROM steps WHERE id = " + Id;
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            ReaderSteps = Command.ExecuteReader();
            
           while(ReaderSteps.GetString(1) != null)
            {
                Step step = new Step
                {
                    RecipeName = name,
                    Id = ReaderSteps.GetInt32(1),
                    Wait_Time = ReaderSteps.GetInt32(3),
                    Nb_step = ReaderSteps.GetInt32(4),
                    Sync = ReaderSteps.GetInt32(5)
                };
                UpdateStep(step);
                Recipe.Steps.Add(step);
                ReaderSteps.Read();
            }           
            ReaderSteps.Close();

            UpdateStock(Recipe.Name);
            }
            
        }

        private void UpdateStep(Step step)
        {
            Rq_sql = "SELECT * FROM step_tool WHERE id_step =" + step.Id;
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            ReaderStep_Tool = Command.ExecuteReader();

            Rq_sql = "SELECT * FROM step_tool WHERE id =" + ReaderStep_Tool.GetInt32(3);
            ReaderStep_Tool.Close();
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            Readertools = Command.ExecuteReader();
            step.Tool_Needed = Readertools.GetString(2);
            Readertools.Close();

        }

        public Recipe.Recipe CreateRecipe(string name)
        {
            Rq_sql = "SELECT * FROM recipes WHERE name =" + name;
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            string recipe = DataSet.ToString();

            Recipe = new Recipe.Recipe
            {
                Name = name
            };
            ReaderRecipe = Command.ExecuteReader();
            string type = ReaderRecipe.GetString(4);
            Recipe.Type = type;
            int nb_people = ReaderRecipe.GetInt32(4);
            Recipe.Nb_people = nb_people;
            Id = ReaderRecipe.GetString(1);
            ReaderRecipe.Close();
            return Recipe;
        }

        public void UpdateStock(string name)
        {
            ReaderRecipe_Resource = GetRessourcesFromRecipe(name);
            while (ReaderRecipe_Resource.GetString(1) != null)
            {
                int resourceId = ReaderRecipe_Resource.GetInt32(2);
                int quantity = ReaderRecipe_Resource.GetInt32(4);
                RemoveResource(resourceId, quantity);
                
                
                ReaderSteps.Read();
            }
            ReaderRecipe_Resource.Close();
            CheckResourceQuantity();
        }

        public void RemoveResource(int resourceId, int quantity)
        {
            Rq_sql = "SELECT * FROM stock WHERE id =" + resourceId;
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            ReaderStock = Command.ExecuteReader();
            quantity = ReaderStock.GetInt32(3) - quantity;
            ReaderStock.Close();

            Rq_sql = "UPDATE stock SET quantity = "+ quantity + "WHERE id =  " + resourceId;
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
           
            
        }

        private SqlDataReader GetRessourcesFromRecipe(string name)
        {
            Rq_sql = "SELECT * FROM recipes WHERE name =" + name ;
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            ReaderRecipe = Command.ExecuteReader();

            Rq_sql = "SELECT * FROM recipe_resource WHERE id_recipe =" + ReaderRecipe.GetInt32(1);
            ReaderRecipe.Close();
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
            ReaderRecipe_Resource = Command.ExecuteReader();

            return ReaderRecipe_Resource;


        }

        private void CheckResourceQuantity()
        {
            Rq_sql = "DELETE * FROM stock WHERE quantity = 0";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(Command);
            DataAdapter.Fill(DataSet, "rows");
           
        }


        }

    }
}
