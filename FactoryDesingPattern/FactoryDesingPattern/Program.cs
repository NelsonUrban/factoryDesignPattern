using System;

namespace FactoryDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            MemberShipFactory obj = new ConcreteFactory();

            Console.WriteLine("Which membership Charges do you wants ?");

            string type = Console.ReadLine();
            IGymChages intance = obj.GetGymMembershipChagesType(type);

            Console.WriteLine(intance.GetChages());
            Console.ReadLine();
        }

        public interface IGymChages // Product
        {
            int GetChages();
        }

        public class Monthly : IGymChages //Croncrete product
        {
            public int GetChages()
            {
                return 1000;
            }
        }

        public class Yearly : IGymChages //Croncrete product
        {
            public int GetChages()
            {
                return 4000;
            }
        }

        public abstract class MemberShipFactory // Factory  class Creator
        {
            public abstract IGymChages GetGymMembershipChagesType(string type);
        }

        public class ConcreteFactory : MemberShipFactory  // Concrete Creator
        {
            public override IGymChages GetGymMembershipChagesType(string type)
            {
                switch (type)
                {
                    case "monthy":
                        return new Monthly();

                    case "yearly":
                        return new Yearly();

                    default:
                        throw new Exception( $"the type of {type} is not already implemented");
                }
            }
        }

    }
}
