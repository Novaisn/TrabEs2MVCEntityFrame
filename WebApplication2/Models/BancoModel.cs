namespace WebApplication2.Models;

public class BancoModel
{
    public BancoModel()
    {
        DtFim = DateTime.Now;
        DtInicio = DateTime.Now;
    }

    public DateTime DtInicio { get; set; }

    public DateTime DtFim { get; set; }

    public String Banco { get; set; }
}