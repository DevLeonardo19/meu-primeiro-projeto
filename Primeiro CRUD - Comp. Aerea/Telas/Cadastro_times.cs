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
    public partial class Cadastro_times : Form
    {
        public Cadastro_times()
        {
            InitializeComponent();
        }

        private void Cadastro_times_Load(object sender, EventArgs e)
        {
            Mostrar_registros_times();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                DataSet ds = new DataSet();
                DataBase database = new DataBase();

                try
                {
                    ds = database.RetornaDataSet($@"SELECT TIM_ID AS ""ID"", CAT_TIM AS ""Categoria Time"", Nome_tim as ""Nome"" FROM times WHERE Nome_tim like '%' + '{txtNometimebusca.Text}' + '%'");
                    dgwTimes.DataSource = ds.Tables[0];
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
        } //Busca

        private void button3_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"UPDATE TIMES SET Cat_tim = '{txtCategoriatime.Text}', Nome_tim = '{txtNomeTime.Text}' WHERE Tim_id = {txtIdtime.Text}";

                dataBase.ExecutaSQLComando(sSQL);

                txtIdtime.Clear();
                txtCategoriatime.Clear();
                txtNomeTime.Clear();

                MessageBox.Show("Registro atualizado com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Mostrar_registros_times();
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
        } //Editar

        private void button4_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"DELETE FROM Times WHERE Tim_id = '{txtIdtime.Text}'";
                dataBase.ExecutaSQLComando(sSQL);

                txtIdtime.Clear();
                txtCategoriatime.Clear();
                txtNomeTime.Clear();

                MessageBox.Show("Registro excluido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Mostrar_registros_times();
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
        } //Delete


        private void button2_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            if (txtCategoriatime.Text == string.Empty)
            {
                MessageBox.Show("Categoria do time é obrigatória.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoriatime.Select();
                return;
            }

            else if (txtNomeTime.Text == string.Empty)
            {
                MessageBox.Show("Nome do time é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeTime.Select();
                return;
            }

            try
            {
                string sSQL = $@"
                    INSERT INTO Times (Cat_tim, Nome_tim)
                        VALUES('{txtCategoriatime.Text}','{txtNomeTime.Text}')";

                dataBase.ExecutaSQLComando(sSQL);

                txtIdtime.Clear();
                txtCategoriatime.Clear();
                txtNomeTime.Clear();

                MessageBox.Show("Registro inserido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Mostrar_registros_times();
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


        private void dgwTimes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdtime.Text = this.dgwTimes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCategoriatime.Text = this.dgwTimes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNomeTime.Text = this.dgwTimes.Rows[e.RowIndex].Cells[2].Value.ToString();
        }//Exibe nos campos ao clicar na celula

        public void Mostrar_registros_times()
        {
            {
                DataSet ds = new DataSet();
                DataBase database = new DataBase();

                try
                {
                    ds = database.RetornaDataSet($@"SELECT TIM_ID AS ""ID"", CAT_TIM AS ""Categoria Time"", Nome_tim as ""Nome"" FROM times ORDER BY Tim_id asc");
                    dgwTimes.DataSource = ds.Tables[0];
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

        private void button5_Click(object sender, EventArgs e)
        {
            txtIdtime.Clear();
            txtCategoriatime.Clear();
            txtNomeTime.Clear();
        }//Novo
    }
}
