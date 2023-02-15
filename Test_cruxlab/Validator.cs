using System.IO;

namespace Test_cruxlab
{
    public static class Validator
    {
        public static async Task<int> ValidateAsync(string path)
        {
            var requirements = await GetRequirementsAsync(path);
            var validPasswords = 0;

            foreach (var line in requirements)
            {
                var claim = line.Split(' ');

                var symbol = claim.FirstOrDefault();
                var minCount = claim[1].Split(new char[] {'-', ':'}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                var maxCount = claim[1].Split(new char[] { '-', ':' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                var password = claim.LastOrDefault();

                var containsCount = password.Where(s => s.ToString() == symbol).Count();

                if(containsCount >= int.Parse(minCount) && containsCount <= int.Parse(maxCount)) 
                    validPasswords++;
            }

            return validPasswords;
        }

        private static async Task<string[]> GetRequirementsAsync(string path)
        {
            var text = await File.ReadAllTextAsync(path);
            var requirements = text.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            return requirements;
        }
    }
}
