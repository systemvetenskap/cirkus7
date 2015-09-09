using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cirkus
{
    class Personal
    {
        public string förnamn { get; set; }
        public string efternamn { get; set; }
        public string telefonnummer { get; set; }
        public string gatuadress { get; set; }
        public string epost { get; set; }
        public string användarnamn { get; set; }
        public string lösenord { get; set; }
        public string behörighetsnivå { get; set; }

        public override string ToString()
        {
            return förnamn+" "+efternamn+"\t"+telefonnummer;
        }
    }
}
