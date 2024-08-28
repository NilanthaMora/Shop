using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models;

public partial class EshopContext : DbContext
{
    public EshopContext()
    {
    }

    public EshopContext(DbContextOptions<EshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<QuantityType> QuantityTypes { get; set; }

    public virtual DbSet<ShopLog> ShopLogs { get; set; }

    public virtual DbSet<ShopProduct> ShopProducts { get; set; }

    public virtual DbSet<ShopSupplier> ShopSuppliers { get; set; }

    public virtual DbSet<ShopUser> ShopUsers { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CKBEGSR;Database=eshop;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PaymentId });

            entity.ToTable("Payment");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentId");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("paymentDate");
            entity.Property(e => e.PaymentType).HasColumnName("paymentType");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.PaymentTypeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentType)
                .HasConstraintName("FK_Payment_PaymentType");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeId");
            entity.Property(e => e.PaymentTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentTypeName");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.ProductTypeId).HasColumnName("productTypeId");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productTypeName");
        });

        modelBuilder.Entity<QuantityType>(entity =>
        {
            entity.ToTable("QuantityType");

            entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeId");
            entity.Property(e => e.QuantityTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("quantityTypeName");
        });

        modelBuilder.Entity<ShopLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("ShopLog");

            entity.Property(e => e.LogId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("logId");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ip");
            entity.Property(e => e.LogTime)
                .HasColumnType("datetime")
                .HasColumnName("logTime");
        });

        modelBuilder.Entity<ShopProduct>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ProductId });

            entity.ToTable("ShopProduct");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productId");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.ProductModel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productModel");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("productPrice");
            entity.Property(e => e.ProductQuantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("productQuantity");
            entity.Property(e => e.ProductTypeId).HasColumnName("productTypeId");
            entity.Property(e => e.QuantityType).HasColumnName("quantityType");
            entity.Property(e => e.Store).HasColumnName("store");
            entity.Property(e => e.Supplier).HasColumnName("supplier");

            entity.HasOne(d => d.ProductType).WithMany(p => p.ShopProducts)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK_ShopProduct_ProductType");

            entity.HasOne(d => d.QuantityTypeNavigation).WithMany(p => p.ShopProducts)
                .HasForeignKey(d => d.QuantityType)
                .HasConstraintName("FK_ShopProduct_QuantityType");

            entity.HasOne(d => d.StoreNavigation).WithMany(p => p.ShopProducts)
                .HasForeignKey(d => d.Store)
                .HasConstraintName("FK_ShopProduct_Store");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.ShopProducts)
                .HasForeignKey(d => d.Supplier)
                .HasConstraintName("FK_ShopProduct_ShopSupplier");
        });

        modelBuilder.Entity<ShopSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);

            entity.ToTable("ShopSupplier");

            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("supplierAddress");
            entity.Property(e => e.SupplierContact)
                .HasMaxLength(15)
                .HasColumnName("supplierContact");
            entity.Property(e => e.SupplierDetails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("supplierDetails");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("supplierName");
        });

        modelBuilder.Entity<ShopUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("ShopUser");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserRoll)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userRoll");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CartId });

            entity.ToTable("ShoppingCart");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CartId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cartId");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.StoreAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("storeAddress");
            entity.Property(e => e.StoreContactNumber)
                .HasMaxLength(15)
                .HasColumnName("storeContactNumber");
            entity.Property(e => e.StoreName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("storeName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
