namespace LangBasics;
public class Closures
{
    public IEnumerable<int> TransformNumbersWithoutStatic(IEnumerable<int> numbers)
    {
        var num = 1;
        var result = numbers.Select(x =>
        {
            var num1 = num;
            return x * 2;
        });
        return result;
    }

    public IEnumerable<int> TransformNumbersWithStatic(IEnumerable<int> numbers)
    {
        var result = numbers.Select(static x => x * 2);
        return result;
    }
}
