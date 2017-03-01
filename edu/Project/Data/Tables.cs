﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace Project.Data
{
    public abstract class Table<T> : IEnumerable<T> where T : ITableRow
    {
        protected internal Dictionary<int, T> Items = new Dictionary<int, T>();

        protected internal OleDbDataReader Reader;

        public bool IsEmpty => Items.Count.Equals(0);

        public T this[int id] => Items[id];

        public int GetIdByValue(T item) => (from i in Items where i.Value.Equals(item) select i.Key).FirstOrDefault();

        public int NextId
        {
            get
            {
                int id;
                if (Items.Keys.Count != 0) id = Items.Keys.Max() + 1;
                else id = 1;
                return id;
            }
        }

        internal void Clear() => Items.Clear();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public IEnumerator<T> GetEnumerator() => Items.Values.GetEnumerator();

        public string TableName;

        public OleDbCommand Command = new OleDbCommand();

        public List<OleDbParameter> Parameters = new List<OleDbParameter>();

        public int Insert(T item)
        {
            var id = NextId;
            item.Id = id;
            var pId = new OleDbParameter("Id", OleDbType.Integer) {Value = id};
            Command.Parameters.Add(pId);
            string comParams = "", comVals = "";
            comParams += "([Id], ";
            comVals += "(?, ";
            foreach (var parameter in Parameters)
            {
                comParams += $"[{parameter.ParameterName}], ";
                comVals += "?, ";
            }
            comParams = comParams.Remove(comParams.Length - 2);
            comVals = comVals.Remove(comVals.Length - 2);
            comParams += ")";
            comVals += ")";

            string comText = $"INSERT INTO {TableName} {comParams} VALUES {comVals};";
            foreach (var parameter in Parameters)
            {
                parameter.Value = item.GetType().GetProperty(parameter.ParameterName).GetValue(item, null);
                Command.Parameters.Add(parameter);
            }

            Command.CommandText = comText;
            Command.Connection = Databases.Connection;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Parameters.Clear();
            Command.Connection.Close();

            Items.Add(id, item);
            return id;
        }

        public void Update(T item, T newItem)
        {
            newItem.Id = item.Id;
            var id = GetIdByValue(item);
            var pId = new OleDbParameter("Id", OleDbType.Integer) {Value = id};


            var comItems = "";

            foreach (var parameter in Parameters)
            {
                comItems += $" [{parameter.ParameterName}] = ?, ";
                parameter.Value = newItem.GetType().GetProperty(parameter.ParameterName).GetValue(newItem, null);
                Command.Parameters.Add(parameter);
            }
            comItems = comItems.Remove(comItems.Length - 2);

            Command.Parameters.Add(pId);


            Command.CommandText = $"UPDATE {TableName} SET {comItems} WHERE [Id] = ?;";
            Command.Connection = Databases.Connection;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Parameters.Clear();
            Command.Connection.Close();

            Items[id] = newItem;
        }

        public void Delete(T item)
        {
            var id = GetIdByValue(item);
            if (id == 0) return;

            var pId = new OleDbParameter("Id", OleDbType.Integer) {Value = id};

            Command.Connection = Databases.Connection;
            Command.CommandText = $"DELETE * FROM [{TableName}] WHERE [Id] = ?;";
            Command.Parameters.Add(pId);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Parameters.Clear();
            Command.Connection.Close();

            Items.Remove(id);
        }

        public void Load(OleDbConnection connection)
        {
            Command.Connection = connection;
            Command.CommandText = $"SELECT * FROM {TableName};";
            var reader = Command.ExecuteReader();

            if (reader == null) return;

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader["Id"]);
                var item = (T)Activator.CreateInstance(typeof(T), reader);

                Items.Add(id, item);
            }
        }
    }

    public class Persons : Table<Person>
    {
        public Persons()
        {
            TableName = "Persons";
            Parameters.Add(new OleDbParameter("Code", OleDbType.SmallInt));
            Parameters.Add(new OleDbParameter("FirstName", OleDbType.VarWChar, sizeof(char) * 31));
            Parameters.Add(new OleDbParameter("MiddleName", OleDbType.VarWChar, sizeof(char) * 31));
            Parameters.Add(new OleDbParameter("LastName", OleDbType.VarWChar, sizeof(char) * 31));
            Parameters.Add(new OleDbParameter("Begin", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("End", OleDbType.DBDate));
        }

        public Persons Active
        {
            get
            {
                var persons = new Persons();
                var items = Databases.Tables.Persons.Items
                    .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
                    .ToArray();
                foreach (var item in items)
                    persons.Items.Add(item.Key, item.Value);
                return persons;
            }
        }

        internal void Optimize()
        {
            var persons = Databases.Tables.Persons
                .Except(Databases.Tables.Persons.Active)
                .Where(r => r.Executors.Count().Equals(0))
                .ToArray();

            foreach (var person in persons)
                person.Delete();
        }
    }

    public class Professions : Table<Profession>
    {
        public Professions()
        {
            TableName = "Professions";
            Parameters.Add(new OleDbParameter("Code", OleDbType.SmallInt));
            Parameters.Add(new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 31));
            Parameters.Add(new OleDbParameter("Rank1", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Rank2", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Rank3", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Rank4", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Rank5", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Rank6", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Begin", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("End", OleDbType.DBDate));
        }

        public Professions Active
        {
            get
            {
                var professions = new Professions();
                var items = Databases.Tables.Professions.Items
                    .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
                    .ToArray();
                foreach (var item in items)
                    professions.Items.Add(item.Key, item.Value);
                return professions;
            }
        }

        internal void Optimize()
        {
            var professions = Databases.Tables.Professions
                .Except(Databases.Tables.Professions.Active)
                .ToArray();

            foreach (var profession in professions)
                profession.Delete();
        }
    }

    public class Warranties : Table<Warranty>
    {
        public Warranties()
        {
            TableName = "Warranties";
            Parameters.Add(new OleDbParameter("Customer", OleDbType.VarWChar, sizeof(char) * 50));
            Parameters.Add(new OleDbParameter("Order", OleDbType.SmallInt));
            Parameters.Add(new OleDbParameter("Percent", OleDbType.Single));
            Parameters.Add(new OleDbParameter("WarrantyDate", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("AreaId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("BrigadeId", OleDbType.Integer));
        }
    }

    public class Areas : Table<Area>
    {
        public Areas()
        {
            TableName = "Areas";
            Parameters.Add(new OleDbParameter("Code", OleDbType.SmallInt));
            Parameters.Add(new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 50));
            Parameters.Add(new OleDbParameter("Begin", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("End", OleDbType.DBDate));
        }

        public Areas Active
        {
            get
            {
                var areas = new Areas();
                var temp = Databases.Tables.Areas.Items
                    .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
                    .ToArray();
                foreach (var area in temp) areas.Items.Add(area.Key, area.Value);
                return areas;
            }
        }

        internal void Optimize()
        {
            var areas = Databases.Tables.Areas
             .Except(Databases.Tables.Areas.Active)
             .Where(r => r.Warranties.Count().Equals(0))
             .ToArray();

            foreach (var area in areas)
                Databases.Tables.Areas.Delete(area);
        }
    }

    public class Positions : Table<Position>
    {
        public Positions()
        {
            TableName = "Positions";
            Parameters.Add(new OleDbParameter("WarrantyId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 50));
            Parameters.Add(new OleDbParameter("Draw", OleDbType.VarWChar, sizeof(char) * 50));
            Parameters.Add(new OleDbParameter("Matherial", OleDbType.VarWChar, sizeof(char) * 50));
            Parameters.Add(new OleDbParameter("Number", OleDbType.SmallInt));
            Parameters.Add(new OleDbParameter("Mass", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Norm", OleDbType.Single));
            Parameters.Add(new OleDbParameter("Price", OleDbType.Single));
        }
    }

    public class Executors : Table<Executor>
    {
        public Executors()
        {
            TableName = "Executors";
            Parameters.Add(new OleDbParameter("WarrantyId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("PersonId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("ProfessionId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("Rank", OleDbType.UnsignedTinyInt));
        }
    }

    public class Labors : Table<Labor>
    {
        public Labors()
        {
            TableName = "Labors";
            Parameters.Add(new OleDbParameter("WarrantyId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("LaborDate", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("Hours", OleDbType.Single));
        }
    }

    public class Brigades : Table<Brigade>
    {
        public Brigades()
        {
            TableName = "Brigades";
            Parameters.Add(new OleDbParameter("AreaId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("Code", OleDbType.UnsignedTinyInt));
            Parameters.Add(new OleDbParameter("Title", OleDbType.VarWChar, sizeof(char) * 63));
            Parameters.Add(new OleDbParameter("Begin", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("End", OleDbType.DBDate));
        }

        public Brigades Active
        {
            get
            {
                var brigades = new Brigades();
                var items = Databases.Tables.Brigades.Items
                    .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
                    .ToArray();
                foreach (var item in items) brigades.Items.Add(item.Key, item.Value);
                return brigades;
            }
        }

        internal void Optimize()
        {
            var brigades = Databases.Tables.Brigades
                .Except(Databases.Tables.Brigades.Active)
                .Where(r => r.Warranties.Count().Equals(0))
                .ToArray();

            foreach (var brigade in brigades)
                Databases.Tables.Brigades.Delete(brigade);
        }
    }

    public class BrigadePersons : Table<BrigadePerson>
    {
        public BrigadePersons()
        {
            TableName = "BrigadePersons";

            Parameters.Add(new OleDbParameter("BrigadeId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("PersonId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("Begin", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("End", OleDbType.DBDate));
        }

        public BrigadePersons Active
        {
            get
            {
                var brigadePersons = new BrigadePersons();
                var items = Databases.Tables.BrigadePersons.Items
                    .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
                    .ToArray();
                foreach (var item in items) brigadePersons.Items.Add(item.Key, item.Value);
                return brigadePersons;
            }
        }
    }

    public class PersonProfessions : Table<PersonProfession>
    {
        public PersonProfessions()
        {
            TableName = "PersonProfessions";

            Parameters.Add(new OleDbParameter("PersonId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("ProfessionId", OleDbType.Integer));
            Parameters.Add(new OleDbParameter("Rank", OleDbType.UnsignedTinyInt));
            Parameters.Add(new OleDbParameter("Begin", OleDbType.DBDate));
            Parameters.Add(new OleDbParameter("End", OleDbType.DBDate));
        }

        public PersonProfessions Active
        {
            get
            {
                var personProfessions = new PersonProfessions();
                var items = Databases.Tables.PersonProfessions.Items
                    .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
                    .ToArray();
                foreach (var item in items) personProfessions.Items.Add(item.Key, item.Value);
                return personProfessions;
            }
        }
    }

    public class Tables
    {
        public Professions Professions = new Professions();
        public Persons Persons = new Persons();
        public PersonProfessions PersonProfessions = new PersonProfessions();
        public Areas Areas = new Areas();
        public Brigades Brigades = new Brigades();
        public BrigadePersons BrigadePersons = new BrigadePersons();
        public Warranties Warranties = new Warranties();
        public Positions Positions = new Positions();
        public Executors Executors = new Executors();
        public Labors Labors = new Labors();

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

        internal void Load(OleDbConnection connection)
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
            Areas.Optimize();
            Brigades.Optimize();
            Persons.Optimize();
            Professions.Optimize();
        }
    }
}
