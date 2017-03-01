using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Project.Data
{
    public interface ITableRow
    {
        int Id { get; set; }
    }

    public abstract class TableRow : ITableRow
    {
        public int Id { get; set; }
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
        private DateTime _begin;
        private DateTime _end;

        protected PeriodicTableRow(DateTime begin, DateTime end)
        {
            _begin = begin;
            _end = end;
        }

        public DateTime Begin
        {
            get
            {
                return _begin;
            }
            set
            {
                var item = Clone();
                item._begin = value;
                Update(item);
            }
        }
        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                var item = Clone();
                item._end = value;
                Update(item);
            }
        }

        public bool IsActive => Begin.CompareTo(DateTime.Now) <= 0 && End.CompareTo(DateTime.Now) > 0;

        public abstract bool IsUsed { get; }
        public abstract T Clone();
        public abstract void Update(T item);
        public abstract void Delete();

    }

    public class Person : PeriodicTableRow<Person>, IEquatable<Person>
    {
        public Person(IDataRecord record)
            : base(Convert.ToDateTime(record["Begin"]), Convert.ToDateTime(record["End"]))
        {
            Id = Convert.ToInt32(record["Id"]);
            Code = Convert.ToInt16(record["Code"]);
            FirstName = Convert.ToString(record["FirstName"]);
            MiddleName = Convert.ToString(record["MiddleName"]);
            LastName = Convert.ToString(record["LastName"]);
        }

        public Person(short code, string firstName, string middleName, string lastName)
            : this(code, firstName, middleName, lastName, DateTime.Now.Date, new DateTime(9000, 1, 1)) { }


        public Person(short code, string firstName, string middleName, string lastName, DateTime begin, DateTime end)
            : base(begin, end)
        {
            Id = 0;
            Code = code;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public short Code { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public BrigadePersons BrigadePersons
        {
            get
            {
                var brigadePersons = new BrigadePersons();
                brigadePersons.Clear();
                var items = Databases.Tables.BrigadePersons.Items.Where(r => r.Value.PersonId.Equals(Id)).ToArray();
                foreach (var item in items) brigadePersons.Items.Add(item.Key, item.Value);
                return brigadePersons;
            }
        }
        public Executors Executors
        {
            get
            {
                var executors = new Executors();
                var items = Databases.Tables.Executors.Items.Where(r => r.Value.PersonId.Equals(Id)).ToArray();
                foreach (var item in items) executors.Items.Add(item.Key, item.Value);
                return executors;
            }
        }
        public PersonProfessions PersonProfessions
        {
            get
            {
                var personeProfessions = new PersonProfessions();
                var items = Databases.Tables.PersonProfessions.Items.Where(r => r.Value.PersonId.Equals(Id)).ToArray();
                foreach (var item in items) personeProfessions.Items.Add(item.Key, item.Value);
                return personeProfessions;
            }
        }

        public override bool IsUsed => !Executors.Count().Equals(0);

        public override Person Clone()
        {
            return new Person(Code, FirstName, MiddleName, LastName, Begin, End);
        }

        public override void Update(Person newItem)
        {
            Databases.Tables.Persons.Update(this, newItem);
        }

        public override void Delete()
        {
            foreach (var brigadePerson in BrigadePersons)
                brigadePerson.Delete();
            foreach (var personProfession in PersonProfessions)
                personProfession.Delete();

            if (IsUsed)
            {
                var item = new Person(Code, FirstName, MiddleName, LastName, Begin, DateTime.Now.Date);
                Update(item);
            }
            else
                Databases.Tables.Persons.Delete(this);
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;

            return Code.Equals(other.Code) &&
                   FirstName.Equals(other.FirstName) &&
                   MiddleName.Equals(other.MiddleName) &&
                   LastName.Equals(other.LastName) &&
                   Begin.Equals(other.Begin) &&
                   End.Equals(other.End);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Person))
                throw new InvalidCastException("The 'obj' argument is not a Person object.");
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                Code.GetHashCode() +
                FirstName.GetHashCode() +
                MiddleName.GetHashCode() +
                LastName.GetHashCode() +
                Begin.GetHashCode() +
                End.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Profession : PeriodicTableRow<Profession>, IEquatable<Profession>
    {
        public Profession(IDataRecord record)
            : base(Convert.ToDateTime(record["Begin"]), Convert.ToDateTime(record["End"]))
        {
            Id = Convert.ToInt32(record["Id"]);
            Code = Convert.ToInt16(record["Code"]);
            Title = Convert.ToString(record["Title"]);
            Rank1 = Convert.ToSingle(record["Rank1"]);
            Rank2 = Convert.ToSingle(record["Rank2"]);
            Rank3 = Convert.ToSingle(record["Rank3"]);
            Rank4 = Convert.ToSingle(record["Rank4"]);
            Rank5 = Convert.ToSingle(record["Rank5"]);
            Rank6 = Convert.ToSingle(record["Rank6"]);
        }

        public Profession(short code, string title, float rank1, float rank2, float rank3, float rank4, float rank5, float rank6)
            : this(code, title, rank1, rank2, rank3, rank4, rank5, rank6, DateTime.Now.Date, new DateTime(9000, 1, 1)) { }

        public Profession(short code, string title, float rank1, float rank2, float rank3, float rank4, float rank5, float rank6, DateTime begin, DateTime end)
            : base(begin, end)
        {
            Id = 0;
            Code = code;
            Title = title;
            Rank1 = rank1;
            Rank2 = rank2;
            Rank3 = rank3;
            Rank4 = rank4;
            Rank5 = rank5;
            Rank6 = rank6;
        }


        public short Code { get; }
        public string Title { get; }
        public float Rank1 { get; }
        public float Rank2 { get; }
        public float Rank3 { get; }
        public float Rank4 { get; }
        public float Rank5 { get; }
        public float Rank6 { get; }

        public PersonProfessions PersonProfessions
        {
            get
            {
                var personProfessions = new PersonProfessions();
                var items = Databases.Tables.PersonProfessions.Items.Where(r => r.Value.ProfessionId.Equals(Id)).ToArray();
                foreach (var item in items) personProfessions.Items.Add(item.Key, item.Value);
                return personProfessions;
            }
        }

        public Executors Executors
        {
            get
            {
                var executors = new Executors();
                var items = Databases.Tables.Executors.Items.Where(r => r.Value.ProfessionId.Equals(Id)).ToArray();
                foreach (var item in items) executors.Items.Add(item.Key, item.Value);
                return executors;
            }
        }

        public override bool IsUsed => !Executors.Count().Equals(0);

        public override Profession Clone()
        {
            return new Profession(Code, Title, Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Begin, End);
        }

        public override void Update(Profession newItem)
        {
            Databases.Tables.Professions.Update(this, newItem);
        }

        public override void Delete()
        {
            foreach (var personProfession in PersonProfessions)
                personProfession.Delete();
            if (IsUsed)
            {
                var item = new Profession(Code, Title, Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Begin, DateTime.Now.Date);
                Update(item);
            }
            else
                Databases.Tables.Professions.Delete(this);
        }

        public bool Equals(Profession other)
        {
            if (other == null) return false;

            return Code.Equals(other.Code) &&
                   Title.Equals(other.Title) &&
                   Rank1.Equals(other.Rank1) &&
                   Rank2.Equals(other.Rank2) &&
                   Rank3.Equals(other.Rank3) &&
                   Rank4.Equals(other.Rank4) &&
                   Rank5.Equals(other.Rank5) &&
                   Rank6.Equals(other.Rank6) &&
                   Begin.Equals(other.Begin) &&
                   End.Equals(other.End);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Profession))
                throw new InvalidCastException("The 'obj' argument is not a Profession object...");
            return Equals(obj as Profession);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                Code.GetHashCode() +
                Title.GetHashCode() +
                Rank1.GetHashCode() +
                Rank2.GetHashCode() +
                Rank3.GetHashCode() +
                Rank4.GetHashCode() +
                Rank5.GetHashCode() +
                Rank6.GetHashCode() +
                Begin.GetHashCode() +
                End.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Warranty : TableRow, IEquatable<Warranty>
    {
        public Warranty(IDataRecord record)
        {
            Id = Convert.ToInt32(record["Id"]);
            Customer = Convert.ToString(record["Customer"]);
            Order = Convert.ToInt16(record["Order"]);
            Percent = Convert.ToSingle(record["Percent"]);
            WarrantyDate = Convert.ToDateTime(record["WarrantyDate"]);
            AreaId = Convert.ToInt32(record["AreaId"]);
            BrigadeId = Convert.ToInt32(record["BrigadeId"]);
        }

        public Warranty(string customer, short order, float percent, DateTime warrantyDate, int areaId, int brigadeId)
        {
            Id = 0;
            Customer = customer;
            Order = order;
            Percent = percent;
            WarrantyDate = warrantyDate;
            AreaId = areaId;
            BrigadeId = brigadeId;
        }

        public string Customer { get; }
        public short Order { get; }
        public float Percent { get; }
        public DateTime WarrantyDate { get; }
        public int AreaId { get; }
        public int BrigadeId { get; }

        public Executors Executors
        {
            get
            {
                var executors = new Executors();
                var items = Databases.Tables.Executors.Items.Where(r => r.Value.WarrantyId.Equals(Id)).ToArray();
                foreach (var item in items) executors.Items.Add(item.Key, item.Value);
                return executors;
            }
        }

        public Labors Labors
        {
            get
            {
                var labors = new Labors();
                var items = Databases.Tables.Labors.Items.Where(r => r.Value.WarrantyId.Equals(Id)).ToArray();
                foreach (var item in items) labors.Items.Add(item.Key, item.Value);
                return labors;
            }
        }

        public Positions Positions
        {
            get
            {
                var positions = new Positions();
                var items = Databases.Tables.Positions.Items.Where(r => r.Value.WarrantyId.Equals(Id)).ToArray();
                foreach (var item in items) positions.Items.Add(item.Key, item.Value);
                return positions;
            }
        }

        public void Update(Warranty newItem)
        {
            Databases.Tables.Warranties.Update(this, newItem);
        }

        public void Delete()
        {
            foreach (var position in Positions)
                position.Delete();
            foreach (var executor in Executors)
                executor.Delete();
            Databases.Tables.Warranties.Delete(this);
        }

        public bool Equals(Warranty other)
        {
            if (other == null) return false;

            return Customer.Equals(other.Customer) &&
                   Order.Equals(other.Order) &&
                   Percent.Equals(other.Percent) &&
                   WarrantyDate.Equals(other.WarrantyDate) &&
                   AreaId.Equals(other.AreaId) &&
                   BrigadeId.Equals(other.BrigadeId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Warranty))
                throw new InvalidCastException("The 'obj' argument is not a Warranty object.");

            return Equals((Warranty) obj);
        }
        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                Customer.GetHashCode() +
                Order.GetHashCode() +
                Percent.GetHashCode() +
                WarrantyDate.GetHashCode() +
                AreaId.GetHashCode() +
                BrigadeId.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Area : PeriodicTableRow<Area>, IEquatable<Area>
    {
        public Area(IDataRecord record) : base(Convert.ToDateTime(record["Begin"]), Convert.ToDateTime(record["End"]))
        {
            Id = Convert.ToInt32(record["Id"]);
            Code = Convert.ToByte(record["Code"]);
            Title = Convert.ToString(record["Title"]);
        }

        public Area(byte code, string title) : this(code, title, DateTime.Now.Date, new DateTime(9000, 1, 1)) { }

        public Area(byte code, string title, DateTime begin, DateTime end) : base(begin, end)
        {
            Id = 0;
            Code = code;
            Title = title;
        }

        public byte Code { get; }
        public string Title { get; }

        public Brigades Brigades
        {
            get
            {
                var brigades = new Brigades();
                var items = Databases.Tables.Brigades.Items
                    .Where(r => r.Value.AreaId.Equals(Id))
                    .ToArray();
                foreach (var item in items) brigades.Items.Add(item.Key, item.Value);
                return brigades;
            }
        }

        public Warranties Warranties
        {
            get
            {
                var warranties = new Warranties();
                var items = Databases.Tables.Warranties.Items.Where(r => r.Value.BrigadeId.Equals(Id)).ToArray();
                foreach (var item in items) warranties.Items.Add(item.Key, item.Value);
                return warranties;
            }
        }

        public override bool IsUsed => !Warranties.Count().Equals(0);

        public override Area Clone()
        {
            return new Area(Code, Title, Begin, End);
        }

        public override void Update(Area newItem)
        {
            Databases.Tables.Areas.Update(this, newItem);
        }

        public override void Delete()
        {
            foreach (var brigade in Brigades)
                brigade.Delete();
            if (IsUsed)
            {
                var item = new Area(Code, Title, Begin, DateTime.Now.Date);
                Update(item);
            }
            else
                Databases.Tables.Areas.Delete(this);
        }

        public bool Equals(Area other)
        {
            if (other == null) return false;

            return Code.Equals(other.Code) &&
                   Title.Equals(other.Title) &&
                   Begin.Equals(other.Begin) &&
                   End.Equals(other.End);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Area))
                throw new InvalidCastException("The 'obj' argument is not an Area object.");
            return Equals((Area) obj);
        }
        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                Code.GetHashCode() +
                Title.GetHashCode() +
                Begin.GetHashCode() +
                End.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Position : TableRow, IEquatable<Position>
    {
        public Position(IDataRecord record)
        {
            Id = Convert.ToInt32(record["Id"]);
            WarrantyId = Convert.ToInt32(record["WarrantyId"]);
            Title = Convert.ToString(record["Title"]);
            Draw = Convert.ToString(record["Draw"]);
            Matherial = Convert.ToString(record["Matherial"]);
            Number = Convert.ToInt32(record["Number"]);
            Mass = Convert.ToSingle(record["Mass"]);
            Norm = Convert.ToSingle(record["Norm"]);
            Price = Convert.ToSingle(record["Price"]);
        }

        public Position(int warrantyId, string title, string draw, string matherial, int number, float mass, float norm, float price)
        {
            Id = 0;
            WarrantyId = warrantyId;
            Title = title;
            Draw = draw;
            Matherial = matherial;
            Number = number;
            Mass = mass;
            Norm = norm;
            Price = price;
        }

        public int WarrantyId { get; }
        public string Title { get; }
        public string Draw { get; }
        public string Matherial { get; }
        public int Number { get; }
        public float Mass { get; }
        public float Norm { get; }
        public float Price { get; }


        public void Update(Position newItem)
        {
            Databases.Tables.Positions.Update(this, newItem);
        }

        public void Delete()
        {
            Databases.Tables.Positions.Delete(this);
        }

        public bool Equals(Position other)
        {
            if (other == null) return false;

            return WarrantyId.Equals(other.WarrantyId) &&
                   Title.Equals(other.Title) &&
                   Draw.Equals(other.Draw) &&
                   Matherial.Equals(other.Matherial) &&
                   Number.Equals(other.Number) &&
                   Mass.Equals(other.Mass) &&
                   Norm.Equals(other.Norm) &&
                   Price.Equals(other.Price);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Position))
                throw new InvalidCastException("The 'obj' argument is not a Position object.");
            return Equals((Position) obj);
        }
        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                WarrantyId.GetHashCode() +
                Title.GetHashCode() +
                Draw.GetHashCode() +
                Matherial.GetHashCode() +
                Number.GetHashCode() +
                Mass.GetHashCode() +
                Norm.GetHashCode() +
                Price.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Executor : TableRow, IEquatable<Executor>
    {
        public Executor(IDataRecord record)
        {
            Id = Convert.ToInt32(record["Id"]);
            WarrantyId = Convert.ToInt32(record["WarrantyId"]);
            PersonId = Convert.ToInt32(record["PersonId"]);
            ProfessionId = Convert.ToInt32(record["ProfessionId"]);
            Rank = Convert.ToByte(record["Rank"]);
        }
        public Executor(int warrantyId, int personId, int professionId, byte rank)
        {
            Id = 0;
            WarrantyId = warrantyId;
            PersonId = personId;
            ProfessionId = professionId;
            Rank = rank;
        }

        public int WarrantyId { get; }
        public int PersonId { get; }
        public int ProfessionId { get; }
        public byte Rank { get; }

        public Person Person => Databases.Tables.Persons[PersonId];

        public Profession Profession => Databases.Tables.Professions[ProfessionId];

        public Labors Labors
        {
            get
            {
                var labors = new Labors();
                var items = Databases.Tables.Labors.Items.Where(r => r.Value.WarrantyId.Equals(Id)).ToArray();
                foreach (var item in items) labors.Items.Add(item.Key, item.Value);
                return labors;
            }
        }

        public void Update(Executor newItem)
        {
            Databases.Tables.Executors.Update(this, newItem);
        }

        public void Delete()
        {
            foreach (var labor in Labors)
                labor.Delete();
            Databases.Tables.Executors.Delete(this);
        }

        public bool Equals(Executor other)
        {
            if (other == null) return false;

            return WarrantyId.Equals(other.WarrantyId) &&
                   PersonId.Equals(other.PersonId) &&
                   ProfessionId.Equals(other.ProfessionId) &&
                   Rank.Equals(other.Rank);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Executor))
                throw new InvalidCastException("The 'obj' argument is not a Executor object.");
            return Equals((Executor) obj);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                WarrantyId.GetHashCode() +
                PersonId.GetHashCode() +
                ProfessionId.GetHashCode() +
                Rank.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Labor : TableRow, IEquatable<Labor>
    {
        public Labor(IDataRecord reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            WarrantyId = Convert.ToInt32(reader["WarrantyId"]);
            LaborDate = Convert.ToDateTime(reader["LaborDate"]);
            Hours = Convert.ToSingle(reader["Hours"]);
        }
        public Labor(int warrantyId, DateTime laborDate, float hours)
        {
            Id = 0;
            WarrantyId = warrantyId;
            LaborDate = laborDate;
            Hours = hours;
        }

        public int WarrantyId { get; }
        public DateTime LaborDate { get; }
        public float Hours { get; }

        public void Update(Labor newItem)
        {
            Databases.Tables.Labors.Update(this, newItem);
        }

        public void Delete()
        {
            Databases.Tables.Labors.Delete(this);
        }

        public bool Equals(Labor other)
        {
            if (other == null) return false;

            return WarrantyId.Equals(other.WarrantyId) &&
                   LaborDate.Equals(other.LaborDate) &&
                   Hours.Equals(other.Hours);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Labor))
                throw new InvalidCastException("The 'obj' argument is not a Labor object.");
            return Equals((Labor) obj);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                WarrantyId.GetHashCode() +
                LaborDate.GetHashCode() +
                Hours.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class Brigade : PeriodicTableRow<Brigade>, IEquatable<Brigade>
    {
        public Brigade(IDataRecord record)
            : base(Convert.ToDateTime(record["Begin"]), Convert.ToDateTime(record["End"]))
        {
            Id = Convert.ToInt32(record["Id"]);
            AreaId = Convert.ToInt32(record["AreaId"]);
            Code = Convert.ToByte(record["Code"]);
            Title = Convert.ToString(record["Title"]);
        }

        public Brigade(int areaId, byte code, string title)
            : this(areaId, code, title, DateTime.Now.Date, new DateTime(9000, 1, 1))
        {
            Id = 0;
            AreaId = areaId;
            Code = code;
            Title = title;
        }

        public Brigade(int areaId, byte code, string title, DateTime begin, DateTime end)
            : base(begin, end)
        {
            Id = 0;
            AreaId = areaId;
            Code = code;
            Title = title;
        }

        public int AreaId { get; }
        public byte Code { get; }
        public string Title { get; }
        public Area Area => Databases.Tables.Areas[AreaId];

        public BrigadePersons BrigadePersons
        {
            get
            {
                var brigadePersons = new BrigadePersons();
                brigadePersons.Clear();
                var items = Databases.Tables.BrigadePersons.Items.Where(r => r.Value.BrigadeId.Equals(Id)).ToArray();
                foreach (var item in items) brigadePersons.Items.Add(item.Key, item.Value);
                return brigadePersons;
            }
        }

        public Warranties Warranties
        {
            get
            {
                var warranties = new Warranties();
                var items = Databases.Tables.Warranties.Items.Where(r => r.Value.BrigadeId.Equals(Id)).ToArray();
                foreach (var item in items) warranties.Items.Add(item.Key, item.Value);
                return warranties;
            }
        }

        public override bool IsUsed => !Warranties.Count().Equals(0);

        public override Brigade Clone()
        {
            return new Brigade(AreaId, Code, Title, Begin, End);
        }

        public override void Update(Brigade newItem)
        {
            Databases.Tables.Brigades.Update(this, newItem);
        }

        public override void Delete()
        {
            foreach (var brigadePerson in BrigadePersons)
                brigadePerson.Delete();
            if (IsUsed)
            {
                var item = new Brigade(AreaId, Code, Title, Begin, DateTime.Now.Date);
                Update(item);
            }
            else
                Databases.Tables.Brigades.Delete(this);
        }

        public bool Equals(Brigade other)
        {
            if (other == null) return false;

            return Code.Equals(other.Code) &&
                   Title.Equals(other.Title) &&
                   AreaId.Equals(other.AreaId) &&
                   Begin.Equals(other.Begin) &&
                   End.Equals(other.End);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Brigade))
                throw new InvalidCastException("The 'obj' argument is not a Brigade object.");
            return Equals(obj as Brigade);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                AreaId.GetHashCode() +
                Code.GetHashCode() +
                Title.GetHashCode() +
                Begin.GetHashCode() +
                End.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class BrigadePerson : PeriodicTableRow<BrigadePerson>, IEquatable<BrigadePerson>
    {
        public BrigadePerson(OleDbDataReader reader)
            : base(Convert.ToDateTime(reader["Begin"]), Convert.ToDateTime(reader["End"]))
        {
            Id = Convert.ToInt32(reader["Id"]);
            BrigadeId = Convert.ToInt32(reader["BrigadeId"]);
            PersonId = Convert.ToInt32(reader["PersonId"]);
        }

        public BrigadePerson(int brigadeId, int personId)
            : this(brigadeId, personId, DateTime.Now.Date, new DateTime(9000, 1, 1))
        {
            Id = 0;
            BrigadeId = brigadeId;
            PersonId = personId;
        }

        public BrigadePerson(int brigadeId, int personId, DateTime begin, DateTime end)
            : base(begin, end)
        {
            Id = 0;
            BrigadeId = brigadeId;
            PersonId = personId;
        }

        public int BrigadeId { get; }
        public int PersonId { get; }

        public Brigade Brigade => Databases.Tables.Brigades[BrigadeId];

        public Person Person => Databases.Tables.Persons[PersonId];

        public override bool IsUsed => (!Brigade.Warranties.Count().Equals(0)) || (!Person.Executors.Count().Equals(0));

        public override BrigadePerson Clone()
        {
            return new BrigadePerson(BrigadeId, PersonId, Begin, End);
        }

        public override void Update(BrigadePerson newItem)
        {
            Databases.Tables.BrigadePersons.Update(this, newItem);
        }

        public override void Delete()
        {
            if (IsUsed)
            {
                var item = new BrigadePerson(BrigadeId, PersonId, Begin, DateTime.Now.Date);
                Update(item);
            }
            else
                Databases.Tables.BrigadePersons.Delete(this);
        }

        public bool Equals(BrigadePerson other)
        {
            if (other == null) return false;

            return BrigadeId.Equals(other.BrigadeId) &&
                   PersonId.Equals(other.PersonId) &&
                   Begin.Equals(other.Begin) &&
                   End.Equals(other.End);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is BrigadePerson))
                throw new InvalidCastException("The 'obj' argument is not a BrigadePerson object.");
            return Equals(obj as BrigadePerson);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                BrigadeId.GetHashCode() +
                PersonId.GetHashCode() +
                Begin.GetHashCode() +
                End.GetHashCode();
            return hash.GetHashCode();
        }
    }

    public class PersonProfession : PeriodicTableRow<PersonProfession>, IEquatable<PersonProfession>
    {
        public PersonProfession(IDataRecord reader)
            : base(Convert.ToDateTime(reader["Begin"]), Convert.ToDateTime(reader["End"]))
        {
            Id = Convert.ToInt32(reader["Id"]);
            PersonId = Convert.ToInt32(reader["PersonId"]);
            ProfessionId = Convert.ToInt32(reader["ProfessionId"]);
            Rank = Convert.ToByte(reader["Rank"]);
        }

        public PersonProfession(int personId, int professionId, byte rank)
            : this(personId, professionId, rank, DateTime.Now.Date, new DateTime(9000, 1, 1))
        {
            Id = 0;
            PersonId = personId;
            ProfessionId = professionId;
            Rank = rank;
        }

        public PersonProfession(int personId, int professionId, byte rank, DateTime begin, DateTime end)
            : base(begin, end)
        {
            Id = 0;
            PersonId = personId;
            ProfessionId = professionId;
            Rank = rank;
        }

        public int PersonId { get; }
        public int ProfessionId { get; }
        public byte Rank { get; }

        public Person Person => Databases.Tables.Persons[PersonId];

        public Profession Profession => Databases.Tables.Professions[ProfessionId];

        public override bool IsUsed => Person.IsUsed;

        public override PersonProfession Clone()
        {
            return new PersonProfession(PersonId, ProfessionId, Rank, Begin, End);
        }

        public override void Update(PersonProfession newItem)
        {
            Databases.Tables.PersonProfessions.Update(this, newItem);
        }

        public override void Delete()
        {
            if (IsUsed)
            {
                var item = new PersonProfession(PersonId, ProfessionId, Rank, Begin, DateTime.Now.Date);
                Update(item);
            }
            else
                Databases.Tables.PersonProfessions.Delete(this);
        }

        public bool Equals(PersonProfession other)
        {
            if (other == null) return false;

            return PersonId.Equals(other.PersonId) &&
                   ProfessionId.Equals(other.ProfessionId) &&
                   Rank.Equals(other.Rank) &&
                   Begin.Equals(other.Begin) &&
                   End.Equals(other.End);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is PersonProfession))
                throw new InvalidCastException("The 'obj' argument is not a PersonProfession object.");
            return Equals((PersonProfession) obj);
        }

        public override int GetHashCode()
        {
            var hash =
                Id.GetHashCode() +
                PersonId.GetHashCode() +
                ProfessionId.GetHashCode() +
                Begin.GetHashCode() +
                End.GetHashCode();
            return hash.GetHashCode();
        }
    }
}