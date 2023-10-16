namespace GrammarSystem
{
    public class D0LSystem
    {
        public bool HasAllDerivatives(string[] derivations)
        {
            int n = derivations.Length;
            string tempString = derivations[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                if (tempString.Contains(derivations[i]))
                {
                    tempString = tempString.Replace(derivations[i], "");
                }
            }

            if (tempString == String.Empty)
            {
                return true;
            }

            return false;
        }

        public int[] FindSequeuence(string[] derivations)
        {
            int n = derivations.Length;
            string tempEmpty = derivations[n - 1];
            string tempReplace = derivations[n - 1];
            int index = 0;

            for (int i = n-2; i >= 0; i--)
            {
                if (tempEmpty.Contains(derivations[i]))
                {
                    tempEmpty = tempEmpty.Replace(derivations[i], "");
                    tempReplace = tempReplace.Replace(derivations[i], index.ToString()+",");
                }
                index++;
            }

            int prev = -1;
            int[] sequence = new int[n - 1];
            int place = 0;

            string[] replace = tempReplace.Split(",");

            foreach (string s in tempReplace.Split(","))
            {
                if (s.Length > 0)
                {
                    int num = Convert.ToInt32(s);
                    if (prev != num)
                    {
                        prev = num;
                        sequence[place] = num;
                        place++;
                    }
                }
            }

            return sequence;
        }

        public string GenerateNext(string[] derivations)
        {
            string next = string.Empty;

            if (HasAllDerivatives(derivations) == false)
            {
                return next;
            }

            int[] sequence = FindSequeuence(derivations);

            foreach (int element in sequence)
            {
                next += derivations[element];
            }

            return next;
        }
    }
}