using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBootcamp_LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {

            /*
                var s = new ServicesTest();
                s.AdultStudents();
                Console.ReadLine();
            */

            #region Snippets
            
            Snippets snippets = new Snippets();
            /*
            var listaObjetos = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var paginas = snippets.GetPage(listaObjetos, 2, 5);

            foreach(var pagina in paginas)
            {
                Console.WriteLine(pagina);
            }
            */
            //snippets.ObtenerCuadradoDeLosMayoresQueElPromedio();
            
            //snippets.Zippeando();

            snippets.AgregateQueries();

            Console.ReadLine();

            #endregion 
        }

    }
}
