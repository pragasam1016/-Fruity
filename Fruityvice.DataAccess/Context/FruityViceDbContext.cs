using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FruityVice.DataAccess;

public partial class FruityViceDbContext : DbContext
{
    public FruityViceDbContext()
    {
    }

    public FruityViceDbContext(DbContextOptions<FruityViceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fruity> Fruities { get; set; }

    public virtual DbSet<Nutrition> Nutritions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-EAGD40N;Initial Catalog=FruityVice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=true;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nutrition>(entity =>
        {
            entity.HasOne(d => d.Fruity).WithMany(p => p.Nutritions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nutritions_FruityId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
