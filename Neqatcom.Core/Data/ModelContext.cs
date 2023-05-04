using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Neqatcom.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gpcategory> Gpcategories { get; set; }
        public virtual DbSet<Gpcommercialregister> Gpcommercialregisters { get; set; }
        public virtual DbSet<Gpcomplaint> Gpcomplaints { get; set; }
        public virtual DbSet<Gpcontactu> Gpcontactus { get; set; }
        public virtual DbSet<Gphomepage> Gphomepages { get; set; }
        public virtual DbSet<Gplenderstore> Gplenderstores { get; set; }
        public virtual DbSet<Gploan> Gploans { get; set; }
        public virtual DbSet<Gploanee> Gploanees { get; set; }
        public virtual DbSet<Gpmeeting> Gpmeetings { get; set; }
        public virtual DbSet<Gpnationalnumber> Gpnationalnumbers { get; set; }
        public virtual DbSet<Gpoffer> Gpoffers { get; set; }
        public virtual DbSet<Gppurchasing> Gppurchasings { get; set; }
        public virtual DbSet<Gptestimonial> Gptestimonials { get; set; }
        public virtual DbSet<Gpuser> Gpusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=JOR17_User51;PASSWORD=Ghayath123;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR17_USER51")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Gpcategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("SYS_C00367179");

                entity.ToTable("GPCATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryimage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYIMAGE");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Gpcommercialregister>(entity =>
            {
                entity.HasKey(e => e.Commercialid)
                    .HasName("SYS_C00367579");

                entity.ToTable("GPCOMMERCIALREGISTER");

                entity.Property(e => e.Commercialid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COMMERCIALID");

                entity.Property(e => e.Commercialcode)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIALCODE");
            });

            modelBuilder.Entity<Gpcomplaint>(entity =>
            {
                entity.HasKey(e => e.Complaintsid)
                    .HasName("SYS_C00368004");

                entity.ToTable("GPCOMPLAINTS");

                entity.Property(e => e.Complaintsid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COMPLAINTSID");

                entity.Property(e => e.Compliantnotes)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COMPLIANTNOTES");

                entity.Property(e => e.Dateofcomplaints)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFCOMPLAINTS");

                entity.Property(e => e.Leid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LEID");

                entity.Property(e => e.Loid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOID");

                entity.Property(e => e.Managestatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MANAGESTATUS")
                    .HasDefaultValueSql("0 ");

                entity.HasOne(d => d.Le)
                    .WithMany(p => p.Gpcomplaints)
                    .HasForeignKey(d => d.Leid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("LENDERID663_FK");

                entity.HasOne(d => d.Lo)
                    .WithMany(p => p.Gpcomplaints)
                    .HasForeignKey(d => d.Loid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("LOANEEID123_FK");
            });

            modelBuilder.Entity<Gpcontactu>(entity =>
            {
                entity.HasKey(e => e.Contactid)
                    .HasName("SYS_C00367195");

                entity.ToTable("GPCONTACTUS");

                entity.Property(e => e.Contactid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTID");

                entity.Property(e => e.Emaill)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EMAILL");

                entity.Property(e => e.Firstnamee)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAMEE");

                entity.Property(e => e.Lastnamee)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAMEE");

                entity.Property(e => e.Message)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<Gphomepage>(entity =>
            {
                entity.HasKey(e => e.Homeid)
                    .HasName("SYS_C00367197");

                entity.ToTable("GPHOMEPAGE");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Companyaddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COMPANYADDRESS");

                entity.Property(e => e.Companyemail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COMPANYEMAIL");

                entity.Property(e => e.Companyphonenumber)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COMPANYPHONENUMBER");

                entity.Property(e => e.Logo)
                    .HasMaxLength(355)
                    .IsUnicode(false)
                    .HasColumnName("LOGO");

                entity.Property(e => e.Paragraph1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH1");

                entity.Property(e => e.Paragraph2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH2");

                entity.Property(e => e.Paragraph3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH3");
            });

            modelBuilder.Entity<Gplenderstore>(entity =>
            {
                entity.HasKey(e => e.Lenderid)
                    .HasName("SYS_C00367175");

                entity.ToTable("GPLENDERSTORE");

                entity.HasIndex(e => e.Commercialregister, "SYS_C00367176")
                    .IsUnique();

                entity.Property(e => e.Lenderid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LENDERID");

                entity.Property(e => e.Commercialregister)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIALREGISTER");

                entity.Property(e => e.Companysize)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANYSIZE");

                entity.Property(e => e.Lenderuserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LENDERUSERID");

                entity.Property(e => e.Registerstatus)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("REGISTERSTATUS");

                entity.Property(e => e.Shadowstatus)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SHADOWSTATUS");

                entity.Property(e => e.Siteurl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SITEURL");

                entity.Property(e => e.Warncounter)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WARNCOUNTER");

                entity.Property(e => e.Warndate)
                    .HasColumnType("DATE")
                    .HasColumnName("WARNDATE");

                entity.HasOne(d => d.Lenderuser)
                    .WithMany(p => p.Gplenderstores)
                    .HasForeignKey(d => d.Lenderuserid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERID344_FK");
            });

            modelBuilder.Entity<Gploan>(entity =>
            {
                entity.HasKey(e => e.Loanid)
                    .HasName("SYS_C00367185");

                entity.ToTable("GPLOAN");

                entity.Property(e => e.Loanid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOANID");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Estimatedprice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("ESTIMATEDPRICE");

                entity.Property(e => e.Latedayscounter)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LATEDAYSCOUNTER");

                entity.Property(e => e.Loaneeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOANEEID");

                entity.Property(e => e.Loanstatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOANSTATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Monthlyamount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("MONTHLYAMOUNT");

                entity.Property(e => e.Offerid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("OFFERID");

                entity.Property(e => e.Postponedate)
                    .HasColumnType("DATE")
                    .HasColumnName("POSTPONEDATE");

                entity.Property(e => e.Postponestatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POSTPONESTATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Predayscounter)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PREDAYSCOUNTER")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Totalmonths)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALMONTHS");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TOTALPRICE");

                entity.HasOne(d => d.Loanee)
                    .WithMany(p => p.Gploans)
                    .HasForeignKey(d => d.Loaneeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("USERID6534D52G343_FK");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Gploans)
                    .HasForeignKey(d => d.Offerid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("USERID653452G343_FK");
            });

            modelBuilder.Entity<Gploanee>(entity =>
            {
                entity.HasKey(e => e.Loaneeid)
                    .HasName("SYS_C00367171");

                entity.ToTable("GPLOANEE");

                entity.HasIndex(e => e.Nationalnumber, "SYS_C00367172")
                    .IsUnique();

                entity.Property(e => e.Loaneeid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOANEEID");

                entity.Property(e => e.Creditscore)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CREDITSCORE");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Loaneeuserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOANEEUSERID");

                entity.Property(e => e.Nationalnumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALNUMBER");

                entity.Property(e => e.Numoffamily)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMOFFAMILY");

                entity.Property(e => e.Postponecounter)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POSTPONECOUNTER")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALARY");

                entity.Property(e => e.Warncounter)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WARNCOUNTER");

                entity.HasOne(d => d.Loaneeuser)
                    .WithMany(p => p.Gploanees)
                    .HasForeignKey(d => d.Loaneeuserid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERID653_FK");
            });

            modelBuilder.Entity<Gpmeeting>(entity =>
            {
                entity.HasKey(e => e.Meetingid)
                    .HasName("SYS_C00367199");

                entity.ToTable("GPMEETINGS");

                entity.Property(e => e.Meetingid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MEETINGID");

                entity.Property(e => e.Feedbackk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FEEDBACKK");

                entity.Property(e => e.Lenderid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LENDERID");

                entity.Property(e => e.Loaneeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOANEEID");

                entity.Property(e => e.Loanid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOANID");

                entity.Property(e => e.Meetingtime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEETINGTIME");

                entity.Property(e => e.Meetingurl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MEETINGURL");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.HasOne(d => d.Lender)
                    .WithMany(p => p.Gpmeetings)
                    .HasForeignKey(d => d.Lenderid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USDFGH43_FK");

                entity.HasOne(d => d.Loanee)
                    .WithMany(p => p.Gpmeetings)
                    .HasForeignKey(d => d.Loaneeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GH52G343_FK");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Gpmeetings)
                    .HasForeignKey(d => d.Loanid)
                    .HasConstraintName("FK_MEETINGLOAN");
            });

            modelBuilder.Entity<Gpnationalnumber>(entity =>
            {
                entity.HasKey(e => e.Nnid)
                    .HasName("SYS_C00367581");

                entity.ToTable("GPNATIONALNUMBER");

                entity.Property(e => e.Nnid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NNID");

                entity.Property(e => e.Nationalnum)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALNUM");
            });

            modelBuilder.Entity<Gpoffer>(entity =>
            {
                entity.HasKey(e => e.Offerid)
                    .HasName("SYS_C00367181");

                entity.ToTable("GPOFFER");

                entity.Property(e => e.Offerid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OFFERID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Lenderid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LENDERID");

                entity.Property(e => e.Minmonth)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MINMONTH");

                entity.Property(e => e.Totalmonths)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALMONTHS");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Gpoffers)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERID653452343_FK");

                entity.HasOne(d => d.Lender)
                    .WithMany(p => p.Gpoffers)
                    .HasForeignKey(d => d.Lenderid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERID652343_FK");
            });

            modelBuilder.Entity<Gppurchasing>(entity =>
            {
                entity.HasKey(e => e.Purchaseid)
                    .HasName("SYS_C00367189");

                entity.ToTable("GPPURCHASING");

                entity.Property(e => e.Purchaseid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PURCHASEID");

                entity.Property(e => e.Loanid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOANID");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYMENTDATE");

                entity.Property(e => e.Paymenttype)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENTTYPE");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Gppurchasings)
                    .HasForeignKey(d => d.Loanid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("US5ERID6534D52G343_FK");
            });

            modelBuilder.Entity<Gptestimonial>(entity =>
            {
                entity.HasKey(e => e.Testimonialid)
                    .HasName("SYS_C00367192");

                entity.ToTable("GPTESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Message)
                    .HasMaxLength(355)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Testimonialstatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TESTIMONIALSTATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Gptestimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERID5G653_FK");
            });

            modelBuilder.Entity<Gpuser>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C00367168");

                entity.ToTable("GPUSER");

                entity.HasIndex(e => e.Username, "SYS_C00367169")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUM");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Userimage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("USERIMAGE");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.HasSequence("EMP_SEQ1").IncrementsBy(5);

            modelBuilder.HasSequence("EMP_SEQ2").IsCyclic();

            modelBuilder.HasSequence("EMP_SEQ3")
                .IncrementsBy(2)
                .IsCyclic();

            modelBuilder.HasSequence("EMPLOYEE_SEQ").IncrementsBy(2);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
