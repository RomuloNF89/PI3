using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PI3.Models
{
    public partial class BDContexto : DbContext
    {
        public BDContexto()
        {
        }

        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Bolsa> Bolsa { get; set; }
        public virtual DbSet<Concedente> Concedente { get; set; }
        public virtual DbSet<ContagemEstudantesGraduados> ContagemEstudantesGraduados { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Diferenca> Diferenca { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Estudante> Estudante { get; set; }
        public virtual DbSet<Leciona> Leciona { get; set; }
        public virtual DbSet<PodeSer> PodeSer { get; set; }
        public virtual DbSet<Possui> Possui { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Tem> Tem { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Trabalha> Trabalha { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=cadastro_estudante");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.CodArea)
                    .HasName("PRIMARY");

                entity.ToTable("Area");

                entity.Property(e => e.Nome).HasMaxLength(30);
            });

            modelBuilder.Entity<Bolsa>(entity =>
            {
                entity.HasKey(e => e.CodBolsa)
                    .HasName("PRIMARY");

                entity.ToTable("Bolsa");

                entity.Property(e => e.Ano).HasColumnType("year");

                entity.Property(e => e.Edital)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Concedente>(entity =>
            {
                entity.HasKey(e => e.CodConcedente)
                    .HasName("PRIMARY");

                entity.ToTable("Concedente");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ContagemEstudantesGraduados>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("contagem_estudantes_graduados");

                entity.Property(e => e.AvgIdade)
                    .HasColumnName("AVG(idade)")
                    .HasColumnType("decimal(14,4)");

                entity.Property(e => e.CountCursoCodCurso).HasColumnName("count(Curso.CodCurso)");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.CodCurso)
                    .HasName("PRIMARY");

                entity.ToTable("Curso");

                entity.HasIndex(e => e.CodArea)
                    .HasName("CodArea");

                entity.HasIndex(e => e.CodCoordenador)
                    .HasName("CodCoordenador");

                entity.HasIndex(e => e.CodDepartamento)
                    .HasName("CodDepartamento");

                entity.HasIndex(e => e.CodTipo)
                    .HasName("CodTipo");

                entity.Property(e => e.Modalidade)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.CodAreaNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.CodArea)
                    .HasConstraintName("curso_ibfk_3");

                entity.HasOne(d => d.CodCoordenadorNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.CodCoordenador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("curso_ibfk_4");

                entity.HasOne(d => d.CodDepartamentoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.CodDepartamento)
                    .HasConstraintName("curso_ibfk_1");

                entity.HasOne(d => d.CodTipoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.CodTipo)
                    .HasConstraintName("curso_ibfk_2");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CodDepartamento)
                    .HasName("PRIMARY");

                entity.ToTable("Departamento");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Diferenca>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Diferenca");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.HasKey(e => e.CodDisciplina)
                    .HasName("PRIMARY");

                entity.ToTable("Disciplina");

                entity.Property(e => e.Nome).HasMaxLength(30);
            });

            modelBuilder.Entity<Estudante>(entity =>
            {
                entity.HasKey(e => e.MatEstudante)
                    .HasName("PRIMARY");

                entity.ToTable("Estudante");

                entity.HasIndex(e => e.CodCurso)
                    .HasName("CodCurso");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.HasOne(d => d.CodCursoNavigation)
                    .WithMany(p => p.Estudante)
                    .HasForeignKey(d => d.CodCurso)
                    .HasConstraintName("estudante_ibfk_1");
            });

            modelBuilder.Entity<Leciona>(entity =>
            {
                entity.HasKey(e => new { e.MatProfessor, e.CodDisciplina })
                    .HasName("PRIMARY");

                entity.ToTable("Leciona");

                entity.HasIndex(e => e.CodDisciplina)
                    .HasName("CodDisciplina");

                entity.HasOne(d => d.CodDisciplinaNavigation)
                    .WithMany(p => p.Leciona)
                    .HasForeignKey(d => d.CodDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leciona_ibfk_2");

                entity.HasOne(d => d.MatProfessorNavigation)
                    .WithMany(p => p.Leciona)
                    .HasForeignKey(d => d.MatProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leciona_ibfk_1");
            });

            modelBuilder.Entity<PodeSer>(entity =>
            {
                entity.HasKey(e => new { e.MatEstudante, e.CodBolsa })
                    .HasName("PRIMARY");

                entity.ToTable("Pode_ser");

                entity.HasIndex(e => e.CodBolsa)
                    .HasName("CodBolsa");

                entity.Property(e => e.DataFim)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DataInicio)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.CodBolsaNavigation)
                    .WithMany(p => p.PodeSer)
                    .HasForeignKey(d => d.CodBolsa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pode_ser_ibfk_2");

                entity.HasOne(d => d.MatEstudanteNavigation)
                    .WithMany(p => p.PodeSer)
                    .HasForeignKey(d => d.MatEstudante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pode_ser_ibfk_1");
            });

            modelBuilder.Entity<Possui>(entity =>
            {
                entity.HasKey(e => new { e.CodBolsa, e.CodConcedente })
                    .HasName("PRIMARY");

                entity.ToTable("Possui");

                entity.HasIndex(e => e.CodConcedente)
                    .HasName("CodConcedente");

                entity.HasOne(d => d.CodBolsaNavigation)
                    .WithMany(p => p.Possui)
                    .HasForeignKey(d => d.CodBolsa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("possui_ibfk_1");

                entity.HasOne(d => d.CodConcedenteNavigation)
                    .WithMany(p => p.Possui)
                    .HasForeignKey(d => d.CodConcedente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("possui_ibfk_2");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.MatProfessor)
                    .HasName("PRIMARY");

                entity.ToTable("Professor");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Tem>(entity =>
            {
                entity.HasKey(e => new { e.CodDisciplina, e.CodCurso })
                    .HasName("PRIMARY");

                entity.ToTable("Tem");

                entity.HasIndex(e => e.CodCurso)
                    .HasName("CodCurso");

                entity.HasOne(d => d.CodCursoNavigation)
                    .WithMany(p => p.Tem)
                    .HasForeignKey(d => d.CodCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tem_ibfk_2");

                entity.HasOne(d => d.CodDisciplinaNavigation)
                    .WithMany(p => p.Tem)
                    .HasForeignKey(d => d.CodDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tem_ibfk_1");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.CodTipo)
                    .HasName("PRIMARY");

                entity.ToTable("Tipo");

                entity.Property(e => e.Nome).HasMaxLength(30);
            });

            modelBuilder.Entity<Trabalha>(entity =>
            {
                entity.HasKey(e => new { e.CodDepartamento, e.MatProfessor })
                    .HasName("PRIMARY");

                entity.ToTable("Trabalha");

                entity.HasIndex(e => e.MatProfessor)
                    .HasName("MatProfessor");

                entity.HasOne(d => d.CodDepartamentoNavigation)
                    .WithMany(p => p.Trabalha)
                    .HasForeignKey(d => d.CodDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trabalha_ibfk_1");

                entity.HasOne(d => d.MatProfessorNavigation)
                    .WithMany(p => p.Trabalha)
                    .HasForeignKey(d => d.MatProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trabalha_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
