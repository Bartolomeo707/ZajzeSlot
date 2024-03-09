using System;
using System.Numerics;

namespace ZajzeSlot {

    class Program {

        static BigInteger Sqrt(BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        static BigInteger Silnia(int n) {
            BigInteger wynik = 1;
            int indeks = n;

            while (indeks != 1) {
                wynik = wynik * indeks;
                indeks--;
            }
            return wynik;
        }

        static void Kwadratowa() {
            double a, b, c;

            Console.WriteLine("Wpisz a");
            a = double.Parse(Console.ReadLine());

            Console.WriteLine("Wpisz b");
            b = double.Parse(Console.ReadLine());

            Console.WriteLine("Wpisz c");
            c = double.Parse(Console.ReadLine());


            double delta = b * b - 4 * a * c;
            Console.WriteLine($"Wartość delty jest równa {delta}, tępe chuje");

            if (delta < 0)
            {
                Console.WriteLine("Brak miejsc zerowych");
            }
            else if (delta == 0)
            {
                Console.WriteLine("Jedno miejsce zerowe");
                Console.WriteLine($"Miejsce zerowe to {-b / (2 * a)}");
            }
            else
            {
                Console.WriteLine("Dwa miejsca zerowe");
                double x_1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x_2 = (-b - Math.Sqrt(delta)) / (2 * a);

                Console.WriteLine($"Miejsca zerowe to {Math.Round(x_1, 2)} i {Math.Round(x_2, 2)}");
            }

            Console.WriteLine($"A teraz sobie kurwa pierdolniemy silnie z {b}");
            Console.WriteLine($"Silnia z {b} to {Silnia(Convert.ToInt32(Math.Round(b)))}");
        }

        static int Pierwsza(int x) {
            int n = 2;
            int wynik = 2;

            while(n <=x) {
                int i = n/2;
                bool CzyPierwsza = true;
                while (i >= 2) {
                    if (n % i == 0) {
                        CzyPierwsza = false;
                        Console.WriteLine($"{n} nie jest liczbą pierwszą, ponieważ dzieli się przez {i} z reztą {n % i}");
                        break;
                    }
                    i--;
                }
                if (CzyPierwsza) {
                    Console.WriteLine($"{n} jest liczbą pierwszą");
                    wynik = n;
                }
                n++;
            }

            return wynik;
        }

        static BigInteger IntPow(BigInteger x, uint pow)
        {
            BigInteger ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        static void PierwszawChujDuza () {
            uint n = 3;
            Console.WriteLine(IntPow(2, n) - 1);
            while (true) {
                BigInteger i = Sqrt((IntPow(2, n) - 1));
                bool CzyPierwsza = true;
                while (i >= 2)
                {
                    if ((IntPow(2, n) - 1) % i == 0)
                    {
                        CzyPierwsza = false;
                        Console.WriteLine($"{IntPow(2, n) - 1} (n={n}) nie jest liczbą pierwszą, ponieważ dzieli się przez {i} z reztą {(IntPow(2, n) - 1) % i}");
                        break;
                    }
                    i--;
                }
                if (CzyPierwsza) {
                    Console.WriteLine($"{IntPow(2, n) - 1} (n={n}) jest liczbą pierwszą");
                }

                n++;
            }

        }

        static void Main() {
            // Kwadratowa();
            // Console.WriteLine($"Wpisz liczbę");
            // int max = int.Parse(Console.ReadLine());
            // Console.WriteLine($"Największa liczba pierwsza w zakresie do {max} to {Pierwsza(max)}");

            PierwszawChujDuza();
            Console.ReadKey();
        }
    }
}
