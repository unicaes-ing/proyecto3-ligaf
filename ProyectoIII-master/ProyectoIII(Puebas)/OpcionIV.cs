using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ProyectoIII_Puebas_
{
    class OpcionIV : OpcionI
    {
        [Serializable]
        public struct partido
        {
            public equipos ganador;
            public equipos perdedor;
            public equipos empate1;
            public equipos empate2;

        }

        public void opcionIV()
        {
            if (liga.Count > 5 && liga.Count < 10)
            {


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("===== INGRESO DE RESULTADOS =====");
                Console.WriteLine("\n 1 - Ingreso Manual.");
                Console.WriteLine(" 2 - Ingreso Automatico.");
                Console.WriteLine("==========================");
                Console.ResetColor();
                int opRes = Convert.ToInt32(Console.ReadLine());
                switch (opRes)
                {
                    case 1:
                        #region Manual
                        Console.Clear();
                        foreach (KeyValuePair<string, equipos> item in liga)
                        {
                            equipos equips = item.Value;

                            Console.WriteLine("\n===================================");
                            Console.WriteLine("Nombre de Equipo: \t{0}", equips.nombreEq);
                        }
                        Console.WriteLine("===================================");
                        equipos equipo1;
                        equipos equipo2;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("===== Ingreso MANUAL =====");
                        Console.WriteLine(" Nombre equipo 1: ");
                        Console.ResetColor();
                        string nombreEq1 = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Nombre equipo 2: ");
                        Console.ResetColor();
                        string nombreEq2 = Console.ReadLine();
                        if ((liga.ContainsKey(nombreEq1)) && (liga.ContainsKey(nombreEq2)))
                        {
                            int res = 0;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Ingrese los goles del equipo 1");
                            Console.ResetColor();
                            int goles1 = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Ingrese los goles del equipo 2");
                            Console.ResetColor();
                            int goles2 = Convert.ToInt32(Console.ReadLine());

                            if (goles1 > goles2)
                            {
                                res = 1;
                            }
                            else if (goles1 == goles2)
                            {
                                res = 2;
                            }
                            else if (goles1 < goles2)
                            {
                                res = 3;
                            }
                            equipo1 = liga[nombreEq1];
                            equipo2 = liga[nombreEq2];
                            partido partideshon = part(equipo1, equipo2, res, goles1, goles2);
                            switch (res)
                            {
                                case 1:
                                    equipo1 = partideshon.ganador;
                                    equipo2 = partideshon.perdedor;
                                    break;
                                case 2:
                                    equipo1 = partideshon.empate1;
                                    equipo2 = partideshon.empate2;
                                    break;
                                case 3:
                                    equipo1 = partideshon.perdedor;
                                    equipo2 = partideshon.ganador;
                                    break;
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Equipo 1 {0}", equipo1.nombreEq);
                            Console.WriteLine("Ganados: {0}", equipo1.ganados);
                            Console.WriteLine("Empatados: {0}", equipo1.empatados);
                            Console.WriteLine("Perdidos: {0}", equipo1.perdidos);
                            Console.WriteLine("Goles a favor: {0}", equipo1.golesF);
                            Console.WriteLine("Goles en contra: {0}", equipo1.golesC);
                            Console.WriteLine("Puntos: {0}", equipo1.puntos);
                            Console.ResetColor();
                            Console.WriteLine("========================================");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Equipo 2 {0}", equipo2.nombreEq);
                            Console.WriteLine("Ganados: {0}", equipo2.ganados);
                            Console.WriteLine("Empatados: {0}", equipo2.empatados);
                            Console.WriteLine("Perdidos: {0}", equipo2.perdidos);
                            Console.WriteLine("Goles a favor: {0}", equipo2.golesF);
                            Console.WriteLine("Goles en contra: {0}", equipo2.golesC);
                            Console.WriteLine("Puntos: {0}", equipo2.puntos);
                            Console.ResetColor();
                            liga[nombreEq1] = equipo1;
                            liga[nombreEq2] = equipo2;
                            Console.ReadKey();
                        }

                        else
                        {
                            Console.WriteLine("Uno de los equipos no esta registrado");
                        }

                        #endregion
                        break;
                    case 2:
                        Console.Clear();
                        #region Automatico
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("===== Ingreso AUTOMATICO =====");
                        Console.WriteLine(" 1 - Uno.");
                        Console.WriteLine(" 2 - Todos.");
                        Console.ResetColor();
                        int opAut = Convert.ToInt32(Console.ReadLine());
                        switch (opAut)
                        {
                            case 1:
                                #region Auto UNO
                                auto1();
                                #endregion
                                break;
                            case 2:
                                #region Auto TODOS
                                auto2();
                                #endregion
                                break;
                        }
                        #endregion
                        break;
                }
                gDiccionario(liga);
            }
            else
            {
                Console.WriteLine("No hay suficientes equipos para realizar la liga");
                Console.ReadKey();
            }
        }

        static partido part(equipos e1, equipos e2, int res, int goles1, int goles2)
        {

            partido nuevoPartido = new partido();
            switch (res)
            {
                case 1:
                    e1.golesF = goles1;
                    e1.golesC = goles2;
                    e1.ganados++;
                    e1.jugados++;
                    e1.puntos = e1.puntos + 3;
                    nuevoPartido.ganador = e1;
                    e2.golesF = goles2;
                    e2.golesC = goles1;
                    e2.perdidos++;
                    e2.jugados++;
                    nuevoPartido.perdedor = e2;

                    break;
                case 2:
                    e1.golesF = goles1;
                    e1.golesC = goles2;
                    e1.empatados++;
                    e1.puntos += 1;
                    e1.jugados++;
                    nuevoPartido.empate1 = e1;
                    e2.golesF = goles2;
                    e2.golesC = goles1;
                    e2.empatados++;
                    e2.jugados++;
                    e2.puntos += 1;
                    nuevoPartido.empate2 = e2;
                    break;
                case 3:
                    e2.golesF = goles2;
                    e2.golesC = goles1;
                    e2.ganados++;
                    e2.puntos += 3;
                    e1.jugados++;
                    nuevoPartido.ganador = e2;
                    e1.golesF = goles1;
                    e1.golesC = goles2;
                    e1.perdidos++;
                    e2.jugados++;
                    nuevoPartido.perdedor = e1;
                    break;
            }
            return nuevoPartido;
            
        }

        public void auto1()
        {
            Random r = new Random();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Nombre equipo 1: ");
            Console.ResetColor();
            string nombreEq1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Nombre equipo 2: ");
            Console.ResetColor();
            string nombreEq2 = Console.ReadLine();
            if ((liga.ContainsKey(nombreEq1)) && (liga.ContainsKey(nombreEq2)))
            {
                int res = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese los goles del equipo 1");
                Console.ResetColor();
                int goles1 = r.Next(1, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese los goles del equipo 2");
                Console.ResetColor();
                int goles2 = r.Next(1, 5);

                if (goles1 > goles2)
                {
                    res = 1;
                }
                else if (goles1 == goles2)
                {
                    res = 2;
                }
                else if (goles1 < goles2)
                {
                    res = 3;
                }
                equipos equipo1 = liga[nombreEq1];
                equipos equipo2 = liga[nombreEq2];
                partido partideshon = part(equipo1, equipo2, res, goles1, goles2);
                switch (res)
                {
                    case 1:
                        equipo1 = partideshon.ganador;
                        equipo2 = partideshon.perdedor;
                        break;
                    case 2:
                        equipo1 = partideshon.empate1;
                        equipo2 = partideshon.empate2;
                        break;
                    case 3:
                        equipo1 = partideshon.perdedor;
                        equipo2 = partideshon.ganador;
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Equipo 1 {0}", equipo1.nombreEq);
                Console.WriteLine("Ganados: {0}", equipo1.ganados);
                Console.WriteLine("Empatados: {0}", equipo1.empatados);
                Console.WriteLine("Perdidos: {0}", equipo1.perdidos);
                Console.WriteLine("Goles a favor: {0}", equipo1.golesF);
                Console.WriteLine("Goles en contra: {0}", equipo1.golesC);
                Console.WriteLine("Puntos: {0}", equipo1.puntos);
                Console.ResetColor();
                Console.WriteLine("========================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Equipo 2 {0}", equipo2.nombreEq);
                Console.WriteLine("Ganados: {0}", equipo2.ganados);
                Console.WriteLine("Empatados: {0}", equipo2.empatados);
                Console.WriteLine("Perdidos: {0}", equipo2.perdidos);
                Console.WriteLine("Goles a favor: {0}", equipo2.golesF);
                Console.WriteLine("Goles en contra: {0}", equipo2.golesC);
                Console.WriteLine("Puntos: {0}", equipo2.puntos);
                Console.ResetColor();
                liga[nombreEq1] = equipo1;
                liga[nombreEq2] = equipo2;
                Console.ReadKey();

            }

        }

        public void auto2()
        {
            Random r = new Random();
            List<string> nombreE = new List<string>();
            foreach (string item in liga.Keys)
            {
                nombreE.Add(item);
                nombreE.Sort();
            }
            string nombreEq1;
            string nombreEq2;
            int max = liga.Count();
            for (int i = 0; i < max; i++)
            {
                nombreEq1 = nombreE[i];
                for (int j = 0; j < max; j++)
                {
                    nombreEq2 = nombreE[j];
                    if (!(nombreEq1.Equals(nombreEq2)))
                    {
                        int res = 0;
                        Console.WriteLine("Ingrese los goles del equipo 1");
                        int goles1 = r.Next(1, 5);
                        Console.WriteLine("Ingrese los goles del equipo 2");
                        int goles2 = r.Next(1, 5);

                        if (goles1 > goles2)
                        {
                            res = 1;
                        }
                        else if (goles1 == goles2)
                        {
                            res = 2;
                        }
                        else if (goles1 < goles2)
                        {
                            res = 3;
                        }
                        equipos equipo1 = liga[nombreEq1];
                        equipos equipo2 = liga[nombreEq2];
                        partido partideshon = part(equipo1, equipo2, res, goles1, goles2);
                        switch (res)
                        {
                            case 1:
                                equipo1 = partideshon.ganador;
                                equipo2 = partideshon.perdedor;
                                break;
                            case 2:
                                equipo1 = partideshon.empate1;
                                equipo2 = partideshon.empate2;
                                break;
                            case 3:
                                equipo1 = partideshon.perdedor;
                                equipo2 = partideshon.ganador;
                                break;
                        }
                        Console.WriteLine("equipo 1 {0}", equipo1.nombreEq);
                        Console.WriteLine("ganados: {0}", equipo1.ganados);
                        Console.WriteLine("empatados: {0}", equipo1.empatados);
                        Console.WriteLine("perdidos: {0}", equipo1.perdidos);
                        Console.WriteLine("goles a favor: {0}", equipo1.golesF);
                        Console.WriteLine("goles en contra: {0}", equipo1.golesC);
                        Console.WriteLine("Puntos: {0}", equipo1.puntos);
                        Console.WriteLine("========================================");
                        Console.WriteLine("equipo 2 {0}", equipo2.nombreEq);
                        Console.WriteLine("ganados: {0}", equipo2.ganados);
                        Console.WriteLine("empatados: {0}", equipo2.empatados);
                        Console.WriteLine("perdidos: {0}", equipo2.perdidos);
                        Console.WriteLine("goles a favor: {0}", equipo2.golesF);
                        Console.WriteLine("goles en contra: {0}", equipo2.golesC);
                        Console.WriteLine("Puntos: {0}", equipo2.puntos);
                        liga[nombreEq1] = equipo1;
                        liga[nombreEq2] = equipo2;
                        Console.ReadKey();
                    }
                }
            }
            


        }
    }
}




