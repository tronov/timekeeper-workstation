using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JRO;

namespace Project.Data
{
    public static class Databases
    {
        private static readonly DirectoryInfo DataDirectory = new DirectoryInfo(@".\Data");

        private static readonly OleDbConnectionStringBuilder ConnectionStringBuilder =
            new OleDbConnectionStringBuilder("Provider=Microsoft.Jet.OLEDB.4.0;");

        public static bool IsEmpty => Tables.IsEmpty;

        public static readonly Tables Tables = new Tables();

        internal static readonly OleDbConnection Connection = new OleDbConnection();

        private static List<string> AvailableDatabases { get; } = new List<string>();

        /// <summary>
        /// Оптимизирует базу данных текущего года
        /// посредством удаления устаревших данных
        /// и последующего сжатия файла базы данных.
        /// </summary>
        private static void Optimize()
        {
            Load(Connection);
            Tables.Optimize();
            Clear();

            // Сжатие базы данных
            var tempPath = Path.Combine(DataDirectory.FullName, "temp.mdb");
            ConnectionStringBuilder.DataSource = tempPath;
            var jet = new JetEngine();
            jet.CompactDatabase(Connection.ConnectionString, ConnectionStringBuilder.ConnectionString);
            File.Delete(Connection.DataSource);
            File.Copy(tempPath, Connection.DataSource);
            File.Delete(tempPath);
        }

        private static void ClearDocs()
        {
            var docs = Tables.Warranties.ToList();
            foreach (var doc in docs) doc.Delete();
        }

        private static void Init()
        {
            // Проверить существование директории данных
            // Если не существует - создать
            if (!DataDirectory.Exists)
            {
                DataDirectory.Create();
            }

            var currentYear = DateTime.Now.Year;

            // Получить список путей к каждому из *.mdb файлов в каталоге данных
            var files = DataDirectory.GetFiles("*.mdb");

            var reg = new Regex(@"^\d\d\d\d.mdb$");

            foreach (var file in files)
            {
                if (!reg.IsMatch(file.Name)) continue;

                var fName = file.Name.Remove(file.Name.Length - 4);
                var year = Convert.ToInt32(fName);
                if (year <= currentYear) AvailableDatabases.Add(fName);
            }

            if (AvailableDatabases.Count != 0)
            {
                var maxYear = AvailableDatabases.Select(r => Convert.ToInt32(r)).Max();
                if (maxYear != currentYear)
                {
                    var ifPath = Path.Combine(DataDirectory.FullName, maxYear + ".mdb");
                    var ofPath = Path.Combine(DataDirectory.FullName, currentYear + ".mdb");

                    File.Copy(ifPath, ofPath);
                    AvailableDatabases.Add(currentYear.ToString());
                    ConnectionStringBuilder.DataSource = ofPath;
                    Connection.ConnectionString = ConnectionStringBuilder.ConnectionString;

                    ClearDocs();
                    Optimize();
                }
                else
                {
                    var fPath = Path.Combine(DataDirectory.FullName, currentYear + ".mdb");
                    ConnectionStringBuilder.DataSource = fPath;
                    Connection.ConnectionString = ConnectionStringBuilder.ConnectionString;
                }
            }
            else
            {
                var ifPath = Path.Combine(DataDirectory.FullName, "template.mdb");
                var ofPath = Path.Combine(DataDirectory.FullName, currentYear + ".mdb");
                File.Copy(ifPath, ofPath);
                AvailableDatabases.Add(currentYear.ToString());
                ConnectionStringBuilder.DataSource = ofPath;
                Connection.ConnectionString = ConnectionStringBuilder.ConnectionString;
            }

        }

        private static void Load(OleDbConnection connection)
        {
            Connection.Open();
            Tables.Load(connection);
            Connection.Close();
        }

        private static void Clear()
        {
            Tables.Clear();
        }

        static Databases()
        {
            Init();

            Load(Connection);
        }
    }
}
