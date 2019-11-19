using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIII_Puebas_
{
    class OpcionV
    {
        public void opcionV()
        {
            string equipo1 = "X";
            string equipo2 = "1-5";
            string equipo3 = "2-6";
            string equipo4 = "3-5";
            string equipo5 = "2-2";
            string equipos = "Equipo";
            Console.WriteLine("TABLA DE RESULTADOS");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0,-14} {1,-10} {2,-12} {3,-15} {4, -14},{5,-14}   "
                                      , "Equipos", "Equipo 1", "Equipo 2", "Equipo 3", "Equipo 4", "Equipo 5 ");
            Console.ResetColor();
            Console.WriteLine("==============================================================================");
            Console.ResetColor();
            int num = 1;
            do
            {

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("{0,-16} {1,-10} {2,-12} {3, -15} {4, -12}  {5,-10}", equipos + num, equipo1, equipo2, equipo3, equipo4, equipo5);
                Console.ResetColor();
                Console.WriteLine("=============================================================================");


                Console.ReadKey();
            } while (true);
        }
    }
}
