using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

using BLL.Funcoes;
using DAL.acessos;
using ENT.acessos;
using ENT.Log;
using DAL.log;
using DAL.Usuario;
using BLL.acessos;
using ENT.pessoa;
using ENT.uteis;
using System.ComponentModel;

namespace BLL.Usuario
{
    public class BLL_usuario
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_usuario objDAL = null;
        DAL_log objDAL_Log = null;
        DAL_usuarioCargo objDAL_UsuCargo = null;
        DAL_usuarioCCB objDAL_UsuCCB = null;

        DAL_usuarioRegiao objDAL_UsuReg = null;

        BLL_acessos objBLL_Acesso = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoAcesso;
        bool blnRetornoLog;
        bool blnRetornoCargo;
        bool blnRetornoCargoLog;
        bool blnRetornoCCB;
        bool blnRetornoCCBLog;
        bool blnRetornoReg;
        bool blnRetornoRegLog;

        DataTable objDtb = null;
        DataTable objDtb_UsuCargo = null;
        DataTable objDtb_UsuCCB = null;
        DataTable objDtbCargo = null;
        DataTable objDtbCCB = null;
        DataTable objDtb_UsuReg = null;
        DataTable objDtbRegiao = null;

        List<MOD_usuario> listaFunc = new List<MOD_usuario>();
        List<MOD_acessos> listaAcesso = new List<MOD_acessos>();
        List<MOD_rotinas> listaRotina = new List<MOD_rotinas>();
        List<MOD_usuarioCargo> listaUsuCargo = new List<MOD_usuarioCargo>();
        BindingList<MOD_usuarioCCB> listaUsuCCB = new BindingList<MOD_usuarioCCB>();
        List<MOD_cargo> listaCargo = new List<MOD_cargo>();
        List<MOD_ccb> listaCCB = new List<MOD_ccb>();
        BindingList<MOD_usuarioRegiao> listaUsuReg = new BindingList<MOD_usuarioRegiao>();
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_usuario objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoAcesso = true;
                    blnRetornoLog = true;
                    blnRetornoCargo = true;
                    blnRetornoCargoLog = true;
                    blnRetornoCCB = true;
                    blnRetornoCCBLog = true;
                    blnRetornoReg = true;
                    blnRetornoRegLog = true;

                    #endregion

                    #region Movimentação da tabela Usuario e Logs

                    objDAL = new DAL_usuario();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt = validaDadosUsuario(objEnt);
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela Acessos

                    //verifica se há registro na lista Acesso
                    if (objEnt.listaAcesso != null && objEnt.listaAcesso.Count > 0)
                    {
                        objBLL_Acesso = new BLL_acessos();
                        foreach (MOD_acessos ent in objEnt.listaAcesso)
                        {
                            ent.CodUsuario = objEnt.CodUsuario;
                            blnRetornoAcesso = objBLL_Acesso.salvar(ent);

                            //verifica se retornou false e sai do for
                            if (blnRetornoAcesso.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela UsuarioCargo

                    objDAL_UsuCargo = new DAL_usuarioCargo();
                    //Verifica os registros anteriores, quais comum estão já permitidas e quais não estão
                    List<MOD_usuarioCargo> listaUsuCargoPerm = buscarUsuarioCargo(objEnt.CodUsuario);

                    //verifica se há registro na lista
                    if (objEnt.listaUsuarioCargo != null && objEnt.listaUsuarioCargo.Count > 0)
                    {
                        objDAL_UsuCargo = new DAL_usuarioCargo();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_usuarioCargo ent in objEnt.listaUsuarioCargo)
                        {

                            ///Verificar se na lista de comuns informada, já consta nas comuns ja permitidas anteriormente 
                            List<MOD_usuarioCargo> listaFiltro = new List<MOD_usuarioCargo>();
                            listaFiltro = listaUsuCargoPerm.Where(u => u.CodCargo.Equals(ent.CodCargo)).ToList();

                            bool blnRetornoCargoPerm = false;
                            bool blnRetornoCargoPermLog = false;

                            if (listaFiltro.Count > 0)
                            {
                                foreach (MOD_usuarioCargo entFiltro in listaFiltro)
                                {
                                    if (!ent.Marcado.Equals(entFiltro.Marcado))
                                    {
                                        if (entFiltro.Marcado.Equals(true))
                                        {
                                            //Chama a função que converte as datas
                                            objEnt.Logs = criarLogCargo(entFiltro, "Liberação");
                                        }
                                        else
                                        {
                                            //Chama a função que converte as datas
                                            objEnt.Logs = criarLogCargo(entFiltro, "Bloqueio");
                                        }
                                        objEnt.Logs = validaDadosLog(objEnt.Logs);

                                        ent.CodUsuario = objEnt.CodUsuario;
                                        blnRetornoCargoPerm = objDAL_UsuCargo.salvar(ent);
                                        blnRetornoCargoPermLog = objDAL_Log.inserir(objEnt.Logs);
                                    }
                                    else
                                    {
                                        blnRetornoCargoPerm = true;
                                        blnRetornoCargoPermLog = true;
                                    }
                                }
                            }
                            else
                            {
                                if (ent.Marcado.Equals(true))
                                {
                                    //Chama a função que converte as datas
                                    objEnt.Logs = criarLogCargo(ent, "Liberação");
                                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                                    ent.CodUsuario = objEnt.CodUsuario;
                                    blnRetornoCargoPerm = objDAL_UsuCargo.salvar(ent);
                                    blnRetornoCargoPermLog = objDAL_Log.inserir(objEnt.Logs);
                                }
                                else
                                {
                                    blnRetornoCargoPerm = true;
                                    blnRetornoCargoPermLog = true;
                                }
                            }
                            blnRetornoCargo = blnRetornoCargoPerm;
                            blnRetornoCargoLog = blnRetornoCargoPermLog;

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoCargo.Equals(false) || blnRetornoCargoLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion
                    
                    #region Movimentação da tabela UsuarioRegiao

                    //Verifica os registros anteriores, quais comum estão já permitidas e quais não estão
                    BindingList<MOD_usuarioRegiao> listaUsuRegiaoPerm = buscarUsuarioRegiao(objEnt.CodUsuario);

                    //verifica se há registro na lista
                    if (objEnt.listaUsuarioRegiao != null && objEnt.listaUsuarioRegiao.Count > 0)
                    {
                        objDAL_UsuReg = new DAL_usuarioRegiao();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_usuarioRegiao ent in objEnt.listaUsuarioRegiao)
                        {

                            ///Verificar se na lista de comuns informada, já consta nas comuns ja permitidas anteriormente 
                            List<MOD_usuarioRegiao> listaFiltro = new List<MOD_usuarioRegiao>();
                            listaFiltro = listaUsuRegiaoPerm.Where(u => u.CodRegiao.Equals(ent.CodRegiao)).ToList();

                            bool blnRetornoRegPerm = false;
                            bool blnRetornoRegPermLog = false;

                            if (listaFiltro.Count > 0)
                            {
                                foreach (MOD_usuarioRegiao entFiltro in listaFiltro)
                                {
                                    if (!ent.Marcado.Equals(entFiltro.Marcado))
                                    {
                                        if (entFiltro.Marcado.Equals(true))
                                        {
                                            //Chama a função que converte as datas
                                            objEnt.Logs = criarLogRegiao(entFiltro, "Liberação");
                                        }
                                        else
                                        {
                                            //Chama a função que converte as datas
                                            objEnt.Logs = criarLogRegiao(entFiltro, "Bloqueio");
                                        }
                                        objEnt.Logs = validaDadosLog(objEnt.Logs);

                                        ent.CodUsuario = objEnt.CodUsuario;
                                        blnRetornoRegPerm = objDAL_UsuReg.salvar(ent);
                                        blnRetornoRegPermLog = objDAL_Log.inserir(objEnt.Logs);
                                    }
                                    else
                                    {
                                        blnRetornoRegPerm = true;
                                        blnRetornoRegPermLog = true;
                                    }
                                }
                            }
                            else
                            {
                                if (ent.Marcado.Equals(true))
                                {
                                    //Chama a função que converte as datas
                                    objEnt.Logs = criarLogRegiao(ent, "Liberação");
                                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                                    ent.CodUsuario = objEnt.CodUsuario;
                                    blnRetornoRegPerm = objDAL_UsuReg.salvar(ent);
                                    blnRetornoRegPermLog = objDAL_Log.inserir(objEnt.Logs);
                                }
                                else
                                {
                                    blnRetornoRegPerm = true;
                                    blnRetornoRegPermLog = true;
                                }
                            }
                            blnRetornoReg = blnRetornoRegPerm;
                            blnRetornoRegLog = blnRetornoRegPermLog;

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoReg.Equals(false) || blnRetornoRegLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela UsuarioCCB

                    objDAL_UsuCCB = new DAL_usuarioCCB();
                    //Verifica os registros anteriores, quais comum estão já permitidas e quais não estão
                    BindingList<MOD_usuarioCCB> listaUsuCCBPermitida = buscarUsuarioCCB(objEnt.CodUsuario);

                    //verifica se há registro na lista
                    if (objEnt.listaUsuarioCCB != null && objEnt.listaUsuarioCCB.Count > 0)
                    {

                        objDAL_UsuCCB = new DAL_usuarioCCB();
                        //Faz o loop para gravar na tabela
                        foreach (MOD_usuarioCCB ent in objEnt.listaUsuarioCCB)
                        {

                            ///Verificar se na lista de comuns informada, já consta nas comuns ja permitidas anteriormente 
                            List<MOD_usuarioCCB> listaFiltro = new List<MOD_usuarioCCB>();
                            listaFiltro = listaUsuCCBPermitida.Where(u => u.CodCCB.Equals(ent.CodCCB)).ToList();

                            bool blnRetornoCCBPerm = false;
                            bool blnRetornoCCBPermLog = false;

                            if (listaFiltro.Count > 0)
                            {
                                foreach (MOD_usuarioCCB entFiltro in listaFiltro)
                                {
                                    if (!ent.Marcado.Equals(entFiltro.Marcado))
                                    {
                                        if (entFiltro.Marcado.Equals(true))
                                        {
                                            //Chama a função que converte as datas
                                            objEnt.Logs = criarLogCCB(ent, "Liberação");
                                        }
                                        else
                                        {
                                            //Chama a função que converte as datas
                                            objEnt.Logs = criarLogCCB(ent, "Bloqueio");
                                        }
                                        objEnt.Logs = validaDadosLog(objEnt.Logs);

                                        ent.CodUsuario = objEnt.CodUsuario;
                                        blnRetornoCCBPerm = objDAL_UsuCCB.salvar(ent);
                                        blnRetornoCCBPermLog = objDAL_Log.inserir(objEnt.Logs);
                                    }
                                    else
                                    {
                                        blnRetornoCCBPerm = true;
                                        blnRetornoCCBPermLog = true;
                                    }
                                }
                            }
                            else
                            {
                                if (ent.Marcado.Equals(true))
                                {
                                    //Chama a função que converte as datas
                                    objEnt.Logs = criarLogCCB(ent, "Liberação");
                                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                                    ent.CodUsuario = objEnt.CodUsuario;
                                    blnRetornoCCBPerm = objDAL_UsuCCB.salvar(ent);
                                    blnRetornoCCBPermLog = objDAL_Log.inserir(objEnt.Logs);
                                }
                                else
                                {
                                    blnRetornoCCBPerm = true;
                                    blnRetornoCCBPermLog = true;
                                }
                            }
                            blnRetornoCCB = blnRetornoCCBPerm;
                            blnRetornoCCBLog = blnRetornoCCBPermLog;
                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoCCB.Equals(false) || blnRetornoCCBLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }                

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) || blnRetornoAcesso.Equals(false) ||
                        blnRetornoCCB.Equals(false) || blnRetornoCCBLog.Equals(false) || 
                        blnRetornoReg.Equals(false) || blnRetornoRegLog.Equals(false) ||
                        blnRetornoCargo.Equals(false) || blnRetornoCargoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE na Senha
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvarSenha(MOD_usuario objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação na Tabela Usuario e Logs

                    objDAL = new DAL_usuario();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "UpdateSenha");
                    objEnt = validaDadosUsuario(objEnt);
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvarSenha(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_usuario objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoAcesso = true;
                    blnRetornoLog = true;
                    blnRetornoCargo = true;
                    blnRetornoCargoLog = true;
                    blnRetornoCCB = true;
                    blnRetornoCCBLog = true;
                    blnRetornoReg = true;
                    blnRetornoRegLog = true;

                    #endregion

                    #region Movimentação da tabela Usuario e Logs

                    objDAL = new DAL_usuario();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodUsuario = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt = validaDadosUsuario(objEnt);
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela Acessos

                    //verifica se há registro na lista Acesso
                    if (objEnt.listaAcesso != null && objEnt.listaAcesso.Count > 0)
                    {
                        objBLL_Acesso = new BLL_acessos();
                        foreach (MOD_acessos ent in objEnt.listaAcesso)
                        {
                            ent.CodUsuario = objEnt.CodUsuario;
                            blnRetornoAcesso = objBLL_Acesso.salvar(ent);

                            //verifica se retornou false e sai do for
                            if (blnRetornoAcesso.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela UsuarioCargo

                    //verifica se há registro na lista
                    if (objEnt.listaUsuarioCargo != null && objEnt.listaUsuarioCargo.Count > 0)
                    {
                        objDAL_UsuCargo = new DAL_usuarioCargo();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_usuarioCargo ent in objEnt.listaUsuarioCargo)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLogCargo(ent, "Liberação");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodUsuario = objEnt.CodUsuario;
                            blnRetornoCargo = objDAL_UsuCargo.salvar(ent);
                            blnRetornoCargoLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoCargo.Equals(false) || blnRetornoCargoLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela UsuarioRegiao

                    //verifica se há registro na lista
                    if (objEnt.listaUsuarioRegiao != null && objEnt.listaUsuarioRegiao.Count > 0)
                    {
                        objDAL_UsuReg = new DAL_usuarioRegiao();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_usuarioRegiao ent in objEnt.listaUsuarioRegiao)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLogRegiao(ent, "Liberação");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodUsuario = objEnt.CodUsuario;
                            blnRetornoReg = objDAL_UsuReg.salvar(ent);
                            blnRetornoRegLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoReg.Equals(false) || blnRetornoRegLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela UsuarioCCB

                    //verifica se há registro na lista
                    if (objEnt.listaUsuarioCCB != null && objEnt.listaUsuarioCCB.Count > 0)
                    {
                        objDAL_UsuCCB = new DAL_usuarioCCB();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_usuarioCCB ent in objEnt.listaUsuarioCCB)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLogCCB(ent, "Liberação");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodUsuario = objEnt.CodUsuario;
                            blnRetornoCCB = objDAL_UsuCCB.salvar(ent);
                            blnRetornoCCBLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoCCB.Equals(false) || blnRetornoCCBLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) || blnRetornoAcesso.Equals(false) ||
                        blnRetornoCCB.Equals(false) || blnRetornoCCBLog.Equals(false) ||
                        blnRetornoReg.Equals(false) || blnRetornoRegLog.Equals(false) ||
                        blnRetornoCargo.Equals(false) || blnRetornoCargoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer DELETE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_usuario objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Usuario e Logs

                    objDAL = new DAL_usuario();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Delete");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.excluir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroExcluir);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        #endregion

        #region Funções que transmite os Critério para a DAL realizar a Busca no Banco

        #region Busca os Valores da Tabela Usuarios

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarCod(string CodUsuario)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarCod(CodUsuario);

                if (objDtb != null)
                {
                    listaFunc = this.criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Código informado, para pesquisa e Retorna Usuarios Ativos ou Inativos
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarCod(string CodUsuario, string Ativo)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarCod(CodUsuario, Ativo);

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarNome(string Nome)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarNome(Nome + "%");

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Nome informado, para pesquisa e Retorna Usuarios Ativos ou Inativos
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarNome(string Nome, string Ativo)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarNome(Nome + "%", Ativo);

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarPessoa(string CodPessoa)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarPessoa(CodPessoa);

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o CodPessoa informado, para pesquisa e Retorna Usuarios Ativos ou Inativos
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarPessoa(string CodPessoa, string Ativo)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarPessoa(CodPessoa, Ativo);

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Usuario informado
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarUsuario(string Usuario)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarUsuario(Usuario + "%");

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Usuario informado, e Retorna Usuarios Ativos ou Inativos
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarUsuario(string Usuario, string Ativo)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarUsuario(Usuario, Ativo);

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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
        /// Função que Transmite o Usuario e a Senha informada, e Retorna Usuarios Ativos ou Inativos
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Senha"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_usuario> buscarSenha(string Usuario, string Senha, string Ativo)
        {
            try
            {
                objDAL = new DAL_usuario();
                objDtb = objDAL.buscarSenha(Usuario, Senha, Ativo);

                if (objDtb != null)
                {
                    listaFunc = criarLista(objDtb);
                }
                return listaFunc;
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

        #region Busca os Valores da Tabela Usuario Cargo

        /// <summary>
        /// Função que Transmite o Usuario informado, para pesquisa na
        /// Tabela Usuario Cargo
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public List<MOD_usuarioCargo> buscarUsuarioCargo(string CodUsuario)
        {
            try
            {
                objDAL_UsuCargo= new DAL_usuarioCargo();
                objDtb_UsuCargo = objDAL_UsuCargo.buscarUsuarioCargo(CodUsuario);

                if (objDtb_UsuCargo != null)
                {
                    listaUsuCargo = criarListaUsuarioCargo(objDtb_UsuCargo);
                }
                return listaUsuCargo;
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
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela Cargo
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public List<MOD_cargo> buscarCargos(string CodUsuario)
        {
            try
            {
                objDAL_UsuCargo = new DAL_usuarioCargo();
                objDtbCargo = objDAL_UsuCargo.buscarCargos(CodUsuario);

                if (objDtbCargo != null)
                {
                    listaCargo = criarListaCargo(objDtbCargo);
                }
                return listaCargo;
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

        #region Busca os Valores da Tabela Usuario CCB

        /// <summary>
        /// Função que Transmite o Usuario informado, para pesquisa na
        /// Tabela Usuario CCB
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public BindingList<MOD_usuarioCCB> buscarUsuarioCCB(string CodUsuario)
        {
            try
            {
                objDAL_UsuCCB = new DAL_usuarioCCB();
                objDtb_UsuCCB = objDAL_UsuCCB.buscarUsuarioCCB(CodUsuario);

                if (objDtb_UsuCCB != null)
                {
                    listaUsuCCB = criarListaUsuarioCCB(objDtb_UsuCCB);
                }
                return listaUsuCCB;
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
        /// Função que Transmite o Usuario informado, para pesquisa na
        /// Tabela Usuario CCB
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>       
        public BindingList<MOD_usuarioCCB> buscarUsuarioCCB(string CodUsuario, string CodRegiao)
        {
            try
            {
                if (string.IsNullOrEmpty(CodRegiao))
                {
                    CodRegiao = "0";
                }
                objDAL_UsuCCB = new DAL_usuarioCCB();
                objDtb_UsuCCB = objDAL_UsuCCB.buscarUsuarioCCB(CodUsuario, CodRegiao);

                if (objDtb_UsuCCB != null)
                {
                    listaUsuCCB = criarListaUsuarioCCB(objDtb_UsuCCB);
                }
                return listaUsuCCB;
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
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela CCB
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public List<MOD_ccb> buscarCCBs(string CodUsuario)
        {
            try
            {
                objDAL_UsuCCB = new DAL_usuarioCCB();
                objDtbCCB = objDAL_UsuCCB.buscarCCBs(CodUsuario);

                if (objDtbCCB != null)
                {
                    listaCCB = criarListaCCB(objDtbCCB);
                }
                return listaCCB;
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
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela CCB
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>       
        public List<MOD_ccb> buscarCCBs(string CodUsuario, string CodRegiao)
        {
            try
            {
                if (string.IsNullOrEmpty(CodRegiao))
                {
                    CodRegiao = "0";
                }
                objDAL_UsuCCB = new DAL_usuarioCCB();
                objDtbCCB = objDAL_UsuCCB.buscarCCBs(CodUsuario, CodRegiao);

                if (objDtbCCB != null)
                {
                    listaCCB = criarListaCCB(objDtbCCB);
                }
                return listaCCB;
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

        #region Busca os Valores da Tabela Usuario RegiaoAtuacao

        /// <summary>
        /// Função que Transmite o Usuario informado, para pesquisa na
        /// Tabela Usuario Regiao
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public BindingList<MOD_usuarioRegiao> buscarUsuarioRegiao(string CodUsuario)
        {
            try
            {
                objDAL_UsuReg = new DAL_usuarioRegiao();
                objDtb_UsuReg = objDAL_UsuReg.buscarUsuarioRegiao(CodUsuario);

                if (objDtb_UsuReg != null)
                {
                    listaUsuReg = criarListaUsuarioReg(objDtb_UsuReg);
                }
                return listaUsuReg;
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
        /// Função que Transmite o Usuario informado, para pesquisa na
        /// Tabela Usuario RegiaoAtuacao
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegional"></param>
        /// <returns></returns>       
        public BindingList<MOD_usuarioRegiao> buscarUsuarioRegiao(string CodUsuario, string CodRegional)
        {
            try
            {
                objDAL_UsuReg = new DAL_usuarioRegiao();
                objDtb_UsuReg = objDAL_UsuReg.buscarUsuarioRegiao(CodUsuario, CodRegional);

                if (objDtb_UsuReg != null)
                {
                    listaUsuReg = criarListaUsuarioReg(objDtb_UsuReg);
                }
                return listaUsuReg;
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
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela RegiaoAtuacao
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public List<MOD_regiaoAtuacao> buscarRegiao(string CodUsuario)
        {
            try
            {
                objDAL_UsuReg = new DAL_usuarioRegiao();
                objDtbRegiao = objDAL_UsuReg.buscarRegiao(CodUsuario);

                if (objDtbRegiao != null)
                {
                    listaRegiao = criarListaRegiao(objDtbRegiao);
                }
                return listaRegiao;
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
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela RegiaoAtuacao
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>       
        public List<MOD_regiaoAtuacao> buscarRegiao(string CodUsuario, string CodRegiao)
        {
            try
            {
                objDAL_UsuReg = new DAL_usuarioRegiao();
                objDtbRegiao = objDAL_UsuReg.buscarRegiao(CodUsuario, CodRegiao);

                if (objDtbRegiao != null)
                {
                    listaRegiao = criarListaRegiao(objDtbRegiao);
                }
                return listaRegiao;
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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                objDAL = new DAL_usuario();
                return objDAL.retornaId();
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_usuario> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_usuario> lista = new List<MOD_usuario>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_usuario ent = new MOD_usuario();
                    //adiciona os campos às propriedades
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.Senha = (string)(row.IsNull("Senha") ? null : row["Senha"]);
                    ent.DataAlteraSenha = (string)(row.IsNull("DataAlteraSenha") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataAlteraSenha"])));
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataCadastro"])));
                    ent.Supervisor = (string)(row.IsNull("Supervisor") ? null : row["Supervisor"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.AlteraSenha = (string)(row.IsNull("AlteraSenha") ? null : row["AlteraSenha"]);

                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista comos valores
                return lista;
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

        #region Lista Usuario Cargo

        /// <summary>
        /// Função que Retorna a Lista da Tabela Usuario Cargo Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_usuarioCargo> criarListaUsuarioCargo(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_usuarioCargo> lista = new List<MOD_usuarioCargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_usuarioCargo ent = new MOD_usuarioCargo();
                    //adiciona os campos às propriedades
                    ent.CodUsuarioCargo = (string)(row.IsNull("CodUsuarioCargo") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioCargo"]));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
                    ent.AtendeGEM = (string)(row.IsNull("AtendeGEM") ? null : row["AtendeGEM"]);
                    ent.AtendeRegiao = (string)(row.IsNull("AtendeRegiao") ? null : row["AtendeRegiao"]);
                    ent.AtendeComum = (string)(row.IsNull("AtendeComum") ? null : row["AtendeComum"]);
                    ent.Marcado = true;
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela Cargos Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_cargo> criarListaCargo(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_cargo> lista = new List<MOD_cargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_cargo ent = new MOD_cargo();
                    //adiciona os campos às propriedades
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #region Lista Usuario CCB

        /// <summary>
        /// Função que Retorna a Lista da Tabela Usuario CCB Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_usuarioCCB> criarListaUsuarioCCB(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_usuarioCCB> lista = new BindingList<MOD_usuarioCCB>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_usuarioCCB ent = new MOD_usuarioCCB();
                    //adiciona os campos às propriedades
                    ent.CodUsuarioCCB = (string)(row.IsNull("CodUsuarioCCB") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioCCB"]));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : row["CodRegiao"].ToString().PadLeft(6, '0'));
                    ent.Marcado = true;
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela CCBs Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_ccb> criarListaCCB(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_ccb> lista = new List<MOD_ccb>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_ccb ent = new MOD_ccb();
                    //adiciona os campos às propriedades
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : row["CodRegiao"].ToString().PadLeft(6, '0'));
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #region Lista Usuario Regiao

        /// <summary>
        /// Função que Retorna a Lista da Tabela Usuario Regiao Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_usuarioRegiao> criarListaUsuarioReg(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_usuarioRegiao> lista = new BindingList<MOD_usuarioRegiao>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_usuarioRegiao ent = new MOD_usuarioRegiao();
                    //adiciona os campos às propriedades
                    ent.CodUsuarioRegiao = (string)(row.IsNull("CodUsuarioRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioRegiao"]));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.DescRegiao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.CodigoRegiao = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.CodRegional = (string)(row.IsNull("CodRegional") ? Convert.ToString(null) : Convert.ToString(row["CodRegional"]).PadLeft(5, '0'));
                    ent.DescRegional = (string)(row.IsNull("DescRegional") ? null : row["DescRegional"]);
                    ent.Marcado = true;
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela RegiaoAtuacao Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_regiaoAtuacao> criarListaRegiao(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_regiaoAtuacao> lista = new List<MOD_regiaoAtuacao>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_regiaoAtuacao ent = new MOD_regiaoAtuacao();
                    //adiciona os campos às propriedades
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.DescRegiao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.CodRegional = (string)(row.IsNull("CodRegional") ? Convert.ToString(null) : Convert.ToString(row["CodRegional"]).PadLeft(5, '0'));
                    ent.DescricaoRegional = (string)(row.IsNull("DescRegional") ? null : row["DescRegional"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #endregion

        #region Funções de apoio para validações

        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_usuario validaDadosUsuario(MOD_usuario ent)
        {
            ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
            ent.DataAlteraSenha = string.IsNullOrEmpty(ent.DataAlteraSenha) ? null : funcoes.DataInt(ent.DataAlteraSenha);

            return ent;
        }
        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_log validaDadosLog(MOD_log ent)
        {
            ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
            ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

            return ent;
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Update ou Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_usuario ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsUsuario);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditUsuario);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotExcUsuario);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("UpdateSenha"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotSenhaUsuario);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs do Cargo
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Liberação ou Bloqueio</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLogCargo(MOD_usuarioCargo ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                ent.Logs.CodRotina = Convert.ToString(modulos.rotUsuAcessoCargo);
                ent.Logs.Ocorrencia = "Foi feito " + Operacao.ToUpper() + " do Cargo: < " + ent.SiglaCargo + " - " + ent.DescCargo + " > " + " no cadastro do usuário Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs da Comum Congregação
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Liberação ou Bloqueio</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLogCCB(MOD_usuarioCCB ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                ent.Logs.CodRotina = Convert.ToString(modulos.rotUsuAcessoCargo);
                ent.Logs.Ocorrencia = "Foi feito " + Operacao.ToUpper() + " da Comum Congregação: < " + ent.Codigo + " - " + ent.Descricao + " > " + " no cadastro do usuário Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs da Região
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Liberação ou Bloqueio</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLogRegiao(MOD_usuarioRegiao ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                ent.Logs.CodRotina = Convert.ToString(modulos.rotUsuAcessoCargo);
                ent.Logs.Ocorrencia = "Foi feito " + Operacao.ToUpper() + " da Região: < " + ent.CodigoRegiao + " - " + ent.DescRegiao + " > " + " no cadastro do usuário Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs dos Acessos
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Liberação ou Bloqueio</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLogAcesso(MOD_usuarioRegiao ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                ent.Logs.CodRotina = Convert.ToString(modulos.rotUsuAcessoCargo);
                ent.Logs.Ocorrencia = "Foi feito " + Operacao.ToUpper() + " da Região: < " + ent.CodigoRegiao + " - " + ent.DescRegiao + " > " + " no cadastro do usuário Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }

        #endregion

    }
}