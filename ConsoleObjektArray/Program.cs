namespace ConsoleObjektArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleObjektArray");

            // ---------- Klasse Value ---------------

            // testdaten erzeugen für v[] array
            Value[] v = new Value[20];
            for (int i = 0; i < 20; i++)
            {
                // id 0-2
                v[i] = new Value(i % 3, (double) (i + 125) * 2 / 3);
            }
            foreach (var item in v)
            {
                Console.WriteLine($"{item.SensorId} {item.Wert} {item.Datum}");
            }

            Random r = new Random();
            Value[] v2 = new Value[36];
            for (int i = 0; i < 36; i++)
            {
                v2[i] = new Value(i % 3, r.Next(50, 200), DateTime.Now.AddHours(-((i / 3) * 6)));
            }
            Info[] infos2 = new Info[20];
            for (int i = 0; i < 20; i++)
            {
                int rand = r.Next(10, 30);
                infos2[i] = new Info(
                    i % 5, 
                    DateOnly.FromDateTime(DateTime.Now.AddDays(-((i / 5) + 1))), 
                    rand * r.Next(10, 30), 
                    rand);
            }


            Console.WriteLine("[Value] Mittelwert ID0: " + Value.BerechneMittelwert(v, 0));
            Console.WriteLine("[Value] Mittelwert ID1: " + Value.BerechneMittelwert(v, 1));
            Console.WriteLine("[Value] Mittelwert ID2: " + Value.BerechneMittelwert(v, 2));

            Console.WriteLine("\n[Value] AnteilÜ90: " + Value.BestimmeAnteilÜ90(v) + " %");

            Console.WriteLine("\n[Value] Anteil über Mindestwert (87): " + Value.BestimmeAnteilÜberMindestwert(v, 87) + " %");
            Console.WriteLine("[Value] Anteil über Mindestwert (92): " + Value.BestimmeAnteilÜberMindestwert(v, 92) + " %");


            // ----------- Klasse Info ---------------

            // testdaten erzeugen für infos[] array
            Info[] infos = new Info[20];
            for (int i = 0; i < 20; i++)
            {
                // id 1-3
                infos[i] = new Info(i % 3 + 1, DateOnly.FromDateTime(DateTime.Now), (double) (i + 12500) * 2 / 3, (i % 5 + 1) * 11);
            }
            foreach (var item in infos)
            {
                Console.WriteLine($"{item.KlasseId} {item.Datum} {item.Umsatz} {item.AnzahlKunden}");
            }

            

            Console.WriteLine("[Info] Mittelwert:  " + BerechneMittelwertAnzahlKunden(infos));
            Console.WriteLine("[Info2] Mittelwert: " + BerechneMittelwertAnzahlKunden(infos2));



            Console.Write("\npress [ENTER] to exit...");
            Console.ReadLine();
        }

        

        public static double BerechneMittelwertAnzahlKunden(Info[] infos)
        {
            int kunden = 0;

            foreach (var item in infos)
            {
                kunden += item.AnzahlKunden;
            }
            
            return (double) kunden / infos.Length;
        }
    }

    class Value
    {
        public Value() { }

        public Value(int sensorId, double wert)
        {
            SensorId = sensorId;
            Wert = wert;
        }

        public Value(int sensorId, double wert, DateTime datum) : this(sensorId, wert)
        {
            Datum = datum;
        }

        public int SensorId { get; set; } = 0;
        public double Wert { get; set; } = 0;
        public DateTime Datum { get; set; } = DateTime.Now;

        public static double BestimmeAnteilÜberMindestwert(Value[] v, double mindestwert)
        {
            int count = 0;
            foreach (var item in v)
            {
                if (item.Wert > mindestwert)
                    count++;
            }
            return (double)count / v.Length * 100;
        }

        public static double BestimmeAnteilÜ90(Value[] v)
        {
            int countÜ90 = 0;
            foreach (var item in v)
            {
                if (item.Wert > 90)
                    countÜ90++;
            }
            return (double)countÜ90 / v.Length * 100;
        }

        public static double BerechneMittelwert(Value[] v, int sensorID)
        {
            int count = 0;
            double sum = 0;
            foreach (var value in v)
            {
                if (value.SensorId == sensorID)
                {
                    count++;
                    sum += value.Wert;
                }
            }

            return sum / count;
        }
    }

    class Info
    {
        public Info() { }

        public Info(int klasseId, DateOnly datum, double umsatz, int anzahlKunden)
        {
            KlasseId = klasseId;
            Datum = datum;
            Umsatz = umsatz;
            AnzahlKunden = anzahlKunden;
        }

        public int KlasseId { get; set; } = 0;
        public DateOnly Datum { get; set; } = DateOnly.MinValue;
        public double Umsatz { get; set; } = 0;
        public int AnzahlKunden { get; set; } = 0;
    }
}
