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
        public bool Registro(string nombreUsuario, string contrasena, string nombre, string apellido, string celular)
        {
            bool seRegistro = _UsuarioRepository.Registro(nombreUsuario, contrasena, nombre, apellido, celular);

            return seRegistro;
        }
    }
}
