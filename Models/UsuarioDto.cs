﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Aula_api_fuel_manager.Models
{
    public class UsuarioDto
    {
        
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Perfil Perfil { get; set; }
    }
}
