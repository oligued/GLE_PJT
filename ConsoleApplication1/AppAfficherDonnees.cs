using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using petitPateLib.Logic;

namespace petitPate.Cmd
{
    class AppAfficherDonnees
    {
        static void Main(string[] args)
        {


            var monPathe = new PetitPate();
            
            var c = monPathe.GetCinemaByName("rex 1");

            Console.WriteLine(c.Name);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c);
            Console.ReadKey();




        }

    }
}
