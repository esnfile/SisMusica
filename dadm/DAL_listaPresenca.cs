using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.administracao;

namespace DAL.administracao
{
    public class DAL_listaPresenca
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idPresenca = null;

        #endregion

        #region Strings Sql da tabela ReuniaoListaPresenca

        //string de insert na tabela ReuniaoListaPresenca
        private string strInsert = "INSERT INTO ReuniaoListaPresenca (CodListaPresenca, CodReuniao, CodPessoa) " +
"VALUES (@CodListaPresenca, @CodReuniao, @CodPessoa) ";

        //string de update na tabela ReuniaoListaPresenca
        private string strUpdate = "UPDATE ReuniaoListaPresenca SET CodReuniao = @CodReuniao, CodPessoa = @CodPessoa " +
"WHERE CodListaPresenca = @CodListaPresenca ";


        //string de delete na tabela ReuniaoListaPresenca
        private string strDelete = "DELETE FROM ReuniaoListaPresenca WHERE CodListaPresenca = @CodListaPresenca ";

        //string de select na tabela ReuniaoListaPresenca
        private string strSelect = "SELECT LP.CodListaPresenca, LP.CodReuniao, LP.CodPessoa, " +
"R.Status, R.CodUsuario, R.DataReuniao, R.HoraReuniao, R.CodTipoReuniao, R.CodUsuario, R.CodCCB AS CodCCBReuniao, " +
"CR.Codigo AS CodigoCCBReuniao, CR.Descricao AS DescricaoCCBReuniao, CR.CodRegiao AS CodRegiaoReuniao, RG.Descricao AS DescricaoRegiaoReuniao, " +
"R.CodAnciao, R.CodEncReg, R.CodExamina, R.CodCooperador, R.CodEncLocal, R.CodInstrutor, R.CodBiblia, " +
"B.DescLivro, R.Capitulo, R.VersoInicio, R.VersoFim, R.AssuntoPalavra, R.HinoAbertura, " +
"PA.Nome AS NomeAnciao, PR.Nome AS NomeEncReg, PE.Nome AS NomeExamina, " +
"PC.Nome AS NomeCooperador, PL.Nome AS NomeEncLocal, PI.Nome AS NomeInstrutor, " +
"P.CodCCB AS CodCCBPessoa, P.Nome, P.CodCargo, P.Sexo, P.CodInstrumento, I.DescInstrumento, I.CodFamilia, F.DescFamilia, " +
"CG.DescCargo, CG.SiglaCargo, CG.Ordem, CG.Masculino, CG.Feminino, U.Usuario, T.DescTipoReuniao, C.Codigo AS CodigoCCBPessoa, " +
"C.Descricao AS DescricaoCCBPessoa, C.CodCidade AS CodCidadeCCBPessoa, CC.Cidade AS CidadeCCBPessoa, " +
"C.CodRegiao AS CodRegiaoPessoa, RP.Descricao AS DescricaoRegiaoPessoa " +
"FROM ReuniaoListaPresenca AS LP " +
"LEFT OUTER JOIN ReuniaoMinisterio AS R ON LP.CodReuniao = R.CodReuniao " +
"LEFT OUTER JOIN Pessoa AS P ON LP.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PA ON R.CodAnciao = PA.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PR ON R.CodEncReg = PR.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PE ON R.CodExamina = PE.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PC ON R.CodCooperador = PC.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PL ON R.CodEncLocal = PL.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PI ON R.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN Biblia AS B ON R.CodBiblia = B.CodBiblia " +
"LEFT OUTER JOIN CCB AS CR ON R.CodCCB = CR.CodCCB " +
"LEFT OUTER JOIN CCB AS C ON P.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS RG ON CR.CodRegiao = RG.CodRegiao " +
"LEFT OUTER JOIN RegiaoAtuacao AS RP ON C.CodRegiao = RP.CodRegiao " +
"LEFT OUTER JOIN Usuario AS U ON R.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN TipoReuniao AS T ON R.CodTipoReuniao = T.CodTipoReuniao " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS CC ON C.CodCidade = CC.CodCidade " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de select na tabela Cargo
        private string strSelectAusente = "SELECT P.CodPessoa, P.CodCargo, P.Nome, " +
"P.Sexo, P.CodCidadeRes, P.EndRes, P.NumRes, P.BairroRes, P.ComplRes, P.Telefone1, P.Telefone2, " +
"P.Celular1, P.Celular2, P.Email, P.CodCCB, P.EstadoCivil, P.CodInstrumento, " +
"CG.DescCargo, CG.SiglaCargo, CG.Ordem AS OrdemCargo, CG.Masculino, CG.Feminino, " +
"C.Cidade AS CidadeRes, C.Estado AS EstadoRes, C.Cep AS CepRes, CM.Codigo AS CodigoCCB, CM.Descricao, " +
"CM.CodCidade AS CodCidadeCCB, CC.Cidade AS CidadeCCB, CC.Estado AS EstadoCCB, CM.CodRegiao AS CodRegiaoCCB, CC.Cidade AS CidadeCCB, " +
"I.DescInstrumento, I.CodFamilia, I.Ordem AS OrdemInstrumento, F.DescFamilia, R.Descricao AS DescricaoRegiaoCCB " +
"FROM Pessoa AS P " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS C ON P.CodCidadeRes = C.CodCidade " +
"LEFT OUTER JOIN CCB AS CM ON P.CodCCB = CM.CodCCB " +
"LEFT OUTER JOIN Cidade AS CC ON CM.CodCidade = CC.CodCidade " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON CM.CodRegiao = R.CodRegiao ";

        //string que retorna o próximo Id da tabela ReuniaoListaPresenca
        private string strId = "SELECT MAX (CodListaPresenca) FROM ReuniaoListaPresenca ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela ReuniaoListaPresenca
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_listaPresenca objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodListaPresenca", Convert.ToInt64(objEnt.CodListaPresenca) as object));
                objParam.Add(new SqlParameter("@CodReuniao", string.IsNullOrEmpty(objEnt.CodReuniao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodReuniao) as object));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));

                blnRetorno = objAcessa.executar(strUpdate, objParam);
                //retorna o blnRetorno da tabela principal
                return blnRetorno;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que faz INSERT na Tabela ReuniaoListaPresenca
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_listaPresenca objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ReuniaoListaPresenca
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodListaPresenca", Convert.ToInt64(objEnt.CodListaPresenca) as object));
                objParam.Add(new SqlParameter("@CodReuniao", string.IsNullOrEmpty(objEnt.CodReuniao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodReuniao) as object));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                if (exl.Number.Equals(544))
                {
                    throw new Exception("Não foi possivel buscar o próximo número da tabela");
                }
                else if (exl.Number.Equals(2601))
                {
                    throw new Exception("Não foi possivel salvar o registro, já que criaram" + "\n" +
                                        "valores duplicados na base de dados.");
                }
                else
                {
                    throw new Exception("Erro: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que faz DELETE na ReuniaoListaPresenca
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_listaPresenca objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //ReuniaoListaPresenca
                bool blnRetorno = true;

                //Declara a lista de parametros da ReuniaoListaPresenca
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodListaPresenca.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodListaPresenca", Convert.ToInt64(objEnt.CodListaPresenca) as object));

                    blnRetorno = objAcessa.executar(strDelete, objParam);
                }

                //retorna o blnRetorno da tabela principal
                return blnRetorno;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela ReuniaoListaPresenca, pesquisado pelo CodReuniao
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <returns></returns>
        public DataTable buscarListaPresenca(string CodReuniao)
        {
            try
            {
                if (string.IsNullOrEmpty(CodReuniao))
                {
                    //declara a lista de parametros
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.Nome ", objParam, "ReuniaoListaPresenca");
                }
                else
                {
                    //declara a lista de parametros
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE LP.CodReuniao = @CodReuniao ORDER BY P.Nome ", objParam, "ReuniaoListaPresenca");
                }
                    return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela ReuniaoListaPresenca, pesquisado pela Reuniao e Pessoa
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarListaPresenca(string CodReuniao, string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LP.CodReuniao = @CodReuniao AND LP.CodPessoa = @CodPessoa ORDER BY R.DataReuniao ", objParam, "ReuniaoListaPresenca");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa que estiveram Presentes, pesquisado pelo CodReunião, Sexo, Cargo e Regiao
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="Sexo"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPresentes(string CodReuniao, string Sexo, string CodCargo, string CodRegiao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));

                objDtb = objAcessa.retornaDados(strSelect + "WHERE LP.CodReuniao = @CodReuniao AND C.CodRegiao IN(" + @CodRegiao + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Sexo IN('" + @Sexo + "') ", objParam, "ReuniaoListaPresenca");

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa que não estiveram na lista de Presença, pesquisado pelo CodReunião, Sexo, Cargo e Regiao
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="Sexo"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioAusente(string CodReuniao, string Sexo, string CodCargo, string CodRegiao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));

                objDtb = objAcessa.retornaDados(strSelectAusente + "WHERE CM.CodRegiao IN(" + @CodRegiao + ") AND " +
                                                "P.CodCargo IN(" + @CodCargo + ") AND P.Sexo IN('" + @Sexo + "') AND " +
                                                "P.CodPessoa NOT IN (SELECT CodPessoa FROM ReuniaoListaPresenca WHERE CodReuniao = @CodReuniao)", objParam, "Pessoa");

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções Publicas e Privadas Usadas para retorno de Valores

        /// <summary>
        /// Função que retorna o Ultimo Código inserido na Tabela
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                idPresenca = objAcessa.retornarId(strId);
                return Convert.ToInt64(idPresenca);
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}