using Test_cruxlab;

string path = "..\\requirements.txt";
string[] requirements = new string[] { "a 1-5: abcdj", "z 2-4: asfalseiruqwo", "b 3-6: bhhkkbbjjjb" };

await File.WriteAllLinesAsync(path, requirements);

var validPasswords = await Validator.ValidateAsync(path);

Console.WriteLine($"Number of valid passwords from file: {path} = {validPasswords}");
