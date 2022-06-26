using WebApplication2.Entities;

namespace WebApplication2.Models;

public class FundoModel
{
    public FundoModel(Fundo fundo)
    {
        this.Idfundo = fundo.Idfundo;
        this.Nome = fundo.Nome;
        this.Montante = fundo.Montante;
        this.Taxajuro = fundo.Taxajuro;
        this.Idativo = fundo.Idativo;
    }

    public int Idfundo { get; set; }

    public int? Idativo { get; set; }

    public double? Taxajuro { get; set; }

    public double? Montante { get; set; }

    public string? Nome { get; set; }
}