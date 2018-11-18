using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);

                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(UsuarioModel usuario)
        {
            bool login = usuario.Autenticar();
            if (login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Usuario ou senha inválidos!";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult NovoUsuario()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {

            bool cadastro = usuario.Cadastrar();

            if (cadastro)
            {
                TempData["MensagemCadastroSucesso"] = "Usuario cadastrado com sucesso!";
                return RedirectToAction("NovoUsuario");
            }
            else
            {
                TempData["MensagemCadastroInvalido"] = "Usuario não cadastrado";
                return RedirectToAction("NovoUsuario");
            }
        }
        public IActionResult CadastroUsuario()
        {
            return View();
        }

    }
}
