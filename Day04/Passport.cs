using System;
using System.Linq;

namespace Day04
{
    class Passport
    {
        public int? BirthYear;
        public int? IssueYear;
        public int? ExpirationYear;
        public string Height;
        public string HairColor;
        public string EyeColor;
        public string PassportID;
        public string CountryID;

        public bool IsValid(bool simple = true)
        {
            var valid = 
                BirthYear != null &&
                IssueYear != null &&
                ExpirationYear != null &&
                Height != null &&
                HairColor != null &&
                EyeColor != null &&
                PassportID != null;

            if (valid && !simple)
            {
                valid &= BirthYear >= 1920 && BirthYear <= 2002;
                valid &= IssueYear >= 2010 && IssueYear <= 2020;
                valid &= ExpirationYear >= 2020 && ExpirationYear <= 2030;

                var unit = Height[^2..];
                valid &= Int32.TryParse(Height[0..^2], out int h);
                if (unit == "cm") valid &= h >= 150 && h <= 193;
                else if (unit == "in") valid &= h >= 59 && h <= 76;
                else valid = false;

                valid &= HairColor[0] == '#' && long.TryParse(HairColor[1..], System.Globalization.NumberStyles.HexNumber, null, out long hcl);

                valid &= (new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }).Contains(EyeColor);

                valid &= PassportID.Length == 9 && long.TryParse(PassportID, out long pid);
            }

            return valid;
        }
    }
}