using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        public ObservableCollection<Event> Events { get; set; }
        public EventCatalogSingleton()
        {
            Events.Add(new Event() {Id = 1, Name = "Event1", Description = "Cykelløb", Place = "Glostrup", DateTime = new DateTime(2017, 2, 1) });
            Events.Add(new Event() { Id = 2, Name = "Event2", Description = "party-hardy", Place = "Aarhus", DateTime = new DateTime(2017,2,2) });
            Events.Add(new Event() { Id = 3, Name = "Event3", Description = "Ironman", Place = "København", DateTime = new DateTime(2017, 2, 5) });
        }


        public void AddEvent()
        {
            //this.Add();
        }
    }
}
