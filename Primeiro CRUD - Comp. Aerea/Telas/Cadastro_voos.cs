using Primeiro_CRUD___Comp.Aerea.Dl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primeiro_CRUD___Comp.Aerea
{
    public partial class Cadastro_voos : Form
    {
        public Cadastro_voos()
        {
            InitializeComponent();
        }

        public void Cadastro_voos_Load(object sender, EventArgs e)
        {
            Mostrar_voos();
            carregaCategoriacidadeori(); //Lista combo box cidade origem
            carregaCategoriacidadest(); //Lista combo box cidade destino
        }

        private void button2_Click(object sender, EventArgs e) //Criar
        {
            DataBase dataBase = new DataBase();

            if (txtIdaviao.Text == string.Empty)
            {
                MessageBox.Show("Id avião é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdaviao.Select();
                return;
            }

            if (txtIdtime.Text == string.Empty)
            {
                MessageBox.Show("Id do time é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdtime.Select();
                return;
            }

            if (txtHoraprevpart.Text == string.Empty)
            {
                MessageBox.Show("Hora prevista é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoraprevpart.Select();
                return;
            }

            if (txtHoraprevcheg.Text == string.Empty)
            {
                MessageBox.Show("Hora de chegada é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoraprevcheg.Select();
                return;
            }

            if (txtDataChegada.Text == string.Empty)
            {
                MessageBox.Show("Data de chegada é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataChegada.Select();
                return;
            }

            if (txtDataPartida.Text == string.Empty)
            {
                MessageBox.Show("Data de partida é obrigatório.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataPartida.Select();
                return;
            }

            string horaPrevPartida = txtHoraprevpart.Text;
            string dataPartida = txtDataPartida.Text;
            string horaPrevChegada = txtHoraprevcheg.Text;
            string dataChegada = txtDataChegada.Text;        

            try
            {
                string sSQL = $@"
                    INSERT INTO Voos (Avi_id, Tim_id, Cod_ibge_ori, Cod_ibge_des, Hora_prev_partida, Voo_dt_partida, Hora_prev_chegada, Voo_dt_chegada)
            VALUES ({txtIdaviao.Text},{txtIdtime.Text},'{cboCidadeOri.SelectedValue}','{cboCidadeDest.SelectedValue}',
            '{horaPrevPartida}', '{dataPartida}', '{horaPrevChegada}', '{dataChegada}')";

                dataBase.ExecutaSQLComando(sSQL);

                txtIdaviao.Clear();
                txtIdaviao.Clear();
                txtIdtime.Clear();
                txtHoraprevpart.Clear();
                txtDataPartida.Clear();
                txtHoraprevcheg.Clear();
                txtDataChegada.Clear();
                cboCidadeOri.Text = "";
                cboCidadeDest.Text = "";

                MessageBox.Show("Registro inserido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Mostrar_voos();
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

        private void button1_Click(object sender, EventArgs e) //Editar
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"UPDATE Voos SET Avi_id = {txtIdaviao.Text}, Tim_id = {txtIdtime.Text}, Hora_prev_partida = '{txtHoraprevpart.Text}', Voo_dt_partida = '{txtDataPartida.Text}', Hora_prev_chegada = '{txtHoraprevcheg.Text}', Voo_dt_chegada = '{txtDataChegada.Text}', Cod_ibge_ori = {cboCidadeOri.SelectedValue}, Cod_ibge_des = {cboCidadeDest.SelectedValue}
                               WHERE Voo_id = {txtIdVoo.Text}";

                dataBase.ExecutaSQLComando(sSQL);

                txtIdVoo.Clear();
                txtIdaviao.Clear();
                txtIdtime.Clear();
                txtHoraprevpart.Clear();
                txtDataPartida.Clear();
                txtHoraprevcheg.Clear();
                txtDataChegada.Clear();
                cboCidadeOri.Text = "";
                cboCidadeDest.Text = "";

                MessageBox.Show("Registro atualizado com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Mostrar_voos();
            }

            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Erro SQL: {sqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase = null;
                GC.Collect();
            }
        }

        private void button3_Click(object sender, EventArgs e) //Deletar
        {
            DataBase dataBase = new DataBase();

            try
            {
                string sSQL = $@"DELETE FROM Voos WHERE Voo_id = {txtIdVoo.Text}";
                dataBase.ExecutaSQLComando(sSQL);

                txtIdVoo.Clear();
                txtIdaviao.Clear();
                txtIdtime.Clear();
                txtHoraprevpart.Clear();
                txtDataPartida.Clear();
                txtHoraprevcheg.Clear();
                txtDataChegada.Clear();
                cboCidadeOri.Text = "";
                cboCidadeDest.Text = "";

                MessageBox.Show("Registro excluido com sucesso.", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Mostrar_voos();
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
        }

        private void button4_Click(object sender, EventArgs e) //Novo
        {
            txtIdVoo.Clear();
            txtIdaviao.Clear();
            txtIdtime.Clear();
            txtHoraprevpart.Clear();
            txtDataPartida.Clear();
            txtHoraprevcheg.Clear();
            txtDataChegada.Clear();
            cboCidadeOri.Text = "";
            cboCidadeDest.Text = "";
        }


        private void Buscar_Click(object sender, EventArgs e)
        {
            {
                DataSet ds = new DataSet();
                DataBase database = new DataBase();

                try
                {
                    ds = database.RetornaDataSet($@"select
                    Voo_id ""Id"", Avi_id ""Id Avião"", Tim_id ""Id Time"", Hora_prev_partida, Voo_dt_partida, Hora_prev_chegada, Voo_dt_chegada, cido.Cid_nome ""Cidade Origem"", cidd.cid_nome ""Cidade Destino""
                    from voos v
                    inner join cidade cido on cido.Cod_ibge = v.Cod_ibge_ori
                    inner join cidade cidd on cidd.Cod_ibge = v.Cod_ibge_des WHERE Voo_id LIKE '%{txtBuscar.Text}%' OR cido.Cid_nome like '%{txtBuscar.Text}%' OR cidd.cid_nome like '%{txtBuscar.Text}%'");

                    dgwVoo.DataSource = ds.Tables[0];
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
        public void Mostrar_voos()
        {

            DataSet ds = new DataSet();
            DataBase database = new DataBase();

            try
            {
                ds = database.RetornaDataSet(

                    $@"select
                    Voo_id ""Id"", Avi_id ""Id Avião"", Tim_id ""Id Time"", Hora_prev_partida, Voo_dt_partida, Hora_prev_chegada, Voo_dt_chegada, cido.Cid_nome ""Cidade Origem"", cidd.cid_nome ""Cidade Destino""
                    from voos v
                    inner join cidade cido on cido.Cod_ibge = v.Cod_ibge_ori
                    inner join cidade cidd on cidd.Cod_ibge = v.Cod_ibge_des ORDER BY Voo_id");

                dgwVoo.DataSource = ds.Tables[0];
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void carregaCategoriacidadeori()
        {
            SqlConnection Conexao;
            try
            {

                string data_source = "Server=GTEC-PAT-2590;Database=Comp_Aerea;User Id=sa;Password=B1Admin!!";

                Conexao = new SqlConnection(data_source);
                Conexao.Open();

                SqlCommand cmd = new SqlCommand("Select COD_IBGE, Cid_nome from CIDADE order by Cid_nome", Conexao);
                SqlDataReader leitorCat = cmd.ExecuteReader();
                DataTable tabelaCat = new DataTable();
                tabelaCat.Load(leitorCat);


                DataRow linha = tabelaCat.NewRow();
                linha["cid_nome"] = "";
                linha["Cod_IBGE"] = 0;
                tabelaCat.Rows.InsertAt(linha,0);

                cboCidadeOri.DataSource = tabelaCat;
                cboCidadeOri.ValueMember = "COD_IBGE";
                cboCidadeOri.DisplayMember = "Cid_nome";

                Conexao.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cboCidadeDest_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void carregaCategoriacidadest()
        {
            SqlConnection Conexao;
            try
            {

                string data_source = "Server=GTEC-PAT-2590;Database=Comp_Aerea;User Id=sa;Password=B1Admin!!";

                Conexao = new SqlConnection(data_source);
                Conexao.Open();

                SqlCommand cmd = new SqlCommand("Select COD_IBGE, Cid_nome from CIDADE order by Cid_nome", Conexao);
                SqlDataReader leitorCat = cmd.ExecuteReader();
                DataTable tabelaCat = new DataTable();
                tabelaCat.Load(leitorCat);


                DataRow linha = tabelaCat.NewRow();
                linha["cid_nome"] = "";
                linha["Cod_IBGE"] = 0;
                tabelaCat.Rows.InsertAt(linha, 0);

                cboCidadeDest.DataSource = tabelaCat;
                cboCidadeDest.ValueMember = "COD_IBGE";
                cboCidadeDest.DisplayMember = "Cid_nome";

                Conexao.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgwVoo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboCidadeOri.Text = "";
            cboCidadeDest.Text = ""; 

            txtIdVoo.Text = this.dgwVoo.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtIdaviao.Text = this.dgwVoo.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtIdtime.Text = this.dgwVoo.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtHoraprevpart.Text = this.dgwVoo.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDataPartida.Text = this.dgwVoo.Rows[e.RowIndex].Cells[6].Value.ToString().Replace(" 00:00:00", "");
            txtHoraprevcheg.Text = this.dgwVoo.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDataChegada.Text = this.dgwVoo.Rows[e.RowIndex].Cells[6].Value.ToString().Replace(" 00:00:00", "");
            cboCidadeOri.SelectedText = this.dgwVoo.Rows[e.RowIndex].Cells[7].Value.ToString();
            cboCidadeDest.SelectedText = this.dgwVoo.Rows[e.RowIndex].Cells[8].Value.ToString();
        } //Preenche os campos ao clicar na linha

              

        
    }
}