using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
namespace WebApplication1.Controllers;

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

    public IActionResult Matrix(int matrixSize)
    {
        Random rnd = new Random();
        Matrix matrix = new Matrix(matrixSize, matrixSize);
        matrix.Rows = matrixSize;
        matrix.Columns = matrixSize;
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                matrix.Data.SetValue(rnd.Next(-3,10),i,j);
            }
        }
        int[] sum = new int[matrixSize];

        for (int i = 0; i < matrix.Rows; i++)
        {
            sum[i] = 0;
            bool negative = false;

            for (int j = 0; j < matrix.Columns; j++)
            {
                if((int)matrix.Data.GetValue(i,j) < 0)
                {
                    negative = true;
                    break;
                }
            }
            if (negative == false)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    sum[i] += (int)matrix.Data.GetValue(i,j);
                }
            }
            else
                sum[i] = -1;
        }
        int minSum = MinSumParallelDiagonals(matrix);

        var viewModel = new MatrixViewModel(matrix, sum, minSum);
        return View(viewModel);
        
    }
    public int MinSumParallelDiagonals(Matrix matrix)
    {
        int minSum = int.MaxValue;
        for (int i = 1; i < matrix.Rows; i++)
        {
            int sum = 0;

            int startRow = i;
            int startColumn = 0;
            
            while (startRow < matrix.Rows && startColumn < matrix.Columns)
            {
                sum += matrix.Data[startRow, startColumn];
                startRow++;
                startColumn++;
            }

            if (sum < minSum)
            {
                minSum = sum;
            }
        }

        return minSum;
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
