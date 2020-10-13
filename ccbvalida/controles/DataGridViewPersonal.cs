using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL.validacoes.Controles
{
    public partial class DataGridViewPersonal : DataGridView
    {
        public DataGridViewPersonal()
        {
            InitializeComponent();

            this.DefaultCellStyle.NullValue = null;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeRows = false;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackgroundColor = Color.White;
            this.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.EnableHeadersVisualStyles = false;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.RowTemplate.Height = 18;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ScrollBars = ScrollBars.Both;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ModoOpera = modoOpera.Nenhum;
        }

        #region Propriedades do Controle

        #region Modo Opera

        /// <summary>
        /// Opções para o modo do DataGridView (Nenhum, Inserção ou Edição)
        /// </summary>
        public enum modoOpera
        {
            Nenhum,
            Insert,
            Edit,
            Novo
        }
        /// <summary>
        /// Variavel que recebe e envia o Modo do Grid
        /// </summary>
        private modoOpera Operacao;
        /// <summary>
        /// Opções para o modo do DataGridView (Nenhum, Inserção ou Edição)
        /// </summary>
        public modoOpera ModoOpera
        {
            get
            {
                return Operacao;
            }
            set
            {
                Operacao = value;
            }
        }

        #endregion

        #region Desabilitar Celulas

        private int[] CellsDisabled;
        public int[] DisabledCell
        {
            get
            {
                return CellsDisabled;
            }
            set
            {
                CellsDisabled = value;
            }
        }

        #endregion

        #endregion

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (this.ModoOpera == modoOpera.Novo)
                {
                    this.ModoOpera = modoOpera.Insert;
                    return false;
                }
                else
                {
                    this.ProcessTabKey(e.KeyData);
                    return true;
                }
            }
            return base.ProcessDataGridViewKey(e);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.Equals(Keys.Enter))
            {
                this.ProcessTabKey(keyData);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override bool SetCurrentCellAddressCore(int columnIndex, int rowIndex,
                                                          bool setAnchorCellAddress, bool validateCurrentCell,
                                                          bool throughMouseClick)
        {
            try
            {

                if (CellsDisabled != null)
                {
                    foreach (int disabledCell in CellsDisabled)
                    {
                        if (columnIndex.Equals(disabledCell) && !disabledCell.Equals(-1))
                        {
                            if (disabledCell.Equals(this[ColumnCount - 1, RowCount -1]))
                            {
                                EndEdit();
                                ReadOnly = true;
                                columnIndex = 0;
                            }
                            else
                            {
                                columnIndex = columnIndex + 1;
                            }
                        }
                    }
                }
                return base.SetCurrentCellAddressCore(columnIndex, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick);
            }
            catch
            {
                return false;
            }
        }
        protected override void SetSelectedCellCore(int columnIndex, int rowIndex, bool selected)
        {
            if (CellsDisabled != null)
            {
                foreach (int disabledCell in CellsDisabled)
                {
                    if (columnIndex.Equals(disabledCell))
                    {
                        if (disabledCell.Equals(this.ColumnCount - 1))
                        {
                            columnIndex = 0;
                            base.SetSelectedCellCore(0, rowIndex, selected);
                        }
                        else
                        {
                            if (!this.ColumnCount.Equals(0))
                            {
                                columnIndex = columnIndex + 1;
                            }
                        }
                    }
                }
            }
            base.SetSelectedCellCore(columnIndex, rowIndex, selected);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled.Equals(true))
            {
                //define a cor inicial do textbox
                BackColor = Color.White;
                ForeColor = Color.Black;
                ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                //define a cor inicial do textbox
                BackColor = Color.White;
                ForeColor = Color.Gray;
                ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            }
            base.OnEnabledChanged(e);

        }
    }
}