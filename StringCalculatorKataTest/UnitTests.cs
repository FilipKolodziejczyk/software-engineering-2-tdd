using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorKataTest;

public class UnitTests
{
    [Test]
    public void Tests()
    {
        Assert.Multiple(() =>
        {
            // Step 1
            Assert.That(StringCalculator.Add(""), Is.EqualTo(0));

            // Step 2
            Assert.That(StringCalculator.Add("1"), Is.EqualTo(1));
            Assert.That(StringCalculator.Add("5"), Is.EqualTo(5));

            // Step 3
            Assert.That(StringCalculator.Add("1,2"), Is.EqualTo(3));
            Assert.That(StringCalculator.Add("5,6"), Is.EqualTo(11));

            // Step 4
            Assert.That(StringCalculator.Add("1\n3"), Is.EqualTo(4));
            Assert.That(StringCalculator.Add("5\n6"), Is.EqualTo(11));

            // Step 5
            Assert.That(StringCalculator.Add("1\n2,3"), Is.EqualTo(6));
            Assert.That(StringCalculator.Add("2,3\n5"), Is.EqualTo(10));

            // Step 6
            Assert.That(() => StringCalculator.Add("1,-2"), Throws.ArgumentException);
            Assert.That(() => StringCalculator.Add("-5,6"), Throws.ArgumentException);
            
            // Step 7
            Assert.That(StringCalculator.Add("1,1001"), Is.EqualTo(1));
            Assert.That(StringCalculator.Add("1000,6"), Is.EqualTo(1006));
            
            // Step 8
            Assert.That(StringCalculator.Add("//;1;2"), Is.EqualTo(3));
            Assert.That(StringCalculator.Add("//#5#6"), Is.EqualTo(11));
            
            // Step 9
            Assert.That(StringCalculator.Add("//[ab]1ab2ab3"), Is.EqualTo(6));
            Assert.That(StringCalculator.Add("//[###]1###2,3\n4"), Is.EqualTo(10));
            
            // Step 10
            Assert.That(StringCalculator.Add("//[ab][cd]1ab2cd3"), Is.EqualTo(6));
            Assert.That(StringCalculator.Add("//[###][@@@]1###2@@@3\n4,5"), Is.EqualTo(15));
        });
    }
}