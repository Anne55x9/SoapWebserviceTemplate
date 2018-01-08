using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace SoapClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1"))
            {
                Console.WriteLine("Udregning af value1:");

                
                Console.WriteLine("Boksens volumen er:" + client.GetValue1(2, 2, 2));

                Console.WriteLine("Udregning af value2:");

                Console.WriteLine("Boksens manglende side er:" + client.GetValue2(8, 2, 2));

                client.InsertTableXX("volume", 8, 2, 2, 2);

                ClassModel[] allrequest = client.GetAllTableXX();
                foreach (var reg in allrequest)
                {
                    Console.WriteLine(reg.Navn);
                }
            }

            Console.ReadLine();
        }
    }
}
