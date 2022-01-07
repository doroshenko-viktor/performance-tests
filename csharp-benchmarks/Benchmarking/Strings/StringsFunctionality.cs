using System.Text;

namespace Benchmarking.Strings
{
    public class StringsFunctionality
    {
        const string sourceString = "somestring";
        public string BuildString(int num)
        {
            var result = string.Empty;
            for (int i = 0; i < num; i++)
            {
                result = result + sourceString + "; ";
            }
            return result;
        }
        public string BuildStringBuilder(int num)
        {
            var result = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                result.Append(sourceString).Append("; ");
            }
            return result.ToString();
        }
    }
}