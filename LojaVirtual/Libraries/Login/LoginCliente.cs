using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Sessao;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{   
    public class LoginCliente
    {
        private string Key = "LiginCliente";
        private Sessao.Sessao _sessao;

        public LoginCliente( Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }
        public void Login(Cliente cliente)
        {
            //Serealizar
           string clienteJSONString = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(Key, clienteJSONString);
        }
        public Cliente GetCliente()
        {
            //Deserealizar
            if (_sessao.Existe(Key)) { 
            string clienteJSONString = _sessao.Consultar(Key);
            return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
