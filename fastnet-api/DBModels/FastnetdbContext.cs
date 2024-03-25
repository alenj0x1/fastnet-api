using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fastnet_api.DBModels;

public partial class FastnetdbContext : DbContext
{
    public FastnetdbContext()
    {
    }

    public FastnetdbContext(DbContextOptions<FastnetdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attention> Attentions { get; set; }

    public virtual DbSet<Attentionstatus> Attentionstatuses { get; set; }

    public virtual DbSet<Attentiontype> Attentiontypes { get; set; }

    public virtual DbSet<Cash> Cashes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Methodpayment> Methodpayments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Statuscontract> Statuscontracts { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usercash> Usercashes { get; set; }

    public virtual DbSet<Userstatus> Userstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L9DERQU\\SQLEXPRESS;Database=fastnetdb;Trusted_Connection=True;TrustServerCertificate=true;Persist Security Info=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attention>(entity =>
        {
            entity.HasKey(e => e.Attentionid).HasName("PK__attentio__99FD35529FEF1197");

            entity.ToTable("attention");

            entity.Property(e => e.Attentionid).HasColumnName("attentionid");
            entity.Property(e => e.AttentionstatusStatusid).HasColumnName("attentionstatus_statusid");
            entity.Property(e => e.AttentiontypeAttentiontypeid).HasColumnName("attentiontype_attentiontypeid");
            entity.Property(e => e.ClientClientid).HasColumnName("client_clientid");
            entity.Property(e => e.TurnTurnid).HasColumnName("turn_turnid");

            entity.HasOne(d => d.AttentionstatusStatus).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.AttentionstatusStatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__atten__571DF1D5");

            entity.HasOne(d => d.AttentiontypeAttentiontype).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.AttentiontypeAttentiontypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__atten__5629CD9C");

            entity.HasOne(d => d.TurnTurn).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.TurnTurnid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__turn___5535A963");
        });

        modelBuilder.Entity<Attentionstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("PK__attentio__36247E30611E2A33");

            entity.ToTable("attentionstatus");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Attentiontype>(entity =>
        {
            entity.HasKey(e => e.Attentiontypeid).HasName("PK__attentio__9D38AAA32A90C931");

            entity.ToTable("attentiontype");

            entity.Property(e => e.Attentiontypeid).HasColumnName("attentiontypeid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Cash>(entity =>
        {
            entity.HasKey(e => e.Cashid).HasName("PK__cash__96014CBDB8B61609");

            entity.ToTable("cash");

            entity.Property(e => e.Cashid).HasColumnName("cashid");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Cashdescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("without description")
                .HasColumnName("cashdescription");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("PK__client__819DC769155EF664");

            entity.ToTable("client");

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Identification)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("identification");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Referenceaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referenceaddress");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Contracid).HasName("PK__contract__2ECBB3DBA608B5E6");

            entity.ToTable("contract");

            entity.Property(e => e.Contracid).HasColumnName("contracid");
            entity.Property(e => e.ClientClientid).HasColumnName("client_clientid");
            entity.Property(e => e.Enddate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("enddate");
            entity.Property(e => e.MethodpaymentMethodpaymentid).HasColumnName("methodpayment_methodpaymentid");
            entity.Property(e => e.ServiceServiceid).HasColumnName("service_serviceid");
            entity.Property(e => e.Startdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("startdate");
            entity.Property(e => e.StatuscontractStatusid).HasColumnName("statuscontract_statusid");

            entity.HasOne(d => d.ClientClient).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientClientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__client__66603565");

            entity.HasOne(d => d.MethodpaymentMethodpayment).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.MethodpaymentMethodpaymentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__method__6754599E");

            entity.HasOne(d => d.ServiceService).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ServiceServiceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__servic__6477ECF3");

            entity.HasOne(d => d.StatuscontractStatus).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StatuscontractStatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__status__656C112C");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Deviceid).HasName("PK__device__84B9F7FF7649B978");

            entity.ToTable("device");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Devicename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("devicename");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");

            entity.HasOne(d => d.Service).WithMany(p => p.Devices)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__device__servicei__48CFD27E");
        });

        modelBuilder.Entity<Methodpayment>(entity =>
        {
            entity.HasKey(e => e.Methodpaymentid).HasName("PK__methodpa__633563A493F8BEF7");

            entity.ToTable("methodpayment");

            entity.Property(e => e.Methodpaymentid).HasColumnName("methodpaymentid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("PK__payments__AF26EBEE18C20925");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("datetime")
                .HasColumnName("paymentdate");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__payments__client__4D94879B");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Rolid).HasName("PK__rol__5403326CD21BCB1B");

            entity.ToTable("rol");

            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Rolname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rolname");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("PK__service__45516CA7F2B6FAFD");

            entity.ToTable("service");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("price");
            entity.Property(e => e.Servicedescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("servicedescription");
            entity.Property(e => e.Servicename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("servicename");
        });

        modelBuilder.Entity<Statuscontract>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("PK__statusco__36247E3071A223E3");

            entity.ToTable("statuscontract");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.HasKey(e => e.Turnid).HasName("PK__turn__C2FE6222D2E68138");

            entity.ToTable("turn");

            entity.Property(e => e.Turnid).HasColumnName("turnid");
            entity.Property(e => e.CashCashid).HasColumnName("cash_cashid");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("without description.")
                .HasColumnName("description");
            entity.Property(e => e.Usergestorid).HasColumnName("usergestorid");

            entity.HasOne(d => d.CashCash).WithMany(p => p.Turns)
                .HasForeignKey(d => d.CashCashid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__turn__cash_cashi__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B257CBB72A83");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationdate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RolRolid).HasColumnName("rol_rolid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.UserstatusStatusid).HasColumnName("userstatus_statusid");

            entity.HasOne(d => d.RolRol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolRolid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__rol_rolid__59FA5E80");

            entity.HasOne(d => d.UserstatusStatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserstatusStatusid)
                .HasConstraintName("FK__users__userstatu__5BE2A6F2");
        });

        modelBuilder.Entity<Usercash>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usercash");

            entity.HasIndex(e => e.UserUserid, "UQ__usercash__436BE0FAF9FAFD68").IsUnique();

            entity.Property(e => e.CashCashid).HasColumnName("cash_cashid");
            entity.Property(e => e.UserUserid).HasColumnName("user_userid");

            entity.HasOne(d => d.CashCash).WithMany()
                .HasForeignKey(d => d.CashCashid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usercash__cash_c__5FB337D6");

            entity.HasOne(d => d.UserUser).WithOne()
                .HasForeignKey<Usercash>(d => d.UserUserid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usercash__user_u__5EBF139D");
        });

        modelBuilder.Entity<Userstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("PK__userstat__36247E305EC4D201");

            entity.ToTable("userstatus");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
