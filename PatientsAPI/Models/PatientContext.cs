using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatientsApi.Models
{
    public class PatientsContext : DbContext
    {
        public PatientsContext(DbContextOptions<PatientsContext> options) : base(options)
        {

        }

        public DbSet<Patient> PatientItems { get; set; }
    }
}