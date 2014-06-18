using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace petitPateLib.Logic
{

    
    [ServiceContract]
    public interface IPetitPateMovie
    {
        [OperationContract]Movie GetMovieByTitle(string title);
        [OperationContract]List<Movie> GetAllMovies();
    }



    /// <summary>
    /// Classe de logique
    /// </summary>
    public class PetitPateMovie : IPetitPateMovie
    {
        /// <summary>
        /// Classe pour récupérer un filme à l'affiche (UC001)
        /// </summary>
        /// <param name="name">title</param>
        /// <returns>null si pas trouvé</returns>
        public Movie GetMovieByTitle(string title)
        {
            Movie m = null;


            if (!string.IsNullOrWhiteSpace(title))
            {
                var ctx = new petitPateBDDEntities();

                m = ctx.Movie.FirstOrDefault(x => x.Title.Equals(title));

                var cat = from z in ctx.Movie
                         where z.Movie_category.Movie.Equals(title)
                         select z;                
            }

            return m;
        }

        /// <summary>
        /// Classe pour récupérer la lsite des films
        /// </summary>
        /// <param name="name">aucun</param>
        /// <returns>null si pas trouvé</returns>
        public List<Movie> GetAllMovies()
        {

            var ctx = new petitPateBDDEntities();
            List<Movie> listeMovies = ctx.Movie.ToList();

            return listeMovies;

        }
            
    }
}
