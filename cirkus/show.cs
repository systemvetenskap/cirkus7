using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cirkus
{
    class show
    {
        public int id;
        public int seat_number;
        public string date;
        public string name;

        public override string ToString()
        {
            return name + " " + date + " " + id.ToString(); 
        }
    }
}
