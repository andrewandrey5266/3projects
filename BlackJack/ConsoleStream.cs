using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class ConsoleStream
    {
        public int Input()
        {
            while (true)
            {
                string str = Console.ReadLine();

                int response;
                int.TryParse(str, out response);

                if (response != 1 && response != 2)
                {
                    Console.Write("Wrong input, try again!\n");
                    continue;
                }
                else
                    return response;
            }
        }
        public void Output(string str)
        {
            Console.Write(str);
        }
    }
}
