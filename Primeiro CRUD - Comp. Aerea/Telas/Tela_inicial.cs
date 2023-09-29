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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Mostra a tela de cadastro de aviao
        {
            cadastro_avi cadastro_Aviao = new cadastro_avi();
            cadastro_Aviao.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro_times cadastro_Times = new Cadastro_times();
            cadastro_Times.Show();
        }//Mostra a tela de cadastro de times

        private void button3_Click(object sender, EventArgs e)
        {
            Cadastro_cidade cadastro_cidades = new Cadastro_cidade();
            cadastro_cidades.Show();
        }//Mostra a tela de cadastro de cidades

        private void button4_Click(object sender, EventArgs e)
        {
            Cadastro_voos cadastro_voos = new Cadastro_voos();
            cadastro_voos.Show();
        }//Mostra a tela de cadastro de voos
    }
}
