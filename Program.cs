using IOApplication;

namespace IOApp
{
    class Person
    {
        public int _id { get; private set; }
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public Person(int id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }
    }

    class Address
    {
        public int _id { get; private set; }
        public string _street { get; private set; }

        public Address(int id, string street)
        {
            _id = id;
            _street = street;
        }
    }

    class Program
    {

        public static void Main(string[] args)
        {
            var num = new List<int> { 1, 2, 3, 4, 5 };
            var num2 = new List<int> { 2, 2, 2, 69, -420 };

            var str1 = new List<string> { "Hello", "World", "I", "Am", "Here" };
            var capsStr2 = new List<string> { "HELLO", "WORLD", "I", "AM", "HERE", "really" };

            num.MySelect(x => x * 2).ToList().ForEach(x => Console.WriteLine(x));
            num.MyWhere(x => x == 5).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine(num.MyFirst());
            Console.WriteLine(num.MyCount());
            Console.WriteLine(num.MyCount(x => x > 2));
            Console.WriteLine(num.Aggregate(0, (a, i) => a + i));
            Console.WriteLine(num2.Aggregate(0, (a, i) => a + i));
            Console.WriteLine(num2.MyAggregate(0, (a, i) => a + i));

            //Returns MAXIMUM element from the list
            Console.WriteLine(num2.MyAggregate(0, (a, i) =>
            {
                if (a > i) return a;
                return i;
            }));

            //Returns MINIMUM element from the list
            Console.WriteLine(num2.MyAggregate(0, (a, i) =>
           {
               if (a < i) return a;
               return i;
           }));
            var combined = num2.MyConcat(num);
            var num3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var num4 = new List<int> { 1, 2, 3, 4, 5 };

            num3.MyExcept(num4).ToList().ForEach(Console.WriteLine);
            num3.MyIntersect(num4).ToList().ForEach(Console.WriteLine);

            var union = num3.MyUnion(num4);
            var union2 = str1.MyUnion(capsStr2, StringComparer.CurrentCultureIgnoreCase);

            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            foreach (var item in union2)
            {
                Console.WriteLine(item);
                var source = new List<int> { 1, 2, 3 };
                source.GroupBy(x => x % 2).ToList().ForEach(x => Console.WriteLine(x.Key));
                var dictionary = source.MyToDictionary<int, int, int>(x => x, x => x * x);
            }

            var personDb = new[]
            {
                new Person(1,"Riyaz", "Doe"),
                new Person(2,"Tom", "Doe"),
                new Person(3,"Sarah", "Smith"),
                new Person(4,"Jack", "Smith"),
            };

            var addressDb = new[]
            {
                new Address(1, "Mumbai 4090"),
                new Address(1, "Vashi 4091"),
                new Address(2, "Borivali 4092"),
                new Address(2, "Andheri 4093"),
                new Address(3, "Govandi 4082")
            };

            var result = personDb.MyJoin(
                addressDb,
                p => p._id,
                a => a._id,
                (p, a) => string.Format("An Address for {0} is {1}", p._firstName, a._street),
                EqualityComparer<int>.Default);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
