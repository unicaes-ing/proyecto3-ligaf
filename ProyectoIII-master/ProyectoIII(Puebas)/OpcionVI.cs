using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIII_Puebas_
{
    class OpcionVI : OpcionIV
    {
        //TABLA DE POSICIONES*sin terminar*
        List<equipos> puntosEq = new List<equipos>();
        public void opcionVI()
        {
            //lista de equipos

            List<equipos> eq = new List<equipos>();
            foreach (equipos equi in liga.Values)
            {
                eq.Add(equi);
            }

            Console.WriteLine("╔════════════════╦══════════╦══════════╦══════════╦══════════╦══════════╦══════════╦══════════╦═════════╗");
            Console.WriteLine("║{0, -15} ║ {1, -8} ║ {2, -8} ║ {3, -8} ║ {4, -8} ║ {5, -8} ║ {6, -8} ║ {7, -8} ║ {8, -8}║", "Equipo", "PJ", "PG", "PE",
                "PP", "GF", "GC", "DG", "pts");

            foreach (equipos equipo in eq)
            {
                Console.WriteLine("╠════════════════╬══════════╬══════════╬══════════╬══════════╬══════════╬══════════╬══════════╬═════════╣");
                Console.WriteLine("║{0, -15} ║ {1, -8} ║ {2, -8} ║ {3, -8} ║ {4, -8} ║ {5, -8} ║ {6, -8} ║ {7, -8} ║ {8, -8}║",
                    equipo.nombreEq, equipo.jugados, equipo.ganados, equipo.empatados, equipo.perdidos, equipo.golesF, equipo.golesC, equipo.df, equipo.puntos);
            }
            Console.WriteLine("╚════════════════╩══════════╩══════════╩══════════╩══════════╩══════════╩══════════╩══════════╩═════════╝");
            Console.ReadKey();

            
        }
    }
}
