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
                { "apologized", "apologised" },
                { "fantasize", "fantasise" },
                { "fantasized", "fantasised" },
                { "idolize", "idolise" },
                { "idolized", "idolised" },
                { "theorize", "theorise" },
                { "theorized", "theorised" },
                { "standardize", "standardise" },
                { "standardized", "standardised" },
                { "standardization", "standardisation" },
                { "organize", "organise" },
                { "organized", "organised" },
                { "organization", "organisation" },
                { "customize", "customise" },
                { "customized", "customised" },
                { "prioritize", "prioritise" },
                { "prioritized", "prioritised" },
                { "personalize", "personalise" },
                { "personalized", "personalised" },
                { "analyze", "analyse" },
                { "analyzed", "analysed" },
                { "paralyze", "paralyse" },
                { "paralyzed", "paralysed" },
                { "sanitize", "sanitise" },
                { "sanitized", "sanitised" },
                { "minimize", "minimise" },
                { "minimized", "minimised" },
                { "maximize", "maximise" },
                { "maximized", "maximised" },
                { "realize", "realise" },
                { "realized", "realised" },
                { "sympathize", "sympathise" },
                { "sympathized", "sympathised" },
                { "authorize", "authorise" },
                { "authorization", "authorisation" },
                { "authorized", "authorised" },
                { "optimize", "optimise" },
                { "optimization", "optimisation" },
                { "optimized", "optimised" },
                { "specialize", "specialise" },
                { "specialization", "specialisation" },
                { "specialized", "specialised" },
                { "criticize", "criticise" },
                { "criticized", "criticised" },
                { "recognize", "recognise" },
                { "recognized", "recognised" },
                { "characterize", "charactise" },
                { "characterization", "characterisation" },
                { "characterized", "characterised" },
                { "traveled", "travelled" },
                { "labeling", "labelling" },
                { "pediatrics", "peaediatrics" },
                { "leukemia", "leukaemia" },
                { "defense", "defence" },
                { "catalog", "catalogue" },
                { "dialog", "dialogue" },
                { "dialogs", "dialogues" },
                { "caliber", "calibre" },
                { "center", "centre" },
                { "fiber", "fibre" },
                { "fibers", "fibres" },
                { "liter", "litre" },
                { "liters", "litres" },
                { "scepter", "sceptre" },
                { "meager", "meagre" },
                { "saber", "sabre" },
                { "somber", "sombre" },
                { "theater", "theatre" },
                { "meter", "metre" },
                { "meters", "metres" },
                { "luster", "lustre" },
                { "mold", "mould" },
                { "molds", "moulds" },
                { "enroll", "enrol" },
                { "enrollment", "enrolment" },
                { "enrollments", "enrolments" },
                { "fulfill", "fulfil" },
                { "installment", "instalment" },
                { "installments", "instalments" },
                { "instill", "instil" },
                { "skillful", "skilful" },
                { "program", "programme" },
                { "programs", "programmes" },
                { "maneuver", "manoeuvre" },
                { "maneuvers", "manoeuvres" },
                { "airplane", "aeroplane" },
                { "airplanes", "aeroplanes" },
                { "artefact", "artifact" },
                { "artefacts", "artifacts" },
                { "cozy", "cosy" },
                { "donut", "doughnut" },
                { "donuts", "doughnuts" },
                { "gray", "grey" },
                { "grays", "greys" },
                { "jewelry", "jewellery" },
                { "plow", "plough" },
                { "plows", "ploughs" },
                { "skeptic", "sceptic" },
                { "skeptics", "sceptics" },
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
