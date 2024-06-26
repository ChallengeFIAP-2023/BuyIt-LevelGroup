﻿// <auto-generated />
using System;
using Buyit.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Buyit.Migrations
{
    [DbContext(typeof(BuyitContext))]
    [Migration("20240329191916_FirstDataBase")]
    partial class FirstDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Buyit.Models.AvaliacaoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_AVALIACAO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("DATA_AVALIACAO");

                    b.Property<string>("Descricao")
                        .HasMaxLength(400)
                        .HasColumnType("NVARCHAR2(400)")
                        .HasColumnName("DESCRICAO_AVALIACAO");

                    b.Property<long>("ID_COTACAO")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("NotaEntrega")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("NOTA_ENTREGA_AVALIACAO");

                    b.Property<long>("NotaPreco")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("NOTA_PRECO_AVALIACAO");

                    b.Property<long>("NotaQualidade")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("NOTA_QUALIDADE_AVALIACAO");

                    b.HasKey("Id");

                    b.HasIndex("ID_COTACAO");

                    b.ToTable("AVALIACAO");
                });

            modelBuilder.Entity("Buyit.Models.ContatoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_CONTATO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ID_USUARIO")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TIPO_CONTATO");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("VALOR_CONTATO");

                    b.HasKey("Id");

                    b.HasIndex("ID_USUARIO");

                    b.ToTable("CONTATO");
                });

            modelBuilder.Entity("Buyit.Models.CotacaoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_COTACAO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("date")
                        .HasColumnName("DATA_ABERTURA_COTACAO");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_FECHAMENTO_COTACAO");

                    b.Property<long>("ID_PRODUTO")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("ID_STATUS")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("ID_USUARIO")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("Prazo")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PRAZO_COTACAO");

                    b.Property<long>("PrioridadeEntrega")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PRIORIDADE_ENTREGA");

                    b.Property<long>("PrioridadePreco")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PRIORIDADE_PRECO");

                    b.Property<long>("PrioridadeQualidade")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("PRIORIDADE_QUALIDADE");

                    b.Property<decimal>("QuantidadeProduto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("QUANTIDADE_PRODUTO");

                    b.Property<decimal>("ValorProduto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALOR_PRODUTO");

                    b.HasKey("Id");

                    b.HasIndex("ID_PRODUTO");

                    b.HasIndex("ID_STATUS");

                    b.HasIndex("ID_USUARIO");

                    b.ToTable("COTACAO");
                });

            modelBuilder.Entity("Buyit.Models.DepartamentoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_DEPARTAMENTO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Icone")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ICONE_DEPARTAMENTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME_DEPARTAMENTO");

                    b.HasKey("Id");

                    b.ToTable("DEPARTAMENTO");
                });

            modelBuilder.Entity("Buyit.Models.HistoricoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_HISTORICO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("DATA_HISTORICO");

                    b.Property<string>("Descricao")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DESCRICAO_HISTORICO");

                    b.Property<long>("ID_COTACAO")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("ID_FORNECEDOR")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("ID_STATUS")
                        .HasColumnType("NUMBER(19)");

                    b.Property<bool>("RecusadoPorPrazo")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("RECUSADO_POR_PRAZO");

                    b.Property<bool>("RecusadoPorPreco")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("RECUSADO_POR_PRECO");

                    b.Property<bool>("RecusadoPorProduto")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("RECUSADO_POR_PRODUTO");

                    b.Property<bool>("RecusadoPorQuantidade")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("RECUSADO_POR_QUANTIDADE");

                    b.Property<decimal?>("ValorOfertado")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALOR_OFERTADO_HISTORICO");

                    b.HasKey("Id");

                    b.HasIndex("ID_COTACAO");

                    b.HasIndex("ID_FORNECEDOR");

                    b.HasIndex("ID_STATUS");

                    b.ToTable("HISTORICO");
                });

            modelBuilder.Entity("Buyit.Models.ProdutoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_PRODUTO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cor")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("COR_PRODUTO");

                    b.Property<long>("ID_DEPARTAMENTO")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("Marca")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MARCA_PRODUTO");

                    b.Property<string>("Material")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MATERIAL_PRODUTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME_PRODUTO");

                    b.Property<string>("Observacao")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)")
                        .HasColumnName("OBSERVACAO_PRODUTO");

                    b.Property<string>("Tamanho")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TAMANHO_PRODUTO");

                    b.HasKey("Id");

                    b.HasIndex("ID_DEPARTAMENTO");

                    b.ToTable("PRODUTO");
                });

            modelBuilder.Entity("Buyit.Models.StatusModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_STATUS");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME_STATUS");

                    b.HasKey("Id");

                    b.ToTable("STATUS");
                });

            modelBuilder.Entity("Buyit.Models.TagModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_TAG");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME_TAG");

                    b.HasKey("Id");

                    b.ToTable("TAG");
                });

            modelBuilder.Entity("Buyit.Models.UsuarioModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID_USUARIO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CNPJ_USUARIO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAIL_USUARIO");

                    b.Property<bool>("IsFornecedor")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_FORNECEDOR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME_USUARIO");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("SENHA_USUARIO");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("IMAGEM_USUARIO");

                    b.HasKey("Id");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("DepartamentoModelTagModel", b =>
                {
                    b.Property<long>("DepartamentosId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("TagsId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("DepartamentosId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("DepartamentoModelTagModel");
                });

            modelBuilder.Entity("ProdutoModelTagModel", b =>
                {
                    b.Property<long>("ProdutosId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("TagsId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("ProdutosId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ProdutoModelTagModel");
                });

            modelBuilder.Entity("TagModelUsuarioModel", b =>
                {
                    b.Property<long>("TagsId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("UsuariosId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("TagsId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("TagModelUsuarioModel");
                });

            modelBuilder.Entity("Buyit.Models.AvaliacaoModel", b =>
                {
                    b.HasOne("Buyit.Models.CotacaoModel", "Cotacao")
                        .WithMany()
                        .HasForeignKey("ID_COTACAO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotacao");
                });

            modelBuilder.Entity("Buyit.Models.ContatoModel", b =>
                {
                    b.HasOne("Buyit.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID_USUARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Buyit.Models.CotacaoModel", b =>
                {
                    b.HasOne("Buyit.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ID_PRODUTO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("ID_STATUS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.UsuarioModel", "Comprador")
                        .WithMany()
                        .HasForeignKey("ID_USUARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprador");

                    b.Navigation("Produto");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Buyit.Models.HistoricoModel", b =>
                {
                    b.HasOne("Buyit.Models.CotacaoModel", "Cotacao")
                        .WithMany()
                        .HasForeignKey("ID_COTACAO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.UsuarioModel", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("ID_FORNECEDOR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("ID_STATUS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotacao");

                    b.Navigation("Fornecedor");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Buyit.Models.ProdutoModel", b =>
                {
                    b.HasOne("Buyit.Models.DepartamentoModel", "Departamento")
                        .WithMany()
                        .HasForeignKey("ID_DEPARTAMENTO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("DepartamentoModelTagModel", b =>
                {
                    b.HasOne("Buyit.Models.DepartamentoModel", null)
                        .WithMany()
                        .HasForeignKey("DepartamentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.TagModel", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProdutoModelTagModel", b =>
                {
                    b.HasOne("Buyit.Models.ProdutoModel", null)
                        .WithMany()
                        .HasForeignKey("ProdutosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.TagModel", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TagModelUsuarioModel", b =>
                {
                    b.HasOne("Buyit.Models.TagModel", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buyit.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
