using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChessWithCohorts.Models;
using Microsoft.AspNetCore.Http;        //Session
using Microsoft.EntityFrameworkCore;    //Enable entity
using Microsoft.AspNetCore.Identity;    //use password hasher
using ChessWithCohorts.Contexts;


namespace ChessWithCohorts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MyContext dbContext;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public User UserInDb()
        {
            return dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            User userInDb = UserInDb();
            if(userInDb != null)
            {
                ViewBag.LoginMessage = TempData["LoginMessage"];
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.LoginRequired = true;
                return View();
            }
        }


        [HttpGet("loginpage")]
        public IActionResult LoginPage()
        {
            User userInDb = UserInDb();
            if(userInDb != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginRequired = true;
                return View();
            }
        }


        [HttpPost("register")]
        public IActionResult Register(User reg)
        {
            User userInDb = UserInDb();
            if(userInDb != null)
                return RedirectToAction("Index");

            // Check validations
            if(ModelState.IsValid)
            {
                // Check for duplicate email
                if(dbContext.Users.Any(u => u.Email == reg.Email))
                {
                    ModelState.AddModelError("Email", "That email address is already in use.");

                    return View("LoginPage");
                }

                // Initialize Hasher and hash password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                reg.Password = Hasher.HashPassword(reg, reg.Password);                

                // Save reg model to db
                dbContext.Users.Add(reg);
                dbContext.SaveChanges();

                // save new user into session
                HttpContext.Session.SetInt32("UserId", reg.UserId);

                //send login message
                TempData["LoginMessage"] = $"Successfully Registered! Welcome {reg.FirstName} {reg.LastName.Substring(0,1)}.";
                ViewBag.LoginMessage = TempData["LoginMessage"];
                return RedirectToAction("Dashboard");
            }
            else
            {

                return View("LoginPage");
            }
        }


        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            User userInDb = UserInDb();
            if(userInDb != null)
                return RedirectToAction("Index");

            // Check form validations
            if(ModelState.IsValid)
            {
                userInDb = dbContext.Users.FirstOrDefault(u => u.Email == user.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid credentials. Please try again.");
                    ModelState.AddModelError("LoginPassword", "Invalid credentials. Please try again.");
                    return View("LoginPage");
                }

                // Initialize Hasher and verify password
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LoginPassword);

                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid credentials. Please try again.");
                    ModelState.AddModelError("LoginPassword", "Invalid credentials. Please try again.");

                    return View("LoginPage");
                }

                // log user into session
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                TempData["LoginMessage"] = $"Welcome {userInDb.FirstName} {userInDb.LastName.Substring(0,1)}.";
                ViewBag.LoginMessage = TempData["LoginMessage"];
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("LoginPage");
            }
        } 


        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            ViewBag.LoginMessage = "Logged out successfully.";
            return RedirectToAction("Index");
        }


        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }

            // put code here

            ViewBag.Update = TempData["Update"];
            ViewBag.LoginMessage = TempData["LoginMessage"];
            ViewBag.User = userInDb;
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


        [HttpGet("tutorial")]
        public IActionResult Tutorial()
        {
            return View();
        }


        public IActionResult TestJson()
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
