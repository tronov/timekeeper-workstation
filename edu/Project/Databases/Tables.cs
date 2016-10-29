using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace Project.Databases
{
 public abstract class Table<T> : IEnumerable<T>
  where T : ITableRow
 {
  protected internal Dictionary<int, T> _Items = new Dictionary<int, T>();

  protected internal OleDbDataReader reader;

  public bool IsEmpty
  {
   get { return this._Items.Count.Equals(0); }
  }

  public T this[int id]
  {
   get { return this._Items[id]; }
  }

  public int GetIdByValue(T item)
  {
   foreach (var i in this._Items)
    if (i.Value.Equals(item)) return i.Key;
   return 0;
  }

  public int NextId
  {
   get
   {
    int id;
    if (this._Items.Keys.Count != 0) id = this._Items.Keys.Max() + 1;
    else id = 1;
    return id;
   }
  }

  internal void Clear()
  {
   this._Items.Clear();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
   return this._Items.GetEnumerator();
  }
  public IEnumerator<T> GetEnumerator()
  {
   return this._Items.Values.GetEnumerator();
  }


  public string TableName;

  public OleDbCommand Command = new OleDbCommand();

  public List<OleDbParameter> Parameters = new List<OleDbParameter>();

  public int Insert(T item)
  {
   int id = this.NextId;
   item.Id = id;
   OleDbParameter pId = new OleDbParameter("Id", OleDbType.Integer);
   pId.Value = id;
   Command.Parameters.Add(pId);
   string comParams = "", comVals = "";
   comParams += "([Id], ";
   comVals += "(?, ";   
   foreach (OleDbParameter parameter in Parameters)
   {
    comParams += String.Format("[{0}], ", parameter.ParameterName);
    comVals += "?, ";
   }
   comParams = comParams.Remove(comParams.Length - 2);
   comVals = comVals.Remove(comVals.Length - 2);
   comParams += ")";
   comVals += ")";

   string comText = String.Format("INSERT INTO {0} {1} VALUES {2};", TableName, comParams, comVals);
   foreach (OleDbParameter parameter in Parameters)
   {
    parameter.Value = item.GetType().GetProperty(parameter.ParameterName).GetValue(item, null);
    Command.Parameters.Add(parameter);
   }

   Command.CommandText = comText;
   Command.Connection = Data.Connection;
   Command.Connection.Open();
   Command.ExecuteNonQuery();
   Command.Parameters.Clear();
   Command.Connection.Close();

   this._Items.Add(id, item);
   return id;
  }

  public void Update(T item, T newItem)
  {
   newItem.Id = item.Id;
   int id = GetIdByValue(item);
   OleDbParameter pId = new OleDbParameter("Id", OleDbType.Integer);
   pId.Value = id;
   

   string comItems = "";

   //comItems += "(";
   foreach (OleDbParameter parameter in Parameters)
   {
    comItems += String.Format(" [{0}] = ?, ", parameter.ParameterName);
    parameter.Value = newItem.GetType().GetProperty(parameter.ParameterName).GetValue(newItem, null);
    Command.Parameters.Add(parameter);
   }
   comItems = comItems.Remove(comItems.Length - 2);
   //comItems += ")";

   Command.Parameters.Add(pId);


   Command.CommandText = String.Format("UPDATE {0} SET {1} WHERE [Id] = ?;", TableName, comItems);
   Command.Connection = Data.Connection;
   Command.Connection.Open();
   Command.ExecuteNonQuery();
   Command.Parameters.Clear();
   Command.Connection.Close();

   this._Items[id] = newItem;
  }

  public void Delete(T item)
  {
   int id = GetIdByValue(item);
   if (id != 0)
   {
    OleDbParameter pId = new OleDbParameter("Id", OleDbType.Integer);
    pId.Value = id;

    Command.Connection = Data.Connection;
    Command.CommandText = String.Format("DELETE * FROM [{0}] WHERE [Id] = ?;", TableName);
    Command.Parameters.Add(pId);

    Command.Connection.Open();
    Command.ExecuteNonQuery();
    Command.Parameters.Clear();
    Command.Connection.Close();

    this._Items.Remove(id);
   }
  }

  public void Load(OleDbConnection connection)
  {
   Command.Connection = connection;
   Command.CommandText = String.Format("SELECT * FROM {0};", TableName);
   OleDbDataReader reader = Command.ExecuteReader();
   while (reader.Read())
   {
    int id = Convert.ToInt32(reader["Id"]);
    T item = (T)Activator.CreateInstance(typeof(T), new object[] { reader });

    this._Items.Add(id, item);
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
    Persons persons = new Persons();
    var _Items = Data.Tables.Persons._Items
     .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
     .ToArray();
    foreach (var item in _Items)
     persons._Items.Add(item.Key, item.Value);
    return persons;
   }
  }

  internal void Optimize()
  {
   Person[] persons = Data.Tables.Persons
    .Except(Data.Tables.Persons.Active)
    .Where(r => r.Executors.Count().Equals(0))
    .ToArray();

   foreach (Person person in persons)
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
    Professions professions = new Professions();
    var _Items = Data.Tables.Professions._Items
     .Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0)
     .ToArray();
    foreach (var item in _Items)
     professions._Items.Add(item.Key, item.Value);
    return professions;
   }
  }

  internal void Optimize()
  {
   Profession[] professions = Data.Tables.Professions
    .Except(Data.Tables.Professions.Active)
    .ToArray();

   foreach (Profession profession in professions)
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
    Areas areas = new Areas();
    var temp = Data.Tables.Areas._Items.Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0).ToArray();
    foreach (var area in temp) areas._Items.Add(area.Key, area.Value);
    return areas;
   }
  }

  internal void Optimize()
  {
   Area[] areas = Data.Tables.Areas
    .Except(Data.Tables.Areas.Active)
    .Where(r => r.Warranties.Count().Equals(0))
    .ToArray();

   foreach (Area area in areas)
    Data.Tables.Areas.Delete(area);
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
    Brigades brigades = new Brigades();
    var _Items = Data.Tables.Brigades._Items.Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0).ToArray();
    foreach (var item in _Items) brigades._Items.Add(item.Key, item.Value);
    return brigades;
   }
  }

  internal void Optimize()
  {
   Brigade[] brigades = Data.Tables.Brigades
    .Except(Data.Tables.Brigades.Active)
    .Where(r => r.Warranties.Count().Equals(0))
    .ToArray();

   foreach (Brigade brigade in brigades)
    Data.Tables.Brigades.Delete(brigade);
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
    BrigadePersons brigadePersons = new BrigadePersons();
    var _Items = Data.Tables.BrigadePersons._Items.Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0).ToArray();
    foreach (var item in _Items) brigadePersons._Items.Add(item.Key, item.Value);
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
    PersonProfessions personProfessions = new PersonProfessions();
    var _Items = Data.Tables.PersonProfessions._Items.Where(r => r.Value.Begin.CompareTo(DateTime.Now) <= 0 && r.Value.End.CompareTo(DateTime.Now) > 0).ToArray();
    foreach (var item in _Items) personProfessions._Items.Add(item.Key, item.Value);
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

  public bool IsEmpty
  {
   get
   {
    if (
     Professions.IsEmpty &&
     Persons.IsEmpty &&
     PersonProfessions.IsEmpty &&
     Areas.IsEmpty &&
     Brigades.IsEmpty &&
     BrigadePersons.IsEmpty &&
     Warranties.IsEmpty &&
     Positions.IsEmpty &&
     Executors.IsEmpty &&
     Labors.IsEmpty)
     return true;
    else return false;
   }
  }

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
