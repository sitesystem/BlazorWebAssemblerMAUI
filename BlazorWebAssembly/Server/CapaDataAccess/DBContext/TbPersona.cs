using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssembly.Server.CapaDataAccess.DBContext;

public partial class TbPersona
{
    public int? IdPersona { get; set; }

    public string PerNombre { get; set; } = null!;

    public int? PerEdad { get; set; }

    public string? PerEmail { get; set; }

    public string PerFechaAlta { get; set; } = null!;
}
