using System;
using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            Ativofinanceiros = new HashSet<Ativofinanceiro>();
        }

        public int Idutilizador { get; set; }
        public string? Nome { get; set; }
        public string? Nif { get; set; }
        public string? Ncc { get; set; }
        public string? Rua { get; set; }
        public string? Nporta { get; set; }
        public string? Username { get; set; }
        public string? Pass { get; set; }
        public string? Codpostal { get; set; }
        public int? Tipouser { get; set; }

        public virtual Codpostal? CodpostalNavigation { get; set; }
        public virtual ICollection<Ativofinanceiro> Ativofinanceiros { get; set; }
    }
}
