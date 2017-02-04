using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    class PersistencyService
    {
        public static async void SaveEventsAsJsonAsync(ObservableCollection<Model.Event> events)
        {
            
        }

        public static async Task<List<Model.Event>> LoadEventsFromJsonAsync()
        {
            return null;
        }

        public static async void SerializeEventsFileAsync(string eventsSting, string filename)
        {
            
        }

        public static async Task<string> DeSerializeEventsFileAsync(string filename)
        {
            return null;
        }
    }
}
