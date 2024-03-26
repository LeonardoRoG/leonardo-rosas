﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novit.Academia.Database;

#nullable disable

namespace Novit.Academia.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240320150445_PopulateRoles")]
    partial class PopulateRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Novit.Academia.Domain.Barrio", b =>
                {
                    b.Property<int>("IdBarrio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("IdBarrio");

                    b.ToTable("Barrio");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBarrio")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdBarrio");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstadoReserva")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SolicitarAprobacion")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("TEXT");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdProducto");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rol");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1b7d7225-d028-4a54-a528-154cd1202982"),
                            Name = "administrador"
                        },
                        new
                        {
                            Id = new Guid("fd824a8b-d90f-4afe-8c27-011740b081fd"),
                            Name = "comercial"
                        },
                        new
                        {
                            Id = new Guid("ac425c31-4b9c-4a77-b35b-291bce295bcf"),
                            Name = "vendedor"
                        });
                });

            modelBuilder.Entity("Novit.Academia.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuariosId")
                        .HasColumnType("TEXT");

                    b.HasKey("RolesId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("RolUsuario");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Producto", b =>
                {
                    b.HasOne("Novit.Academia.Domain.Barrio", "Barrio")
                        .WithMany("Productos")
                        .HasForeignKey("IdBarrio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barrio");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Reserva", b =>
                {
                    b.HasOne("Novit.Academia.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Novit.Academia.Domain.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Novit.Academia.Domain.Usuario", null)
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Cliente");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.HasOne("Novit.Academia.Domain.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Novit.Academia.Domain.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Novit.Academia.Domain.Barrio", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}