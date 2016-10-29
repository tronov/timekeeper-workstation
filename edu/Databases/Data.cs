using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JRO;

namespace Project.Databases
{
    public static class Data
    {
        private static DirectoryInfo _DataDirectory = new DirectoryInfo(@".\Databases");

        private static OleDbConnectionStringBuilder _ConnectionStringBuilder =
            new OleDbConnectionStringBuilder("Provider=Microsoft.Jet.OLEDB.4.0;");

        public static bool IsEmpty
        {
            get { return Tables.IsEmpty; }
        }

        public static Tables Tables = new Tables();

        internal static OleDbConnection Connection = new OleDbConnection();

        private static List<string> _AvailableDatabases = new List<string>();

        public static List<string> AvailableDatabases
        {
            get { return _AvailableDatabases; }
        }

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
            string tempPath = Path.Combine(_DataDirectory.FullName, "temp.mdb");
            _ConnectionStringBuilder.DataSource = tempPath;
            JRO.JetEngine jro = new JetEngine();
            jro.CompactDatabase(Connection.ConnectionString, _ConnectionStringBuilder.ConnectionString);
            File.Delete(Connection.DataSource);
            File.Copy(tempPath, Connection.DataSource);
            File.Delete(tempPath);
        }

        private static void ClearDocs()
        {
            List<Warranty> docs = Tables.Warranties.ToList();
            foreach (Warranty doc in docs) doc.Delete();
        }

        private static void Init()
        {
            int currentYear = DateTime.Now.Year;

            // Получить список путей к каждому из *.mdb файлов в каталоге данных
            FileInfo[] files = _DataDirectory.GetFiles("*.mdb");

            Regex reg = new Regex(@"^\d\d\d\d.mdb$");

            foreach (FileInfo file in files)
            {
                if (reg.IsMatch(file.Name))
                {
                    string fName = file.Name.Remove(file.Name.Length - 4);
                    int year = Convert.ToInt32(fName);
                    if (year <= currentYear) _AvailableDatabases.Add(fName);
                }
            }

            if (_AvailableDatabases.Count != 0)
            {
                int maxYear = _AvailableDatabases.Select(r => Convert.ToInt32(r)).Max();
                if (maxYear != currentYear)
                {
                    string ifPath = Path.Combine(_DataDirectory.FullName, maxYear.ToString() + ".mdb");
                    string ofPath = Path.Combine(_DataDirectory.FullName, currentYear.ToString() + ".mdb");

                    File.Copy(ifPath, ofPath);
                    _AvailableDatabases.Add(currentYear.ToString());
                    _ConnectionStringBuilder.DataSource = ofPath;
                    Connection.ConnectionString = _ConnectionStringBuilder.ConnectionString;

                    ClearDocs();
                    Optimize();
                }
                else
                {
                    string fPath = Path.Combine(_DataDirectory.FullName, currentYear.ToString() + ".mdb");
                    _ConnectionStringBuilder.DataSource = fPath;
                    Connection.ConnectionString = _ConnectionStringBuilder.ConnectionString;
                }
            }
            else
            {
                string ifPath = Path.Combine(_DataDirectory.FullName, "template.mdb");
                string ofPath = Path.Combine(_DataDirectory.FullName, currentYear.ToString() + ".mdb");
                File.Copy(ifPath, ofPath);
                _AvailableDatabases.Add(currentYear.ToString());
                _ConnectionStringBuilder.DataSource = ofPath;
                Connection.ConnectionString = _ConnectionStringBuilder.ConnectionString;
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

        static Data()
        {
            Init();

            Load(Connection);
        }
    }
}
