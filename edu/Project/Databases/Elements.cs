using System;
using System.Data.OleDb;
using System.Linq;

namespace Project.Databases
{
    public interface ITableRow
    {
        int Id { get; set; }
    }

    public abstract class TableRow : ITableRow
    {
        protected int _Id;
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }
    }

    public interface IPeriodicTableRow<T> : ITableRow
    {
        DateTime Begin { get; }
        DateTime End { get; }
        bool IsActive { get; }
        bool IsUsed { get; }
        T Clone();
        void Update(T item);
        void Delete();
    }

    public abstract class PeriodicTableRow<T> : TableRow, IPeriodicTableRow<T> where T : PeriodicTableRow<T>
    {
        protected DateTime _Begin;
        protected DateTime _End;

        public DateTime Begin
        {
            get
            {
                return this._Begin;
            }
            set
            {
                T item = this.Clone();
                item._Begin = value;
                this.Update(item);
            }
        }
        public DateTime End
        {
            get
            {
                return this._End;
            }
            set
            {
                T item = this.Clone();
                item._End = value;
                this.Update(item);
            }
        }

        public bool IsActive
        {
            get
            {
                return this.Begin.CompareTo(DateTime.Now) <= 0 && this.End.CompareTo(DateTime.Now) > 0;
            }
        }
        public abstract bool IsUsed { get; }
        public abstract T Clone();
        public abstract void Update(T item);
        public abstract void Delete();

    }

    public class Person : PeriodicTableRow<Person>, IEquatable<Person>
    {
        public Person(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._Code = Convert.ToInt16(reader["Code"]);
            this._FirstName = Convert.ToString(reader["FirstName"]);
            this._MiddleName = Convert.ToString(reader["MiddleName"]);
            this._LastName = Convert.ToString(reader["LastName"]);
            this._Begin = Convert.ToDateTime(reader["Begin"]);
            this._End = Convert.ToDateTime(reader["End"]);
        }
        public Person(short Code, string FirstName, string MiddleName, string LastName)
        {
            this._Id = 0;
            this._Code = Code;
            this._FirstName = FirstName;
            this._MiddleName = MiddleName;
            this._LastName = LastName;
            this._Begin = DateTime.Now.Date;
            this._End = new DateTime(9000, 1, 1);
        }
        public Person(short Code, string FirstName, string MiddleName, string LastName, DateTime Begin, DateTime End)
        {
            this._Id = 0;
            this._Code = Code;
            this._FirstName = FirstName;
            this._MiddleName = MiddleName;
            this._LastName = LastName;
            this._Begin = Begin;
            this._End = End;
        }

        private short _Code;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;

        public short Code { get { return this._Code; } }
        public string FirstName { get { return this._FirstName; } }
        public string MiddleName { get { return this._MiddleName; } }
        public string LastName { get { return this._LastName; } }
        public BrigadePersons BrigadePersons
        {
            get
            {
                BrigadePersons brigadePersons = new BrigadePersons();
                brigadePersons.Clear();
                var items = Data.Tables.BrigadePersons._Items.Where(r => r.Value.PersonId.Equals(this.Id)).ToArray();
                foreach (var item in items) brigadePersons._Items.Add(item.Key, item.Value);
                return brigadePersons;
            }
        }
        public Executors Executors
        {
            get
            {
                Executors executors = new Executors();
                var items = Data.Tables.Executors._Items.Where(r => r.Value.PersonId.Equals(this.Id)).ToArray();
                foreach (var item in items) executors._Items.Add(item.Key, item.Value);
                return executors;
            }
        }
        public PersonProfessions PersonProfessions
        {
            get
            {
                PersonProfessions personeProfessions = new PersonProfessions();
                var items = Data.Tables.PersonProfessions._Items.Where(r => r.Value.PersonId.Equals(this.Id)).ToArray();
                foreach (var item in items) personeProfessions._Items.Add(item.Key, item.Value);
                return personeProfessions;
            }
        }

        public override bool IsUsed
        {
            get
            {
                return !this.Executors.Count().Equals(0);
            }
        }

        public override Person Clone()
        {
            return new Person(this.Code, this.FirstName, this.MiddleName, this.LastName, this.Begin, this.End);
        }

        public override void Update(Person newItem)
        {
            Data.Tables.Persons.Update(this, newItem);
        }
        public override void Delete()
        {
            foreach (BrigadePerson brigadePerson in this.BrigadePersons)
                brigadePerson.Delete();
            foreach (PersonProfession personProfession in this.PersonProfessions)
                personProfession.Delete();

            if (this.IsUsed)
            {
                Person item = this.Clone();
                item._End = DateTime.Now.Date;
                this.Update(item);
            }
            else
                Data.Tables.Persons.Delete(this);
        }

        public bool Equals(Person other)
        {
            if (
             this._Code.Equals(other._Code) &&
             this._FirstName.Equals(other._FirstName) &&
             this._MiddleName.Equals(other._MiddleName) &&
             this._LastName.Equals(other._LastName) &&
             this._Begin.Equals(other._Begin) &&
             this._End.Equals(other._End)
             )
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Person))
                throw new InvalidCastException("The 'obj' argument is not a Person object.");
            else
                return Equals(obj as Person);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.Code.GetHashCode().ToString() +
             this.FirstName.GetHashCode().ToString() +
             this.MiddleName.GetHashCode().ToString() +
             this.LastName.GetHashCode().ToString() +
             this.Begin.GetHashCode().ToString() +
             this.End.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Profession : PeriodicTableRow<Profession>, IEquatable<Profession>
    {
        public Profession(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._Code = Convert.ToInt16(reader["Code"]);
            this._Title = Convert.ToString(reader["Title"]);
            this._Rank1 = Convert.ToSingle(reader["Rank1"]);
            this._Rank2 = Convert.ToSingle(reader["Rank2"]);
            this._Rank3 = Convert.ToSingle(reader["Rank3"]);
            this._Rank4 = Convert.ToSingle(reader["Rank4"]);
            this._Rank5 = Convert.ToSingle(reader["Rank5"]);
            this._Rank6 = Convert.ToSingle(reader["Rank6"]);
            this._Begin = Convert.ToDateTime(reader["Begin"]);
            this._End = Convert.ToDateTime(reader["End"]);
        }
        public Profession(short Code, string Title, float Rank1, float Rank2, float Rank3, float Rank4, float Rank5, float Rank6)
        {
            this._Id = 0;
            this._Code = Code;
            this._Title = Title;
            this._Rank1 = Rank1;
            this._Rank2 = Rank2;
            this._Rank3 = Rank3;
            this._Rank4 = Rank4;
            this._Rank5 = Rank5;
            this._Rank6 = Rank6;
            this._Begin = DateTime.Now.Date;
            this._End = new DateTime(9000, 1, 1);
        }
        public Profession(short Code, string Title, float Rank1, float Rank2, float Rank3, float Rank4, float Rank5, float Rank6, DateTime Begin, DateTime End)
        {
            this._Id = 0;
            this._Code = Code;
            this._Title = Title;
            this._Rank1 = Rank1;
            this._Rank2 = Rank2;
            this._Rank3 = Rank3;
            this._Rank4 = Rank4;
            this._Rank5 = Rank5;
            this._Rank6 = Rank6;
            this._Begin = Begin;
            this._End = End;
        }

        private short _Code;
        private string _Title;
        private float _Rank1;
        private float _Rank2;
        private float _Rank3;
        private float _Rank4;
        private float _Rank5;
        private float _Rank6;


        public short Code { get { return this._Code; } }
        public string Title { get { return this._Title; } }
        public float Rank1 { get { return this._Rank1; } }
        public float Rank2 { get { return this._Rank2; } }
        public float Rank3 { get { return this._Rank3; } }
        public float Rank4 { get { return this._Rank4; } }
        public float Rank5 { get { return this._Rank5; } }
        public float Rank6 { get { return this._Rank6; } }
        public PersonProfessions PersonProfessions
        {
            get
            {
                PersonProfessions personProfessions = new PersonProfessions();
                var items = Data.Tables.PersonProfessions._Items.Where(r => r.Value.ProfessionId.Equals(this.Id)).ToArray();
                foreach (var item in items) personProfessions._Items.Add(item.Key, item.Value);
                return personProfessions;
            }
        }
        public Executors Executors
        {
            get
            {
                Executors executors = new Executors();
                var items = Data.Tables.Executors._Items.Where(r => r.Value.ProfessionId.Equals(this.Id)).ToArray();
                foreach (var item in items) executors._Items.Add(item.Key, item.Value);
                return executors;
            }
        }

        public override bool IsUsed
        {
            get
            {
                return !this.Executors.Count().Equals(0);
            }
        }

        public override Profession Clone()
        {
            return new Profession(this.Code, this.Title,
             this.Rank1, this.Rank2, this.Rank3, this.Rank4, this.Rank5, this.Rank6,
             this.Begin, this.End);
        }

        public override void Update(Profession newItem)
        {
            Data.Tables.Professions.Update(this, newItem);
        }
        public override void Delete()
        {
            foreach (PersonProfession personProfession in this.PersonProfessions)
                personProfession.Delete();
            if (this.IsUsed)
            {
                Profession item = this.Clone();
                item._End = DateTime.Now.Date;
                this.Update(item);
            }
            else
                Data.Tables.Professions.Delete(this);
        }

        public bool Equals(Profession other)
        {
            if (
             this._Code.Equals(other._Code) &&
             this._Title.Equals(other._Title) &&
             this._Rank1.Equals(other._Rank1) &&
             this._Rank2.Equals(other._Rank2) &&
             this._Rank3.Equals(other._Rank3) &&
             this._Rank4.Equals(other._Rank4) &&
             this._Rank5.Equals(other._Rank5) &&
             this._Rank6.Equals(other._Rank6) &&
             this._Begin.Equals(other._Begin) &&
             this._End.Equals(other._End)
             )
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Profession))
                throw new InvalidCastException("The 'obj' argument is not a Profession object...");
            else
                return Equals(obj as Profession);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.Code.GetHashCode().ToString() +
             this.Title.GetHashCode().ToString() +
             this.Rank1.GetHashCode().ToString() +
             this.Rank2.GetHashCode().ToString() +
             this.Rank3.GetHashCode().ToString() +
             this.Rank4.GetHashCode().ToString() +
             this.Rank5.GetHashCode().ToString() +
             this.Rank6.GetHashCode().ToString() +
             this.Begin.GetHashCode().ToString() +
             this.End.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Warranty : TableRow, IEquatable<Warranty>
    {
        public Warranty(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._Customer = Convert.ToString(reader["Customer"]);
            this._Order = Convert.ToInt16(reader["Order"]);
            this._Percent = Convert.ToSingle(reader["Percent"]);
            this._WarrantyDate = Convert.ToDateTime(reader["WarrantyDate"]);
            this._AreaId = Convert.ToInt32(reader["AreaId"]);
            this._BrigadeId = Convert.ToInt32(reader["BrigadeId"]);
        }
        public Warranty(string Customer, short Order, float Percent, DateTime WarrantyDate, int AreaId, int BrigadeId)
        {
            this._Id = 0;
            this._Customer = Customer;
            this._Order = Order;
            this._Percent = Percent;
            this._WarrantyDate = WarrantyDate;
            this._AreaId = AreaId;
            this._BrigadeId = BrigadeId;
        }

        private string _Customer;
        private short _Order;
        private float _Percent;
        private DateTime _WarrantyDate;
        private int _AreaId;
        private int _BrigadeId;

        public string Customer { get { return this._Customer; } }
        public short Order { get { return this._Order; } }
        public float Percent { get { return this._Percent; } }
        public DateTime WarrantyDate { get { return this._WarrantyDate; } }
        public int AreaId { get { return this._AreaId; } }
        public int BrigadeId { get { return this._BrigadeId; } }
        public Executors Executors
        {
            get
            {
                Executors executors = new Executors();
                var items = Data.Tables.Executors._Items.Where(r => r.Value.WarrantyId.Equals(this.Id)).ToArray();
                foreach (var item in items) executors._Items.Add(item.Key, item.Value);
                return executors;
            }
        }
        public Labors Labors
        {
            get
            {
                Labors labors = new Labors();
                var items = Data.Tables.Labors._Items.Where(r => r.Value.WarrantyId.Equals(this.Id)).ToArray();
                foreach (var item in items) labors._Items.Add(item.Key, item.Value);
                return labors;
            }
        }
        public Positions Positions
        {
            get
            {
                Positions positions = new Positions();
                var items = Data.Tables.Positions._Items.Where(r => r.Value.WarrantyId.Equals(this.Id)).ToArray();
                foreach (var item in items) positions._Items.Add(item.Key, item.Value);
                return positions;
            }
        }

        public void Update(Warranty newItem)
        {
            Data.Tables.Warranties.Update(this, newItem);
        }
        public void Delete()
        {
            foreach (Position position in this.Positions)
                position.Delete();
            foreach (Executor executor in this.Executors)
                executor.Delete();
            Data.Tables.Warranties.Delete(this);
        }

        public bool Equals(Warranty other)
        {
            if (this._Customer.Equals(other._Customer) &&
             this._Order.Equals(other._Order) &&
             this._Percent.Equals(other._Percent) &&
             this._WarrantyDate.Equals(other._WarrantyDate) &&
             this._AreaId.Equals(other._AreaId) &&
             this._BrigadeId.Equals(other._BrigadeId))
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Warranty))
                throw new InvalidCastException("The 'obj' argument is not a Warranty object.");
            else
                return Equals(obj as Warranty);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.Customer.GetHashCode().ToString() +
             this.Order.GetHashCode().ToString() +
             this.Percent.GetHashCode().ToString() +
             this.WarrantyDate.GetHashCode().ToString() +
             this.AreaId.GetHashCode().ToString() +
             this.BrigadeId.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Area : PeriodicTableRow<Area>, IEquatable<Area>
    {
        public Area(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._Code = Convert.ToByte(reader["Code"]);
            this._Title = Convert.ToString(reader["Title"]);
            this._Begin = Convert.ToDateTime(reader["Begin"]);
            this._End = Convert.ToDateTime(reader["End"]);
        }
        public Area(byte Code, string Title)
        {
            this._Id = 0;
            this._Code = Code;
            this._Title = Title;
            this._Begin = DateTime.Now.Date;
            this._End = new DateTime(9000, 1, 1);
        }
        public Area(byte Code, string Title, DateTime Begin, DateTime End)
        {
            this._Id = 0;
            this._Code = Code;
            this._Title = Title;
            this._Begin = Begin;
            this._End = End;
        }

        private byte _Code;
        private string _Title;

        public byte Code { get { return this._Code; } }
        public string Title { get { return this._Title; } }
        public Brigades Brigades
        {
            get
            {
                Brigades brigades = new Brigades();
                var items = Data.Tables.Brigades._Items
                 .Where(r => r.Value.AreaId.Equals(this.Id))
                 .ToArray();
                foreach (var item in items) brigades._Items.Add(item.Key, item.Value);
                return brigades;
            }
        }
        public Warranties Warranties
        {
            get
            {
                Warranties warranties = new Warranties();
                var items = Data.Tables.Warranties._Items.Where(r => r.Value.BrigadeId.Equals(this.Id)).ToArray();
                foreach (var item in items) warranties._Items.Add(item.Key, item.Value);
                return warranties;
            }
        }

        public override bool IsUsed
        {
            get
            {
                return !this.Warranties.Count().Equals(0);
            }
        }

        public override Area Clone()
        {
            return new Area(this.Code, this.Title, this.Begin, this.End);
        }

        public override void Update(Area newItem)
        {
            Data.Tables.Areas.Update(this, newItem);
        }
        public override void Delete()
        {
            foreach (Brigade brigade in this.Brigades)
                brigade.Delete();
            if (this.IsUsed)
            {
                Area item = this.Clone();
                item._End = DateTime.Now.Date;
                this.Update(item);
            }
            else
                Data.Tables.Areas.Delete(this);
        }

        public bool Equals(Area other)
        {
            if (
             this._Code.Equals(other._Code) &&
             this._Title.Equals(other._Title) &&
             this._Begin.Equals(other._Begin) &&
             this._End.Equals(other._End)
             )
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Area))
                throw new InvalidCastException("The 'obj' argument is not a Area object.");
            else
                return Equals(obj as Area);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.Code.GetHashCode().ToString() +
             this.Title.GetHashCode().ToString() +
             this.Begin.GetHashCode().ToString() +
             this.End.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Position : TableRow, IEquatable<Position>
    {
        public Position(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._WarrantyId = Convert.ToInt32(reader["WarrantyId"]);
            this._Title = Convert.ToString(reader["Title"]);
            this._Draw = Convert.ToString(reader["Draw"]);
            this._Matherial = Convert.ToString(reader["Matherial"]);
            this._Number = Convert.ToInt32(reader["Number"]);
            this._Mass = Convert.ToSingle(reader["Mass"]);
            this._Norm = Convert.ToSingle(reader["Norm"]);
            this._Price = Convert.ToSingle(reader["Price"]);
        }
        public Position(int WarrantyId, string Title, string Draw, string Matherial, int Number, float Mass, float Norm, float Price)
        {
            this._Id = 0;
            this._WarrantyId = WarrantyId;
            this._Title = Title;
            this._Draw = Draw;
            this._Matherial = Matherial;
            this._Number = Number;
            this._Mass = Mass;
            this._Norm = Norm;
            this._Price = Price;
        }

        private int _WarrantyId;
        private string _Title;
        private string _Draw;
        private string _Matherial;
        private int _Number;
        private float _Mass;
        private float _Norm;
        private float _Price;

        public int WarrantyId { get { return this._WarrantyId; } }
        public string Title { get { return this._Title; } }
        public string Draw { get { return this._Draw; } }
        public string Matherial { get { return this._Matherial; } }
        public int Number { get { return this._Number; } }
        public float Mass { get { return this._Mass; } }
        public float Norm { get { return this._Norm; } }
        public float Price { get { return this._Price; } }


        public void Update(Position newItem)
        {
            Data.Tables.Positions.Update(this, newItem);
        }
        public void Delete()
        {
            Data.Tables.Positions.Delete(this);
        }

        public bool Equals(Position other)
        {
            if (this._WarrantyId.Equals(other._WarrantyId) &&
             this._Title.Equals(other._Title) &&
             this._Draw.Equals(other._Draw) &&
             this._Matherial.Equals(other._Matherial) &&
             this._Number.Equals(other._Number) &&
             this._Mass.Equals(other._Mass) &&
             this._Norm.Equals(other._Norm) &&
             this._Price.Equals(other._Price))
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Position))
                throw new InvalidCastException("The 'obj' argument is not a Position object.");
            else
                return Equals(obj as Position);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.WarrantyId.GetHashCode().ToString() +
             this.Title.GetHashCode().ToString() +
             this.Draw.GetHashCode().ToString() +
             this.Matherial.GetHashCode().ToString() +
             this.Number.GetHashCode().ToString() +
             this.Mass.GetHashCode().ToString() +
             this.Norm.GetHashCode().ToString() +
             this.Price.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Executor : TableRow, IEquatable<Executor>
    {
        public Executor(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._WarrantyId = Convert.ToInt32(reader["WarrantyId"]);
            this._PersonId = Convert.ToInt32(reader["PersonId"]);
            this._ProfessionId = Convert.ToInt32(reader["ProfessionId"]);
            this._Rank = Convert.ToByte(reader["Rank"]);
        }
        public Executor(int WarrantyId, int PersonId, int ProfessionId, byte Rank)
        {
            this._Id = 0;
            this._WarrantyId = WarrantyId;
            this._PersonId = PersonId;
            this._ProfessionId = ProfessionId;
            this._Rank = Rank;
        }

        private int _WarrantyId;
        private int _PersonId;
        private int _ProfessionId;
        private byte _Rank;

        public int WarrantyId { get { return this._WarrantyId; } }
        public int PersonId { get { return this._PersonId; } }
        public int ProfessionId { get { return this._ProfessionId; } }
        public byte Rank { get { return this._Rank; } }
        public Person Person
        {
            get
            {
                return Data.Tables.Persons[this._PersonId];
            }
        }
        public Profession Profession
        {
            get
            {
                return Data.Tables.Professions[this._ProfessionId];
            }
        }
        public Labors Labors
        {
            get
            {
                Labors labors = new Labors();
                var items = Data.Tables.Labors._Items.Where(r => r.Value.WarrantyId.Equals(this.Id)).ToArray();
                foreach (var item in items) labors._Items.Add(item.Key, item.Value);
                return labors;
            }
        }

        public void Update(Executor newItem)
        {
            Data.Tables.Executors.Update(this, newItem);
        }
        public void Delete()
        {
            foreach (Labor labor in this.Labors)
                labor.Delete();
            Data.Tables.Executors.Delete(this);
        }

        public bool Equals(Executor other)
        {
            if (this._WarrantyId.Equals(other._WarrantyId) &&
             this._PersonId.Equals(other._PersonId) &&
             this._ProfessionId.Equals(other._ProfessionId) &&
             this._Rank.Equals(other._Rank))
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Executor))
                throw new InvalidCastException("The 'obj' argument is not a Executor object.");
            else
                return Equals(obj as Executor);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.WarrantyId.GetHashCode().ToString() +
             this.PersonId.GetHashCode().ToString() +
             this.ProfessionId.GetHashCode().ToString() +
             this.Rank.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Labor : TableRow, IEquatable<Labor>
    {
        public Labor(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._WarrantyId = Convert.ToInt32(reader["WarrantyId"]);
            this._LaborDate = Convert.ToDateTime(reader["LaborDate"]);
            this._Hours = Convert.ToSingle(reader["Hours"]);
        }
        public Labor(int WarrantyId, DateTime LaborDate, float Hours)
        {
            this._Id = 0;
            this._WarrantyId = WarrantyId;
            this._LaborDate = LaborDate;
            this._Hours = Hours;
        }

        private int _WarrantyId;
        private DateTime _LaborDate;
        private float _Hours;

        public int WarrantyId { get { return this._WarrantyId; } }
        public DateTime LaborDate { get { return this._LaborDate; } }
        public float Hours { get { return this._Hours; } }

        public void Update(Labor newItem)
        {
            Data.Tables.Labors.Update(this, newItem);
        }
        public void Delete()
        {
            Data.Tables.Labors.Delete(this);
        }

        public bool Equals(Labor other)
        {
            if (this._WarrantyId.Equals(other._WarrantyId) &&
             this._LaborDate.Equals(other._LaborDate) &&
             this._Hours.Equals(other._Hours)
             )
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Labor))
                throw new InvalidCastException("The 'obj' argument is not a Labor object.");
            else
                return Equals(obj as Labor);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.WarrantyId.GetHashCode().ToString() +
             this.LaborDate.GetHashCode().ToString() +
             this.Hours.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class Brigade : PeriodicTableRow<Brigade>, IEquatable<Brigade>
    {
        public Brigade(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._AreaId = Convert.ToInt32(reader["AreaId"]);
            this._Code = Convert.ToByte(reader["Code"]);
            this._Title = Convert.ToString(reader["Title"]);
            this._Begin = Convert.ToDateTime(reader["Begin"]);
            this._End = Convert.ToDateTime(reader["End"]);
        }
        public Brigade(int AreaId, byte Code, string Title)
        {
            this._Id = 0;
            this._AreaId = AreaId;
            this._Code = Code;
            this._Title = Title;
            this._Begin = DateTime.Now.Date;
            this._End = new DateTime(9000, 1, 1);
        }
        public Brigade(int AreaId, byte Code, string Title, DateTime Begin, DateTime End)
        {
            this._Id = 0;
            this._AreaId = AreaId;
            this._Code = Code;
            this._Title = Title;
            this._Begin = Begin;
            this._End = End;
        }

        private int _AreaId;
        private byte _Code;
        private string _Title;

        public int AreaId { get { return this._AreaId; } }
        public byte Code { get { return this._Code; } }
        public string Title { get { return this._Title; } }
        public Area Area { get { return Data.Tables.Areas[this.AreaId]; } }
        public BrigadePersons BrigadePersons
        {
            get
            {
                BrigadePersons brigadePersons = new BrigadePersons();
                brigadePersons.Clear();
                var items = Data.Tables.BrigadePersons._Items.Where(r => r.Value.BrigadeId.Equals(this.Id)).ToArray();
                foreach (var item in items) brigadePersons._Items.Add(item.Key, item.Value);
                return brigadePersons;
            }
        }
        public Warranties Warranties
        {
            get
            {
                Warranties warranties = new Warranties();
                var items = Data.Tables.Warranties._Items.Where(r => r.Value.BrigadeId.Equals(this.Id)).ToArray();
                foreach (var item in items) warranties._Items.Add(item.Key, item.Value);
                return warranties;
            }
        }

        public override bool IsUsed
        {
            get
            {
                return !this.Warranties.Count().Equals(0);
            }
        }

        public override Brigade Clone()
        {
            return new Brigade(this.AreaId, this.Code, this.Title, this.Begin, this.End);
        }

        public override void Update(Brigade newItem)
        {
            Data.Tables.Brigades.Update(this, newItem);
        }
        public override void Delete()
        {
            foreach (BrigadePerson brigadePerson in this.BrigadePersons)
                brigadePerson.Delete();
            if (this.IsUsed)
            {
                Brigade item = this.Clone();
                item._End = DateTime.Now.Date;
                this.Update(item);
            }
            else
                Data.Tables.Brigades.Delete(this);
        }

        public bool Equals(Brigade other)
        {
            if (
             this._Code.Equals(other._Code) &&
             this._Title.Equals(other._Title) &&
             this._AreaId.Equals(other._AreaId) &&
             this._Begin.Equals(other._Begin) &&
             this._End.Equals(other._End)
             )
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Brigade))
                throw new InvalidCastException("The 'obj' argument is not a Brigade object.");
            else
                return Equals(obj as Brigade);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.AreaId.GetHashCode().ToString() +
             this.Code.GetHashCode().ToString() +
             this.Title.GetHashCode().ToString() +
             this.Begin.GetHashCode().ToString() +
             this.End.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class BrigadePerson : PeriodicTableRow<BrigadePerson>, IEquatable<BrigadePerson>
    {
        public BrigadePerson(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._BrigadeId = Convert.ToInt32(reader["BrigadeId"]);
            this._PersonId = Convert.ToInt32(reader["PersonId"]);
            this._Begin = Convert.ToDateTime(reader["Begin"]);
            this._End = Convert.ToDateTime(reader["End"]);
        }
        public BrigadePerson(int BrigadeId, int PersonId)
        {
            this._Id = 0;
            this._BrigadeId = BrigadeId;
            this._PersonId = PersonId;
            this._Begin = DateTime.Now.Date;
            this._End = new DateTime(9000, 1, 1);
        }
        public BrigadePerson(int BrigadeId, int PersonId, DateTime Begin, DateTime End)
        {
            this._Id = 0;
            this._BrigadeId = BrigadeId;
            this._PersonId = PersonId;
            this._Begin = Begin;
            this._End = End;
        }

        private int _BrigadeId;
        private int _PersonId;

        public int BrigadeId { get { return this._BrigadeId; } }
        public int PersonId { get { return this._PersonId; } }
        public Brigade Brigade
        {
            get
            {
                return Data.Tables.Brigades[this.BrigadeId];
            }
        }
        public Person Person
        {
            get
            {
                return Data.Tables.Persons[this._PersonId];
            }
        }

        public override bool IsUsed
        {
            get
            {
                return (!this.Brigade.Warranties.Count().Equals(0)) || (!this.Person.Executors.Count().Equals(0));

            }
        }

        public override BrigadePerson Clone()
        {
            return new BrigadePerson(this.BrigadeId, this.PersonId, this.Begin, this.End);
        }

        public override void Update(BrigadePerson newItem)
        {
            Data.Tables.BrigadePersons.Update(this, newItem);
        }
        public override void Delete()
        {
            if (this.IsUsed)
            {
                BrigadePerson item = this.Clone();
                item._End = DateTime.Now.Date;
                this.Update(item);
            }
            else
                Data.Tables.BrigadePersons.Delete(this);
        }

        public bool Equals(BrigadePerson other)
        {
            if (this._BrigadeId.Equals(other._BrigadeId) &&
             this._PersonId.Equals(other._PersonId) &&
             this._Begin.Equals(other._Begin) &&
             this._End.Equals(other._End))
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is BrigadePerson))
                throw new InvalidCastException("The 'obj' argument is not a BrigadePerson object.");
            else
                return Equals(obj as BrigadePerson);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.BrigadeId.GetHashCode().ToString() +
             this.PersonId.GetHashCode().ToString() +
             this.Begin.GetHashCode().ToString() +
             this.End.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }

    public class PersonProfession : PeriodicTableRow<PersonProfession>, IEquatable<PersonProfession>
    {
        public PersonProfession(OleDbDataReader reader)
        {
            this._Id = Convert.ToInt32(reader["Id"]);
            this._PersonId = Convert.ToInt32(reader["PersonId"]);
            this._ProfessionId = Convert.ToInt32(reader["ProfessionId"]);
            this._Rank = Convert.ToByte(reader["Rank"]);
            this._Begin = Convert.ToDateTime(reader["Begin"]);
            this._End = Convert.ToDateTime(reader["End"]);
        }
        public PersonProfession(int PersonId, int ProfessionId, byte Rank)
        {
            this._Id = 0;
            this._PersonId = PersonId;
            this._ProfessionId = ProfessionId;
            this._Rank = Rank;
            this._Begin = Begin;
            this._End = End;
        }
        public PersonProfession(int PersonId, int ProfessionId, byte Rank, DateTime Begin, DateTime End)
        {
            this._Id = 0;
            this._PersonId = PersonId;
            this._ProfessionId = ProfessionId;
            this._Rank = Rank;
            this._Begin = Begin;
            this._End = End;
        }

        private int _PersonId;
        private int _ProfessionId;
        private byte _Rank;

        public int PersonId { get { return this._PersonId; } }
        public int ProfessionId { get { return this._ProfessionId; } }
        public byte Rank { get { return this._Rank; } }
        public Person Person
        {
            get
            {
                return Data.Tables.Persons[this.PersonId];
            }
        }
        public Profession Profession
        {
            get
            {
                return Data.Tables.Professions[this._ProfessionId];
            }
        }

        public override bool IsUsed
        {
            get
            {
                return this.Person.IsUsed;
            }
        }

        public override PersonProfession Clone()
        {
            return new PersonProfession(this.PersonId, this.ProfessionId, this.Rank, this.Begin, this.End);
        }

        public override void Update(PersonProfession newItem)
        {
            Data.Tables.PersonProfessions.Update(this, newItem);
        }
        public override void Delete()
        {
            if (this.IsUsed)
            {
                PersonProfession item = this.Clone();
                item._End = DateTime.Now.Date;
                this.Update(item);
            }
            else
                Data.Tables.PersonProfessions.Delete(this);
        }

        public bool Equals(PersonProfession other)
        {
            if (this._PersonId.Equals(other._PersonId) &&
             this._ProfessionId.Equals(other._ProfessionId) &&
             this._Rank.Equals(other._Rank) &&
             this._Begin.Equals(other._Begin) &&
             this._End.Equals(other._End))
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is PersonProfession))
                throw new InvalidCastException("The 'obj' argument is not a PersonProfession object.");
            else
                return Equals(obj as PersonProfession);
        }
        public override int GetHashCode()
        {
            string hash =
             this.Id.GetHashCode().ToString() +
             this.PersonId.GetHashCode().ToString() +
             this.ProfessionId.GetHashCode().ToString() +
             this.Begin.GetHashCode().ToString() +
             this.End.GetHashCode().ToString();
            return hash.GetHashCode();
        }
    }
}