using System.Globalization;

namespace ConsoleObjektArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleObjektArray");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // testdaten erzeugen für v[] array
            Value[] v = new Value[20];
            for (int i = 0; i < 20; i++)
            {   // id 0-2
                v[i] = new Value(i % 3, (double) (i * 2 + 125) * 2 / 3, DateTime.Now.AddHours(-i / 3 * 6));
            }
            
            Console.WriteLine($"[v] {"Id",2} {"Wert",6:N2} {"Datum",20}");
            foreach (var item in v)
            {
                Console.WriteLine($"[v] {item.SensorId,2} {item.Wert,6:N2} {item.Datum,20}");
            }

            // testdaten erzeugen für infos[] array
            Info[] infos = new Info[20];
            for (int i = 0; i < 20; i++)
            {   // id 0-3
                infos[i] = new Info(
                    i % 4,
                    DateOnly.FromDateTime(DateTime.Now.AddDays(-(i / 4 + 1))),
                    (double)(i * 3 + 1000 * (i % 7 + 1)) * 2 / 7, 
                    (i % 7 + 1) * 11);
            }

            Console.WriteLine($"\n[infos] {"Id",2} {"Datum",11} {"Umsatz",12:N2} {"Kunden",6}");
            foreach (var item in infos)
            {
                Console.WriteLine($"[infos] {item.KlasseId,2} {item.Datum,11} {item.Umsatz,12:N2} {item.AnzahlKunden,6}");
            }

            // testdaten v2 (Luca) -------------------------------
            Random r = new Random();
            // Value array
            Value[] v2 = new Value[36];
            for (int i = 0; i < 36; i++)
            {   // id 0-2
                v2[i] = new Value(i % 3, r.Next(50, 200), DateTime.Now.AddHours(-(i / 3 * 6)));
            }
            Console.WriteLine($"\n[v2] {"Id",2} {"Wert",7:N2} {"Datum",20}");
            foreach (var item in v2)
            {
                Console.WriteLine($"[v2] {item.SensorId,2} {item.Wert,7:N2} {item.Datum,20}");
            }

            // Info array
            Info[] infos2 = new Info[20];
            for (int i = 0; i < 20; i++)
            {   // id 0-3
                int rand = r.Next(10, 30);
                infos2[i] = new Info(
                    i % 4, 
                    DateOnly.FromDateTime(DateTime.Now.AddDays(-((i / 4) + 1))), 
                    rand * r.Next(10, 30), 
                    rand);
            }
            Console.WriteLine($"\n[infos2] {"Id",2} {"Datum",11} {"Umsatz",12:N2} {"Kunden",6}");
            foreach (var item in infos2)
            {
                Console.WriteLine($"[infos2] {item.KlasseId,2} {item.Datum,11} {item.Umsatz,12:N2} {item.AnzahlKunden,6}");
            }
            Console.WriteLine("\n-------------------------------------------------------------\n");


            // ---------- Klasse Value ---------------

            Console.WriteLine($"[v]  Mittelwert (ID 0): {Value.BerechneMittelwert(v, 0):N2}");
            Console.WriteLine($"[v]  Mittelwert (ID 1): {Value.BerechneMittelwert(v, 1):N2}");
            Console.WriteLine($"[v]  Mittelwert (ID 2): {Value.BerechneMittelwert(v, 2):N2} \n");
            
            Console.WriteLine($"[v2] Mittelwert (ID 0): {Value.BerechneMittelwert(v2, 0):N2}");
            Console.WriteLine($"[v2] Mittelwert (ID 1): {Value.BerechneMittelwert(v2, 1):N2}");
            Console.WriteLine($"[v2] Mittelwert (ID 2): {Value.BerechneMittelwert(v2, 2):N2} \n");

            Console.WriteLine($"[v]  AnteilÜ90: {Value.BestimmeAnteilÜ90(v):N2} % ");
            Console.WriteLine($"[v2] AnteilÜ90: {Value.BestimmeAnteilÜ90(v2):N2} % \n");

            Console.WriteLine($"[v]  Anteil über Mindestwert (87): {Value.BestimmeAnteilÜberMindestwert(v, 87):N2} %");
            Console.WriteLine($"[v]  Anteil über Mindestwert (92): {Value.BestimmeAnteilÜberMindestwert(v, 92):N2} % \n");
            
            Console.WriteLine($"[v2] Anteil über Mindestwert (87): {Value.BestimmeAnteilÜberMindestwert(v2, 87):N2} %");
            Console.WriteLine($"[v2] Anteil über Mindestwert (92): {Value.BestimmeAnteilÜberMindestwert(v2, 92):N2} %");
            Console.WriteLine("\n-------------------------------------------------------------\n");


            // ----------- Klasse Info ---------------

            Console.WriteLine($"[infos]  Mittelwert Anzahl Kunden: {Info.BerechneMittelwertAnzahlKunden(infos):N2}");
            Console.WriteLine($"[infos2] Mittelwert Anzahl Kunden: {Info.BerechneMittelwertAnzahlKunden(infos2):N2} \n");

            Console.WriteLine($"[infos]  Umsatz (ID 0): {Info.BerechneUmsatz(infos, 0):C2}");
            Console.WriteLine($"[infos]  Umsatz (ID 1): {Info.BerechneUmsatz(infos, 1):C2}");
            Console.WriteLine($"[infos]  Umsatz (ID 2): {Info.BerechneUmsatz(infos, 2):C2}");
            Console.WriteLine($"[infos]  Umsatz (ID 2): {Info.BerechneUmsatz(infos, 3):C2} \n");

            Console.WriteLine($"[infos2] Umsatz (ID 0): {Info.BerechneUmsatz(infos2, 0):C2}");
            Console.WriteLine($"[infos2] Umsatz (ID 1): {Info.BerechneUmsatz(infos2, 1):C2}");
            Console.WriteLine($"[infos2] Umsatz (ID 2): {Info.BerechneUmsatz(infos2, 2):C2}");
            Console.WriteLine($"[infos2] Umsatz (ID 2): {Info.BerechneUmsatz(infos2, 3):C2} \n");

            Console.WriteLine($"[infos]  Kasse Max Umsatz ({infos[0].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos, infos[0].Datum.ToString())}");
            Console.WriteLine($"[infos]  Kasse Max Umsatz ({infos[4].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos, infos[4].Datum.ToString())}");
            Console.WriteLine($"[infos]  Kasse Max Umsatz ({infos[8].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos, infos[8].Datum.ToString())}");
            Console.WriteLine($"[infos]  Kasse Max Umsatz ({infos[12].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos, infos[12].Datum.ToString())}");
            Console.WriteLine($"[infos]  Kasse Max Umsatz ({infos[16].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos, infos[16].Datum.ToString())} \n");

            Console.WriteLine($"[infos2]  Kasse Max Umsatz ({infos2[0].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos2, infos2[0].Datum.ToString())}");
            Console.WriteLine($"[infos2]  Kasse Max Umsatz ({infos2[4].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos2, infos2[4].Datum.ToString())}");
            Console.WriteLine($"[infos2]  Kasse Max Umsatz ({infos2[8].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos2, infos2[8].Datum.ToString())}");
            Console.WriteLine($"[infos2]  Kasse Max Umsatz ({infos2[12].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos2, infos2[12].Datum.ToString())}");
            Console.WriteLine($"[infos2]  Kasse Max Umsatz ({infos2[16].Datum}): ID {Info.BestimmeKlasseMaxUmsatz(infos2, infos2[16].Datum.ToString())} \n");


            Console.Write("\n\npress [ENTER] to exit...");
            Console.ReadLine();
        }
    }

    public class Value
    {
        public int SensorId { get; set; }
        public double Wert { get; set; }
        public DateTime Datum { get; set; } 

        public Value(int sensorId, double wert, DateTime datum)
        {
            SensorId = sensorId;
            Wert = wert;
            Datum = datum;
        }
                

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

    public class Info
    {
        public int KlasseId { get; set; }
        public DateOnly Datum { get; set; }
        public double Umsatz { get; set; }
        public int AnzahlKunden { get; set; }

        public Info(int klasseId, DateOnly datum, double umsatz, int anzahlKunden)
        {
            KlasseId = klasseId;
            Datum = datum;
            Umsatz = umsatz;
            AnzahlKunden = anzahlKunden;
        }

        public static int BestimmeKlasseMaxUmsatz(Info[] infos, string datum)
        {
            DateOnly d = DateOnly.Parse(datum);
            int maxID = -1;
            double maxUmsatz = 0;

            foreach (var item in infos)
            {
                if (item.Datum == d && item.Umsatz > maxUmsatz)
                {
                    maxUmsatz = item.Umsatz;
                    maxID = item.KlasseId;
                }
            }

            return maxID;
        }

        public static double BerechneUmsatz(Info[] infos, int kasseId)
        {
            double sum = 0;
            foreach (var item in infos)
            {
                if (item.KlasseId == kasseId)
                {
                    sum += item.Umsatz;
                }
            }

            return sum;
        }

        public static double BerechneMittelwertAnzahlKunden(Info[] infos)
        {
            int kunden = 0;

            foreach (var item in infos)
            {
                kunden += item.AnzahlKunden;
            }

            return (double)kunden / infos.Length;
        }
    }
}
