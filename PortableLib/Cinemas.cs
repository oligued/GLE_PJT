using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace petitPateLib.Logic
{
    public class Cinemas
    {

        public class Cinema
        {
            // les variables de l'objet cinema
            public int idCinema;
            public string nomCinema;
            public int nbPlaces;
            public string adresse;
            public string telephone;

            public override string ToString()
            {
                return string.Format("{0}           {1}         {2}             {3}     {4}\r\n", idCinema, nomCinema, nbPlaces, adresse, telephone);
            }
        }




        public static List<String> ObtenirListeCinemas()
        {

            //création d'une liste pour contenir les Cinemas;
            List<String>  lesCinemas = new List<String>();

            Cinema UnCinema = new Cinema();       
   

            // declare the SqlDataReader, which is used in
            // both the try block and the finally block
            SqlDataReader rdrCinema = null;

            // 1. Instantiate the connection
            SqlConnection connexion = new SqlConnection("Data Source=(local);Initial Catalog=petitPateBDD;Integrated Security=SSPI");

            // create a command object
            SqlCommand reqAfficherCinemas = new SqlCommand(
                "select IdCinema, Cinema.Name, Nb_Places, Adresse, Phone from Cinema, Emplacement where Cinema.Emplacement = Emplacement.IdPlace", connexion);

            try
            {
                // 2. Open the connection
                connexion.Open();

                // get query results
                rdrCinema = reqAfficherCinemas.ExecuteReader();
                
                // parcours des valeurs retournées par la requête et inscription dans la liste chaînée
                while (rdrCinema.Read())
                {
                        UnCinema.idCinema = (int)rdrCinema["IdCinema"];
                        UnCinema.nomCinema = (string)rdrCinema["Name"];
                        UnCinema.nbPlaces = (int)rdrCinema["Nb_Places"];
                        UnCinema.adresse = (string)rdrCinema["Adresse"];
                        UnCinema.telephone = (string)rdrCinema["Phone"];

                        lesCinemas.Add(UnCinema.ToString());
                }                

                return lesCinemas; //on renvoie la liste des cinemas
            }
            finally
            {
                // close the reader
                if (rdrCinema != null)
                {
                    rdrCinema.Close();
                }

                // 5. Close the connection
                if (connexion != null)
                {
                    connexion.Close();
                }
                
            }
        }
    }
}
