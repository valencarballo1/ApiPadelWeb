﻿namespace ApiWeb.Models
{
    public class DTO
    {
        public class UsuarioDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string NombreUsuario { get; set; }
        }

        public class UsuarioRegistroDTO
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string NombreUsuario { get; set; }
            public string Contrasena { get; set; }
            public string Celular { get; set; }

        }
    }
}
