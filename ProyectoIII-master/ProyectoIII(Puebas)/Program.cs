using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIII_Puebas_
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Clear();
                mainMenu();
                op = validaciones("Seleccione una opcion.", 1, 9);
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        OpcionI opI = new OpcionI();
                        opI.opcionI();
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        OpcionII opII = new OpcionII();
                        opII.opcion2();
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        do
                        {
                            Console.WriteLine(" 1 - Mostrar Liga.");
                            Console.WriteLine(" 2 - Mostrar Equipo Especifico.");
                            Console.WriteLine(" 3 - Salir.");
                            op = validaciones("Seleccione opccion", 1, 3);
                            switch (op)
                            {
                                case 1:
                                    Console.Clear();
                                    OpcionIII opIII = new OpcionIII();
                                    opIII.opcionIII();
                                    Console.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    OpcionIII opIII2 = new OpcionIII();
                                    opIII2.opIIIMostrarEquipo();
                                    Console.Clear();
                                    break;
                            }
                        } while (op != 3);
                        Console.Clear();
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        OpcionIV opIV = new OpcionIV();
                        opIV.opcionIV();
                        break;
                    case 6:
                        Console.Clear();
                        OpcionVI opVI = new OpcionVI();
                        opVI.opcionVI();
                        break;
                    case 8:
                        Console.Clear();
                        OpcionVIII opVIII = new OpcionVIII();
                        opVIII.opcionVIII();
                        break;
                }
            } while (op != 9);
        }
        #region menu principal
        static void mainMenu()
        {
            Console.WriteLine("====== MENU PRINCIPAL ======");
            Console.WriteLine(" 1 - Gestion de equipos.");
            Console.WriteLine(" 2 - Gestion de jugadores.");
            Console.WriteLine(" 3 - Mostrar liga.");
            Console.WriteLine(" 4 - Ingresar resultado.");
            Console.WriteLine(" 5 - Tabla de resultados.");
            Console.WriteLine(" 6 - Tabla de posiciones.");
            Console.WriteLine(" 7 - Tabla de Goleadores.");
            Console.WriteLine(" 8 - Restaurar Liga.");
            Console.WriteLine(" 9 - salir.");
            Console.WriteLine("============================");
        }
        #endregion
        #region validacion
        static int validaciones(string men, int lim1, int lim2)
        {
            bool esInt;
            int nOP;
            do
            {
                Console.WriteLine(men);
                esInt = int.TryParse(Console.ReadLine(), out nOP);
            } while (esInt == false || nOP < lim1 || nOP > lim2);
            return nOP;
        }
        #endregion
    }
}
