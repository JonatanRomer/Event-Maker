using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using EventMaker.Persistency;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        public ObservableCollection<Event> Events { get; set; }
        
        public EventCatalogSingleton()
        {
            Events.Add(new Event(1, "Event1", "Cykelløb", "Glostrup", new DateTime(2017, 2, 1)));
            Events.Add(new Event(2, "Event2", "Party-Hardy", "Århus", new DateTime(2017, 2, 2)));
            Events.Add(new Event(3, "Event3", "Ironman", "København", new DateTime(2017, 2, 5)));
        }


        public void AddEvent()
        {
            //this.Add();
        }
    }
}
