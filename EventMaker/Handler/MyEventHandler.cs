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
        public EventViewModel evm { get; set; }

        public MyEventHandler(EventViewModel Evm)
        {
            this.evm = Evm;
        }
        public void CreateEvent()
        {
            Event NewEvent = new Event(evm.Id, evm.Name, evm.Description, evm.Place, DateTimeConveter.DateTimeOffsetAndTimeSetToDateTime(evm.Date, evm.Time));
        }

        public void DeleteEvent(Event ev)
        {
            //Model.EventCatalogSingleton.Instance.RemoveEvent(evm.);
            //EventCatalogSingleton.Instance.RemoveEvent(ev);
        }
    }
}
