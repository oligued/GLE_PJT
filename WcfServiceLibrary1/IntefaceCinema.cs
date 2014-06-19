using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace petitPateLib.Logic
{


    [ServiceContract]
    public interface IPetitPateCinema
    {
        [OperationContract]
        Cinema GetCinemaByName(string name);
        [OperationContract]
        List<Cinema> GetAllCinemas();
    }



    /// <summary>
    /// Classe de logique
    /// </summary>
    public class PetitPateCinema : IPetitPateCinema
    {
        /// <summary>
        /// Classe pour récupérer un cinéma par rapprot à son nom
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>null si pas trouvé</returns>
        public Cinema GetCinemaByName(string name)
        {
            Cinema c = null;


            if (!string.IsNullOrWhiteSpace(name))
            {
                using (var ctx = new petitPateBDDEntities())
                {

                    ctx.Configuration.ProxyCreationEnabled = false;
                    c = ctx.Cinema.FirstOrDefault(x => x.Name.Equals(name));

                    var c2 = from z in ctx.Cinema
                             where z.Emplacement1.Adresse.Equals(name)
                             select z;
                }

            }

            return c;
        }

        /// <summary>
        /// Classe pour récupérer la lsite des cinémas avec leurs infos
        /// </summary>
        /// <param name="name">aucun</param>
        /// <returns>null si pas trouvé</returns>
        public List<Cinema> GetAllCinemas()
        {

            var ctx = new petitPateBDDEntities();
            List<Cinema> listeCinemas = ctx.Cinema.ToList();

            return listeCinemas;

        }


        Cinema IPetitPateCinema.GetCinemaByName(string name)
        {
            throw new NotImplementedException();
        }

        List<Cinema> IPetitPateCinema.GetAllCinemas()
        {
            throw new NotImplementedException();
        }
    }
}
