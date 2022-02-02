using System;
using System.Collections.Generic;

namespace TestePI
{
    public partial class Cooperado
    {
        public Cooperado()
        {
            InverseICodCooperativaNavigation = new HashSet<Cooperado>();
        }

        public int ICodCooperado { get; set; }
        public int ICodCooperativa { get; set; }
        public int IContaCorrente { get; set; }
        public string SNomeCooperado { get; set; }

        public virtual Cooperado ICodCooperativaNavigation { get; set; }
        public virtual ICollection<Cooperado> InverseICodCooperativaNavigation { get; set; }
    }
}
