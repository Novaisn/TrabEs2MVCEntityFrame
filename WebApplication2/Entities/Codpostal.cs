using System;
using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public partial class Codpostal
    {
        public Codpostal()
        {
            Imovels = new HashSet<Imovel>();
            Utilizadors = new HashSet<Utilizador>();
        }

        public string Codpostal1 { get; set; } = null!;
        public string? Localidade { get; set; }

        public virtual ICollection<Imovel> Imovels { get; set; }
        public virtual ICollection<Utilizador> Utilizadors { get; set; }
    }
}
