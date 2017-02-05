using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Converter;
using EventMaker.Model;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    class MyEventHandler
    {
        public EventViewModel VievModel { get; set; }

        public MyEventHandler(EventViewModel Event)
        {
            this.VievModel = Event;
        }
        public void CreateEvent()
        {
            Event NewEvent = new Event(VievModel.Id, VievModel.Name, VievModel.Description, VievModel.Place, DateTimeConveter.DateTimeOffsetAndTimeSetToDateTime(VievModel.Date, VievModel.Time));
            Model.EventCatalogSingleton.Instance.AddEvent(NewEvent);
        }

        public void DeleteEvent()
        {
            Model.EventCatalogSingleton.Instance.RemoveEvent(VievModel.SelectedEvent);
            
        }
    }
}
