#pragma checksum "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ba0ffd9e610561f05ef35ed08d5e1e5436562ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Tutorial), @"mvc.1.0.view", @"/Views/Home/Tutorial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\_ViewImports.cshtml"
using ChessWithCohorts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\_ViewImports.cshtml"
using ChessWithCohorts.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ba0ffd9e610561f05ef35ed08d5e1e5436562ea", @"/Views/Home/Tutorial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0de7ae498b85aeac9ae4cc1287bc719ce16c0832", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Tutorial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
  
    ViewData["Title"] = "Tutorial";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"d-flex flex-column align-items-center text-center\">\r\n");
#nullable restore
#line 6 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
     if(ViewBag.LoginMessage != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"alert alert-success mb-2\">");
#nullable restore
#line 8 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
                                       Write(ViewBag.LoginMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 9 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <h1 class=""display-4"">Learn to Move!</h1>
    <p class=""lead"">Please select a piece to practice.</p>
    <div id=""Selections"" class=""d-flex flex-wrap"">
        <div id=""PracticePawn"" style=""background-image: url(/images/05.png);width:100px; height: 100px;"" class=""practice""></div>
        <div id=""PracticeRook"" style=""background-image: url(/images/02.png);width:100px; height: 100px;"" class=""practice""></div>
    </div>
    <a id=""ResetBoard"" href=""#"" class=""btn btn-dark col-2"">Reset Board</a>
    <div id=""Board"" class=""d-flex flex-wrap mt-4""></div></div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var gameBoard = {};\r\n        var moveset = {};\r\n        function getBoard(){\r\n            $.get(\"");
#nullable restore
#line 25 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
              Write(Url.Action("CreateBoard"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",null, function (data) {
                constructBoard(data.board);
            });
        }
        function printResponse(){
            console.log(gameBoard);
        }
        function constructBoard(e){
            gameBoard = e;
            var board = gameBoard;
            for(i=0; i<board.boardSquares.length;i++)
            {
                let file = board.boardSquares[i].location.file;
                let rank = board.boardSquares[i].location.rank;
                let piece = (board.boardSquares[i].currentPiece) ? String(""/images/"" + board.boardSquares[i].currentPiece.color) : """";
                piece += (board.boardSquares[i].currentPiece) ? String(board.boardSquares[i].currentPiece.type + "".png"") : """";

                $(""#Board"").append(""<div id='F""+ file +""R""+ rank +""' class='square color"" + board.boardSquares[i].color + ""'></div>"");
                
                if (piece)
                    $(""#F""+ file +""R""+ rank).attr(""style"", ""background-image: url(""+piece+"")");
                WriteLiteral(@";"");
            }
        }
        function saveMoves(e){
            moveset = e;
            console.log(moveset);
        }
        function showMoves(id) {
            // get square id from param
            // loop through board squares to match
            // check if occupied
            // send ajax call with piece to server to return moveset
            var location = id.replace(/\D/g,'');

            gameBoard.boardSquares.forEach(s => {
                // console.log(s.location.file == location[0]);
                if(s.location.file == location[0] && s.location.rank == location[1]){
                    console.log(""match"");
                    if(s.isOccupied){
                        // console.log(""occupied"", s.currentPiece, location);
                        // $.get(""");
#nullable restore
#line 65 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
                             Write(Url.Action("GetMoves", new {piececolor ="+ s.currentPiece.color +", l = " + location + ", board ="+ gameBoard +"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",null, function (data) {
                        //     console.log(data.moves);
                        // });

                        moveset.forEach(m => {
                            let sid = ""#F"" + m.file + ""R"" + m.rank;
                            console.log(m.file, m.rank, sid);
                            $(sid).toggleClass(""movable"");
                        });
                    }
                }
            });
        }

        $(document).ready(function() {
            var x = false;
            var y = false;
            // generate board
            getBoard();

            $(document).on(""click"", "".square"", function(){
                if($(this).hasClass(""selected"")){
                    $(""#Board > div"").removeClass(""selected"");
                    $(""#Board > div"").removeClass(""movable"");
                }else{
                    showMoves($(this).attr(""id""));
                    $(""#Board > div"").removeClass(""selected"");
                    $(this).toggl");
                WriteLiteral(@"eClass(""selected"");
                }
                printResponse();
            });

            $(""#PracticePawn"").click(function() {
                if($(this).hasClass(""selected"")){
                    $(""#Selections > div"").removeClass(""selected"");
                }else{
                    $(""#Selections > div"").removeClass(""selected"");
                    $(this).toggleClass(""selected"");
                }
                if (!x){
                    $.get(""");
#nullable restore
#line 105 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
                      Write(Url.Action("PracticePawn", new {boardstate ="+ gameBoard +"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",null, function (data) {
                        $(""#Board"").html("""");
                        saveMoves(data.moves);
                        constructBoard(data.board);
                    });
                    x = true;
                } else{
                    $(""#Board"").html("""");
                    getBoard();
                    x = false;
                }
            });

            $(""#PracticeRook"").click(function() {
                if($(this).hasClass(""selected"")){
                    $(""#Selections > div"").removeClass(""selected"");
                }else{
                    $(""#Selections > div"").removeClass(""selected"");
                    $(this).toggleClass(""selected"");
                }

                if (!y){
                    $.get(""");
#nullable restore
#line 127 "D:\Users\Cepheid Variable\Documents\codingDojo\c_sharp\ChessWithCohorts\Views\Home\Tutorial.cshtml"
                      Write(Url.Action("PracticeRook", new {boardstate ="+ gameBoard +"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",null, function (data) {
                        $(""#Board"").html("""");
                        saveMoves(data.moves);
                        constructBoard(data.board);
                    });
                    y = true;
                } else{
                    $(""#Board"").html("""");
                    getBoard();
                    y = false;
                }
            });

            $(document).on( ""click"", ""#ResetBoard"", function() {
                $(""#Selections > div"").removeClass(""selected"");
                $(""#Board"").html("""");
                getBoard();
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
