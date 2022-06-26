namespace WebApplication2.Models;

public class ImovelModel
{
    public ImovelModel(Entities.Imovel imovel)
    {
        this.Idimovel = imovel.Idimovel;
        this.Name = imovel.Nome;
        this.valorRenda = imovel.Valorrenda;
        //this.UserName = imovel.IdativoNavigation.Idativo.ToString();
       // this.Time = imovel.IdativoNavigation.Datainicio;
        this.rua = imovel.Rua;
        this.valorCondo = imovel.Valorcondo;
        this.valoresti = imovel.Valoresti;
        this.nporta = imovel.Nporta;
        //this.codpostal = imovel.CodpostalNavigation.Localidade;
       
    }

    public int Idimovel { get; set; }


    public string? codpostal { get; set; }

    public string? nporta { get; set; }

    public double? valoresti { get; set; }

    public double? valorCondo { get; set; }

    public string? rua { get; set; }

    public DateTime Time { get; set; }

    public string UserName { get; set; }

    public double? valorRenda { get; set; }

    public string? Name { get; set; }
}