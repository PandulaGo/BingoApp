using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.V1.Business.Actions
{
	public class BingoWinCheckCommand : IRequest<BingoWinCheckCommadResult>
	{
		public int boardSize = 4;
		public string buttonId { get; set; }
	}

	public class BingoWinCheckCommadResult
	{
		public int winCount { get; set; }
	}

	public class BingoWinCheckCommandHandler : IRequestHandler<BingoWinCheckCommand, BingoWinCheckCommadResult>
	{
		List<int> selectedIndexes;
		int winCount = 0;
		bool isVerticalCheck = true;
		bool isLeftDiaganoalCheck = true;
		bool isRightDiaganoalCheck = true;
		bool winCheck = false;

		public async Task<BingoWinCheckCommadResult> Handle(BingoWinCheckCommand request, CancellationToken cancellationToken)
		{
			ReqeustDataSet datas = new ReqeustDataSet();
			var random = new Random();		

			selectedIndexes.Add(Convert.ToInt32(request.buttonId));
			HorizontalWinCheck(request.boardSize, selectedIndexes);
			VerticalWinCheck(request.boardSize, Convert.ToInt32(request.buttonId));
			LeftDiagonalWinCheck(request.boardSize);
			RightDiagonalWinCheck(request.boardSize);

			if (isVerticalCheck)
				winCount++;

			if (isLeftDiaganoalCheck)
				winCount++;

			if (isRightDiaganoalCheck)
				winCount++;

			var result = new BingoWinCheckCommadResult();
			return result;
		}
		public void HorizontalWinCheck(int boardSize, List<int> DataSets)
		{
			int count = 0;

			for (int i = 0; i < boardSize; i++)
			{
				int checkData = 0;

				for (int j = 0; j < boardSize; j++)
				{
					for (int k = 0; k < DataSets.Count; k++)
					{
						if (DataSets[k] == count)
						{
							checkData++;
						}

						if (checkData == boardSize)
						{
							checkData = 0;
							winCount++;
						}
					}
					count = count + boardSize;
				}
			}
		}

		public void VerticalWinCheck(int boardSize, int index)
		{
			int startIndex = index;

			while (true)
			{
				int nextIndex = startIndex - boardSize;

				if (nextIndex < 0)
					break;

				startIndex = nextIndex;
			}

			for (int i = 0; i < boardSize; i++)
			{
				if (!selectedIndexes.Contains(startIndex))
				{
					isVerticalCheck = false;
					break;
				}
				startIndex += boardSize;
			}
		}

		public void LeftDiagonalWinCheck(int boardSize)
		{
			for (int i = 0; i < boardSize; i += 6)
			{
				if (!selectedIndexes.Contains(i))
				{
					isLeftDiaganoalCheck = false;
					break;
				}

			}
		}

		public void RightDiagonalWinCheck(int boardSize)
		{
			for (int i = 4; i < boardSize; i += 4)
			{
				if (!selectedIndexes.Contains(i))
				{
					isRightDiaganoalCheck = false;
					break;
				}
			}
		}
	}

	public class ReqeustDataSet
	{
		public string playerName { get; set; }
		//{"datas":[{"data":"0,1"},{"data":"0,1"},{ "data":"0,1"},{ "data":"0,1"}]}
		public List <int> Data;
	}

	public class BingoWinCheckStructure
	{
		public DataSetStructure HorizontalData { get; set; }
		public DataSetStructure VerticalData { get; set; }
		public DataSetStructure Diagonal { get; set; }
	}

	/*public class DataSetStructure
	{
		public List<DataSet> dataSets { get; set; }

		public DataSetStructure()
		{
			dataSets = new List<DataSet>();
		}
	}

	public class DataSet
	{
		public int[]? numberArray; 
	}*/

	public class DataSetStructure
	{
		public int[,] HorizontalData { get; set; }
	}

	public class BingoWinFunctions
	{
		/*public void HorizontalWinCheck(int number)
		{

		}

		public void VerticalWinCheck(int number)
		{
		}

		public void DiagonalWinCheck(int number)
		{
		}*/
	}

}
