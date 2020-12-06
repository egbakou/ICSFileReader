using Ical.Net;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ICSFileReader
{
    class Program
    {
        static async Task Main()
        {
            // Read Calendar Online
            var olineSchedule = WebRequest.Create("https://gist.githubusercontent.com/egbakou/2f9ea8129fcfb58b80eca78f1a6d1387/raw/f15d920edac3068a42a7ef9f05993c2a6b365d33/cours.ics");
            var response = await olineSchedule.GetResponseAsync().ConfigureAwait(false);
            var stream = response.GetResponseStream();
            
            var calendar = Calendar.Load(stream);

            // Load the .ics file localy
            // var calendar = Calendar.Load(File.OpenRead("cours.ics"));

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
