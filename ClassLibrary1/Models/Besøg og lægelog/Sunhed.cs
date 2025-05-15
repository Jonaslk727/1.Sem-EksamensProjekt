using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models.Besøg_og_lægelog
{
    internal class Sunhed
    {
        public DateTime Lægebesøg { get; set; }
        public string Journal { get; set; } = "none";

        public Sunhed(DateTime lægebesøg, string journal)
        {
            Lægebesøg = lægebesøg;
            Journal = journal;
        }
    }
}
