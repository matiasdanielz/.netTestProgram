using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class IParticipant
    {
        private static int nextID = 1;
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public IParticipant()
        {
            id = nextID++.ToString();
        }
    }
}
