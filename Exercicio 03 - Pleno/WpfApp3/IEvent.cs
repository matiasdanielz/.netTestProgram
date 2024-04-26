using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class IEvent
    {
        private static int nextID = 1;
        public string id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string localization { get; set; }
        public string description { get; set; }
        public List<IParticipant> participants { get; set; }
        public IEvent()
        {
            participants = new List<IParticipant>();
            id = nextID++.ToString();
        }
    }
}
