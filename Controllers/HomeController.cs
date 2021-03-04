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
            ChessBoard NewBoard = new ChessBoard();
            Pawn NewPawn = new Pawn(PieceColor.WHITE);
            Pawn BlackPawn = new Pawn(PieceColor.BLACK);
            Rook WRook = new Rook(PieceColor.WHITE);
            WRook.CurrentSquare = NewBoard.BoardSquares[4,4];
            NewBoard.BoardSquares[5,4].CurrentPiece = NewPawn;
            NewBoard.BoardSquares[5,4].IsOccupied = true;


            NewBoard.BoardSquares[4,3].CurrentPiece = BlackPawn;
            NewBoard.BoardSquares[4,3].IsOccupied = true;
            List<Location> RookMoves = WRook.GetValidMoves(NewBoard);

            var result = new{
                whitePawn = NewPawn,
                blackPawn = BlackPawn,
                whiterook = WRook,
                rookmoves = RookMoves,
            };
            return Json(result);
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
