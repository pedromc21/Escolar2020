﻿namespace Escolar2020.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "Persona_Id")]
        public int Persona_Id { get; set; }

        [Required]
        [Display(Name = "Clave_Familia")]
        public string Clave_Familia { get; set; }

    }
}
