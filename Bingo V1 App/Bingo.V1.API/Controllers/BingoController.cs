using Bingo.V1.Business.Actions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.V1.API.Controllers
{
	public class BingoController : Controller
	{
		private readonly IMediator mediator;

		public BingoController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		public ActionResult Index()
		{
			var boardNumbers = mediator.Send(new GenerateBingoBoardCommand
			{
				boardSize = 25
			});

			return View(boardNumbers.Result);
		}
		
		[HttpPost]
		[Route("checkWin")]
        public async Task<ActionResult<int>> CheckWin([FromBody]string s)
        {
			var result = 3;

			return Ok(result);
           
        }
    }
}
