using System.Text;

namespace InferrableLanguages
{
    public static class InferrableLanguages
    { 
        private static string SubtractFromRight(string left, string right)
        {
            if (left.Length < right.Length)
            {
                if (right.Substring(right.Length - left.Length, left.Length) == left)
                {
                    return right.Substring(0, right.Length - left.Length);
                }
            }
            else if (right.Length < left.Length)
            {
                if (left.Substring(0, right.Length) == right)
                {
                    return left.Substring(left.Length - right.Length, right.Length);
                }
            }

            return string.Empty;
        }

        private static string AddLeft(string left, string right)
        {
            StringBuilder stringBuilder = new StringBuilder(left);
            stringBuilder.Append(right);

            return stringBuilder.ToString();
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

        public static string Equation1(string y1, string z2, string x2, string y2, string z1)
        {
            var cur = SubtractFromRight(y2, z1);
            var cur2 = AddLeft(x2, cur);
            var cur3 = SubtractFromRight(z2, cur2);
            var cur4 = AddLeft(y1, cur3);

            return cur4;
        }
    }
}