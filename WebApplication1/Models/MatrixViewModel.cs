namespace WebApplication1.Models
{
    public class MatrixViewModel
    {
        public Matrix Matrix { get; set; }
        public int[] Sum { get; set; }
        public int MinDiag{get;set;}
        public MatrixViewModel(Matrix matrix, int[] sum,int minDiag)
        {
            Matrix = matrix;
            Sum = sum;
            MinDiag = minDiag;
        }
    }
}
