using System.Text;

namespace InferrableLanguages
{
    public static class InferrableLanguages
    { 
        private static string SubtractFromLeft(string left, string right)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;

            while (i < left.Length && i < right.Length)
            {
                if (left[i] != right[i])
                {
                    break;
                }

                i++;
            }

            while (i < right.Length)
            {
                stringBuilder.Append(right[i++]);
            }

            return stringBuilder.ToString();
        }

        private static (int, string) SubtractFromRight(string left, string right)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = left.Length - 1;
            int j = right.Length - 1;

            if (i < j)
            {
                while (i >= 0 && j >= 0)
                {
                    if ((left[i] != right[j]))
                    {
                        break;
                    }
                    i--;
                    j--;
                }

                while (i >= 0)
                {
                    stringBuilder.Append(left[i--]);
                }

                while (j >= 0)
                {
                    stringBuilder.Append(right[j--]);
                }
                
                StringBuilder reversed = new StringBuilder();
                String str = stringBuilder.ToString();

                for (int k = str.Length - 1; k >= 0; k--)
                {
                    reversed.Append(str[k]);
                }

                return (1, reversed.ToString());
            }
            else
            {
                return (-1, SubtractFromLeft(left, right));
            }

        }

        // The LHS equations can be generalized to LHS = a - b + c - d + e, 
        // however, writing it in the format will allow us to visualize
        // what is being computed
        // Current problem: the negative string
        // 1. Stacks
        // 2. Algorithm
        // 3. Replace function
        // 4. Class
        // Of the four, investigation into algorthm and classes.
        // Stacks would require more more stacking, what of other operations besides + and -?
        // Replace is generalized

        public static string LHSx1(string y1, string z2, string x2, string y2, string z1)
        {
            StringBuilder x1Sb = new StringBuilder();

            x1Sb = new StringBuilder(SubtractFromRight(y1, z2).Item2);
            x1Sb.Append(x2);
            x1Sb = new StringBuilder(SubtractFromRight(x1Sb.ToString(), y2).Item2);
            x1Sb.Append(z1);

            return x1Sb.ToString();
        }

        public static string LHSy1(string z2, string x2, string y2, string z1, string x1)
        {
            StringBuilder y1Sb = new StringBuilder();

            y1Sb = new StringBuilder(SubtractFromRight(z2, x2));
            y1Sb.Append(y2);
            y1Sb = new StringBuilder(SubtractFromRight(y1Sb.ToString(), z1));
            y1Sb.Append(x1);
            
            return y1Sb.ToString();
        }

        public static string LHSz1(string x2, string y2, string z1, string x1, string y1)
        {
            StringBuilder z1Sb = new StringBuilder();

            (int p, string ret) = SubtractFromRight(x2, y2);
            z1Sb = new StringBuilder(ret);
            if (p < 0)
            {
                (int p, string ret1) = SubtractFromRight(z1, ret);
                z1Sb = new StringBuilder(ret1);
            }
            z1Sb.Append(z1);
            z1Sb = new StringBuilder(SubtractFromRight(z1Sb.ToString(), x1));
            z1Sb.Append(y1);
            
            return z1Sb.ToString();

        }
    }
}