using System.Collections.Generic;

namespace LangUtils
{
    public class USUKEnglish
    {
        public static string ConvertAmericanToBritish(string input)
        {
            return ConvertString(input, true);
        }

        public static string ConvertBritishToAmerican(string input)
        {
            return ConvertString(input, false);
        }

        private static string ConvertString(string input, bool fromAmerican)
        {
            string[] words = input.Split(' ');
            string result = "";

            foreach (var w in words)
            {
                if (result.Length > 0)
                    result += " ";
                result += ConvertWord(w, fromAmerican);
            }
            return result;
        }

        private static string ConvertWord(string word, bool fromAmerican)
        {
            string prePunc = "", postPunc = "";
            for (var i = 0; i < word.Length; i++)
            {
                if (!char.IsLetter(word[i]))
                    prePunc += word[i];
                else
                    break;
            }
            for (var i = word.Length - 1; i >= 0; i--)
            {
                if (!char.IsLetter(word[i]))
                    postPunc = word[i] + postPunc;
                else
                    break;
            }
            if (prePunc.Length == word.Length)
                return word;
            string w = word.Substring(prePunc.Length, word.Length - (postPunc.Length + prePunc.Length));
            if (w.Length == 0)
                return word;
            bool[] uppercase = new bool[w.Length];
            for (var i = 0; i < w.Length; i++)
            {
                uppercase[i] = (char.IsUpper(w[i]));
            }
            w = w.ToLowerInvariant();
            w = TransWord(w, fromAmerican);
            string final = "";
            for (var i = 0; i < w.Length; i++)
            {
                if (i < uppercase.Length && uppercase[i] || i >= uppercase.Length && uppercase[uppercase.Length - 1])
                    final += char.ToUpperInvariant(w[i]);
                else
                    final += w[i];
            }
            return prePunc + final + postPunc;
        }

        private static Dictionary<string, string> ustouk = new Dictionary<string, string>()
            {
            // very much not exhaustive - please add to these as you find

                { "color", "colour" },
                { "armor", "armour" },
                { "behavior", "behaviour" },
                { "endeavor", "endeavour" },
                { "favor", "favour" },
                { "harbor", "habour" },
                { "honor", "honour" },
                { "humor", "humour" },
                { "labor", "labour" },
                { "neighbor", "neighbour" },
                { "odor", "odour" },
                { "parlor", "parlour" },
                { "rancor", "rancour" },
                { "rumor", "rumour" },
                { "savior", "saviour" },
                { "savor", "savour" },
                { "splendor", "splendour" },
                { "tumor", "tumour" },
                { "valor", "valour" },
                { "rigor", "rigour" },
                { "flavor", "flavour" },
                { "apologize", "apologise" },
                { "fantasize", "fantasise" },
                { "idolize", "idolise" },
                { "theorize", "theorise" },
                { "standardize", "standardise" },
                { "analyze", "analyse" },
                { "paralyze", "paralyse" },
                { "traveled", "travelled" },
                { "labeling", "labelling" },
                { "pediatrics", "peaediatrics" },
                { "leukemia", "leukaemia" },
                { "defense", "defence" },
                { "catalog", "catalogue" },
                { "dialog", "dialogue" },
                { "caliber", "calibre" },
                { "center", "centre" },
                { "fiber", "fibre" },
                { "liter", "litre" },
                { "scepter", "sceptre" },
                { "meager", "meagre" },
                { "saber", "sabre" },
                { "somber", "sombre" },
                { "theater", "theatre" },
                { "meter", "metre" },
                { "luster", "lustre" },
                { "grey", "gray" },
                { "mold", "mould" },
                { "enroll", "enrol" },
                { "fulfill", "fulfil" },
                { "installment", "instalment" },
                { "instill", "instil" },
                { "skillful", "skilful" },
                { "program", "programme" },
                { "maneuver", "manoeuvre" },
                { "airplane", "aeroplane" },
                { "artefact", "artifact" },
                { "cozy", "cosy" },
                { "donut", "doughnut" },
                { "gray", "grey" },
                { "jewelry", "jewellery" },
                { "plow", "plough" },
                { "skeptical", "sceptical" },
                { "sulfur", "sulphur" },
            };

        private static Dictionary<string, string> uktous = ustouk.ToDictionary(x => x.Value, x => x.Key);

        private static string TransWord(string w, bool fromAmerican)
        {
            if (fromAmerican && ustouk.ContainsKey(w))
                return ustouk[w];
            if (!fromAmerican && uktous.ContainsKey(w))
                return uktous[w];
            return w;
        }
    }
}
