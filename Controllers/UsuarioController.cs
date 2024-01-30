using ApiWeb.Models;
using ApiWeb.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using static ApiWeb.Models.DTO;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository _UsuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioController()
        {
            this._UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet("GetUsuario")]
        public UsuarioDTO GetUsuario(int id)
        {
            UsuarioDTO usuario = _UsuarioRepository.GetUsuario(id);

            return usuario;
        }

        [HttpPost("Registro")]
        public bool Registro(UsuarioRegistroDTO usuarioRegistro)
        {
            bool seRegistro = _UsuarioRepository.Registro(usuarioRegistro);

            return seRegistro;
        }

        [HttpGet("Login")]
        public string Login(string usuarioNombre, string contrasena)
        {
            return _UsuarioRepository.LogIn(usuarioNombre, contrasena); 
        }
    }
}
