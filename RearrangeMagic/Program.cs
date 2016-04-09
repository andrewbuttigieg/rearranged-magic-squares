using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rearrange_Magic
{
    public class Program
    {
        public static bool IsMagicSquare(List<int> square){
            int columns = Int32.Parse(Math.Sqrt(square.Count).ToString());
                
            int magicSum = 0;
            bool toReturn = true;
            
            int forwardDiagnal = 0; // => 0, 4, 8
            int backwardDiagnal = 0;// => 2, 4, 6
            
            for (int i = 0; i < columns; i++){
                int rowSum = 0;
                int columnSum = 0;
                for (int j = 0; j < columns; j++){
                    columnSum += square[(i * columns) + j];
                    rowSum += square[i + (j * columns)];
                }
                if (magicSum == 0)
                    magicSum = columnSum;
                if(columnSum != magicSum) 
                    toReturn = false;
                if (rowSum != magicSum)
                    toReturn = false;
                forwardDiagnal += square[i * columns + i];
                backwardDiagnal += square[(columns * (i + 1))- (i + 1)];
            }
            
            if (forwardDiagnal != magicSum)
                toReturn = false;
            if (backwardDiagnal != magicSum)
                toReturn = false;
                
            return toReturn;
        }
        
        public static List<int> FindMagicSquare(List<int> square){
            int c = int.Parse(Math.Sqrt(square.Count()).ToString());
            int x = 0;
            int y = 0;
            while (!IsMagicSquare(square))
            {
                //take out
                List<int> sub = square.Skip(x * c).Take(c).ToList();
                square.RemoveRange(x, c);
                
                //add somewhere else
            }
            return square;
        }
        
        public static void Main(string[] args)
        {
            string input = @"15 14  1  4
            12  6  9  7
            2 11  8 13
            5  3 16 10";
            
            List<List<int>> magicSquare = new List<List<int>>();
            List<int> magicSquareAsLine = new List<int>();
            
            int i;
            foreach (var x in input.Split(' '))
                if (int.TryParse(x, out i))
                    magicSquareAsLine.Add(i);
            
            Console.WriteLine(IsMagicSquare(magicSquareAsLine));
            Console.Read();
        }
    }
}
