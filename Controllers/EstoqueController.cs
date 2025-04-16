﻿using ClosedXML.Excel;
using LojaProdutos.Filtros;
using LojaProdutos.Services.Estoque;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LojaProdutos.Controllers
{
    [UsuarioLogado]
    [UsuarioLogadoAdm]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueInterface _estoqueInterface;

        public EstoqueController(IEstoqueInterface estoqueInterface)
        {
            _estoqueInterface = estoqueInterface;
        }

        public IActionResult Index()
        {
            var registro = _estoqueInterface.ListagemRegistro();
            return View(registro);
        }
        [HttpPost]
        public async Task<IActionResult> BaixarEstoque(int id)
        {
            var produtoBaixado = await _estoqueInterface.CriarRegistro(id);
            TempData["MensagemSucesso"] = "Compra Realizada com Sucesso";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GerarRelatorio()
        {
            var dados = BuscarDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Vendas");

                using(MemoryStream ms  = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vmd.openxmlformats-officedocument.spredsheetml.sheet", "Vendas.xls");
                }
            }
        }
        private DataTable BuscarDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados Vendas - Produtos";
            dataTable.Columns.Add("ProdutoID", typeof(int));
            dataTable.Columns.Add("Categoria", typeof(string));
            dataTable.Columns.Add("Data da Compra", typeof(DateTime));
            dataTable.Columns.Add("Valor Total", typeof(double));

            var dados = _estoqueInterface.ListagemRegistro();

            if(dados.Count > 0)
            {
                foreach (var registro in dados)
                {
                    dataTable.Rows.Add(registro.ProdutoId,registro.CategoriaNome,registro.DataCompra,registro.Total);
                }
            }
            return dataTable;
        }
    }
}
