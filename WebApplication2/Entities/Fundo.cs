using System;
using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public partial class Fundo
    {
        public int Idfundo { get; set; }
        public string? Nome { get; set; }
        public double? Montante { get; set; }
        public double? Taxajuro { get; set; }
        public int Idativo { get; set; }

        public virtual Ativofinanceiro? IdativoNavigation { get; set; }
    }
}
