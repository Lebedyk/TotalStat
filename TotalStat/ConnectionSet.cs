using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    class ConnectionSet
    {
        private string DataSourceString;
        private string InitialCatalogString;
        public ConnectionSet()
        {
            ReadConnection();
            ConnectionStrings();
        }
        private void ReadConnection()
        {
            string line;
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\connection.txt"))
                {
                    StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\connection.txt");
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] split_arr = line.Split(' ');
                        if (split_arr.Length > 1)
                        {
                            if (split_arr[0] == "DataSource")
                            {
                                DataSourceString = split_arr[1];
                            }
                            if (split_arr[0] == "InitialCatalog")
                            {
                                InitialCatalogString = split_arr[1];
                            }                           
                        }
                        else
                        {
                            DataSourceString = "(LocalDB)\\MSSQLLocalDB";
                            InitialCatalogString = "Database";
                        }
                    }
                }
                else
                {
                    DataSourceString = "(LocalDB)\\MSSQLLocalDB";
                    InitialCatalogString = "Database";
                    StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\connection.txt", false);
                    writer.WriteLine("DataSource" + " " + DataSourceString);
                    writer.WriteLine("InitialCatalog" + " " + InitialCatalogString);

                    writer.Close();                    
                }
            }
            catch (Exception ex)
            {
                DataSourceString = "(LocalDB)\\MSSQLLocalDB";
                InitialCatalogString = "Database";
            }
        }

        private void ConnectionStrings()
        {

            SqlConnectionStringBuilder connect1 =
                new SqlConnectionStringBuilder();
            connect1.DataSource = DataSourceString; // имя сервера
            connect1.InitialCatalog = InitialCatalogString; // имя базы данных
            connect1.IntegratedSecurity = true; //проверка подлинности через авторизацию Windows
            string conf_name = "DefaultConnection"; // название строки подключения из app.config
            ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[conf_name];
            cs = new ConnectionStringSettings(conf_name, connect1.ConnectionString, "System.Data.SqlClient");

            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
            // Получаем доступ к строкам подключения
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            // заменяем строку подключения
            csSection.ConnectionStrings.Remove(cs.Name);
            csSection.ConnectionStrings.Add(cs);
            // сохранение файла конфигурации
            config.Save(ConfigurationSaveMode.Modified);
        }        
    }
}
