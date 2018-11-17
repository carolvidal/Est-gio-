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

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Nascimento { get; set; }

        public bool Autenticar()
        {
            string sql = $"SELECT ID, NOME, DATA_NASCIMENTO FROM CADASTRO WHERE EMAIL='{Email}'" +
                $" AND SENHA='{Senha}'";
            DAL objDAO = new DAL();
            DataTable dt = objDAO.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString()); //dados para sessao
                    Nome = dt.Rows[0]["NOME"].ToString(); //dados para sessao
                    Data_Nascimento = DateTime.Parse(dt.Rows[0]["DATA_NASCIMENTO"].ToString());
                    return true;
                }
            }
            return false;
        }


        public bool Cadastrar()
        {



            string sql = $"INSERT INTO CADASTRO(NOME,EMAIL,SENHA,DATA_NASCIMENTO) VALUES ('{Nome}','{Email}','{Senha}','{Data_Nascimento}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSql(sql);
            return true;




        }
    }
}
    
