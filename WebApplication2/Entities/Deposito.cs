using System;
using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public partial class Deposito
    {
        public int Iddeposito { get; set; }
        public string? Banco { get; set; }
        public string? Titulares { get; set; }
        public double? Valor { get; set; }
        public double? Taxajuro { get; set; }
        public string? Nconta { get; set; }
        public int Idativo { get; set; }

        public virtual Ativofinanceiro? IdativoNavigation { get; set; }
    }
}
