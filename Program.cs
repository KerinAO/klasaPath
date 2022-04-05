using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace klasaPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string prviDirektorij = @"c:\prviDir";
            string drugiDirektorij = @"c:\drugiDir";

            string[] nazivi = new string[5];

            if (!Directory.Exists(prviDirektorij))
            {
                Directory.CreateDirectory(prviDirektorij);
            }
            
            if (!Directory.Exists (drugiDirektorij))
            {
                Directory.CreateDirectory (drugiDirektorij);
            }

            for (int i = 0; i < 5; i++)
            {
                nazivi[i] = "Datoteka" + i;
                if (!File.Exists(@"c:\prviDir\" + nazivi[i]))
                {
                    File.Create(@"c:\prviDir\" + nazivi[i]);
                }
            }

            try
            {
                foreach (string datoteka in Directory.GetFiles(prviDirektorij))
                {
                    string imeDatoteke = Path.GetFileName(datoteka);
                    string ciljanaDatoteka = Path.Combine(drugiDirektorij, imeDatoteke);

                    File.Copy(datoteka, ciljanaDatoteka, false);
                }
                Console.WriteLine("It is done!");
            }
            catch (Exception greska)
            {
                Console.WriteLine("Greška: {0}", greska.Message);
            }


            Console.ReadKey();
        }
    }
}
