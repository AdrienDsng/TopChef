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
        public Recipe.Recipe Recipe { get; set; }
        public DataSet DataSet { get ; set ; }    
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
        public int Id { get; set; }
       

        public Stock()
        {
            Rq_sql = null;
            Cnx = @"Data Source=DESKTOP-OR03K2O\SQLEXPRESS;Initial Catalog=sql ;Integrated Security=True";
            Connection = new System.Data.SqlClient.SqlConnection(Cnx);
            Connection.Open();
            DataSet = new System.Data.DataSet();
            Command = null;
        }

        public string SelectAll()
        {
            Rq_sql = "SELECT * FROM *";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            string all = DataSet.ToString();
            return all;
        }

        public Recipe.Recipe SelectRecipe(string name)
        {
            Recipe = new Recipe.Recipe();

            if (CheckIfResourceAvailable(name) == true)
            {
                Recipe = CreateRecipe(Recipe,name);

                Rq_sql = "SELECT * FROM steps WHERE id_recipe = " + Id + ";" ;
                Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);           
                ReaderSteps = Command.ExecuteReader();
             
                while (ReaderSteps.Read() != false)
                {
                    Step step = new Step();
                    step.RecipeName = name;
                    step.Id = ReaderSteps.GetInt32(0);
                    step.Wait_Time = ReaderSteps.GetInt32(2);
                    step.Nb_step = ReaderSteps.GetInt32(3);
                    step.Sync = ReaderSteps.GetInt32(4);                    
                    Recipe.AddStep(step);
                    
                }
                ReaderSteps.Close();
                foreach (var value in Recipe.Steps)
                {
                    UpdateStep(value);
                }

                UpdateStock(Recipe.Name);
                return this.Recipe;
            }
            return this.Recipe;            
        }

        private void UpdateStep(Step step)
        {
            
            Rq_sql = "SELECT * FROM step_tool WHERE id_step =" + step.Id+";";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            ReaderStep_Tool = Command.ExecuteReader();
            

            if (ReaderStep_Tool.Read() != false)
            {               
                Rq_sql = "SELECT * FROM tools WHERE id =" + ReaderStep_Tool.GetInt32(2) + ";";
            }
                
            ReaderStep_Tool.Close();
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            Readertools = Command.ExecuteReader();
            if (Readertools.Read() != false)
            {
                step.Tool_Needed = Readertools.GetString(1);
            }               
            Readertools.Close();   
        }

        public Recipe.Recipe CreateRecipe(Recipe.Recipe recipe, string name)
        {
            Rq_sql = "SELECT * FROM recipes WHERE name = '" + name+ "';";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            
  
            recipe.Name = name;
            ReaderRecipe = Command.ExecuteReader();
            ReaderRecipe.Read();
            int type = ReaderRecipe.GetInt32(3);
            recipe.Type = type;
            int nb_people = ReaderRecipe.GetInt32(2);
            recipe.Nb_people = nb_people;
            Id = ReaderRecipe.GetInt32(0);
            ReaderRecipe.Close();
            return recipe;
        }

        public void UpdateStock(string name)
        {
            List<int> resourceId = new List<int>();
            List<int> quantity = new List<int>();
            ReaderRecipe_Resource = GetRessourcesFromRecipe(name);
            
            while (ReaderRecipe_Resource.Read() != false)
            {
                resourceId.Add(ReaderRecipe_Resource.GetInt32(1));
                quantity.Add(ReaderRecipe_Resource.GetInt32(3));
            }
            ReaderRecipe_Resource.Close();
            RemoveResource(resourceId, quantity);
            CheckResourceQuantity();
        }

        public void RemoveResource(List<int> resourceId, List<int> quantity)
        {
            int i = 0;
            Rq_sql = "select * from stock where id_resource =";
            foreach (int value in resourceId)
            {
                Rq_sql += value;             
            }
            Rq_sql += ";";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            ReaderStock = Command.ExecuteReader();
            ReaderStock.Read();
            foreach (int value in resourceId)
            {
                Rq_sql = "UPDATE stock SET quantity =";
                Rq_sql += ReaderStock.GetInt32(2)-quantity[i];
                Rq_sql += " WHERE id_resource = "; 
                Rq_sql += value + ";";
                Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);

                ReaderStock.Read();
                Console.WriteLine(Rq_sql);
                i++;
            }         
        }

        private SqlDataReader GetRessourcesFromRecipe(string name)
        {
            Rq_sql = "select * from recipes where name = '" + name +"';";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);          
            ReaderRecipe = Command.ExecuteReader();
            ReaderRecipe.Read();           
            Rq_sql = "select * from recipe_resource where id_recipe =" + ReaderRecipe.GetInt32(0)+";";
            ReaderRecipe.Close();
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
            ReaderRecipe_Resource = Command.ExecuteReader();

            return ReaderRecipe_Resource;
        }

        private void CheckResourceQuantity()
        {
            Rq_sql = "DELETE * FROM stock WHERE quantity = 0";
            Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
           
        }

        private bool CheckIfResourceAvailable(String name)
        {
            List<int> quantities = new List<int>();
            List<int> ids = new List<int>();
            bool isnull = true;
            ReaderRecipe_Resource = GetRessourcesFromRecipe(name);
            ReaderRecipe_Resource.Read();
            
            while (ReaderRecipe_Resource.Read() != false)
            {                                                
                ids.Add(ReaderRecipe_Resource.GetInt32(1));
                quantities.Add(ReaderRecipe_Resource.GetInt32(3));
                
                ReaderRecipe_Resource.Read();
            }
            ReaderRecipe_Resource.Close();
            int i = 0;
            foreach (int value in ids)
            {
                Rq_sql = "SELECT * FROM stock WHERE id = " + ids + ";" ;
                Command = new System.Data.SqlClient.SqlCommand(Rq_sql, Connection);
                ReaderStock = Command.ExecuteReader();
                ReaderStock.Read();
                if (quantities[i]- ReaderStock.GetInt32(2) >= 0)
                {
                    isnull = true;
                }
                else
                {
                    isnull = false;
                }
                i++;
            }
            return isnull;          
        }
    }
}
