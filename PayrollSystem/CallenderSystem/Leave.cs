using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.CallenderSystem
{
    public class Leave : TimeFrame
    {
        public string Reason { get; set; }
        public Leave() : this("General") { } //Default reason is General leave
        public Leave(string reason_for_leave) { Reason = reason_for_leave; }
    }
}
