using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;
using BLL.Funcoes;

namespace BLL.pessoa
{
    public class BLL_buscaRelatorioPessoa : IBLL_buscaRelatorio
    {
        DataTable objDtb = null;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
        DAL_buscaRelatorio objDAL = new DAL_buscaRelatorio();

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string Desenvolvimento)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string Desenvolvimento)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo, Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal), Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: true ou false</para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: true ou false</para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                objDtb = objDAL.Buscar(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal), Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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