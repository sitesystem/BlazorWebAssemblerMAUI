using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorHybridMAUI.CapaEntities.ViewModels.Request;

public partial class TbPersonaViewModel
{
    public int? IdPersona { get; set; }

    [Required(ErrorMessage = "Obligatorio")]
    public string PerNombre { get; set; } = null!;

    public int? PerEdad { get; set; }

    public string PerEmail { get; set; }

    [Required(ErrorMessage = "Obligatorio")]
    public string PerFechaAlta { get; set; } = null!;
}
