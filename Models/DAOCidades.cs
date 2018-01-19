using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace WebServicesCidades.Models
{
    public class DAOCidades
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string conexao = @"Data Source=.\SQLEXPRESS; Initial Catalog=ProjetoCidades; uid=sa; pwd=senai@123";

        /// <summary>
            /// Listar todas cidades cadastradas no banco de dados.  
            /// </summary>
            /// <returns>List de Cidades</returns>
        public List<Cidades> Listar(){
            var cidades = new List<Cidades>();

            try{
                con = new SqlConnection();
                con.ConnectionString = conexao;

                con.Open(); //aberta conexão

                //SQL query
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Cidades";
                
                dr = cmd.ExecuteReader();
                
                //adiciona a cidade à lista
                while(dr.Read()){
                    cidades.Add(new Cidades(){
                        id = dr.GetInt32(0),
                        nome = dr.GetString(1),
                        uf = dr.GetString(2),
                        habitantes = dr.GetInt32(3)
                    });
                }
            }
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }
            
            return cidades;
        }
        /// <summary>
            /// Cadastrar nova cidade no banco de dados
            /// </summary>
            /// <param name="cidade">Obj Cidade a ser cadastrada.  </param>
            /// <returns>True: executado com sucesso. False: erro de cadastro.</returns>
        public bool Cadastrar(Cidades cidade){
            bool resultado = false;

            try{
                con = new SqlConnection(conexao);

                con.Open();

                string query = string.Format("INSERT INTO Cidades (nome, uf, habitantes) VALUES (@n, @e, @h)");
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", cidade.nome);
                cmd.Parameters.AddWithValue("@e", cidade.uf);
                cmd.Parameters.AddWithValue("@h", cidade.habitantes);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;
                
                cmd.Parameters.Clear();
            }
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }

            return resultado;
        }
        /// <summary>
            /// Atualizar dados de cidade cadastrada.
            /// </summary>
            /// <param name="cidade">Obj Cidade a ser Atualizarda.  </param>
            /// <returns>True: executado com sucesso. False: erro de cadastro.</returns>
        public bool Atualizar(Cidades cidade){
            bool resultado = false;
            
            try{
                con = new SqlConnection(conexao);

                con.Open();

                string query = "UPDATE Cidades SET nome = @n, uf = @e, habitantes = @h WHERE id = @i";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", cidade.nome);
                cmd.Parameters.AddWithValue("@e", cidade.uf);
                cmd.Parameters.AddWithValue("@h", cidade.habitantes);
                cmd.Parameters.AddWithValue("@i", cidade.id);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;
                
                cmd.Parameters.Clear();
            }
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }

            return resultado;
        }
        /// <summary>
            /// Deletar cidade do banco de dados.
            /// </summary>
            /// <param name="cidade">Obj Cidade a ser removida.  </param>
            /// <returns>True: executado com sucesso. False: erro de cadastro.</returns>
        public bool Excluir(int id){
            bool resultado = false;
            
            try{
                con = new SqlConnection(conexao);
                string query = "DELETE Cidades WHERE id = @i";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@i", id);
                
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;
                
                cmd.Parameters.Clear();
            }
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }

            return resultado;
        }
    }
}