using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Project.Data
{
    public class Table<T> : IEnumerable<T> where T : TableRow<T>
    {
        /// <summary>
        /// Имя, которым таблица представлена в базе данных
        /// </summary>
        public string TableName { get; set; }

        public Table(string tableName, IEnumerable<OleDbParameter> parameters)
        {
            TableName = tableName;
            _parameters.AddRange(parameters);
        }

        protected internal Dictionary<int, T> Items = new Dictionary<int, T>();

        private readonly OleDbCommand _command = new OleDbCommand();

        private readonly List<OleDbParameter> _parameters = new List<OleDbParameter>();

        protected internal OleDbDataReader Reader;

        public bool IsPeriodic => typeof(IPeriodicTableRow).IsAssignableFrom(typeof(T));

        public bool IsOptimizable => typeof(IOptimizableTableRow).IsAssignableFrom(typeof(T));

        public bool IsEmpty => Items.Count.Equals(0);


        public void Optimize()
        {
            if (!IsOptimizable) return;

            foreach (var item in Items.Values)
            {
                var i = item as IOptimizableTableRow;
                if (i == null) continue;
                if (i.IsUsed) continue;
                Delete(item);
            }
        }


        public T this[int id] => Items[id];

        public int GetIdByValue(T item) => (from i in Items where i.Value.Equals(item) select i.Key).FirstOrDefault();

        public int NextId => (Items.Keys.Count != 0) ? Items.Keys.Max() + 1 : 1;

        internal void Clear() => Items.Clear();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public IEnumerator<T> GetEnumerator() => Items.Values.GetEnumerator();

        public int Insert(T item)
        {
            var id = NextId;
            item.Id = id;
            var pId = new OleDbParameter("Id", OleDbType.Integer) {Value = id};
            _command.Parameters.Add(pId);
            string comParams = "", comVals = "";
            comParams += "([Id], ";
            comVals += "(?, ";
            foreach (var parameter in _parameters)
            {
                comParams += $"[{parameter.ParameterName}], ";
                comVals += "?, ";
            }
            comParams = comParams.Remove(comParams.Length - 2);
            comVals = comVals.Remove(comVals.Length - 2);
            comParams += ")";
            comVals += ")";

            string comText = $"INSERT INTO {TableName} {comParams} VALUES {comVals};";
            foreach (var parameter in _parameters)
            {
                parameter.Value = item.GetType().GetProperty(parameter.ParameterName).GetValue(item, null);
                _command.Parameters.Add(parameter);
            }

            _command.CommandText = comText;
            _command.Connection = Databases.Connection;
            _command.Connection.Open();
            _command.ExecuteNonQuery();
            _command.Parameters.Clear();
            _command.Connection.Close();

            Items.Add(id, item);
            return id;
        }

        public void Update(T item, T newItem)
        {
            newItem.Id = item.Id;
            var id = GetIdByValue(item);
            var pId = new OleDbParameter("Id", OleDbType.Integer) {Value = id};


            var comItems = "";

            foreach (var parameter in _parameters)
            {
                comItems += $" [{parameter.ParameterName}] = ?, ";
                parameter.Value = newItem.GetType().GetProperty(parameter.ParameterName).GetValue(newItem, null);
                _command.Parameters.Add(parameter);
            }
            comItems = comItems.Remove(comItems.Length - 2);

            _command.Parameters.Add(pId);


            _command.CommandText = $"UPDATE {TableName} SET {comItems} WHERE [Id] = ?;";
            _command.Connection = Databases.Connection;
            _command.Connection.Open();
            _command.ExecuteNonQuery();
            _command.Parameters.Clear();
            _command.Connection.Close();

            Items[id] = newItem;
        }

        public void Delete(T item)
        {
            var id = GetIdByValue(item);
            if (id == 0) return;

            var pId = new OleDbParameter("Id", OleDbType.Integer) {Value = id};

            _command.Connection = Databases.Connection;
            _command.CommandText = $"DELETE * FROM [{TableName}] WHERE [Id] = ?;";
            _command.Parameters.Add(pId);

            _command.Connection.Open();
            _command.ExecuteNonQuery();
            _command.Parameters.Clear();
            _command.Connection.Close();

            Items.Remove(id);
        }

        /// <summary>
        /// Загружает данные из базы данных в экземпляр таблицы.
        /// Для таблиц с периодом времени загружаются только актуальные строки.
        /// </summary>
        /// <param name="connection"></param>
        public void Load(IDbConnection connection)
        {
            if (!connection.GetType().IsAssignableFrom(typeof(OleDbConnection)))
            {
                throw new NotSupportedException("Application did not support any DB provider but OleDb");
            }
            _command.Connection = connection as OleDbConnection;
            _command.CommandText = IsPeriodic ?
                $"SELECT * FROM [{TableName}] WHERE [Begin] < Date() AND ([End] > Date() OR [End] Is Null);" :
                $"SELECT * FROM [{TableName}];";
            var reader = _command.ExecuteReader();

            if (reader == null) return;

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader["Id"]);
                var item = (T)Activator.CreateInstance(typeof(T), reader);

                Items.Add(id, item);
            }
        }
    }

    public class Tables
    {
        public Table<Profession> Professions = new Table<Profession>("Professions", new[]
        {
            new OleDbParameter("Code", OleDbType.SmallInt),
            new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 31),
            new OleDbParameter("Rank1", OleDbType.Single),
            new OleDbParameter("Rank2", OleDbType.Single),
            new OleDbParameter("Rank3", OleDbType.Single),
            new OleDbParameter("Rank4", OleDbType.Single),
            new OleDbParameter("Rank5", OleDbType.Single),
            new OleDbParameter("Rank6", OleDbType.Single),
            new OleDbParameter("Begin", OleDbType.DBDate),
            new OleDbParameter("End", OleDbType.DBDate),
        });

        public Table<Person> Persons = new Table<Person>("Persons", new[]
        {
            new OleDbParameter("Code", OleDbType.SmallInt),
            new OleDbParameter("FirstName", OleDbType.VarWChar, sizeof(char) * 31),
            new OleDbParameter("MiddleName", OleDbType.VarWChar, sizeof(char) * 31),
            new OleDbParameter("LastName", OleDbType.VarWChar, sizeof(char) * 31),
            new OleDbParameter("Begin", OleDbType.DBDate),
            new OleDbParameter("End", OleDbType.DBDate),
        });

        public Table<PersonProfession> PersonProfessions = new Table<PersonProfession>("PersonProfessions", new[]
        {
            new OleDbParameter("PersonId", OleDbType.Integer),
            new OleDbParameter("ProfessionId", OleDbType.Integer),
            new OleDbParameter("Rank", OleDbType.UnsignedTinyInt),
            new OleDbParameter("Begin", OleDbType.DBDate),
            new OleDbParameter("End", OleDbType.DBDate),
        });

        public Table<Area> Areas = new Table<Area>("Areas", new []
        {
            new OleDbParameter("Code", OleDbType.SmallInt),
            new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 50),
            new OleDbParameter("Begin", OleDbType.DBDate),
            new OleDbParameter("End", OleDbType.DBDate),
        });

        public Table<Brigade> Brigades = new Table<Brigade>("Brigades", new []
        {
            new OleDbParameter("AreaId", OleDbType.Integer),
            new OleDbParameter("Code", OleDbType.UnsignedTinyInt),
            new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 63),
            new OleDbParameter("Begin", OleDbType.DBDate),
            new OleDbParameter("End", OleDbType.DBDate),
        });

        public Table<BrigadePerson> BrigadePersons = new Table<BrigadePerson>("BrigadePersons", new []
        {
            new OleDbParameter("BrigadeId", OleDbType.Integer),
            new OleDbParameter("PersonId", OleDbType.Integer),
            new OleDbParameter("Begin", OleDbType.DBDate),
            new OleDbParameter("End", OleDbType.DBDate),
        });

        public Table<Warranty> Warranties = new Table<Warranty>("Warranties", new []
        {
            new OleDbParameter("Customer", OleDbType.VarWChar, sizeof(char) * 50),
            new OleDbParameter("Order", OleDbType.SmallInt),
            new OleDbParameter("Percent", OleDbType.Single),
            new OleDbParameter("WarrantyDate", OleDbType.DBDate),
            new OleDbParameter("AreaId", OleDbType.Integer),
            new OleDbParameter("BrigadeId", OleDbType.Integer),
        });

        public Table<Position> Positions = new Table<Position>("Positions", new []
        {
            new OleDbParameter("WarrantyId", OleDbType.Integer),
            new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 50),
            new OleDbParameter("Draw", OleDbType.VarWChar, sizeof(char) * 50),
            new OleDbParameter("Matherial", OleDbType.VarWChar, sizeof(char) * 50),
            new OleDbParameter("Number", OleDbType.SmallInt),
            new OleDbParameter("Mass", OleDbType.Single),
            new OleDbParameter("Norm", OleDbType.Single),
            new OleDbParameter("Price", OleDbType.Single),
        });

        public Table<Executor> Executors = new Table<Executor>("Executors", new[]
        {
            new OleDbParameter("WarrantyId", OleDbType.Integer),
            new OleDbParameter("PersonId", OleDbType.Integer),
            new OleDbParameter("ProfessionId", OleDbType.Integer),
            new OleDbParameter("Rank", OleDbType.UnsignedTinyInt),
        });

        public Table<Labor> Labors = new Table<Labor>("Labors", new[]
        {
            new OleDbParameter("WarrantyId", OleDbType.Integer),
            new OleDbParameter("LaborDate", OleDbType.DBDate),
            new OleDbParameter("Hours", OleDbType.Single),
        });

        public bool IsEmpty => Professions.IsEmpty &&
                               Persons.IsEmpty &&
                               PersonProfessions.IsEmpty &&
                               Areas.IsEmpty &&
                               Brigades.IsEmpty &&
                               BrigadePersons.IsEmpty &&
                               Warranties.IsEmpty &&
                               Positions.IsEmpty &&
                               Executors.IsEmpty &&
                               Labors.IsEmpty;

        internal void Load(IDbConnection connection)
        {
            Professions.Load(connection);
            Persons.Load(connection);
            PersonProfessions.Load(connection);
            Areas.Load(connection);
            Brigades.Load(connection);
            BrigadePersons.Load(connection);
            Warranties.Load(connection);
            Positions.Load(connection);
            Executors.Load(connection);
            Labors.Load(connection);
        }

        internal void Clear()
        {
            Professions.Clear();
            Persons.Clear();
            PersonProfessions.Clear();
            Areas.Clear();
            Brigades.Clear();
            BrigadePersons.Clear();
            Warranties.Clear();
            Positions.Clear();
            Executors.Clear();
            Labors.Clear();
        }

        public void Optimize()
        {
            //Areas.Optimize();
            //Brigades.Optimize();
            //Persons.Optimize();
            //Professions.Optimize();
        }
    }
}
