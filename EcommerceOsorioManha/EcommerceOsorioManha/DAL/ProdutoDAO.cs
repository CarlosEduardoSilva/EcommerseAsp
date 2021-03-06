﻿using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class ProdutoDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        public static List<Produto> RetornarProdutos()
        {
            return contexto.Produtos.
                Include("Categoria").
                ToList();
        }

        public static bool CadastrarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {

                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public static void RemoverProduto(int? id)
        {
            try
            {
                contexto.Produtos.Remove(BuscarProdutoPorId(id));
                contexto.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public static Produto BuscarProdutoPorId(int? id)
        {
            return contexto.Produtos.Find(id);

        }

        public static void AlterarProduto(Produto produto)
        {

            try
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();

            }
            catch (Exception)
            {
            }
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return contexto.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        public static List<Produto> RetornarProdutosPorCategoria(string cat)
        {
            return contexto.Produtos.Where(x => x.Categoria.Nome.ToString().Contains(cat)).ToList();
        }

        public static List<Produto> RetornarProdutosHome(int? CategoriaID)
        {
            return CategoriaID.HasValue ? 
                contexto.Produtos.Where(p => p.Categoria.CategoriaID == CategoriaID).ToList() 
                : contexto.Produtos.ToList();
        }

        public static List<Produto> BuscarProdutosPorCategoria(int? id)
        {
            return contexto.Produtos.
                Include("Categoria").Where(x => x.Categoria.CategoriaID== id).
                ToList();
        }
    }
}