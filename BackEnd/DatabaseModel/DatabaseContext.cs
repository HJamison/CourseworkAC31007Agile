using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<FilledQuestionnaires> FilledQuestionnaires { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<PermissionLevels> PermissionLevels { get; set; }
        public virtual DbSet<QuestionTypes> QuestionTypes { get; set; }
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<ResearchOwners> ResearchOwners { get; set; }
        public virtual DbSet<ResearchProjects> ResearchProjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:agile-coursework-server.database.windows.net,1433;Initial Catalog=StorageForTheBois;Persist Security Info=False;User ID=dbadmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Answers_pk")
                    .IsClustered(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("text");

                entity.Property(e => e.Participant).HasColumnName("participant");

                entity.Property(e => e.Question).HasColumnName("question");

                entity.Property(e => e.Questionnaire).HasColumnName("questionnaire");

                entity.HasOne(d => d.ParticipantNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Participant)
                    .HasConstraintName("Answers_Participants_id_fk");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Question)
                    .HasConstraintName("Answers_Questions_Id_fk");

                entity.HasOne(d => d.QuestionnaireNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Questionnaire)
                    .HasConstraintName("Answers_Questionnaires_Id_fk");
            });

            modelBuilder.Entity<FilledQuestionnaires>(entity =>
            {
                entity.HasKey(e => new { e.Questionnaire, e.Participant })
                    .HasName("Filled Questionnaires_pk")
                    .IsClustered(false);

                entity.ToTable("Filled Questionnaires");

                entity.Property(e => e.Questionnaire).HasColumnName("questionnaire");

                entity.Property(e => e.Participant).HasColumnName("participant");

                entity.HasOne(d => d.ParticipantNavigation)
                    .WithMany(p => p.FilledQuestionnaires)
                    .HasForeignKey(d => d.Participant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Filled Questionnaires_Participants_id_fk");

                entity.HasOne(d => d.QuestionnaireNavigation)
                    .WithMany(p => p.FilledQuestionnaires)
                    .HasForeignKey(d => d.Questionnaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Filled Questionnaires_Questionnaires_Id_fk");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Participants_pk")
                    .IsClustered(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Participation>(entity =>
            {
                entity.HasKey(e => e.Project)
                    .HasName("Participation_pk")
                    .IsClustered(false);

                entity.Property(e => e.Project)
                    .HasColumnName("project")
                    .ValueGeneratedNever();

                entity.Property(e => e.Participant).HasColumnName("participant");

                entity.HasOne(d => d.ParticipantNavigation)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.Participant)
                    .HasConstraintName("Participation_Participants_id_fk");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithOne(p => p.Participation)
                    .HasForeignKey<Participation>(d => d.Project)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Participation_Research Projects_id_fk");
            });

            modelBuilder.Entity<PermissionLevels>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("Permission Levels_pk")
                    .IsClustered(false);

                entity.ToTable("Permission Levels");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20);

                entity.Property(e => e.CanAssignCr).HasColumnName("can_assign_CR");

                entity.Property(e => e.CanAssignPr).HasColumnName("can_assign_PR");

                entity.Property(e => e.CanManageUsers).HasColumnName("can_manage_users");
            });

            modelBuilder.Entity<QuestionTypes>(entity =>
            {
                entity.HasKey(e => e.QuestionType)
                    .HasName("Question Types_pk")
                    .IsClustered(false);

                entity.ToTable("Question Types");

                entity.Property(e => e.QuestionType)
                    .HasColumnName("question_type")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Questionnaires>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Questionnaires_pk")
                    .IsClustered(false);

                entity.Property(e => e.HasIdInputQuestion).HasColumnName("has_id_input_question");

                entity.Property(e => e.Invitation)
                    .HasColumnName("invitation")
                    .HasColumnType("text");

                entity.Property(e => e.Json).HasColumnName("json");

                entity.Property(e => e.Research).HasColumnName("research");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("text");

                entity.HasOne(d => d.ResearchNavigation)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(d => d.Research)
                    .HasConstraintName("Questionnaires_Research Projects_id_fk");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Questions_pk")
                    .IsClustered(false);

                entity.HasComment("Choices should be the possible answers separated by comas. System Usability Scales should reference individual question ids in their choices field.");

                entity.Property(e => e.Choices)
                    .HasColumnName("choices")
                    .HasColumnType("text");

                entity.Property(e => e.OrderInQuestionnaire).HasColumnName("order_in_questionnaire");

                entity.Property(e => e.OrderInSus).HasColumnName("order_in_SUS");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("text");

                entity.Property(e => e.Questionnaire).HasColumnName("questionnaire");

                entity.Property(e => e.SusId).HasColumnName("SUS_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(25);

                entity.HasOne(d => d.QuestionnaireNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Questionnaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Questions_Questionnaires_Id_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Questions_Question Types_question_type_fk");
            });

            modelBuilder.Entity<ResearchOwners>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Research Owners_pk")
                    .IsClustered(false);

                entity.ToTable("Research Owners");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ResearchProject).HasColumnName("research_project");

                entity.Property(e => e.Researcher)
                    .HasColumnName("researcher")
                    .HasMaxLength(50);

                entity.HasOne(d => d.ResearchProjectNavigation)
                    .WithMany(p => p.ResearchOwners)
                    .HasForeignKey(d => d.ResearchProject)
                    .HasConstraintName("Research Owners_Research Projects_id_fk");

                entity.HasOne(d => d.ResearcherNavigation)
                    .WithMany(p => p.ResearchOwners)
                    .HasForeignKey(d => d.Researcher)
                    .HasConstraintName("Research Owners_Users_username_fk");
            });

            modelBuilder.Entity<ResearchProjects>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Projects_pk")
                    .IsClustered(false);

                entity.ToTable("Research Projects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("Users_pk")
                    .IsClustered(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("text");

                entity.Property(e => e.PermissionLevel)
                    .IsRequired()
                    .HasColumnName("permission_level")
                    .HasMaxLength(20);

                entity.HasOne(d => d.PermissionLevelNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PermissionLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_Permission Levels_title_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
