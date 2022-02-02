using System;
using System.Collections.Generic;

namespace TestePI
{
    public partial class ContatosFavoritos
    {
        public ContatosFavoritos()
        {
            InverseICodCooperadoNavigation = new HashSet<ContatosFavoritos>();
        }

        public int ICodFavorito { get; set; }
        public int ICodCooperado { get; set; }
        public string SNomeContatoFavorito { get; set; }
        public int ICodPix { get; set; }
        public string SChavePix { get; set; }

        public virtual ContatosFavoritos ICodCooperadoNavigation { get; set; }
        public virtual ICollection<ContatosFavoritos> InverseICodCooperadoNavigation { get; set; }
    }
}
