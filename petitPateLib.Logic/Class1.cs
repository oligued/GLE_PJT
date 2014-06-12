using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace petitPateLib.Logic
{

    
    [ServiceContract]
    public interface IPetitPate
    {
        [OperationContract]Cinema GetCinemaByName(string name);

    }
    /// <summary>
    /// Classe de logique
    /// </summary>
    public class PetitPate : IPetitPate
    {
        /// <summary>
        /// Docuemdsfgsdfgsdfg
        /// </summary>
        /// <param name="name">sdfgsdfgsdgfsfg</param>
        /// <returns>null si pas trouvé</returns>
        public Cinema GetCinemaByName(string name)
        {
            Cinema c = null;
            


            if (!string.IsNullOrWhiteSpace(name))
            {
                var ctx = new petitPateBDDEntities();

                c = ctx.Cinema.FirstOrDefault(x => x.Name.Equals(name));

                var c2 = from z in ctx.Cinema
                         where z.Emplacement1.Adresse.Equals(name)
                         select z;

                
            }

            return c;
        }
            
    }
}
