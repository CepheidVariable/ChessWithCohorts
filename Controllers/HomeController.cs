using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChessWithCohorts.Models;

namespace ChessWithCohorts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }


        [HttpGet("create/board")]
        public IActionResult CreateBoard()
        {
            ChessBoard NewBoard = new ChessBoard();
            var result = new {
                board = NewBoard
            };
            // Console.WriteLine($"{NewBoard.BoardSquares[0,3].Location.File}, {NewBoard.BoardSquares[0,3].Location.Rank}\n{NewBoard.BoardSquares[1,3].Location.File}, {NewBoard.BoardSquares[1,3].Location.Rank}");
            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
