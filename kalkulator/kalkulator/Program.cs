using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator {
    class Operacje {
        public static bool stop = true;
        public static void Wczytaj(string tekst, List<string> licz) {
            tekst = tekst.Replace(" ", "");//usuniecie spacji
            int dlugosc = tekst.Length;
            String slowo = "";//potrzebne do wpisywania znaków w petli for
            string slowo2 = "";
            for (int i = 0; i < dlugosc; ++i) {
                if (i == dlugosc - 1) {
                    slowo += tekst[i];
                    licz.Add(slowo);
                } else if (tekst[i] != '+' && tekst[i] != '-' && tekst[i] != '*' && tekst[i] != '/') {
                    slowo += tekst[i];
                } else if (tekst[i] == '+' || tekst[i] == '-' || tekst[i] == '*' || tekst[i] == '/') {
                    licz.Add(slowo);
                    slowo = "";
                    slowo2 += tekst[i];
                    licz.Add(slowo2);
                    slowo2 = "";
                }
            }
        }
        public static double Konwert(string liczba) {
            double a;
            try {
                a = Convert.ToDouble(liczba);
            } catch (Exception e) {
                a = 0;
                stop = false;
                Console.WriteLine("Nie wpisano liczby");
            }
            return a;
        }

        public static void Wyswietl(List<String> licz) {
            for (int i = 0; i < licz.Count; ++i) {
                Console.Write(licz[i]);
            }
            Console.WriteLine();
        }
        public static void Dodaj(List<String> licz) {
            bool dalej;
            int ktory = licz.IndexOf("+");
            if (ktory > 0) {
                dalej = true;
            } else {
                dalej = false;
            }
            while (dalej) {
                double liczba1 = Konwert(licz[ktory - 1]);
                double liczba2 = Konwert(licz[ktory + 1]);
                if ((ktory - 2) >= 0 && licz[ktory - 2] == "-") {//najpierw czy nie wyjdzie poza zakres a potem czy -
                    liczba1 *= -1;
                    licz.RemoveAt(ktory - 2);
                    licz.Insert(ktory - 2, "+");
                }
                double liczba3 = liczba1 + liczba2;
                licz.RemoveAt(ktory + 1);
                licz.RemoveAt(ktory);
                licz.RemoveAt(ktory - 1);
                licz.Insert(ktory - 1, Convert.ToString(liczba3));

                ktory = licz.IndexOf("+");
                if (ktory > 0) {
                    dalej = true;
                } else {
                    dalej = false;
                }
            }
        }
        public static void Odejmij(List<String> licz) {
            bool dalej;
            int ktory = licz.IndexOf("-");
            if (ktory > 0) {
                dalej = true;
            } else {
                dalej = false;
            }
            while (dalej) {
                double liczba1 = Konwert(licz[ktory - 1]);
                double liczba2 = Konwert(licz[ktory + 1]);
                double liczba3 = liczba1 - liczba2;
                licz.RemoveAt(ktory + 1);
                licz.RemoveAt(ktory);
                licz.RemoveAt(ktory - 1);
                licz.Insert(ktory - 1, Convert.ToString(liczba3));

                ktory = licz.IndexOf("-");
                if (ktory > 0) {
                    dalej = true;
                } else {
                    dalej = false;
                }
            }
        }
        public static void Mnozenie(List<String> licz) {
            bool dalej;
            int ktory = licz.IndexOf("*");
            if (ktory > 0) {
                dalej = true;
            } else {
                dalej = false;
            }
            while (dalej) {
                double liczba1 = Konwert(licz[ktory - 1]);
                double liczba2 = Konwert(licz[ktory + 1]);
                double liczba3 = liczba1 * liczba2;
                licz.RemoveAt(ktory + 1);
                licz.RemoveAt(ktory);
                licz.RemoveAt(ktory - 1);
                licz.Insert(ktory - 1, Convert.ToString(liczba3));
                ktory = licz.IndexOf("*");
                if (ktory > 0) {
                    dalej = true;
                } else {
                    dalej = false;
                }
            }
        }
        public static void Dzielenie(List<String> licz) {
            bool dalej;
            int ktory = licz.IndexOf("/");
            if (ktory > 0) {
                dalej = true;
            } else {
                dalej = false;
            }
            while (dalej) {
                double liczba1 = Konwert(licz[ktory - 1]);
                double liczba2 = Konwert(licz[ktory + 1]);
                if (liczba2 != 0) {
                    double liczba3 = liczba1 / liczba2;
                    licz.RemoveAt(ktory + 1);
                    licz.RemoveAt(ktory);
                    licz.RemoveAt(ktory - 1);
                    licz.Insert(ktory - 1, Convert.ToString(liczba3));

                    ktory = licz.IndexOf("/");
                    if (ktory > 0) {
                        dalej = true;
                    } else {
                        dalej = false;
                    }
                } else {
                    Console.WriteLine("nie można dzielić przez 0");
                    break;
                }
            }
        }
    }

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("wpisz działania:");
            string sWprowadzone2 = Console.ReadLine();
            //            string sWprowadzone2 = "2 + 2 * 2";
            List<String> licz2 = new List<string>();
            Operacje.Wczytaj(sWprowadzone2, licz2);
            if (Operacje.stop) Operacje.Mnozenie(licz2);
            if (Operacje.stop) Operacje.Dzielenie(licz2);
            if (Operacje.stop) Operacje.Dodaj(licz2);
            if (Operacje.stop) Operacje.Odejmij(licz2);
            if (Operacje.stop) Console.Write("wynik: ");
            if (Operacje.stop) {
                Operacje.Wyswietl(licz2);
            }
            Console.ReadKey();
        }
    }
}
