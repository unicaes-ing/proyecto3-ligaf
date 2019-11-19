using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIII_Puebas_
{
    class OpcionII : OpcionI
    {
        public static string jugadorN, equipoo;
        // public static int cantJugadores;
        public void opcion2()
        {
            Console.WriteLine(" 1 - Registrar jugador:");
            Console.WriteLine(" 2 - Eliminar jugador:");
            switch (validaciones("Selecciona una opccion: ", 1, 2))
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Nombre del equipo:");
                        equipoo = Console.ReadLine();
                        //si el equipo esta registrado
                        if (liga.ContainsKey(equipoo))
                        {
                            //limite de jugadores por equipo 11
                            if (liga[equipoo].jugadore.Count <= 11)
                            {
                                Console.WriteLine("Nombre del jugador:");
                                jugadorN = Console.ReadLine();
                                bool op = true;
                                foreach (jugador item in liga[equipoo].jugadore)
                                {
                                    //verifica que el jugador no este registrado 
                                    if (item.nombreJ.Equals(jugadorN))
                                    {
                                        Console.WriteLine("El jugador ya estaba regitrado en este equipo");
                                        op = false;
                                        break;
                                    }
                                }
                                //crea y agrega el jugador a un equipo
                                if (op)
                                {
                                    jugador j = new jugador();
                                    j.nombreJ = jugadorN;
                                    Console.WriteLine("Posicion:");
                                    j.posicion = Console.ReadLine();
                                    Console.WriteLine("Cantidad goles:");
                                    j.gol = validaciones("Ingrese la cantidad", 0, 100);
                                    liga[equipoo].jugadore.Add(j);
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("El equipo esta lleno");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El equipo no existe--intentelo de nuevo o presione [s] para salir");
                            if ((Console.ReadLine().Equals("s")))
                            {
                                break;
                            }
                        }
                    } while (true);
                    break;
                case 2:///elimina a un jugador
                    Console.WriteLine("Nombre del equipo:");
                    equipoo = Console.ReadLine();
                    if (liga.ContainsKey(equipoo))
                    {
                        Console.WriteLine("Nombre del jugador:");
                        jugadorN = Console.ReadLine();
                        bool op2 = true;//si el jugador existe en el equipo
                        foreach (jugador item in liga[equipoo].jugadore)
                        {
                            if (item.nombreJ.Equals(jugadorN))
                            {
                                if (item.gol < 1)//si el jugador tiene goles
                                {
                                    liga[equipoo].jugadore.Remove(item);
                                    Console.WriteLine("jugador eliminado");
                                }
                                else
                                {
                                    Console.WriteLine("el jugador ha marcado goles");
                                }
                                op2 = false;
                                break;
                            }
                        }
                        if (op2)
                        {
                            Console.WriteLine("El jugador no existe");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El equipo no existe");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
