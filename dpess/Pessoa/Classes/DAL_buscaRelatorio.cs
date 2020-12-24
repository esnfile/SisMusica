using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaRelatorio
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));

                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");

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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Desenvolvimento", Desenvolvimento));

                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");

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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));

                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");

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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Ativo"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));

                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");

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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@Desenvolvimento", Desenvolvimento));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                                "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                                "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                                "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, Ativo, EstadoCivil, Cargo e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <returns></returns>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
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
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, Ativo, EstadoCivil, Cargo e Comum
        /// <paramref name="Ativo"/>: true ou false - 
        /// <paramref name="Sexo"/>: Masculino, Feminino - 
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao - 
        /// <paramref name="EstadoCivil"/>: Solteiro(a), Casado(a), Viúvo(a), Divorciado(a) - 
        /// <paramref name="Desenvolvimento"/>: Aluno GEM, Ensaios, Meia Hora, Reunião Jovens, Culto Oficial, Oficializado
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Desenvolvimento"></param>
        public DataTable Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@Desenvolvimento", Desenvolvimento));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
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
    }
}