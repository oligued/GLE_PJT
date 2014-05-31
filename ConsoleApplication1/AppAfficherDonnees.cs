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

            List<String> listeDesCinemas = new List<String>();
            
            listeDesCinemas = Cinemas.ObtenirListeCinemas(); 

            // print a set of column headers
            Console.WriteLine("Id       Nom             Nb places       Adresse                 Telephone");
            Console.WriteLine("---      ------------    ------------    ------------------      ------------");

            listeDesCinemas.ForEach(item => Console.WriteLine(item));

            Console.WriteLine("Appuyer sur une touche pour quitter...");
            Console.ReadLine();
        }

    }
}
