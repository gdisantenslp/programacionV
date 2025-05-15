using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudiante_PreClase.Models;

    public class EstudianteContext : DbContext
    {
        public EstudianteContext (DbContextOptions<EstudianteContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante_PreClase.Models.Estudiante> Estudiante { get; set; } = default!;
    }
