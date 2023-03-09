using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review1
{
    public class Compare
    {
        public static void LenghtCompare ()
        {
            int x1,y1, x2, y2;
            int x3,y3,x4,y4;
            Console.WriteLine("Enter cordinate of line one x1");
            x1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line one x2");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line one y1");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line one y2");
            y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line Two x3");
            x3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line Two x4");
            x4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line Two y3");
            y3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cordinate of line Two y4");
            y4 = Convert.ToInt32(Console.ReadLine());

            
            double calculation1 = Math.Sqrt((Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))); 
            double calculation2 = Math.Sqrt((Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2)));

            Console.WriteLine("Lenght of line one"+calculation1);
            Console.WriteLine("Lenght of line Two" + calculation2); 

            if (calculation1 < calculation2)
            {
                Console.WriteLine("Line Two is grater then Line One");
            }
            else
            {
                Console.WriteLine("Line one is grater then Line Two");
            }



        }
        

           
    }
   
  
}
