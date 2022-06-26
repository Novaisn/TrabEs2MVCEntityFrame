using System;
using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public partial class Ativofinanceiro
    {
        public Ativofinanceiro()
        {
            Depositos = new HashSet<Deposito>();
            Fundos = new HashSet<Fundo>();
            Imovels = new HashSet<Imovel>();
        }

        
        public int Idativo { get; set; }
        public DateTime Datainicio { get; set; }
        public int? Durancao { get; set; }
        public double? Taxaimposto { get; set; }
        public int? Idcliente { get; set; }

        public virtual Utilizador? IdclienteNavigation { get; set; }
        public virtual ICollection<Deposito> Depositos { get; set; }
        public virtual ICollection<Fundo> Fundos { get; set; }
        public virtual ICollection<Imovel> Imovels { get; set; }
    }
}
