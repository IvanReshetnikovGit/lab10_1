using System;

namespace WebApplication1.Models
{
    public class Matrix
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[,] Data { get; set; }

        public Matrix()
        {
            Rows = 0;
            Columns = 0;
            Data = new int[0, 0];
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Data = new int[rows, columns];
        }

        public int GetValue(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new IndexOutOfRangeException("Index out of range");

            return Data[row, column];
        }

        public void SetValue(int row, int column, int value)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new IndexOutOfRangeException("Index out of range");

            Data[row, column] = value;
        }
    }
}
