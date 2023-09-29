using Primeiro_CRUD___Comp.Aerea.Dl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primeiro_CRUD___Comp.Aerea
{
    public partial class Cadastro_cidade : Form
    {
        public Cadastro_cidade()
        {
            InitializeComponent();
        }

        private void Cadastro_cidade_Load(object sender, EventArgs e)
        {
            mostrar_registros_cidade();
        }

        private void button2_Click(object sender, EventArgs e) //Criar
        {

            DataBase dataBase = new DataBase();

            if (txtCodibge.Text == string.Empty)
            {
                MessageBox.Show("Codigo do IBGE é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodibge.Select();
                return;
            }

            else if (txtNomecidade.Text == string.Empty)
            {
                MessageBox.Show("Nome da cidade é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomecidade.Select();
                return;
            }

            else if (txtSiglaEstado.Text == string.Empty)
            {
                MessageBox.Show("Sigla do estado é obrigatória.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomecidade.Select();
                return;
            }

            try
            {
                string sSQL = $@"
                    INSERT INTO Cidade (Cod_IBGE, CID_NOME, ESTADO_SIGLA)
                        VALUES('{txtCodibge.Text}','{txtNomecidade.Text}','{txtSiglaEstado.Text}')";

                dataBase.ExecutaSQLComando(sSQL);

                txtCodibge.Clear();
                txtNomecidade.Clear();
                txtSiglaEstado.Clear();

                MessageBox.Show("Registro inserido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mostrar_registros_cidade();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir o registro. Erro: {ex.Message}", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase = null;
                GC.Collect();
            }
        }

        public void mostrar_registros_cidade()
        {
            DataSet ds = new DataSet();
            DataBase database = new DataBase();

            try
            {
                ds = database.RetornaDataSet($@"SELECT COD_IBGE AS ""IBGE"", CID_NOME as ""CIDADE"", ESTADO_SIGLA as ""Sigla do estado"" FROM CIDADE ORDER BY CID_NOME ASC");

                dgwCidade.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ds = null;
                database = null;
                GC.Collect();
            }
        }

        private void dgwCidade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwCidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodibge.Text = this.dgwCidade.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomecidade.Text = this.dgwCidade.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSiglaEstado.Text = this.dgwCidade.Rows[e.RowIndex].Cells[2].Value.ToString();
        }//Exibe nos campos ao clicar na celula

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataBase database = new DataBase();

            try
            {
                ds = database.RetornaDataSet($@"SELECT COD_IBGE AS ""Codigo IBGE"", CID_NOME as ""Cidade"", ESTADO_SIGLA as ""Sigla do estado"" FROM CIDADE WHERE CID_NOME like '%' + '{txtNomeBusca.Text}' + '%'");

                dgwCidade.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ds = null;
                database = null;
                GC.Collect();
            }
        }//Buscar

        private void button4_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"UPDATE CIDADE SET Cid_nome = '{txtNomecidade.Text}', Estado_sigla = '{txtSiglaEstado.Text}' WHERE Cod_ibge = {txtCodibge.Text}";

                dataBase.ExecutaSQLComando(sSQL);

                txtCodibge.Clear();
                txtNomecidade.Clear();
                txtSiglaEstado.Clear();

                MessageBox.Show("Registro atualizado com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mostrar_registros_cidade();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir registro. Erro: {ex.Message}", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                dataBase = null;
                GC.Collect();
            }
        }//Editar

        private void button3_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"DELETE FROM Cidade WHERE Cod_IBGE = {txtCodibge.Text}";
                dataBase.ExecutaSQLComando(sSQL);

                txtCodibge.Clear();
                txtNomecidade.Clear();
                txtSiglaEstado.Clear();

                MessageBox.Show("Registro excluido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mostrar_registros_cidade();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir registro. Erro: {ex.Message}", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase = null;
                GC.Collect();
            }
        }//Delete

        private void button5_Click(object sender, EventArgs e)
        {
            txtCodibge.Clear();
            txtNomecidade.Clear();
            txtSiglaEstado.Clear();
        }//Novo
    }
}

