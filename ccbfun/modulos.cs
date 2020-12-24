using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.uteis;
using ENT.acessos;

namespace BLL.Funcoes
{
    public static class modulos
    {

        public static string CodUsuario;
        public static string CodPessoaUser;
        public static string Usuario;
        public static string Supervisor;
        public static string NomePessoaUser;
        public static string DescPc;
        public static string IpPc;
        public static string CodUsuarioCCB;
        public static string CodUsuarioCargo;

        /// <summary>
        /// Preenche o Código da pessoa cadastrada para vincular na tabela importação
        /// </summary>
        public static string CodPessoaImportacao;

        /// <summary>
        /// declara um lista para ser preenchida com os dados da empesa que se conectar ao sistema
        /// </summary>
        public static string CodRegional;
        public static string CodigoRegional;
        public static string DescRegional;
        public static string CaminhoBD;

        /// <summary>
        /// Lista Pública que recebe os parametros configurados em todo o sistema.
        /// </summary>
        public static List<MOD_parametros> listaParametros;

        /// <summary>
        /// mensagem para consulta em branco
        /// </summary>
        public static string branco = "Você selecionou uma pesquisa em branco que irá " + "\n" + "consultar todos os registros desta tabela. " + "\n" + "Este procedimento poderá demorar " + "\n" + "muito tempo para carregar. " + "\n" + "Deseja continuar? ";

        /// <summary>
        /// mensagem para excluir registro
        /// </summary>
        public static string exclusao = "Deseja realmente excluir?";

        /// <summary>
        /// mensagem para fechar registro
        /// </summary>
        public static string fechar = "Deseja realmente fechar?";

        /// <summary>
        /// mensagem para finalizar registro
        /// </summary>
        public static string finalizar = "Deseja realmente finalizar?";

        /// <summary>
        /// mensagem para cancelar registro
        /// </summary>
        public static string cancelar = "Deseja realmente cancelar?";

        /// <summary>
        /// mensagem para negar registro
        /// </summary>
        public static string negar = "Deseja realmente negar essa solicitação?" + "\n" +
                                "Isso fará com que essa solicitação de teste seja marcada como Negada.";

        /// <summary>
        /// mensagem para estornar registro
        /// </summary>
        public static string estornar = "Deseja realmente estornar?";

        /// <summary>
        /// mensagem para reabrir registro
        /// </summary>        
        public static string reabrir = "Deseja realmente re-abrir?";

        /// <summary>
        /// mensagem para finalizar entrada mercadoria
        /// </summary>
        public static string msgFechaCompra = "Essa rotina atualizará os saldos dos produtos, portanto" + "\n" + "não será mais permitido alterações nessa compra!" + "\n" + "Deseja realmente finalizar?";

        /// <summary>
        /// mensagem para salvar alterações
        /// </summary>
        public static string msgSalvar = "Deseja salvar as alterações?";

        /// <summary>
        /// mensagem para salvar alterações
        /// </summary>
        public static string msgSair = "Deseja realmente sair?" + '\n' + "Os registros não salvos serão perdidos!";

        /// <summary>
        /// mensagem para pessoa inativa
        /// </summary>
        public static string PessoaInativa = "Esta pessoa não está ativa." + '\n' + "Por favor ativar para usar esse cadastro.";
        /// <summary>
        /// mensagem para veículo inativo
        /// </summary>
        public static string VeiculoInativo = "Este Veículo não está Ativo." + "\n" + "Por favor ativar para usar esse Veículo.";

        /// <summary>
        /// mensagem para equipamento inativo
        /// </summary>
        public static string EquipamentoInativo = "Este Equipamento não está Ativo." + '\n' + "Por favor ativar para usar esse Equipamento.";

        /// <summary>
        /// mensagem para pessoa que não é Fornecedor
        /// </summary>
        public static string PessoaFornecedor = "Esta pessoa não está marcada como fornecedor." + '\n' + "Ir no cadastro de Pessoas, marcar como fornecedor e definir" + '\n' + "quais Centros de Custos estarão disponíveis!";
        /// <summary>
        /// mensagem para pessoa que não é Cliente
        /// </summary>
        public static string PessoaCliente = "Esta pessoa não está marcada como cliente.";
        /// <summary>
        /// mensagem de produto inativo
        /// </summary>
        public static string ProdInativo = "Este produto está inativo." + '\n' + "Por favor ativar para que possa efetuar movimentações.";
        /// <summary>
        /// mensagem para erro de transação anulada ao excluir
        /// </summary>
        public static string MsgErroExcluir = "O registro não foi excluído, por favor tente novamente!" + '\n' + "Erro de Transação!";

        /// <summary>
        /// mensagem para erro de transação anulada ao salvar ou inserir
        /// </summary>
        public static string MsgErroSalvar = "O registro não foi salvo, por favor tente novamente!" + '\n' + "Erro de Transação!";

        /// <summary>
        /// mensagem que o usuario não tem acesso ao programa
        /// </summary>
        public static string semAcesso = "Você não possui acesso a este módulo!" + '\n' + "Favor pedir liberação ao Supervisor do sistema.";

        /// <summary>
        /// mensagem que o usuario não tem acesso ao caasdtro
        /// </summary>
        public static string acessoNegado = "Acesso Negado!" + '\n' + "Não é permitido alterar ao dados dos Administradores.";

        /// <summary>
        /// variavel que armazena qual tecla foi pressionado no DataGridView
        /// </summary>
        public static string pressionaTeclaGrid = string.Empty;

        #region código dos programas e as rotinas que serão carregados os acessos

        public static int progComum = 9;

        public static int progRegiao = 15;

        #region Programas e Rotinas Pessoas

        #region Cidade
        //public static int progCidade = 7;
        //public static int rotInsCidade = 18;
        //public static int rotEditCidade = 19;
        //public static int rotExcCidade = 20;
        //public static int rotVisCidade = 21;
        #endregion
        #region Departamento
        //public static int progDepartamento = 10;
        //public static int rotInsDepartamento = 30;
        //public static int rotEditDepartamento = 31;
        //public static int rotExcDepartamento = 32;
        //public static int rotVisDepartamento = 33;
        #endregion
        #region Cargo
        //public static int progCargo = 8;
        //public static int rotInsCargo = 22;
        //public static int rotEditCargo = 23;
        //public static int rotExcCargo = 24;
        //public static int rotVisCargo = 25;
        #endregion
        #region Regional
        //public static int progRegional = 28;
        //public static int rotInsRegional = 136;
        //public static int rotEditRegional = 137;
        //public static int rotExcRegional = 138;
        //public static int rotVisRegional = 139;
        #endregion
        #region CCB
        //public static int progCCB = 9;
        //public static int rotInsCCB = 26;
        //public static int rotEditCCB = 27;
        //public static int rotExcCCB = 28;
        //public static int rotVisCCB = 29;
        //public static int rotCCBAbaMinist = 155;
        //public static int rotInsCCBMinist = 156;
        //public static int rotExcCCBMinist = 157;
        #endregion

        #endregion

        #region Programas e Rotinas Orquestra e Instrumentos

        #region Familia
        public static int progFamilia = 2;
        public static int rotInsFamilia = 1;
        public static int rotEditFamilia = 2;
        public static int rotExcFamilia = 3;
        public static int rotVisFamilia = 4;
        #endregion
        #region Tonalidade
        public static int progTonalidade = 2;
        public static int rotInsTonalidade = 1;
        public static int rotEditTonalidade = 2;
        public static int rotExcTonalidade = 3;
        public static int rotVisTonalidade = 4;
        #endregion
        #region Hinario
        public static int progHinario = 12;
        public static int rotInsHinario = 38;
        public static int rotEditHinario = 39;
        public static int rotExcHinario = 40;
        public static int rotVisHinario = 41;
        #endregion
        #region Vozes
        public static int progVoz = 13;
        public static int rotInsVoz = 42;
        public static int rotEditVoz = 43;
        public static int rotExcVoz = 44;
        public static int rotVisVoz = 45;
        #endregion
        #region MtsFase
        public static int progMtsFase = 21;
        public static int rotInsMtsFase = 75;
        public static int rotEditMtsFase = 76;
        public static int rotExcMtsFase = 77;
        public static int rotVisMtsFase = 78;
        #endregion
        #region MtsModulo
        public static int progMtsModulo = 22;
        public static int rotInsMtsModulo = 79;
        public static int rotEditMtsModulo = 80;
        public static int rotExcMtsModulo = 81;
        public static int rotVisMtsModulo = 82;
        #endregion
        #region Teoria
        public static int progTeoria = 23;
        public static int rotInsTeoria = 83;
        public static int rotEditTeoria = 84;
        public static int rotExcTeoria = 85;
        public static int rotVisTeoria = 86;
        public static int rotInsFotoTeoria = 140;
        public static int rotEditFotoTeoria = 142;
        public static int rotVisualFotoTeoria = 143;
        public static int rotExcFotoTeoria = 141;
        #endregion
        #region Instrumento
        public static int progInstrumento = 1;
        public static int rotInsInstr = 14;
        public static int rotEditInstr = 15;
        public static int rotExcInstr = 16;
        public static int rotVisInstr = 17;
        #endregion
        #region Visao Orquestral
        public static int progVisaoOrq = 32;
        public static int rotProcVisaoOrq = 167;
        #endregion

        #endregion

        #region Programas e Rotinas Testes e Preteste

        #region Avaliações por Pretestes
        public static int progLicaoPreTeste = 24;
        //Metodos
        public static int rotInsLicaoPreTesteMet = 87;
        public static int rotEditLicaoPreTesteMet = 88;
        public static int rotExcLicaoPreTesteMet = 89;
        //MTS
        public static int rotInsLicaoPreTesteMts = 93;
        public static int rotEditLicaoPreTesteMts = 94;
        public static int rotExcLicaoPreTesteMts = 95;
        //Hino
        public static int rotInsLicaoPreTesteHino = 90;
        public static int rotEditLicaoPreTesteHino = 91;
        public static int rotExcLicaoPreTesteHino = 92;
        //Escala
        public static int rotInsLicaoPreTesteEsc = 96;
        public static int rotEditLicaoPreTesteEsc = 97;
        public static int rotExcLicaoPreTesteEsc = 98;
        //Teoria
        public static int rotInsLicaoPreTesteTeoria = 99;
        public static int rotEditLicaoPreTesteTeoria = 100;
        public static int rotExcLicaoPreTesteTeoria = 101;
        #endregion
        #region Avaliações por Testes
        public static int progLicaoTeste = 25;
        //Metodos
        public static int rotInsLicaoTesteMet = 102;
        public static int rotEditLicaoTesteMet = 103;
        public static int rotExcLicaoTesteMet = 104;
        //MTS
        public static int rotInsLicaoTesteMts = 108;
        public static int rotEditLicaoTesteMts = 109;
        public static int rotExcLicaoTesteMts = 110;
        //Hino
        public static int rotInsLicaoTesteHino = 105;
        public static int rotEditLicaoTesteHino = 106;
        public static int rotExcLicaoTesteHino = 107;
        //Escala
        public static int rotInsLicaoTesteEsc = 111;
        public static int rotEditLicaoTesteEsc = 112;
        public static int rotExcLicaoTesteEsc = 113;
        //Teoria
        public static int rotInsLicaoTesteTeoria = 114;
        public static int rotEditLicaoTesteTeoria = 115;
        public static int rotExcLicaoTesteTeoria = 116;
        #endregion

        #endregion

        #region Programas e Rotinas GerSys

        #region Modulos
        //public static int progModulo = 16;
        //public static int rotInsModulo = 54;
        //public static int rotEditModulo = 55;
        //public static int rotExcModulo = 56;
        //public static int rotVisModulo = 57;
        #endregion
        #region SubModulos
        //public static int progSubModulo = 17;
        //public static int rotInsSubModulo = 58;
        //public static int rotEditSubModulo = 59;
        //public static int rotExcSubModulo = 60;
        //public static int rotVisSubModulo = 61;
        #endregion
        #region Programas
        //public static int progProgModulo = 18;
        //public static int rotInsProgModulo = 62;
        //public static int rotEditProgModulo = 63;
        //public static int rotExcProgModulo = 64;
        //public static int rotVisProgModulo = 65;
        #endregion
        #region Rotinas
        //public static int progRotModulo = 19;
        //public static int rotInsRotModulo = 66;
        //public static int rotEditRotModulo = 67;
        //public static int rotExcRotModulo = 68;
        //public static int rotVisRotModulo = 69;
        #endregion

        #endregion

        #region Programas e Rotinas Configurações

        #region Importacao
        //public static int progImportaPessoa = 31;
        //public static int rotInsImportaPessoa = 164;
        //public static int rotVisImportaPessoa = 165;
        //public static int rotEditImportaPessoa = 166;
        #endregion

        #endregion

        #endregion

        /// <summary>
        /// Sub que preenche a String de Conexão na Classe Acessa
        /// </summary>
        public static void preencheStrConexao()
        {
            acessa.strSql = CaminhoBD;
        }

    }
}