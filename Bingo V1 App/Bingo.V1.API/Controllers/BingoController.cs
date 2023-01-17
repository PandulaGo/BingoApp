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

		[HttpGet]
		[Route("generatebingoboard")]
		public ActionResult GenerateBingoBoard()
		{
			var boardNumbers = mediator.Send(new GenerateBingoBoardCommand
			{
				boardSize = 25
			});

			return View(boardNumbers.Result);
		}
	}
}
