using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIII_Puebas_
{
    class OpcionVIII : OpcionI
    {
        //RESTAURAR TODA LA LIGA
        public void opcionVIII()
        {
            foreach (KeyValuePair<string, equipos> item in liga)
            {
                equipos equips = item.Value;
                equips.golesC = 0;
                equips.golesF = 0;
                equips.ganados = 0;
                equips.empatados = 0;
                equips.perdidos = 0;
                equips.puntos = 0;

                jugador j = new jugador();
                for (int i = 0; i < equips.jugadore.Count; i++)
                {
                    j = equips.jugadore[i];
                    j.gol = 0;
                    equips.jugadore[i] = j;
                }

            }
            Console.WriteLine("Liga reiniciada...");
            Console.WriteLine("===================================");
            Console.WriteLine("\nPresione <ENTER> para continuar.");
            gDiccionario(liga);
            Console.ReadKey();
        }
    }
}
