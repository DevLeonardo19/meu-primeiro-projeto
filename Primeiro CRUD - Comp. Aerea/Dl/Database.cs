using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primeiro_CRUD___Comp.Aerea.Dl
{
    class DataBase
    {
        private SqlConnection Conexao = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter da = null;
        private DataSet ds = null;
        private DataTable dt = null;



        public static string StringdeConexaoCompAerea()
        {
            string data_source = "Server=GTEC-PAT-2590;Database=Comp_Aerea;User Id=sa;Password=B1Admin!!";
            return data_source;

        }


        private SqlConnection AbreBanco()
        {
            Conexao = new SqlConnection(StringdeConexaoCompAerea());
            try
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Open();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Conexao;

        }

        private void FechaBanco(SqlConnection conexao)
        {
            if (Conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public DataSet RetornaDataSet(string strQuery)
        {
            Conexao = new SqlConnection();

            try
            {
                Conexao = AbreBanco();
                cmd = new SqlCommand(strQuery, Conexao);
                cmd.Connection = Conexao;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FechaBanco(Conexao);
            }

        }

        public void ExecutaSQLComando(string Commando)
        {
            Conexao = new SqlConnection(StringdeConexaoCompAerea());
            cmd = new SqlCommand();
            try
            {
                Conexao.Open();
                cmd.Connection = Conexao;
                cmd.CommandText = Commando;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                FechaBanco(Conexao);
                Conexao.Dispose();
                cmd.Dispose();
            }
        }


    }

}
