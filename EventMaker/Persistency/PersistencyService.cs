using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using EventMaker.Model;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    class PersistencyService
    {
        public PersistencyService()
        {
            
        }

        const String fileName = "savedFile.json";
        //private static readonly IStorageFile localFile;

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Model.Event> events)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(EventCatalogSingleton.Instance.Events);
            await FileIO.WriteTextAsync(localFile, JsonData);
        }

        public static async Task<List<Model.Event>> LoadEventsFromJsonAsync()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            string jsonData = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<List<Event>>(jsonData);
        }

        public static async void SerializeEventsFileAsync(string eventsSting, string filename)
        {
            
        }

        public static async Task<string> DeSerializeEventsFileAsync(string filename)
        {
            return filename;
        }
    }
}
