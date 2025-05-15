using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EjercicioEnClase_Modelo.Models;

    public class EstudianteContext : DbContext
    {
        public EstudianteContext (DbContextOptions<EstudianteContext> options)
            : base(options)
        {
        }

        public DbSet<EjercicioEnClase_Modelo.Models.Estudiante> Estudiante { get; set; } = default!;
    }
