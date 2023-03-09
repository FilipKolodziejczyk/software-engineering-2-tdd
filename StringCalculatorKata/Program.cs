namespace StringCalculatorKata;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter a string of numbers to add or 'q' to quit");
            var input = Console.ReadLine();
            if (input is null)
                continue;
            if (input == "q")
                break;
            Console.WriteLine(StringCalculator.Add(input));
        }
    }
}