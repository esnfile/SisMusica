using BLL.cargo;
using BLL.validacoes;
using ENT.Erros;
using ENT.pessoa;
using sismus.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccbpess
{
    public partial class frmCargo
    {

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void Salvar()
        {
            try
            {
                if (ValidarControles(CriarTabela))
                {
                    CargoController apiCargo = new CargoController();
                    if (Convert.ToInt16(txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        apiCargo.Insert(CriarTabela, out listaCargo);
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        apiCargo.Update(CriarTabela, out listaCargo);
                    }
                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmCargoBusca"))
                    {
                        ((frmCargoBusca)formChama).CarregaGrid(listaCargo, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(FrmCargo_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(FrmCargo_FormClosing);
                }
            }
            catch (ArgumentException ae)
            {
                throw new Exception(ae.Message);
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
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControles(MOD_cargo cargo)
        {
            try
            {
                IValidacaoCargo valida = new ValidacaoCargo();
                List<MOD_erros> erros = valida.ValidaCamposCargo(cargo);
                if (erros.Count > 0)
                {
                    return apoio.AbrirErros(erros, this);
                }
                return true;
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
        /// Função que deabilita os controles
        /// </summary>
        internal void DisabledForm()
        {
            try
            {
                pnlCargo.Enabled = false;
                btnSalvar.Enabled = false;
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
        /// Função que habilita os controles
        /// </summary>
        internal void EnabledForm()
        {
            try
            {
                pnlCargo.Enabled = true;
                btnSalvar.Enabled = true;
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
        /// Função que define o foco do cursor
        /// </summary>
        private void DefineFoco()
        {
            txtSigla.Focus();
        }

        /// <summary>
        /// Função que verifica os valores e marca as Opções
        /// </summary>
        private void Verificacoes()
        {
            try
            {
                ///Verifica se o registro permite edição ou não
                if (lblPermiteEdicao.Text.Equals("Não"))
                {
                    lblSigla.Enabled = false;
                    txtSigla.Enabled = false;
                    lblOrdem.Enabled = false;
                    txtOrdem.Enabled = false;
                    lblDescricao.Enabled = false;
                    txtDescricao.Enabled = false;
                    cboDepartamento.Enabled = false;
                }
                else
                {
                    lblSigla.Enabled = true;
                    txtSigla.Enabled = true;
                    lblOrdem.Enabled = true;
                    txtOrdem.Enabled = true;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    cboDepartamento.Enabled = true;
                }
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        private void VerPermAtendimento()
        {
            if (true.Equals(chkMasculino.Checked))
            {
                gpoAtCom.Enabled = true;
                gpoAtReg.Enabled = true;
                gpoAtEspiritual.Enabled = true;
                gpoAtMusical.Enabled = true;
                chkAtBatismo.Enabled = true;
                chkAtCeia.Enabled = true;
                chkAtReunMoc.Enabled = true;
                chkAtReunMin.Enabled = true;
                chkAtRjm.Enabled = true;
                chkAtCasal.Enabled = true;
                chkAtOrdenacao.Enabled = true;
                chkAtGem.Enabled = true;
                chkAtGem.Enabled = true;
                chkAtEnsLoc.Enabled = true;
                chkAtEnsReg.Enabled = true;
                chkAtEnsTec.Enabled = true;
                chkAtEnsParc.Enabled = true;
                chkPreRjmMus.Enabled = true;
                chkPreRjmOrg.Enabled = true;
                chkPreCultoMus.Enabled = true;
                chkPreCultoOrg.Enabled = true;
                chkPreOficialMus.Enabled = true;
                chkPreOficialOrg.Enabled = true;
                chkTesRjmMus.Enabled = true;
                chkTesRjmOrg.Enabled = true;
                chkTesCultoMus.Enabled = true;
                chkTesCultoOrg.Enabled = true;
                chkTesOficialMus.Enabled = true;
                chkTesOficialOrg.Enabled = true;
            }
            else
            {
                if (true.Equals(chkFeminino.Checked))
                {
                    gpoAtCom.Enabled = true;
                    gpoAtReg.Enabled = true;
                    gpoAtEspiritual.Enabled = false;
                    gpoAtMusical.Enabled = true;
                    chkAtGem.Enabled = true;
                    chkAtEnsLoc.Enabled = false;
                    chkAtEnsReg.Enabled = false;
                    chkAtEnsTec.Enabled = true;
                    chkAtEnsParc.Enabled = false;
                    chkPreRjmMus.Enabled = false;
                    chkPreRjmOrg.Enabled = true;
                    chkPreCultoMus.Enabled = false;
                    chkPreCultoOrg.Enabled = true;
                    chkPreOficialMus.Enabled = false;
                    chkPreOficialOrg.Enabled = true;
                    chkTesRjmMus.Enabled = false;
                    chkTesRjmOrg.Enabled = true;
                    chkTesCultoMus.Enabled = false;
                    chkTesCultoOrg.Enabled = true;
                    chkTesOficialMus.Enabled = false;
                    chkTesOficialOrg.Enabled = true;
                }
                else
                {
                    gpoAtCom.Enabled = false;
                    gpoAtReg.Enabled = false;
                    gpoAtEspiritual.Enabled = false;
                    gpoAtMusical.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Efetua a Busca de Cargo pelo Código
        /// </summary>
        /// <param name="codCargo"></param>
        /// <returns></returns>
        private List<MOD_cargo> BuscaCargoPorCodigo(int codCargo)
        {
            try
            {
                using (CargoController apiCargo = new CargoController())
                {
                    return apiCargo.BuscaCargoPorCodigo(codCargo).ToList();
                }
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
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="lista"></param>
        private List<MOD_cargo> Preencher(List<MOD_cargo> lista)
        {
            try
            {
                if (lista != null && lista.Count > 0)
                {
                    //informa os valores aos campos recebidos na lista
                    txtCodigo.Text = lista[0].CodCargo;
                    txtDescricao.Text = lista[0].DescCargo;
                    txtSigla.Text = lista[0].SiglaCargo;
                    txtOrdem.Value = Convert.ToDecimal(lista[0].Ordem);
                    cboDepartamento.SelectedValue = lista[0].CodDepartamento;
                    lblPermiteEdicao.Text = true.Equals(lista[0].PermiteEdicao) ? "Sim" : "Não";
                    if (true.Equals(lista[0].AtendeComum)) { optAtComSim.Checked = true; } else { optAtComNao.Checked = true; }
                    if (true.Equals(lista[0].AtendeRegiao)) { optAtRegSim.Checked = true; } else { optAtRegNao.Checked = true; }
                    chkAtGem.Checked = lista[0].AtendeGEM;
                    chkAtEnsLoc.Checked = lista[0].AtendeEnsaioLocal;
                    chkAtEnsReg.Checked = lista[0].AtendeEnsaioRegional;
                    chkAtEnsParc.Checked = lista[0].AtendeEnsaioParcial;
                    chkAtEnsTec.Checked = lista[0].AtendeEnsaioTecnico;
                    chkAtReunMoc.Checked = lista[0].AtendeReuniaoMocidade;
                    chkAtBatismo.Checked = lista[0].AtendeBatismo;
                    chkAtCeia.Checked = lista[0].AtendeSantaCeia;
                    chkAtRjm.Checked = lista[0].AtendeRJM;
                    chkPreRjmMus.Checked = lista[0].AtendePreTesteRjmMusico;
                    chkPreRjmOrg.Checked = lista[0].AtendePreTesteRjmOrganista;
                    chkPreCultoMus.Checked = lista[0].AtendePreTesteCultoMusico;
                    chkPreCultoOrg.Checked = lista[0].AtendePreTesteCultoOrganista;
                    chkPreOficialMus.Checked = lista[0].AtendePreTesteOficialMusico;
                    chkPreOficialOrg.Checked = lista[0].AtendePreTesteOficialOrganista;
                    chkTesRjmMus.Checked = lista[0].AtendeTesteRjmMusico;
                    chkTesRjmOrg.Checked = lista[0].AtendeTesteRjmOrganista;
                    chkTesCultoMus.Checked = lista[0].AtendeTesteCultoMusico;
                    chkTesCultoOrg.Checked = lista[0].AtendeTesteCultoOrganista;
                    chkTesOficialMus.Checked = lista[0].AtendeTesteOficialMusico;
                    chkTesOficialOrg.Checked = lista[0].AtendeTesteOficialOrganista;
                    chkAtReunMin.Checked = lista[0].AtendeReuniaoMinisterial;
                    chkAtCasal.Checked = lista[0].AtendeCasal;
                    chkAtOrdenacao.Checked = lista[0].AtendeOrdenacao;
                    chkMasculino.Checked = lista[0].Masculino;
                    chkFeminino.Checked = lista[0].Feminino;
                    chkPermiteInstr.Checked = lista[0].PermiteInstrumento;
                    chkAlunoGem.Checked = lista[0].AlunoGem;
                    chkEnsaio.Checked = lista[0].Ensaio;
                    chkMeiaHora.Checked = lista[0].MeiaHora;
                    chkRjm.Checked = lista[0].Rjm;
                    chkCulto.Checked = lista[0].Culto;
                    chkOficial.Checked = lista[0].Oficial;

                    Verificacoes();

                }
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
        /// Função que recebe os dados do formulario e preenche as propriedades
        /// </summary>
        private MOD_cargo CriarTabela
        {
            get
            {
                MOD_cargo ent = new MOD_cargo();
                ent.CodCargo = txtCodigo.Text;
                ent.DescCargo = txtDescricao.Text;
                ent.SiglaCargo = txtSigla.Text;
                ent.Ordem = Convert.ToString(txtOrdem.Value);
                ent.CodDepartamento = Convert.ToString(cboDepartamento.SelectedValue);
                ent.PermiteEdicao = "Sim".Equals(lblPermiteEdicao.Text) ? true : false;
                if (true.Equals(optAtComSim.Checked)) { ent.AtendeComum = true; } else if (true.Equals(optAtComNao.Checked)) { ent.AtendeComum = false; }
                if (true.Equals(optAtRegSim.Checked)) { ent.AtendeRegiao = true; } else if (true.Equals(optAtRegNao.Checked)) { ent.AtendeRegiao = false; }
                ent.AtendeGEM = chkAtGem.Checked;
                ent.AtendeEnsaioLocal = chkAtEnsLoc.Checked;
                ent.AtendeEnsaioRegional = chkAtEnsReg.Checked;
                ent.AtendeEnsaioParcial = chkAtEnsParc.Checked;
                ent.AtendeEnsaioTecnico = chkAtEnsTec.Checked;
                ent.AtendeReuniaoMocidade = chkAtReunMoc.Checked;
                ent.AtendeBatismo = chkAtBatismo.Checked;
                ent.AtendeSantaCeia = chkAtCeia.Checked;
                ent.AtendeRJM = chkAtRjm.Checked;
                ent.AtendePreTesteRjmMusico = chkPreRjmMus.Checked;
                ent.AtendePreTesteRjmOrganista = chkPreRjmOrg.Checked;
                ent.AtendePreTesteCultoMusico = chkPreCultoMus.Checked;
                ent.AtendePreTesteCultoOrganista = chkPreCultoOrg.Checked;
                ent.AtendePreTesteOficialMusico = chkPreOficialMus.Checked;
                ent.AtendePreTesteOficialOrganista = chkPreOficialOrg.Checked;
                ent.AtendeTesteRjmMusico = chkTesRjmMus.Checked;
                ent.AtendeTesteRjmOrganista = chkTesRjmOrg.Checked;
                ent.AtendeTesteCultoMusico = chkTesCultoMus.Checked;
                ent.AtendeTesteCultoOrganista = chkTesCultoOrg.Checked;
                ent.AtendeTesteOficialMusico = chkTesOficialMus.Checked;
                ent.AtendeTesteOficialOrganista = chkTesOficialOrg.Checked;
                ent.AtendeReuniaoMinisterial = chkAtReunMin.Checked;
                ent.AtendeCasal = chkAtCasal.Checked;
                ent.AtendeOrdenacao = chkAtOrdenacao.Checked;
                ent.Masculino = chkMasculino.Checked;
                ent.Feminino = chkFeminino.Checked;
                ent.PermiteInstrumento = chkPermiteInstr.Checked;
                ent.AlunoGem = chkAlunoGem.Checked;
                ent.Ensaio = chkEnsaio.Checked;
                ent.MeiaHora = chkMeiaHora.Checked;
                ent.Rjm = chkRjm.Checked;
                ent.Culto = chkCulto.Checked;
                ent.Oficial = chkOficial.Checked;

                return ent;
            }
        }
    }
}