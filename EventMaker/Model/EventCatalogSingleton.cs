using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.AllJoyn;
using Windows.Media.Streaming.Adaptive;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using EventMaker.Common;
using EventMaker.Persistency;
using Newtonsoft.Json;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        public ObservableCollection<Event> Events { get; set; }
        private static EventCatalogSingleton instance;
        public EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            Events.Add(new Event(1, "Event1", "Cykelløb", "Glostrup", new DateTime(2017, 2, 1)));
            Events.Add(new Event(2, "Event2", "Party-Hardy", "Århus", new DateTime(2017, 2, 2)));
            Events.Add(new Event(3, "Event3", "Ironman", "København", new DateTime(2017, 2, 5)));
        }

        public static EventCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventCatalogSingleton();
                }
                return instance;
            }
        }

        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public void InsertJson(string jsonText)
        {
            List<Event> newList = JsonConvert.DeserializeObject<List<Event>>(jsonText);

            foreach (var eventItem in newList)
            {
                Events.Add(eventItem);
            }
        }

        public Persistency.PersistencyService pservice { get; set; }
        

        public void AddEvent(Event newEvent)
        {
            Events.Add(newEvent);
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }

        public void RemoveEvent(Event ev)
        {
            Events.Remove(ev);
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }
    }
}
