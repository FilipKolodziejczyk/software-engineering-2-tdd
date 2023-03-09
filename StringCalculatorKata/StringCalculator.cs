using System.Text.RegularExpressions;

namespace StringCalculatorKata;

public static class StringCalculator {
    public static int Add(string numbers) {
        if (numbers == "")
            return 0;

        var delimiterPattern = ",|\n";
        if (numbers.StartsWith("//")) {
            numbers = numbers.Substring(2);
            if (numbers[0] != '[') {
                delimiterPattern += "|" + numbers[0];
                numbers = numbers.Substring(1);
            }
            else {
                while (numbers.StartsWith("[")) {
                    var offset = numbers.IndexOf(']') + 1;
                    delimiterPattern += "|" + numbers[1..(offset-1)];
                    numbers = numbers.Substring(offset);
                }
            }
        }

        Console.WriteLine(delimiterPattern);
        Console.WriteLine(numbers);
        var regex = new Regex(delimiterPattern);

        var sum = 0;
        foreach (var number in regex.Split(numbers)) {
            var parsedNumber = int.Parse(number);
            if (parsedNumber < 0)
                throw new ArgumentException("Negative numbers are not allowed");
            if (parsedNumber > 1000)
                continue;
            sum += parsedNumber;
        }

        return sum;
    }
}