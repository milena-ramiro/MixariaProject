using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMixaria.Model
{
    public class tbUsuario
    {
        public int estab { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public virtual tbEstab tbEstab { get; set; }
    }
}
