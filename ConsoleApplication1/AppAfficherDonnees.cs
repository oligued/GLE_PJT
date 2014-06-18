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


            var monCinema = new PetitPateCinema();
            var monFilm = new PetitPateMovie();
            
            //var c = monPathe.GetCinemaByName("rex 1");

            List<Cinema> listAllCinemas = monCinema.GetAllCinemas();
            List<Movie> listAllMovies = monFilm.GetAllMovies();

            Console.WriteLine("Liste des cinemas (nom, nb de places, emplacement, adresse, tél.):");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Cinema unCinema in listAllCinemas)
            {
                Console.WriteLine(unCinema.ToString() + " " + unCinema.Nb_Places + " " + unCinema.Emplacement1.Name + unCinema.Emplacement1.Adresse + unCinema.Emplacement1.Phone);
            }

            Console.WriteLine("*******************************************************************");
            Console.WriteLine(" ");

            Console.WriteLine("Liste des films à l'affiche(type, synposis, poducteur, categorie.):");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Movie unFilm in listAllMovies)
            {
                Console.WriteLine(unFilm.Title + ": " + unFilm.Synopsis + " " + unFilm.Producer + " " + unFilm.Movie_category.Title + " ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }

            Console.ReadKey();
        }

    }
}
