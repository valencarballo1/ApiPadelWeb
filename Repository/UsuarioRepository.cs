using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static ApiWeb.Models.DTO;

namespace ApiWeb.Repository
{
    public class UsuarioRepository
    {
        private DbAa4919Valencarballo1Context db;

        public UsuarioRepository()
        {
            this.db = new DbAa4919Valencarballo1Context();
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

        public bool Registro(string nombreUsuario, string contrasena, string nombre, string apellido, string celular)
        {
            bool registro = false;
            if (!nombreUsuario.IsNullOrEmpty() && !contrasena.IsNullOrEmpty())
            {
                Usuario usuario = new Usuario
                {
                    NombreUsuario = nombreUsuario,
                    Contrasena = contrasena
                };

                Perfil perfil = new Perfil
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Celular = celular
                };
                usuario.Perfils.Add(perfil);

                db.Usuarios.Add(usuario);
                db.SaveChanges();
                registro = true;

            }

            return registro;
        }
    }
}
