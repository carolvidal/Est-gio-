using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ProjetoFinal.Util;

namespace ProjetoFinal.Models
{
    public class UsuarioModel
    {


        public string Nome { get; set; }
        public int Cpf { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public string Condição { get; set; }
        public DateTime Data_nascimento { get; set; }
        

        public bool Autenticar()
        {
            string sql = $"SELECT  NOME, CPF, PESO, ALTURA, EMAIL, SENHA, SEXO, CONDIÇÃO, DATA_NASCIMENTO FROM CADASTRO WHERE e Email='{Email}'" + 
                $" AND SENHA='{Senha}'";
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Nome = dt.Rows[0]["NOME"].ToString();
                    Cpf = int.Parse(dt.Rows[0]["CPF"].ToString());
                    Peso = double.Parse(dt.Rows[0]["CPF"].ToString());
                    Altura = double.Parse(dt.Rows[0]["ALTURA"].ToString());
                    Email = dt.Rows[0]["EMAIL"].ToString();
                    Senha = dt.Rows[0]["SENHA"].ToString();
                    Sexo = dt.Rows[0]["SEXO"].ToString();
                    Condição = dt.Rows[0]["CONDIÇÃO"].ToString();
                    Data_nascimento = DateTime.Parse(dt.Rows[0]["DATA_NASCIMENTO"].ToString());

                    return true;
                }
            }
            return false;

        }
    }
}
    
