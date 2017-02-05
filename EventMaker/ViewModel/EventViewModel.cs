using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.View;

namespace EventMaker.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        public EventCatalogSingleton singleton { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }
        public ICommand CreateEventCommand { get; set; }
        public MyEventHandler eh { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        private Event selectedEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProbertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 

        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                OnProbertyChanged(nameof(SelectedEvent));
            } 
            
        }


        

        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            eh = new MyEventHandler(this);
            CreateEventCommand = new Common.RelayCommand(eh.CreateEvent);
            //DeleteEventCommand = new Common.RelayCommand(eh.DeleteEvent());
        }

        
        

    }
}
