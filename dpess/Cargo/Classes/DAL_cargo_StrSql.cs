using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.cargo
{
    public class DAL_cargo_StrSql : IDAL_Cargo_StrSql
    {

        #region Strings SQL de Manipulação da Tabela Cargo

        //string de insert na tabela Cargo
        private readonly string strInsert = "INSERT INTO Cargo(CodCargo, DescCargo, Ordem, SiglaCargo, CodDepartamento, PermiteEdicao, AtendeComum, AtendeRegiao, " +
"AtendeGEM, AtendeEnsaioLocal, AtendeEnsaioRegional, AtendeEnsaioParcial, AtendeEnsaioTecnico, AtendeReuniaoMocidade, " +
"AtendeBatismo, AtendeSantaCeia, AtendeRJM, AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista, AtendeTesteRjmMusico, AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista, AtendeTesteCultoMusico, AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista, AtendeTesteOficialMusico, AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial, AtendeCasal, AtendeOrdenacao, Masculino, Feminino, PermiteInstrumento, AlunoGem, Ensaio, MeiaHora, Rjm, Culto, Oficial) " +
"VALUES (@CodCargo, @DescCargo, @Ordem, @SiglaCargo, @CodDepartamento, @AtendeComum, @AtendeRegiao, " +
"@AtendeGEM, @AtendeEnsaioLocal, @AtendeEnsaioRegional, @AtendeEnsaioParcial, @AtendeEnsaioTecnico, @AtendeReuniaoMocidade, " +
"@AtendeBatismo, @AtendeSantaCeia, @AtendeRJM, @AtendePreTesteRjmMusico, @AtendePreTesteRjmOrganista, @AtendeTesteRjmMusico, @AtendeTesteRjmOrganista, " +
"@AtendePreTesteCultoMusico, @AtendePreTesteCultoOrganista, @AtendeTesteCultoMusico, @AtendeTesteCultoOrganista, " +
"@AtendePreTesteOficialMusico, @AtendePreTesteOficialOrganista, @AtendeTesteOficialMusico, @AtendeTesteOficialOrganista," +
"@AtendeReuniaoMinisterial, @AtendeCasal, @AtendeOrdenacao, @Masculino, @Feminino, @PermiteInstrumento, @AlunoGem, @Ensaio, @MeiaHora, @Rjm, @Culto, @Oficial) ";

        //string de delete na tabela Cargo
        private readonly string strDelete = "DELETE FROM Cargo WHERE CodCargo = @CodCargo ";

        //string que retorna o próximo Id da tabela Cargo
        private readonly string strRetornaId = "SELECT MAX (CodCargo) FROM Cargo ";

        //string de select na tabela Cargo
        private readonly string strSelect = "SELECT C.CodCargo, C.DescCargo, C.SiglaCargo, C.Ordem, C.CodDepartamento, C.PermiteEdicao, C.AtendeComum, C.AtendeRegiao, " +
"C.AtendeGEM, C.AtendeEnsaioLocal, C.AtendeEnsaioRegional, C.AtendeEnsaioParcial, C.AtendeEnsaioTecnico, C.AtendeReuniaoMocidade, " +
"C.AtendeBatismo, C.AtendeSantaCeia, C.AtendeRJM, C.AtendePreTesteRjmMusico, C.AtendePreTesteRjmOrganista, C.AtendeTesteRjmMusico, C.AtendeTesteRjmOrganista, " +
"C.AtendePreTesteCultoMusico, C.AtendePreTesteCultoOrganista, C.AtendeTesteCultoMusico, C.AtendeTesteCultoOrganista, " +
"C.AtendePreTesteOficialMusico, C.AtendePreTesteOficialOrganista, C.AtendeTesteOficialMusico, C.AtendeTesteOficialOrganista," +
"C.AtendeReuniaoMinisterial, C.AtendeCasal, C.AtendeOrdenacao, C.Masculino, C.Feminino, C.PermiteInstrumento, " +
"C.AlunoGem, C.Ensaio, C.MeiaHora, C.Rjm, C.Culto, C.Oficial, " +
"D.DescDepartamento " +
"FROM Cargo AS C " +
"LEFT OUTER JOIN Departamento AS D ON C.CodDepartamento = D.CodDepartamento ";


        //string de update na tabela Cargo
        private readonly string strUpdate = "UPDATE Cargo SET DescCargo = @DescCargo, Ordem = @Ordem, SiglaCargo = @SiglaCargo, " +
"CodDepartamento = @CodDepartamento, PermiteEdicao = @PermiteEdicao, AtendeComum = @AtendeComum, AtendeRegiao = @AtendeRegiao, " +
"AtendeGEM = @AtendeGEM, AtendeEnsaioLocal = @AtendeEnsaioLocal, AtendeEnsaioRegional = @AtendeEnsaioRegional, " +
"AtendeEnsaioParcial = @AtendeEnsaioParcial, AtendeEnsaioTecnico = @AtendeEnsaioTecnico, AtendeReuniaoMocidade = @AtendeReuniaoMocidade, " +
"AtendeBatismo = @AtendeBatismo, AtendeSantaCeia = @AtendeSantaCeia, AtendeRJM = @AtendeRJM, " +
"AtendePreTesteRjmMusico = @AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista = @AtendePreTesteRjmOrganista, " +
"AtendeTesteRjmMusico = @AtendeTesteRjmMusico, AtendeTesteRjmOrganista = @AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico = @AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista = @AtendePreTesteCultoOrganista, " +
"AtendeTesteCultoMusico = @AtendeTesteCultoMusico, AtendeTesteCultoOrganista = @AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico = @AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista = @AtendePreTesteOficialOrganista, " +
"AtendeTesteOficialMusico = @AtendeTesteOficialMusico, AtendeTesteOficialOrganista = @AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial = @AtendeReuniaoMinisterial, AtendeCasal = @AtendeCasal, AtendeOrdenacao = @AtendeOrdenacao, " +
"Masculino = @Masculino, Feminino = @Feminino, PermiteInstrumento = @PermiteInstrumento, AlunoGem = @AlunoGem, Ensaio = @Ensaio, " +
"MeiaHora = @MeiaHora, Rjm = @Rjm, Culto = @Culto, Oficial = @Oficial " +
"WHERE CodCargo = @CodCargo ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Update para a Tabela Cargo
        /// </summary>
        /// <returns></returns>
        public string StrUpdate
        {
            get
            {
                return strUpdate;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Issert para a Tabela Cargo
        /// </summary>
        /// <returns></returns>
        public string StrInsert
        {
            get
            {
                return strInsert;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Select para a Tabela Cargo
        /// </summary>
        /// <returns></returns>
        public string StrSelect
        {
            get
            {
                return strSelect;
            }
        }

        /// <summary>
        /// Retorna a String SQL que Retorna Proximo ID da Tabela Cargo
        /// </summary>
        /// <returns></returns>
        public string StrRetornaId
        {
            get
            {
                return strRetornaId;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Delete para a Tabela Cargo
        /// </summary>
        /// <returns></returns>
        public string StrDelete
        {
            get
            {
                return strDelete;
            }
        }
    }
}