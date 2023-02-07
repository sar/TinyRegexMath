using global::System.Text.RegularExpressions;
string expression = args[0].Replace(" ", String.Empty).Trim() ?? "2+3*4/2";
List<int> nums = new();
List<(int pos, string token)> tokens = new();
int result = 0;
foreach (Match match in Regex.Matches(expression, @"(\d+)"))
{
    if (match.Groups[0].Success)
        nums.Add(int.Parse(match.Groups[0].Value));
}
foreach (Match match in Regex.Matches(expression, @"(\+|\-|\*|\^|\/)"))
{
    if (match.Groups[0].Success)
        for (int i = 0; i < match.Groups[0].Value.Length; i++)
        {
            string token = match.Groups[0].Value[i].ToString();
            tokens.Add((expression.IndexOf(token), token));
            Console.WriteLine($"[char]::{tokens.Last().token}::{tokens.Last().pos}");
        }
}
for (int j = 0; j < tokens.Count(); j++)
{
    (int pos, string token) = tokens[j];
    Console.WriteLine($"[expr]::{(j == 0 ? nums[j] : result)} {token} {nums[j + 1]}");
    Dictionary<string, Func<int, int, int>> operations = new()
        { { "+", (a, b) => a + b }, { "-", (a, b) => a - b }, { "*", (a, b) => a * b }, { "^", (a, b) => (int)Math.Pow(a, b) }, { "/", (a, b) => a / b }, };
    result = operations[token]((j == 0 ? nums[j] : result), nums[j + 1]);
}
Console.WriteLine($"[calc]::{result}");
