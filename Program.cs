using Ical.Net;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ICSFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the .ics file
            var calendar = Calendar.Load(File.OpenRead("cours.ics"));
            // Get events
            var events = calendar.Events;

            // Order events by Start Date
            var events_sorted = events.OrderBy(e => e.DtStart.AsSystemLocal);
            
            foreach (var evt in events_sorted)
            {
                // C# Target-typed new expressions
                Cours cours = new(evt);
                Console.WriteLine(cours);
                Console.WriteLine("=================================");
            }
        }

        async Task ReadRemoteIcsFileAsync()
        {
            var ing1OlineSchedule = System.Net.WebRequest.Create("link");
            var response = await ing1OlineSchedule.GetResponseAsync().ConfigureAwait(false);
            var stream = response.GetResponseStream();
            
            var calendar = Calendar.Load(stream);

            // Get events
            var events = calendar.Events;

            // Order events by Start Date
            var events_sorted = events.OrderBy(e => e.DtStart.AsSystemLocal);

            foreach (var evt in events_sorted)
            {
                // C# Target-typed new expressions
                Cours cours = new(evt);
                Console.WriteLine(cours);
                Console.WriteLine("=================================");
            }
        }

    }
}
