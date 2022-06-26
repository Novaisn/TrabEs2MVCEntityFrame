using WebApplication2.Entities;

namespace WebApplication2.Models;

public class RelatorioBancoModel
{
    public RelatorioBancoModel()
    {
        depositos = new List<Deposito>();
    }
    public double TotalDep { get; set; }
    public double Totaljuro { get; set; }
    public List<Deposito> depositos { get; set; }
}