using Microsoft.Identity.Client;
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
    public partial class cadastro_avi : Form
    {
        public cadastro_avi()
        {
            InitializeComponent();
        }

        private void cadastro_avi_Load(object sender, EventArgs e)
        {
            carregar_registros_avi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataBase database = new DataBase();

            try
            {
                ds = database.RetornaDataSet($@"SELECT AVI_ID AS ""ID"", Capacidade as ""Qtde Poltronas"", ""Modelo"" FROM AVIAO WHERE Modelo like '%' + '{txtModeloBusca.Text}' + '%'");

                dgwAviao.DataSource = ds.Tables[0];
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
        } //Busca

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            if (txtModeloavi.Text == string.Empty)
            {
                MessageBox.Show("Modelo do Avião é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModeloavi.Select();
                return;
            }

            else if (txtCapacidade.Text == string.Empty)
            {
                MessageBox.Show("Capacidade do Avião é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCapacidade.Select();
                return;
            }
            
                try
            {
                string sSQL = $@"
                    INSERT INTO AVIAO 
                        VALUES('{txtCapacidade.Text}','{txtModeloavi.Text}')";

                dataBase.ExecutaSQLComando(sSQL);

                txtCapacidade.Clear();
                txtModeloavi.Clear();

                MessageBox.Show("Registro inserido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                carregar_registros_avi();
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


        }//Criar

        public void carregar_registros_avi()
        {
            {
                DataSet ds = new DataSet();
                DataBase database = new DataBase();

                try
                {
                    ds = database.RetornaDataSet(@"SELECT AVI_ID AS ""ID"", Capacidade as ""Qtde Poltronas"", ""Modelo"" FROM AVIAO order by ID ASC");
                    dgwAviao.DataSource = ds.Tables[0];
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
        }

        private void dgwAviao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"UPDATE AVIAO SET Modelo = '{txtModeloavi.Text}', Capacidade = {txtCapacidade.Text} WHERE Avi_id = {txtIdaviao.Text}";

                dataBase.ExecutaSQLComando(sSQL);

                txtIdaviao.Clear();
                txtCapacidade.Clear();
                txtModeloavi.Clear();

                MessageBox.Show("Registro atualizado com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                carregar_registros_avi();
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
        } // Editar

        private void button4_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"DELETE FROM AVIAO WHERE Avi_id = {txtIdaviao.Text}";
                dataBase.ExecutaSQLComando(sSQL);

                txtIdaviao.Clear();
                txtCapacidade.Clear();
                txtModeloavi.Clear();

                MessageBox.Show("Registro excluido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                carregar_registros_avi();
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

        } // Delete

        private void dgwAviao_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtIdaviao.Text = this.dgwAviao.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCapacidade.Text = this.dgwAviao.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtModeloavi.Text = this.dgwAviao.Rows[e.RowIndex].Cells[2].Value.ToString();

        }//Exibir os valores ao clicar na celula

        private void button5_Click(object sender, EventArgs e)
        {
            txtIdaviao.Clear();    
            txtCapacidade.Clear();
            txtModeloavi.Clear();
        }// Novo


    }
}
