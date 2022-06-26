using WebApplication2.Entities;

namespace WebApplication2.Models;

public class DepositoAtivoModel
{
    public DepositoAtivoModel(Ativofinanceiro a, Deposito d)
    {
       
        this.Datainicio = a.Datainicio;
        this.Durancao = a.Durancao;
        this.Taxaimposto = a.Taxaimposto;
        this.Idcliente = a.Idcliente;

        this.Iddeposito = d.Iddeposito;
        this.Banco = d.Banco;
        this.Titulares = d.Titulares;
        this.Valor = d.Valor;
        this.Taxajuro = d.Taxajuro;
        this.Nconta = d.Nconta;
        this.Idativo = d.Idativo;
    }

    public int Iddeposito { get; set; }

    public int? Idativo { get; set; }

    public string? Nconta { get; set; }

    public double? Taxajuro { get; set; }

    public double? Valor { get; set; }

    public string? Titulares { get; set; }

    public string? Banco { get; set; }

    public int? Idcliente { get; set; }

    public double? Taxaimposto { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainicio { get; set; }
}