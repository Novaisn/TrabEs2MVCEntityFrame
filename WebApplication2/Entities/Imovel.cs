using System;
using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public partial class Imovel
    {
        public int Idimovel { get; set; }
        public string? Nome { get; set; }
        public double? Valorrenda { get; set; }
        public double? Valorcondo { get; set; }
        public double? Valoresti { get; set; }
        public string? Rua { get; set; }
        public string? Nporta { get; set; }
        public string? Codpostal { get; set; }
        public int Idativo { get; set; }

        public virtual Codpostal? CodpostalNavigation { get; set; }
        public virtual Ativofinanceiro? IdativoNavigation { get; set; }
    }
}
