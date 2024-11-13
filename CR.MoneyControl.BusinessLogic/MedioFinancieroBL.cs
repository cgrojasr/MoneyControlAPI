using System;
using CR.MoneyControl.DataAccess;
using CR.MoneyControl.Models;
using Microsoft.Extensions.Configuration;

namespace CR.MoneyControl.BusinessLogic;

public class MedioFinancieroBL
{
    private readonly MedioFinancieroDA medioFinancieroDA;

    public MedioFinancieroBL(IConfiguration configuration)
    {
        medioFinancieroDA = new MedioFinancieroDA(configuration.GetConnectionString("dbMoneyControl"));
    }

    public IEnumerable<MedioFinancieroItemModel> ListarPorUsuario(string id_usuario)
    {
        try
        {
            return medioFinancieroDA.ListarPorUsuario(id_usuario);   
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}