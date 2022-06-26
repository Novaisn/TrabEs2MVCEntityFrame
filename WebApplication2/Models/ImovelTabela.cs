namespace WebApplication2.Models;

public class ImovelTabela
{
    public ImovelTabela(Entities.Imovel imovel)
    {
        this.Name = imovel.Nome;
        this.valorRenda = imovel.Valorrenda;
        this.Time = imovel.IdativoNavigation.Datainicio;
        this.UserName = imovel.IdativoNavigation.Durancao;
        this.rua = imovel.Rua;
        this.valorCondo = imovel.Valorcondo;
        this.valoresti = imovel.Valoresti;
        this.nporta = imovel.Nporta;
        this.codpostal = imovel.Codpostal;
       
    }

   

    public string? codpostal { get; set; }

    public string? nporta { get; set; }

    public double? valoresti { get; set; }

    public double? valorCondo { get; set; }

    public string? rua { get; set; }

    public DateTime Time { get; set; }

    public int? UserName { get; set; }

    public double? valorRenda { get; set; }

    public string? Name { get; set; }
}