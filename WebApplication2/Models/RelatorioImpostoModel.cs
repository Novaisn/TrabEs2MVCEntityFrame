using WebApplication2.Entities;

namespace WebApplication2.Models;

public class RelatorioImpostoModel
{
    public RelatorioImpostoModel()
    {
        relatorioDepModel = new List<RelatoriolucroDepModel>();
        relatorioImoModel = new List<RelatoriolucroImoModel>();
        relatorioFunModel = new List<RelatoriolucroFunModel>();
    }
    
    public double Imposto { get; set; }
    public List<RelatoriolucroDepModel> relatorioDepModel { get; set; }
    
    public List<RelatoriolucroImoModel> relatorioImoModel { get; set; }
    
    public List<RelatoriolucroFunModel> relatorioFunModel { get; set; }
}