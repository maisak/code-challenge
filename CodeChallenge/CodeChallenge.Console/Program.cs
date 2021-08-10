using CodeChallenge.Library;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Customers();
            var cbn = service.GetCustomer("4815162342");
            System.Console.WriteLine($"Customer succesfully retrieved by id {cbn.Number}: {Environment.NewLine}Name: {cbn.Name}{Environment.NewLine}Email: {cbn.Email}");
            var cbe = service.GetCustomer2("lostone@email.com");
            System.Console.WriteLine($"Customer succesfully retrieved by email {cbe.Email}: {Environment.NewLine}Name: {cbe.Name}{Environment.NewLine}Number: {cbe.Number}");
        }
    }
}
