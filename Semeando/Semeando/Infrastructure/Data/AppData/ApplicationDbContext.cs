using Microsoft.EntityFrameworkCore;
using Semeando.Domain.Entities;

namespace Semeando.Infrastructure.Data.AppData
{
    public class ApplicationDbContext : DbContext
    {
        // Definição dos DbSets para cada entidade
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<LevelEntity> Levels { get; set; }
        public DbSet<PerguntaEntity> Perguntas { get; set; }
        public DbSet<OpcaoEntity> Opcoes { get; set; }
        public DbSet<RespostaEntity> Respostas { get; set; }

        // Construtor padrão
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Método para configurar o modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da tabela de Usuário
            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.ToTable("tb_Usuario");
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
                entity.Property(e => e.Nome).HasColumnName("nome_usuario");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Ranking).HasColumnName("ranking");
            });

            // Configuração da tabela de Level
            modelBuilder.Entity<LevelEntity>(entity =>
            {
                entity.ToTable("tb_Level");
                entity.HasKey(e => e.IdLevel);
                entity.Property(e => e.IdLevel).HasColumnName("id_level");
                entity.Property(e => e.Titulo).HasColumnName("titulo");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.Dificuldade).HasColumnName("dificuldade");
            });

            // Configuração da tabela de Pergunta
            modelBuilder.Entity<PerguntaEntity>(entity =>
            {
                entity.ToTable("tb_Pergunta");
                entity.HasKey(e => e.IdPergunta);
                entity.Property(e => e.IdPergunta).HasColumnName("id_pergunta");
                entity.Property(e => e.IdLevel).HasColumnName("id_level");
                entity.Property(e => e.Texto).HasColumnName("texto");
                entity.Property(e => e.TipoPergunta).HasColumnName("tipo_pergunta");

                // Relacionamento com Level
                entity.HasOne(p => p.Level)
                    .WithMany(l => l.Perguntas)
                    .HasForeignKey(p => p.IdLevel)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuração da tabela de Opção
            modelBuilder.Entity<OpcaoEntity>(entity =>
            {
                entity.ToTable("tb_Opcao");
                entity.HasKey(e => new { e.IdOpcao, e.IdPergunta });
                entity.Property(e => e.IdOpcao).HasColumnName("id_opcao");
                entity.Property(e => e.IdPergunta).HasColumnName("id_pergunta");
                entity.Property(e => e.Texto).HasColumnName("texto");
                entity.Property(e => e.OpcaoCorreta).HasColumnName("op_correta");

                // Relacionamento com Pergunta
                entity.HasOne(o => o.Pergunta)
                    .WithMany(p => p.Opcoes)
                    .HasForeignKey(o => o.IdPergunta);
            });

            // Configuração da tabela de Resposta
            modelBuilder.Entity<RespostaEntity>(entity =>
            {
                entity.ToTable("tb_Resposta");
                entity.HasKey(e => e.IdResposta);
                entity.Property(e => e.IdResposta).HasColumnName("id_resposta");
                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
                entity.Property(e => e.IdPergunta).HasColumnName("id_pergunta");
                entity.Property(e => e.OpcaoEscolhida).HasColumnName("op_escolhida");

                // Relacionamento com Usuário
                entity.HasOne(r => r.Usuario)
                    .WithMany(u => u.Respostas)
                    .HasForeignKey(r => r.IdUsuario);

                // Relacionamento com Pergunta
                entity.HasOne(r => r.Pergunta)
                    .WithMany(p => p.Respostas)
                    .HasForeignKey(r => r.IdPergunta);

                // Relacionamento com Opção
                entity.HasOne(r => r.Opcao)
                    .WithMany()
                    .HasForeignKey(r => new { r.IdPergunta, r.OpcaoEscolhida });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("YourConnectionStringHere");
            }
        }
    }
}


