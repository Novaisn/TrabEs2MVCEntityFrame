using WebApplication2.Entities;

namespace WebApplication2.Models;

public class DepositoModel
{
    public DepositoModel(Deposito deposito)
    {
        this.Iddeposito = deposito.Iddeposito;
        this.Banco = deposito.Banco;
        this.Titulares = deposito.Titulares;
        this.Valor = deposito.Valor;
        this.Taxajuro = deposito.Taxajuro;
        this.Nconta = deposito.Nconta;
        
    }

    public int Iddeposito { get; set; }

    public string? Nconta { get; set; }

    public double? Taxajuro { get; set; }

    public double? Valor { get; set; }

    public string? Titulares { get; set; }

    public string? Banco { get; set; }
}