using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Delegate_Action_Func
{
    class Program
    {
        delegate void DelegateHelloWorld(string name);

        static void Main(string[] args)
        {            
            /* *******************************************************
             * 
             * Declare a delegate to encapsulate a method
             * 
             * *******************************************************/
            //conventional way to delegate a functoin to a reference
            DelegateHelloWorld helloWorld = SayHello;
            helloWorld("Hong Yi Chao");


            /* **************************************************************************
             * 
             * use Action<T> to encapsulate a method that doesn't return anything
             * 
             * ***************************************************************************/

            //using Action<T> delegate when encapsulating a method that does not return a value
            Action<string> sayHello = SayHello;
            sayHello("Hong-Yi Chao");

            //using Action<T> delegate with anonymous method that takes 2 parameters            
            Action<string, string> showYourInformation = delegate (string name, string email) {
                Console.WriteLine("Your Name is: " + name);
                Console.WriteLine("Your email is: " + email);
                Console.WriteLine();
            };
            showYourInformation("Hong Yi Chao", "hongyichao@github.com");

            //using Action<T> delegate with a method that is defined by using Lambda expression and takes 3 parameters
            Action<string, string, string> displayYourInformation = (string name, string email, string phone) => {
                Console.WriteLine("Your Name is " + name);
                Console.WriteLine("Your Email is " + email);
                Console.WriteLine("Your Phone is " + phone);
                Console.WriteLine();
            };
            displayYourInformation("Hong Yi Chao", "hongyichao@github.com", "0440123456");


            List<Student> li = new List<Student>();
            li.Add(new Student() { name = "Hong Yi Chao", email = "hongyichao@github.com", phone = "0404321654" });
            li.Add(new Student() { name = "Lucas Chao", email = "lucaschao@github.com", phone = "0404321658" });
            li.Add(new Student() { name = "Terry Chao", email = "terrychao@github.com", phone = "0404321659" });
            li.Add(new Student() { name = "John Chao", email = "johnchao@github.com", phone = "0404321653" });

            //the signature of List.ForEach is ForEach(Action<Student> action), so you should pass in Action<T>
            //pass in Lambda expression method
            li.ForEach((Student obj) => {
                Console.WriteLine("Your Name is " + obj.name);
                Console.WriteLine("Your Email is " + obj.email);
                Console.WriteLine("Your Phone is " + obj.phone);
                Console.WriteLine();
            });

            //explicitly use DisplayStudentInfo()
            li.ForEach(DisplayStudentInfo);


            /* **************************************************************************
            * 
            * use Func<T> to encapsulate a method that returns something
            * 
            * ***************************************************************************/
            Func<int, int, int> landPriceCalculator = CalculateLandPrice;

            int landPrice = landPriceCalculator(500, 800);
            Console.WriteLine("Your land is $" + landPrice + " dollars");
            Console.WriteLine();

            //use lambda expression
            Func<List<eBayItem>, int> calculateTotalCost = (List<eBayItem> shoppingCartItems) =>
            {
                int totalCost = 0;

                shoppingCartItems.ForEach((eBayItem item) => {

                    totalCost += item.price;
                });

                return totalCost;
            };

            List<eBayItem> items = new List<eBayItem>();

            items.Add(new eBayItem() { name = "Computer Mouse", price = 20 });
            items.Add(new eBayItem() { name = "Computer Monitor", price = 220 });

            int totalShoppingCost = calculateTotalCost(items);

            Console.WriteLine("The total cost is " + calculateTotalCost(items) + ". Thank you for shopping on eBay");
            Console.WriteLine();

            CookingRobot.CookDinner = (string selection) => { return selection + " will be delivered in  5minutes. Please Wait."; };
            Console.WriteLine(CookingRobot.CookDinner("Katsudon"));
            Console.WriteLine();

            Console.ReadKey();
        }

        public static int CalculateLandPrice(int sqm, int unitPrice)
        {

            return sqm * unitPrice;

        }



        public static void DisplayStudentInfo(Student obj)
        {
            Console.WriteLine("Your Name is " + obj.name);
            Console.WriteLine("Your Email is " + obj.email);
            Console.WriteLine("Your Phone is " + obj.phone);
            Console.WriteLine();
        }

        public static void SayHello(string name)
        {

            Console.WriteLine("Hello ~ " + name);
            Console.WriteLine();
        }
    }
}
