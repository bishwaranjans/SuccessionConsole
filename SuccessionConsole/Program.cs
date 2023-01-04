// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Succession Console App");

var firstLine = Console.ReadLine();
var splitFirstLine = firstLine.Split();

var n = int.Parse(splitFirstLine[0]);
var m = int.Parse(splitFirstLine[1]);
var founder = Console.ReadLine();

var family = new Dictionary<string, string[]>();
for (var i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split();
    family[input[0]] = new[] { input[1], input[2] };
}

var possibleClaims = new List<string>();
for (var i = 0; i < m; i++)
{
    var name = Console.ReadLine();
    possibleClaims.Add(name);
}

var claimants = possibleClaims.ToArray();

// Calculate royal blood percentage for each claimant
var royalBlood = new Dictionary<string, double>();
foreach (var claimant in claimants)
{
    royalBlood[claimant] = CalculateRoyalBlood(founder, family, claimant);
}

// Find claimant with most royal blood
var mostRelated = royalBlood.First(x => x.Value == royalBlood.Values.Max());

// Print the name of the winner
Console.WriteLine($"Winner is {mostRelated.Key} with max royal blood percentage: {mostRelated.Value}");

Console.ReadLine();


static double CalculateRoyalBlood(string founder, IReadOnlyDictionary<string, string[]> family, string person)
{
    if (person == founder)
    {
        return 1;
    }

    if (!family.ContainsKey(person))
    {
        return 0;
    }

    return 0.5 * CalculateRoyalBlood(founder, family, family[person][0]) + 0.5 * CalculateRoyalBlood(founder, family, family[person][1]);
}

