using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review1
{
    public class Class1
    {
       
       
          public  int a = 10;
          public  int b = 20;
        
    }
    public class Class2:Class1
    {
        public void Add()
        {
            int c = a + b;
            Console.WriteLine(c);
        }
    }
}
