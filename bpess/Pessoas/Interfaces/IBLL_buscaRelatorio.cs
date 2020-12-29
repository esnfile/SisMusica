using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaRelatorio
    {
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string Desenvolvimento);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string Desenvolvimento);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal);
        List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento);
    }
}