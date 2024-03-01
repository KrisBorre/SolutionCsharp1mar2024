using LibraryPhysicalUnits13feb2024;
using System.Text;

namespace ConsoleArraysBuilderDesignPattern18Feb2024
{
    internal class Problem
    {
        private StringBuilder stringBuilder;

        public Problem()
        {
            stringBuilder = new StringBuilder();
        }

        public Problem(StringBuilder s)
        {
            stringBuilder = s;
        }

        public Problem(TemperatureInCelsius[] array)
        {
            stringBuilder = new StringBuilder();
            foreach (var item in array)
            {
                stringBuilder.Append(item.ToString() + '\t');
            }
        }

        public Problem(TemperatureInCelsius[,] matrix)
        {
            stringBuilder = new StringBuilder();
            int aantalRijen = matrix.GetLength(0);
            int aantalKolommen = matrix.GetLength(1);
            for (int i = 0; i < aantalRijen; i++)
            {
                for (int j = 0; j < aantalKolommen; j++)
                {
                    stringBuilder.Append(matrix[i, j].ToString() + '\t');
                }
                stringBuilder.Append('\n');
            }
        }


        public Problem(WeightInKilogram14feb2024[] array)
        {
            stringBuilder = new StringBuilder();
            foreach (var item in array)
            {
                stringBuilder.Append(item.ToString() + '\t');
            }
        }

        public Problem(WeightInKilogram14feb2024[,] matrix)
        {
            stringBuilder = new StringBuilder();
            int aantalRijen = matrix.GetLength(0);
            int aantalKolommen = matrix.GetLength(1);
            for (int i = 0; i < aantalRijen; i++)
            {
                for (int j = 0; j < aantalKolommen; j++)
                {
                    stringBuilder.Append(matrix[i, j].ToString() + '\t');
                }
                stringBuilder.Append('\n');
            }
        }

        public void Show()
        {
            Console.WriteLine(stringBuilder.ToString());
        }

        public void Solve()
        {

        }
    }

}
