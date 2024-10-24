using Microsoft.EntityFrameworkCore;
using CocomoBackend.Models;
using System.Xml;



namespace CocomoBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<CocomoState> CocomoStates { get; set; }
        public DbSet<CocomoStateVersion> CocomoStatesVersions { get; set; }
        public DbSet<TypeComplexity> TypeComplexities { get; set; }
        public DbSet<TypeRequirement> TypeRequirements { get; set; }
        public DbSet<CocomoHead> CocomoHeads { get; set; }
        public DbSet<CocomoDetail> CocomoDetails { get; set; }
        public DbSet<CocomoVersion> CocomoVersions { get; set; }
        public DbSet<CocomoTypeProyect> CocomoRequeriments { get; set; }
        public DbSet<CocomoFactor> CocomoFactors { get; set; }
        public DbSet<PlatformObjectTime> PlatformObjectTimes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Vertical> Verticals { get; set; }
        public DbSet<TypeProyect> TypeProyects { get; set; }
        public DbSet<TypeFactor> TypeFactors { get; set; }
        public DbSet<TypeFactorDetail> TypeFactorDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CocomoHead>()
                .HasIndex(e => e.Code)
                .IsUnique();

            modelBuilder.Entity<CocomoHead>()
                .HasOne(c => c.Customer)  // CocomoHead tiene un Customer
                .WithMany(c => c.CocomoHeads)  // Customer tiene muchas CocomoHeads
                .HasForeignKey(c => c.IdCustomer)  // La clave foránea es IdCustomer
                .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            modelBuilder.Entity<CocomoHead>()
                .HasOne(tr => tr.TypeRequirement)  // CocomoHead tiene un TypeRequirement
                .WithMany(tr => tr.CocomoHeads)  // TypeRequirement tiene muchas CocomoHeads
                .HasForeignKey(tr => tr.IdTypeRequirement)  // La clave foránea es IdTypeRequirement
                .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            modelBuilder.Entity<CocomoHead>()
               .HasOne(tx => tx.TypeComplexity)  // CocomoHead tiene un TypeRequirement
               .WithMany(tx => tx.CocomoHeads)  // TypeRequirement tiene muchas CocomoHeads
               .HasForeignKey(tx => tx.IdTypeComplexity)  // La clave foránea es IdTypeRequirement
               .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            modelBuilder.Entity<CocomoHead>()
               .HasOne(mo => mo.Module)  // CocomoHead tiene un Module
               .WithMany(mo => mo.CocomoHeads)  // Module tiene muchas CocomoHeads
               .HasForeignKey(mo => mo.IdModule)  // La clave foránea es IdModule
               .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            modelBuilder.Entity<CocomoHead>()
               .HasOne(ve => ve.Vertical)  // CocomoHead tiene un Vertical
               .WithMany(ve => ve.CocomoHeads)  // Module tiene muchas CocomoHeads
               .HasForeignKey(ve => ve.IdVertical)  // La clave foránea es IdVertical
               .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            modelBuilder.Entity<CocomoHead>()
              .HasOne(cs => cs.Cocomostate)  // CocomoHead tiene un Cocomostate
              .WithMany(cs => cs.CocomoHeads)  // Cocomostate tiene muchas CocomoHeads
              .HasForeignKey(cs => cs.IdCocomostate)  // La clave foránea es IdCocomostate
              .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            modelBuilder.Entity<CocomoVersion>();
            //  .HasOne(csv => csv.Cocomostateversion)  // CocomoVersions tiene un Cocomostateversion
            //  .WithMany(csv => csv.CocomoVersions)  // Cocomostateversion tiene muchas CocomoVersion
            //  .HasForeignKey(csv => csv.IdCocomostateversion)  // La clave foránea es IdCocomostateversion
            //  .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            //modelBuilder.Entity<CocomoVersion>()
            //.HasOne(csv => csv.CocomoDetail)  // CocomoVersions tiene un CocomoDetail
            //.WithMany(csv => csv.CocomoVersions)  // CocomoDetail tiene muchas CocomoVersion
            //.HasForeignKey(csv => csv.IdCocomoDetail) // La clave foránea es IdCocomoDetail
            //.OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)

            
            //modelBuilder.Entity<CocomoVersion>()
            //.HasOne(cv => cv.CocomoRequeriment)  // CocomoVersion tiene un CocomoRequeriment
            //.WithOne(cr => cr.CocomoVersions)      // CocomoRequeriment un CocomoVersion
            //.HasForeignKey<CocomoVersion>(cr => cr.IdCocomoRequeriment)  // La clave foránea es IdCocomoRequeriment
            //.OnDelete(DeleteBehavior.Restrict);// Configura el comportamiento en cascada (opcional)

            //modelBuilder.Entity<CocomoVersion>()
            //.HasOne(cv => cv.CocomoFactor)  // CocomoVersion tiene un CocomoFactor
            //.WithOne(cf => cf.CocomoVersions)      // CocomoFactor tiene una CocomoVersion
            //.HasForeignKey<CocomoVersion>(cf => cf.IdCocomoFactor) // La clave foránea es IdCocomoFactor
            //.OnDelete(DeleteBehavior.Restrict);// Configura el comportamiento en cascada (opcional)


        }


        // Creacion de datosp por defecto
        public void SeedData()
        {
            if (!TypeRequirements.Any(tc => tc.Id == 1))
            {
                TypeRequirements.Add(new TypeRequirement { Name = "Cambio Generico" });
            }

            if (!TypeRequirements.Any(tc => tc.Id == 2))
            {
                TypeRequirements.Add(new TypeRequirement { Name = "Eventual" });
            }
            SaveChanges();


            if (!TypeComplexities.Any(tc => tc.Id == 1))
            {
                TypeComplexities.Add(new TypeComplexity { IdTypeRequirement = 2, Name = "Baja" });
            }

            if (!TypeComplexities.Any(tc => tc.Id == 2))
            {
                TypeComplexities.Add(new TypeComplexity { IdTypeRequirement = 2, Name = "Media" });
            }

            if (!TypeComplexities.Any(tc => tc.Id == 3))
            {
                TypeComplexities.Add(new TypeComplexity { IdTypeRequirement = 2, Name = "Alta" });
            }

            if (!TypeComplexities.Any(tc => tc.Id == 4))
            {
                TypeComplexities.Add(new TypeComplexity { IdTypeRequirement = 1, Name = "Desconocidad" });
            }

            SaveChanges();

            if (!Customers.Any(tc => tc.Id == 1))
            {
                Customers.Add(new Customer { Name = "Accusys", Description="Default" });
            }

            SaveChanges();


            if (!Modules.Any(mo => mo.Id == 1))
            {
                Modules.Add(new Module { Name = "Pasivas" });
            }
            if (!Modules.Any(mo => mo.Id == 2))
            {
                Modules.Add(new Module { Name = "Activas" });
            }
            SaveChanges();

            if (!Verticals.Any(ve => ve.Id == 1))
            {
                Verticals.Add(new Vertical { Name = "Cobre" });
            }
            if (!Verticals.Any(ve => ve.Id == 2))
            {
                Verticals.Add(new Vertical { Name = "Gris" });
            }
            if (!Verticals.Any(ve => ve.Id == 3))
            {
                Verticals.Add(new Vertical { Name = "Celeste" });
            }

            SaveChanges();


            if (!CocomoStates.Any(cs => cs.Id == 1))
            {
                CocomoStates.Add(new CocomoState { Name = "Defecto" });
            }

            SaveChanges();

            if (!CocomoStatesVersions.Any(csv => csv.Id == 1))
            {
                CocomoStatesVersions.Add(new CocomoStateVersion { Name = "Defecto" });
            }

            SaveChanges();

            if (!TypeProyects.Any(tp => tp.Id == 1))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "I",
                    Description = "Desarrollo de nuevas funcionalidades",
                    AD = 15,
                    DD = 16,
                    PP = 45,
                    SDT = 7,
                    CP = 17,
                    DT = 0,
                    DF = 0,
                    DB = 0,
                    Total = 100,
                    Editable = false
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 2))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "II",
                    Description = "Mejoras o agregados con menor influencia sobre las funciones del módulo",
                    AD = 13,
                    DD = 15,
                    PP = 50,
                    SDT = 5,
                    CP = 17,
                    DT = 0,
                    DF = 0,
                    DB = 0,
                    Total = 100,
                    Editable = false
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 3))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "III",
                    Description = "Mejoras o agregados con impacto técnico",
                    AD = 11,
                    DD = 16,
                    PP = 60,
                    SDT = 4,
                    CP = 9,
                    DT = 0,
                    DF = 0,
                    DB = 0,
                    Total = 100,
                    Editable = false
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 4))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "IV",
                    Description = "Definido por quien realiza la estimación",
                    AD = 50,
                    DD = 20,
                    PP = 30,
                    SDT = 0,
                    CP = 0,
                    DT = 0,
                    DF = 0,
                    DB = 0,
                    Total = 100,
                    Editable = true
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 5))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "V",
                    Description = "Tipo de Requerimiento II + Documentación Técnica y/o Funcional",
                    AD = 10,
                    DD = 15,
                    PP = 50,
                    SDT = 10,
                    CP = 5,
                    DT = 5,
                    DF = 5,
                    DB = 0,
                    Total = 100,
                    Editable = false
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 6))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "VI",
                    Description = "Tipo de Requerimiento II + Documentación Técnica, Funcional y/o Batch",
                    AD = 10,
                    DD = 13,
                    PP = 50,
                    SDT = 5,
                    CP = 10,
                    DT = 4,
                    DF = 4,
                    DB = 4,
                    Total = 100,
                    Editable = false
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 7))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "VII",
                    Description = "Desarrollo dentro de SWF con documentación Técnica",
                    AD = 0,
                    DD = 15,
                    PP = 65,
                    SDT = 10,
                    CP = 5,
                    DT = 5,
                    DF = 0,
                    DB = 0,
                    Total = 100,
                    Editable = false
                });
            }

            if (!TypeProyects.Any(tp => tp.Id == 8))
            {
                TypeProyects.Add(new TypeProyect
                {
                    ProyectType = "VIII",
                    Description = "Desarrollo dentro de SWF",
                    AD = 15,
                    DD = 0,
                    PP = 60,
                    SDT = 15,
                    CP = 5,
                    DT = 5,
                    DF = 0,
                    DB = 0,
                    Total = 100,
                    Editable = false
                });
            }
            SaveChanges();

            if (!TypeFactors.Any(tf => tf.Id == 1))
            {
                TypeFactors.Add(new TypeFactor { Name = "Default"});
            }

            SaveChanges();


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 1))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 1",
                    Description = "Cant. de Personas en el Equipo",
                    Data = 2,
                    Formula = "0",
                    Observation = "Número de Personas"
                });
            }

            if (!TypeFactorDetails.Any(tfd => tfd.Id == 2))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 2",
                    Description = "Complejidad de la Aplicación",
                    Data = 2,
                    Formula = "0",
                    Observation = "1=Baja,2=Media,3=Alta,4=Desconocida"
                });
            }

            if (!TypeFactorDetails.Any(tfd => tfd.Id == 3))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 3",
                    Description = "Perfiles de Usuarios Diferentes",
                    Data = 2,
                    Formula = "0",
                    Observation = " Número de Usuarios distintos a relevar"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 4))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 4",
                    Description = "Experiencia del Equipo",
                    Data = 3,
                    Formula = "0",
                    Observation = "1=Especialista,2=Senior,3=SSenior,4=Junior"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 5))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 5",
                    Description = "Tiempo dedicado a otras tareas",
                    Data = 0,
                    Formula = "0",
                    Observation = "0% a 100%"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 6))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 6",
                    Description = "Conocimiento Analistas Banco",
                    Data = 0,
                    Formula = "0",
                    Observation = "1=Bien Definido,2=Promedio,3=No claros,4=Ninguno"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 7))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 7",
                    Description = "Disponibilidad Analistas Banco",
                    Data = 2,
                    Formula = "0",
                    Observation = "1=Permanente,2=Promedio,3=Poca,4=Casi Nada"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 8))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 8",
                    Description = "Disponibilidad de Datos de Prueba ",
                    Data = 2,
                    Formula = "0",
                    Observation = "1=Bien Definido,2=Promedio,3=No claros,4=Ninguno"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 9))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 9",
                    Description = "Tiempo Improductivo de Máquina",
                    Data = 0,
                    Formula = "0",
                    Observation = "0% a 100%"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 10))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 10",
                    Description = "Disminución por reusabilidad",
                    Data = 0,
                    Formula = "0",
                    Observation = "0% a 100%"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 11))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 11",
                    Description = "Reusabilidad Modelo de prueba",
                    Data = 0,
                    Formula = "0",
                    Observation = "0% a 100%"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 12))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 12",
                    Description = "Conocimiento de la aplicación",
                    Data = 3,
                    Formula = "0",
                    Observation = "1=ninguno,2=bajo,3=medio,4=alto"
                });
            }

            if (!TypeFactorDetails.Any(tfd => tfd.Id == 13))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 13",
                    Description = "Cantidad de Otros Sectores",
                    Data = 0,
                    Formula = "",
                    Observation = " Número de Otros Sectores que participan de la corrección  / revisión de los productos finales"
                });
            }


            if (!TypeFactorDetails.Any(tfd => tfd.Id == 14))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 14",
                    Description = "Cantidad de Usuarios a Entrenar",
                    Data = 0,
                    Formula = "0",
                    Observation = "Número de Usuarios que participarán en el delivery de la aplicación / Capacitación"
                });
            }

            if (!TypeFactorDetails.Any(tfd => tfd.Id == 15))
            {
                TypeFactorDetails.Add(new TypeFactorDetail
                {
                    IdTypeFactor = 1,
                    Name = "Factor 15",
                    Description = "Impacto a otras funcionalidades",
                    Data = 1,
                    Formula = "0",
                    Observation = "1=ninguno,2=bajo,3=medio,4=alto,5=muy alto"
                });
            }
            SaveChanges();

        }

    }
}
