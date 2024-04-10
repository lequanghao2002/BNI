using Microsoft.EntityFrameworkCore;

namespace BNI.Models
{
    public partial class BNIContext : DbContext
    {
        public BNIContext()
        {
        }

        public BNIContext(DbContextOptions<BNIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventsRegister> EventsRegisters { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Platform> Platforms { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostsCategory> PostsCategories { get; set; } = null!;
        public virtual DbSet<Profession> Professions { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=123.31.29.137;Initial Catalog=BNI;User ID=tt2024;Password=Cubetech@2024;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("Assignment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("Member_ID");

                entity.Property(e => e.PositionId).HasColumnName("Position_ID");

                entity.Property(e => e.TermId).HasColumnName("Term_ID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Assignment_Member1");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Assignment_Position");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_Assignment_Term");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Job).HasMaxLength(50);

                entity.Property(e => e.MemberOfCsj).HasColumnName("MemberOfCSJ");

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.PlatformId).HasColumnName("Platform_ID");

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.YearOfExperience).HasMaxLength(50);

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.PlatformId)
                    .HasConstraintName("FK_Contact_Platform");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.OrganizerEmail).HasMaxLength(100);

                entity.Property(e => e.OrganizerName).HasMaxLength(100);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<EventsRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Events_Register");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("Event_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Events_Register_Event");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Events_Register_User");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .HasColumnName("Address_1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(100)
                    .HasColumnName("Address_2");

                entity.Property(e => e.BillingAddress)
                    .HasMaxLength(200)
                    .HasColumnName("Billing_Address");

                entity.Property(e => e.BillingCompany)
                    .HasMaxLength(200)
                    .HasColumnName("Billing_Company");

                entity.Property(e => e.BillingEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Billing_Email");

                entity.Property(e => e.BusinessSector)
                    .HasMaxLength(100)
                    .HasColumnName("Business_Sector");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(200);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(30);

                entity.Property(e => e.Introducer).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(30);

                entity.Property(e => e.LinkWeb).HasColumnName("Link_web");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(30)
                    .HasColumnName("Postal_code")
                    .IsFixedLength();

                entity.Property(e => e.ProfessionId).HasColumnName("Profession_ID");

                entity.Property(e => e.Pronoun).HasMaxLength(20);

                entity.Property(e => e.Provice).HasMaxLength(100);

                entity.Property(e => e.QrCode).HasColumnName("QR_Code");

                entity.Property(e => e.Referrer1)
                    .HasMaxLength(100)
                    .HasColumnName("Referrer_1");

                entity.Property(e => e.Referrer2)
                    .HasMaxLength(100)
                    .HasColumnName("Referrer_2");

                entity.Property(e => e.Sex).HasMaxLength(20);

                entity.Property(e => e.TaxAddress)
                    .HasMaxLength(200)
                    .HasColumnName("Tax_Address");

                entity.Property(e => e.TaxNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Tax_Number");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ProfessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_Profession1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Member_User");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("Platform");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("Group_ID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Position_Group");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostCategory).HasColumnName("Post_Category");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Posts_Member");

                entity.HasOne(d => d.PostCategoryNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostCategory)
                    .HasConstraintName("FK_Posts_Posts_Category");
            });

            modelBuilder.Entity<PostsCategory>(entity =>
            {
                entity.ToTable("Posts_Category");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.ToTable("Profession");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("Term");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.Vat)
                    .HasMaxLength(50)
                    .HasColumnName("VAT");

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}