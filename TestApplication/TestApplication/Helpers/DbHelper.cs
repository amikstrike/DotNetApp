using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace TestApplication.Helpers
{
    public class DbHelper
    {
        public delegate void ProgressStatus(int status);

        public event ProgressStatus progressStatus;

        public DataSet TableDataSet;


        private SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder
        {
            DataSource = ".\\SQLEXPRESS",
            IntegratedSecurity = true,
            InitialCatalog = "Our_PCDB"
        };

        public DbHelper(List<CsvReader> entities)
        {

            ExecuteNonQuery("delete from CategoryName");
            ExecuteNonQuery("delete from SubCategoryName");
            ExecuteNonQuery("delete from PartTerminologyName");
            ExecuteNonQuery("delete from OurDepartment");
            ExecuteNonQuery("delete from OurCategory");
            ExecuteNonQuery("delete from OurPtype");
            ExecuteNonQuery("delete from OurSubtype");
            ExecuteNonQuery("delete from PtRelations");


            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[CategoryName]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[SubCategoryName]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[PartTerminologyName]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[OurDepartment]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[OurCategory]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[OurPtype]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[OurSubtype]', RESEED, 0)");
            ExecuteNonQuery("DBCC CHECKIDENT ('[Our_PCDB].[dbo].[PtRelations]', RESEED, 0)");


            string _path = "D:\\Projects\\Ivchenko_Oleg_Test_Application\\TestApplication\\TestApplication\\Resources\\UpTypes.csv";
            string[] rows = File.ReadAllLines(_path);
            int i = 0;
            foreach (string row in rows)
            {
                i++;
                if (i==1)
                {
                    continue;
                }


                string[] f = row.Split(';');


                string query = string.Format("SELECT Id FROM CategoryName WHERE Value = '{0}'  ", f[0]);
                object res = ExecuteQuery(query);
                int cn;
                if (res == null)
                {
                    query = string.Format("INSERT INTO CategoryName OUTPUT Inserted.Id VALUES('{0}',NULL)  ", f[0]);
                    cn = Convert.ToInt32(ExecuteQuery(query));
                }
                else
                {
                    cn = Convert.ToInt32(res);
                }



                 query = string.Format("SELECT Id FROM SubCategoryName WHERE Value = '{0}'  ", f[1]);
                object res1 = ExecuteQuery(query);
                int scn;
                if (res1 == null)
                {
                    query = string.Format("INSERT INTO SubCategoryName OUTPUT Inserted.Id  VALUES('{0}',NULL) ", f[1]);
                    scn = Convert.ToInt32(ExecuteQuery(query));
                }
                else
                {
                    scn = Convert.ToInt32(res1);
                }


                query = string.Format("SELECT Id FROM PartTerminologyName WHERE Value = '{0}'  ", f[2]);
                object res2 = ExecuteQuery(query);
                int ptn;
                    if (res2 == null)
                    {
                    query = string.Format("INSERT INTO PartTerminologyName OUTPUT Inserted.Id VALUES('{0}',NULL) ", f[2]);
                    ptn = Convert.ToInt32(ExecuteQuery(query));
                    }
                    else
                    {
                    ptn = Convert.ToInt32(res2);
                    }



                query = string.Format("SELECT Id FROM OurDepartment WHERE Value = '{0}'  ", f[3]);
                object res3 = ExecuteQuery(query);
                int od;
                        if (res3 == null)
                {
                    query = string.Format("INSERT INTO OurDepartment OUTPUT Inserted.Id  VALUES('{0}',NULL) ", f[3]);
                    od = Convert.ToInt32(ExecuteQuery(query));
                    }
                    else
                    {
                    od = Convert.ToInt32(res3);
                    }



                query = string.Format("SELECT Id FROM OurCategory WHERE Value = '{0}'  ", f[4]);
                object res4 = ExecuteQuery(query);
                int oc;
                            if (res4 == null)
                {
                    query = string.Format("INSERT INTO OurCategory OUTPUT Inserted.Id VALUES('{0}',NULL) ", f[4]);
                    oc = Convert.ToInt32(ExecuteQuery(query));
                    }
                    else
                    {
                    oc = Convert.ToInt32(res4);
                    }


                query = string.Format("SELECT Id FROM OurPtype WHERE Value = '{0}'  ", f[5]);
                object res5 = ExecuteQuery(query);
                int op;
                                if (res5 == null)
                {
                    query = string.Format("INSERT INTO OurPtype OUTPUT Inserted.Id VALUES('{0}',NULL) ", f[5]);
                    op = Convert.ToInt32(ExecuteQuery(query));
                    }
                    else
                    {
                    op = Convert.ToInt32(res5);
                    }


                query = string.Format("SELECT Id FROM OurSubtype WHERE Value = '{0}'  ", f[6]);
                object res6 = ExecuteQuery(query);
                int os;
                     if (res6 == null)
                {
                    query = string.Format("INSERT INTO  OurSubtype OUTPUT Inserted.Id VALUES('{0}',NULL) ", f[6]);
                    os = Convert.ToInt32(ExecuteQuery(query));
                    }
                    else
                    {
                    os = Convert.ToInt32(res6);
                    }

                    query = string.Format(@"INSERT INTO PtRelations VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", cn, scn, ptn, od, oc, op, os);
                ExecuteNonQuery(query);


            }





            TableDataSet = new DataSet();
            SetUpDatabase(entities);
        }

        public void SetUpDatabase(List<CsvReader> entities)
        {
            TryCreateDatabase();
            foreach (CsvReader csv in entities)
            {
                TryCreateTable(csv);
            }
        }

        public void TryCreateTable(CsvReader csv)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = GetSqlCreateTableString(csv.TableName, csv.Header);
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    for (int i = 1; i < csv.Header.Count; i++)
                    {
                        sqlQuery = GetSqlAddColumtString(csv.TableName, csv.Header[i]);
                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TryCreateDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    string sqlCreateDbQuery = GetSqlCreateDatabaseString();
                    using (SqlCommand myCommand = new SqlCommand(sqlCreateDbQuery, connection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                }
                connectionString = new SqlConnectionStringBuilder
                {
                    InitialCatalog = Constants.DatabaseName,
                    DataSource = ".\\SQLEXPRESS",
                    IntegratedSecurity = true
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImportToTable(List<CsvReader> entities)
        {
            SetUpDatabase(entities);
        }

        public void FillTables(List<CsvReader> entities)
        {
            SetUpDatabase(entities);
            int allRows = 0;
            foreach (var csvReader in entities)
            {
                AddTableRows(csvReader, ref allRows);
            }
        }

        private void AddTableRows(CsvReader csv, ref int allRows)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    for (int i = 0; i < csv.Rows.Count; i++)
                    {
                        string sqlCreateDbQuery = GetSqlInsertString(csv);
                        if (sqlCreateDbQuery != null)
                        {
                            using (SqlCommand myCommand = new SqlCommand(sqlCreateDbQuery, connection))
                            {
                                myCommand.ExecuteNonQuery();
                            }
                            allRows++;
                            progressStatus(allRows);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddTableRows(Dictionary<string, string> csv, string tableName)
        {            
            ExecuteNonQuery(GetSqlInsertString(csv, tableName));
        }

        public void UpdateTableRows(string table, string key, string column, string value, string idCol)
        {
            ExecuteNonQuery(GetSqlUpdateRowString(table, key, column, value, idCol));
        }

        private object ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    string sqlCreateDbQuery = query;
                    using (SqlCommand myCommand = new SqlCommand(sqlCreateDbQuery, connection))
                    {
                        return myCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    string sqlCreateDbQuery = query;
                    using (SqlCommand myCommand = new SqlCommand(sqlCreateDbQuery, connection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTableRow(string table, string key,  string idCol)
        {
            ExecuteNonQuery(GetSqlDeleteRowString(table, key, idCol));
        }

        public List<List<string>> SearchInDatabase(string table, string column, string key)
        {
            try
            {
                List<List<string>> result = new List<List<string>>();
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    string sqlCreateDbQuery = GetSqlGetRowsString(table, column, key);
                    using (SqlCommand myCommand = new SqlCommand(sqlCreateDbQuery, connection))
                    {
                        var adapter = new SqlDataAdapter(myCommand);
                        TableDataSet = new DataSet();
                        adapter.Fill(TableDataSet);
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<string> GetTableColumns(string tableName)
        {
            try
            {
                List<string> result = new List<string>();
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();

                    string sqlCreateDbQuery = @GetSqlGetColumnsString(tableName);
                    using (SqlCommand myCommand = new SqlCommand(sqlCreateDbQuery, connection))
                    {
                        SqlDataReader reader = myCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetSqlInsertString(CsvReader csv)
        {
            CheckSchemaValid(csv);
            string query = String.Format("INSERT INTO {0} (", csv.TableName);
            string separator = string.Empty;
            List<string> row = csv.GetNextRow();
            if (row != null)
            {
                for (int i = 0; i < csv.Header.Count; i++)
                {
                    query = String.Format("{0} {1} [{2}] ", query, separator, @csv.Header[i]);
                    separator = ",";
                }
                separator = string.Empty;
                query = String.Format("{0}) VALUES (", query);
                for (int i = 0; i < csv.Header.Count; i++)
                {
                    query = String.Format("{0} {1} '{2}' ", query, separator, row[i].Replace("\'", ""));
                    separator = ",";
                }
                query = String.Format("{0})", query);
            }
            else
            {
                return null;
            }
            return query;
        }


        private string GetSqlInsertString(Dictionary<string, string> csv, string TableName)
        {
            string query = String.Format("INSERT INTO {0} (", TableName);
            string separator = string.Empty;
            foreach (KeyValuePair<string, string> row in csv)
            {
                query = String.Format("{0} {1} [{2}] ", query, separator, @row.Key);
                separator = ",";
            }
            separator = string.Empty;
            query = String.Format("{0}) VALUES (", query);
            foreach (KeyValuePair<string, string> row in csv)
            {
                query = String.Format("{0} {1} '{2}' ", query, separator, @row.Value);
                separator = ",";
            }
            query = String.Format("{0})", query);
            return query;
        }
        
        

        public void ClearTables(List<string> tables)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    connection.Open();
                    foreach (string table in tables)
                    {
                        string sqlQuery = GetSqlDeleteAllFromTablesString(table);
                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            command.CommandTimeout = 0;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckSchemaValid(CsvReader csv)
        {
            if (!csv.SchemaIsValid)
            {
                throw new Exception(String.Format("Schema for table {0} is not valid", csv.TableName));
            }
        }

        private string GetSqlCreateTableString(string tableName, List<string> cols)
        {
            string query;
            if (tableName == "Products")
            {

                 query =
                    String.Format(
                        "IF(NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}')) CREATE TABLE {0} ({1} VARCHAR(1000) PRIMARY KEY)",
                        tableName, @cols.First());
            }
            else
            {
                 query =
                    String.Format(
                        "IF(NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}')) CREATE TABLE {0} (ID INTEGER PRIMARY KEY IDENTITY , {1} VARCHAR(1000))",
                        tableName, @cols.First());
            }
            return query;
        }

        private string GetSqlGetRowsString(string table, string column, string key)
        {
            string query =
                String.Format("SELECT TOP 10 * FROM {0} WHERE [{1}] LIKE '%{2}%'  ", table, @column, @key);
            return query;
        }


        private string GetSqlDeleteAllFromTablesString(string table)
        {
            string query =
                String.Format("IF OBJECT_ID('{0}', 'U') IS NOT NULL DROP TABLE {0}", table);
            return query;
        }

        private string GetSqlGetColumnsString(string tableName)
        {
            string query =
                String.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' and columnproperty(object_id(table_name), column_name,'IsIdentity') != 1  ", tableName);
            return query;
        }

        private string GetSqlCreateDatabaseString()
        {
            string query =
                String.Format(
                    "IF (NOT EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE name = '{0}'))BEGIN CREATE DATABASE {0} END  ",
                    Constants.DatabaseName);
            return query;
        }

        private string GetSqlAddColumtString(string table, string column)
        {
            string query = String.Format(
                "IF COL_LENGTH('{0}','{1}') IS NULL BEGIN ALTER TABLE  {0} ADD [{1}] VARCHAR(1000) END", table, @column);
            return query;
        }

        private string GetSqlUpdateRowString(string table, string key, string column, string value, string idCol)
        {
            string query = String.Format(
                "UPDATE {0} SET [{1}] = '{2}' WHERE [{3}] = '{4}'", table, column, value, idCol, key);
            return query;
        }

        private string GetSqlDeleteRowString(string table, string key,  string idCol)
        {
            string query = String.Format(
                "DELETE FROM {0}  WHERE [{1}] = '{2}'", table, idCol, key);
            return query;
        }
    }
}