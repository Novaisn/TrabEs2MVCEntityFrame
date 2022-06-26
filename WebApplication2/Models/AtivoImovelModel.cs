namespace WebApplication2.Models;

public class AtivoImovelModel
{
    public AtivoImovelModel(Entities.Imovel imovel,Entities.Ativofinanceiro ativofinanceiro)
    {
        this.Idimovel = imovel.Idimovel;
        this.Nome = imovel.Nome;
        this.Idativo = imovel.Idativo;
        this.valorRenda = imovel.Valorrenda;
        this.rua = imovel.Rua;
        this.valorCondo = imovel.Valorcondo;
        this.valoresti = imovel.Valoresti;
        this.nporta = imovel.Nporta;
        this.codpostal = imovel.Codpostal;
       
        this.Datainicio = ativofinanceiro.Datainicio;
        this.Durancao = ativofinanceiro.Durancao;
        this.Taxaimposto = ativofinanceiro.Taxaimposto;
        this.Idcliente = ativofinanceiro.Idcliente;
    }

    public int Idimovel { get; set; }

    public int? Idativo { get; set; }

    public int? Idcliente { get; set; }

    public double? Taxaimposto { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainicio { get; set; }

    public string? codpostal { get; set; }

    public string? nporta { get; set; }

    public double? valoresti { get; set; }

    public double? valorCondo { get; set; }

    public string? rua { get; set; }

    

    public string UserName { get; set; }

    public double? valorRenda { get; set; }

    public string? Nome { get; set; }
}