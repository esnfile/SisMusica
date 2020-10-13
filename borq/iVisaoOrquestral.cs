using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ENT.uteis;
using ENT.instrumentos;
using ENT.pessoa;

namespace BLL.Interface
{
    public interface iVisaoOrquestral
    {
        //métodos para buscar os dados nas DALs
        List<MOD_regional> buscarRegional(string Descricao);
        List<MOD_regiaoAtuacao> buscarRegiao(string CodRegional);
        List<MOD_ccb> buscarCCBRegiao(string CodRegiao);
        List<MOD_ccb> buscarCCBCidade(string CodCidade);
        List<MOD_voz> buscarVozes(string Descricao);
        List<MOD_familia> buscarFamilia(string Descricao);
        List<MOD_instrumentoVozPrincipal> buscarInstrumentos(string CodFamilia);
        List<MOD_instrumentoVozPrincipal> buscarInstrumentos(string CodVoz, string CodFamilia);
        List<MOD_uf> buscarUf(string Sigla);
        List<MOD_cidade> buscarMunicipios(string Estado);
        List<MOD_pessoa> buscarVisaoOrquestral(string CodInstrumento, string CodCCB, bool Ativo);
    }
}