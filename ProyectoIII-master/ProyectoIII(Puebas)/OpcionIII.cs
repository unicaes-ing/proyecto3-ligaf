using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIII_Puebas_
{
    class OpcionIII : OpcionI
    {
        public void opcionIII()
        {
            foreach (KeyValuePair<string, equipos> item in liga)
            {
                equipos equips = item.Value;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n===================================");
                Console.WriteLine("Nombre de Equipo: \t{0}", equips.nombreEq);
                Console.WriteLine(equips.golesC + " " + equips.golesF + " " + equips.puntos);
                Console.WriteLine("===================================");
                Console.WriteLine("{0, -20} {1, -10} {2, 5}", "Nombre", "Posicion", "Goles");
                foreach (jugador j in equips.jugadore)
                {
                    //Console.WriteLine("-----------------------------------");
                    //Console.WriteLine("Nombre \tPosicion \t Goles");
                    Console.WriteLine("{0, -20} {1, -10} {2, 5}", j.nombreJ, j.posicion, j.gol); //Pendiente de parsear
                    //Console.WriteLine("Goles: \t\t{0}", j.gol);
                }
            }
            Console.WriteLine("===================================");
            Console.WriteLine("\nPresione <ENTER> para continuar.");
            Console.ReadKey();
        }
        public void opIIIMostrarEquipo()
        {

            Console.WriteLine("Ingrese equipo a mostrar:");
            string nEquip = Console.ReadLine();
            if (liga.ContainsKey(nEquip))
            {
                Console.WriteLine("Nombre de Equipo: \t{0}", liga[nEquip].nombreEq);
                Console.WriteLine("{0,-10}   {1,-10}   {2,-10}  ", "Jugador", "Goles", "Posicion");
                foreach (jugador j in liga[nEquip].jugadore)
                {
                    Console.WriteLine("{0,-10}   {1,-10}   {2,-10}  ", j.nombreJ, j.gol, j.posicion);
                }
            }
            Console.WriteLine("\nPresione <ENTER> para continuar.");
            Console.ReadKey();
        }
    }
}
