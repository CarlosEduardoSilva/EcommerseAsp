﻿using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {


        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ProdutoDAO.RetornarProdutos();
            return View();
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto()
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };

            ProdutoDAO.CadastrarProduto(produto);
            return RedirectToAction("Index", "Produto");

        }

        public ActionResult RemoverProduto(int? id)
        {

            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");

        }

        public ActionResult AlterarProduto(int? id)
        {
            ViewBag.Produto = ProdutoDAO.BuscarProdutoPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult AlterarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria, int txtId)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(txtId);


            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            ProdutoDAO.AlterarProduto(produto);           

            return RedirectToAction("Index", "Produto");

        }


    }
}