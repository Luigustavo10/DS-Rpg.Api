using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgApi.Models.Utils;
namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Armas> Armas { get; set; }
        public DbSet<Usuario> Usuarios {get; set; }
        public DbSet<Habilidades> Habilidades {get; set; }
        public DbSet<PersonagemHabilidade> PersonagemHabilidade {get; set; }
        public DbSet<Disputa> Disputas{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().HasData
            (
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago }
            );

            modelBuilder.Entity<Armas>().HasData
            (
            new Armas() { Id = 1, Nome = "AK-47", Dano = 47, PersonagemId = 1 },
            new Armas() { Id = 2, Nome = "Mp-40", Dano = 34, PersonagemId = 2},
            new Armas() { Id = 3, Nome = "AWP", Dano = 237, PersonagemId = 3 },
            new Armas() { Id = 4, Nome = "USP", Dano = 12, PersonagemId = 4},
            new Armas() { Id = 5, Nome = "Escopeta", Dano = 90, PersonagemId = 5 },
            new Armas() { Id = 6, Nome = "MP5", Dano = 24, PersonagemId = 6 },
            new Armas() { Id = 7, Nome = "Famas", Dano = 45, PersonagemId = 7}
            );

            modelBuilder.Entity<PersonagemHabilidade>()
            .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId}) ;

             modelBuilder.Entity<Habilidades>().HasData
            (
            new Habilidades() { Id = 1, Nome = "Adormecer", Dano = 47 },
            new Habilidades() { Id = 2, Nome = "Congelar", Dano = 34},
            new Habilidades() { Id = 3, Nome = "Hipnotizar", Dano = 237}
            );

             modelBuilder.Entity<PersonagemHabilidade>().HasData
            (
            new PersonagemHabilidade() { PersonagemId = 1,  HabilidadeId = 1 },
            new PersonagemHabilidade() { PersonagemId = 2, HabilidadeId = 2},
            new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId = 3},
            new PersonagemHabilidade() { PersonagemId = 4, HabilidadeId = 4},
            new PersonagemHabilidade() { PersonagemId = 5, HabilidadeId = 5 },
            new PersonagemHabilidade() { PersonagemId = 6, HabilidadeId = 6},
            new PersonagemHabilidade() { PersonagemId = 7, HabilidadeId = 7}
            );


              
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "Admin@gamil.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;
        

            modelBuilder.Entity<Usuario>().HasData(user);

             modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");

        }
        
    }
}