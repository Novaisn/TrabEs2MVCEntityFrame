namespace WebApplication2.Models;

public class DatasModel
{
    public DatasModel()
    {
      DtFim = DateTime.Now;
      DtInicio = DateTime.Now;
    }

    public DateTime DtFim { get; set; }

    public DateTime DtInicio { get; set; }
}