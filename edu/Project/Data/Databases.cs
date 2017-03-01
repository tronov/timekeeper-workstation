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
        private static readonly DirectoryInfo _dataDirectory = new DirectoryInfo(@".\Data");

        private static readonly OleDbConnectionStringBuilder _connectionStringBuilder =
         new OleDbConnectionStringBuilder("Provider=Microsoft.Jet.OLEDB.4.0;");

        public static bool IsEmpty => Tables.IsEmpty;

        public static Tables Tables = new Tables();

        internal static OleDbConnection Connection = new OleDbConnection();

        public static List<string> AvailableDatabases { get; } = new List<string>();

        /// <summary>
        /// Оптимизирует базу данных текущего года
        /// посредством удаления устаревших данных
        /// и последующего сжатия файла базы данных.
        /// </summary>
        public static void Optimize()
        {
            Load(Connection);
            Tables.Optimize();
            Clear();

            // Сжатие базы данных
            var tempPath = Path.Combine(_dataDirectory.FullName, "temp.mdb");
            _connectionStringBuilder.DataSource = tempPath;
            var jet = new JetEngine();
            jet.CompactDatabase(Connection.ConnectionString, _connectionStringBuilder.ConnectionString);
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
            if (!_dataDirectory.Exists)
            {
                _dataDirectory.Create();
            }

            var currentYear = DateTime.Now.Year;

            // Получить список путей к каждому из *.mdb файлов в каталоге данных
            var files = _dataDirectory.GetFiles("*.mdb");

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
                    var ifPath = Path.Combine(_dataDirectory.FullName, maxYear + ".mdb");
                    var ofPath = Path.Combine(_dataDirectory.FullName, currentYear + ".mdb");

                    File.Copy(ifPath, ofPath);
                    AvailableDatabases.Add(currentYear.ToString());
                    _connectionStringBuilder.DataSource = ofPath;
                    Connection.ConnectionString = _connectionStringBuilder.ConnectionString;

                    ClearDocs();
                    Optimize();
                }
                else
                {
                    var fPath = Path.Combine(_dataDirectory.FullName, currentYear + ".mdb");
                    _connectionStringBuilder.DataSource = fPath;
                    Connection.ConnectionString = _connectionStringBuilder.ConnectionString;
                }
            }
            else
            {
                var ifPath = Path.Combine(_dataDirectory.FullName, "template.mdb");
                var ofPath = Path.Combine(_dataDirectory.FullName, currentYear + ".mdb");
                File.Copy(ifPath, ofPath);
                AvailableDatabases.Add(currentYear.ToString());
                _connectionStringBuilder.DataSource = ofPath;
                Connection.ConnectionString = _connectionStringBuilder.ConnectionString;
            }

        }

        private static void Load(OleDbConnection connection)
        {
            Connection.Open();
            Tables.Load(connection);
            Connection.Close();
        }

        public static void Clear()
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
