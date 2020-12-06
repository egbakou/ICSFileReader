using Ical.Net.CalendarComponents;
using System;

namespace ICSFileReader
{
    public class Cours
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        // Constructor that convert CalendarEvent to Cours
        public Cours(CalendarEvent evt)
        {
            Name = evt.Summary.Trim();
            Description = evt.Description.Trim();
            Location = evt.Location.Trim();
            DateStart =  evt.DtStart.AsSystemLocal;
            DateEnd = evt.DtEnd.AsSystemLocal;
        }

        public override string ToString() =>
            $"Cours: {Name}{Environment.NewLine}" +
            $"Description: {Description}{Environment.NewLine}" +
            $"Location: {Location}{Environment.NewLine}" +
            $"Start Date: {DateStart}{Environment.NewLine}" +
            $"End Date: {DateEnd}";
    }


    
}
