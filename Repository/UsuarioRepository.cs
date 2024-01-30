using ApiWeb.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static ApiWeb.Models.DTO;

namespace ApiWeb.Repository
{
    public class UsuarioRepository
    {
        private DbAa4919Valencarballo1Context db;
        private readonly IConfiguration _configuration;

        public UsuarioRepository()
        {
            this.db = new DbAa4919Valencarballo1Context();

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public UsuarioDTO GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Include("Perfils").Where(u => u.Id == id).Single();

            UsuarioDTO usuDto = new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Perfils.First().Nombre,
                Apellido = usuario.Perfils.First().Apellido,
                NombreUsuario = usuario.NombreUsuario,
            };

            return usuDto;

        }

        public bool Registro(UsuarioRegistroDTO usuarioRegistro)
        {
            bool registro = false;
            if (usuarioRegistro != null)
            {
                string contrasenaHash = BCrypt.Net.BCrypt.HashPassword(usuarioRegistro.Contrasena);
                Usuario usuario = new Usuario
                {
                    NombreUsuario = usuarioRegistro.NombreUsuario,
                    Contrasena = contrasenaHash
                };

                Perfil perfil = new Perfil
                {
                    Nombre = usuarioRegistro.Nombre,
                    Apellido = usuarioRegistro.Apellido,
                    Celular = usuarioRegistro.Celular
                };
                usuario.Perfils.Add(perfil);

                db.Usuarios.Add(usuario);
                db.SaveChanges();
                registro = true;

            }

            return registro;
        }

        public string LogIn(string nombreUsuario, string contrasena)
        {
            string mensajeRetorno = "";

            Usuario usuario = db.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).SingleOrDefault();

            if(usuario != null && BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena))
            {
                mensajeRetorno = this.CreateToken(usuario);
            }
            else
            {
                mensajeRetorno = "Error. Datos incorrectos";
            }

            return mensajeRetorno;
        }

        public string CreateToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, usuario.NombreUsuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds 
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
