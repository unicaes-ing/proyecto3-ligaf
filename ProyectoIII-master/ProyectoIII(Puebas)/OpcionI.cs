using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoIII_Puebas_
{
    [Serializable]
    class OpcionI
    {
        public const string N_ARCH = "liga.bin";
        public static BinaryFormatter formatter = new BinaryFormatter();
        static public Dictionary<string, equipos> liga = new Dictionary<string, equipos>();
        

        public struct jugador
        {
            public string nombreJ;
            public string posicion;
            public int gol;
            public int dorsal;
        }
        public struct equipos
        {
            public int jugados;
            public int ganados;
            public int perdidos;
            public int empatados;
            public int puntos;
            public int golesF;
            public int golesC;
            public string nombreEq;
            public int df;
            public List<jugador> jugadore;
        }
        public void opcionI()
        {
            equipos equip = new equipos();
            equip.jugadore = new List<jugador>();
            // public Dictionary<string, equipos> liga = new Dictionary<string, equipos>();
            string nombre = string.Empty;
            //Menu Gestion de Equipos
            Console.WriteLine(" 1 - Crear Equipo.");
            Console.WriteLine(" 2 - Eliminar Equipo.");
            switch (validaciones("Seleccione opccion", 1, 2))
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Nombre de Equipo");
                        equip.nombreEq = Console.ReadLine();
                        if (liga.ContainsKey(equip.nombreEq))
                        {
                            Console.WriteLine("Este carnet ya esta registrado. " + equip.nombreEq);
                        }
                    } while (liga.ContainsKey(equip.nombreEq));
                    liga.Add(equip.nombreEq, equip);
                    Console.WriteLine("Equipo creado correctamente.");
                    break;
                case 2:
                    int op3;
                    Console.Write("Ingrese nombre de equipo a eliminar:");
                    string equi = Console.ReadLine();
                    if (liga.ContainsKey(equi))
                    {
                        Console.WriteLine("Desea borar los datos del equipo: " + equi);
                        Console.WriteLine("* 1 * Si.\n* 2 * No.");
                        int.TryParse(Console.ReadLine(), out op3);
                        if (op3 == 1)
                        {
                            liga.Remove(equi);
                        }
                        else
                        {
                            Console.WriteLine("Presione <ENTER> para continuar");
                            Console.ReadKey();
                        }
                    }
                    // liga.Add(equip.nombreEq, equip);
                    Console.WriteLine("Equipo eliminado correctamente.");
                    Console.WriteLine("\nPresione <ENTER> para continuar.");
                    Console.ReadKey();
                    break;
            }
            gDiccionario(liga);
        }
        //validacion
        #region
        public static int validaciones(string men, int lim1, int lim2)
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
        #region Guardar diccionario
        public static bool gDiccionario(Dictionary<string, equipos> liga)
        {
            try
            {
                FileStream fs = new FileStream(N_ARCH, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, liga);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region reader
        public static bool leerDiccionario()
        {
            try
            {
                FileStream fs = new FileStream(N_ARCH, FileMode.Open, FileAccess.Read);
                liga = (Dictionary<string, equipos>)formatter.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #endregion 
    }
}
