using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.V1.Business.Actions
{
	public class GenerateBingoBoardCommand : IRequest<List<int>>
	{
		public int boardSize { get; set; }
	}


	public class GenerateBingoBoardCommandHandler : IRequestHandler<GenerateBingoBoardCommand, List<int>>
	{
		public async Task<List<int>> Handle(GenerateBingoBoardCommand request, CancellationToken cancellationToken)
		{
			var random = new Random();
			var result = new List<int>();

			result = (Enumerable.Range(1, 1 * request.boardSize).OrderBy(x => random.Next()).ToList());

			return result;
		}
	}
}
