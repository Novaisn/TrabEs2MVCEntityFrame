namespace WebApplication2.Models;

public class RelatoriolucroIListmoModel
{
    public RelatoriolucroIListmoModel()
    {
        relatoriolucroImoModel = new List<RelatoriolucroImoModel>();
    }
    
    public double Lucro { get; set; }
    
    public double LucroImposto { get; set; }
    public List<RelatoriolucroImoModel> relatoriolucroImoModel { get; set; }
}