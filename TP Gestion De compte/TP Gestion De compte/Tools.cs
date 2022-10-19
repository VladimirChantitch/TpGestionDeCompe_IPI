using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public static class Tools
    {
        public static bool CheckYesNo()
        {
            Console.WriteLine("Yes/No");
            string truth = " ";
            while (truth != "yes" || truth != "no")
            {
                try
                {
                    if ((truth = Console.ReadLine().ToLower()) != null)
                    {
                        if (truth == "yes")
                        {
                            return true;
                        }
                        else if (truth == "no")
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }
    }
}
