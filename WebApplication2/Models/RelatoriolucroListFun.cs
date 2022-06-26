namespace WebApplication2.Models;

public class RelatoriolucroListFun
{
    public RelatoriolucroListFun()
    {
        relatoriolucroFunModel = new List<RelatoriolucroFunModel>();
    }
    
    public List<RelatoriolucroFunModel> relatoriolucroFunModel { get; set; }
    
    public double Lucro { get; set; }
    
    public double LucroImposto { get; set; }
}