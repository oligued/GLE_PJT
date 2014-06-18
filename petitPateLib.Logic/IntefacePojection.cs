using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace petitPateLib.Logic
{

    
    [ServiceContract]
    public interface IPetitPateProjection
    {
        [OperationContract]Projection GetProjectionByID(int idprojection);
    }



    /// <summary>
    /// Classe de logique
    /// </summary>
    public class PetitPateProjection : IPetitPateProjection
    {
        /// <summary>
        /// Classe pour récupérer les projections pour un film à l'affiche (UC001)
        /// </summary>
        /// <param name="name">idprojection</param>
        /// <returns>null si pas trouvé</returns>
        public Projection GetProjectionByID(int idprojection)
        {
            Projection p = null;

            var ctx = new petitPateBDDEntities();

            p = ctx.Projection.FirstOrDefault(x => x.IdProjectiondatetime == idprojection);         

            return p;
        }
            
    }
}
