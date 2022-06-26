namespace WebApplication2.Models;

public class RelatoriolucroListDepModel
{
    public RelatoriolucroListDepModel()
    {
        relatoriolucroDepModel = new List<RelatoriolucroDepModel>();
    }
    public double Lucro { get; set; }
    
    public double LucroImposto { get; set; }
    public List<RelatoriolucroDepModel> relatoriolucroDepModel { get; set; }
}