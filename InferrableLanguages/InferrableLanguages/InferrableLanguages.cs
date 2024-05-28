using System.Text;

namespace InferrableLanguages
{
    public static class InferrableLanguages
    {
        // Bilinearity
        // 1. [v1+v2,w]  = [v1,w]+[v2,w] and [cv,w]     = c[v,w]
        // 2. [v, w1+w2] = [v, w1] + [v, w2] and[v, cw] = c[v, w]
        // SubtractFromRight
        // SubtractFromLeft

        // bilinearity: [v1+v2, w] = [v1, w]+[v2, w] and[cv, w] = c[v, w]
        // [v, w1 + w2] = [v, w1] + [v, w2] and[v, cw] = c[v, w]
        // skew symmetry: [v, w] = -[w, v] or[v, v] = 0
        // jacobi: [u,[v, w]] + [v,[w, u]] + [w,[u, v]] = 0

        private static string SubtractFromRight(string left, string right)
        {
            if (left.Length < right.Length)
            {
                if (right.Substring(right.Length - left.Length, left.Length) == left)
                {
                    return right.Substring(0, right.Length - left.Length);
                }
                else if (right.Substring(0, left.Length) == left)
                {
                    return right.Substring(left.Length, right.Length - left.Length);
                }
            }
            else if (right.Length < left.Length)
            {
                if (left.Substring(0, right.Length) == right)
                {
                    return left.Substring(right.Length, left.Length - right.Length);
                }
                else if (left.Substring(left.Length - right.Length, right.Length) == right)
                {
                    return left.Substring(0, left.Length - right.Length);
                }
            }

            return string.Empty;
        }

        private static string SubtractFromLeft(string right, string left)
        {
            if (right.Length < left.Length)
            {
                if (left.Substring(0, right.Length) == right)
                {
                    return left.Substring(right.Length, left.Length - right.Length);
                }
                else if (left.Substring(left.Length - right.Length, right.Length) == right)
                {
                    return left.Substring(0, left.Length - right.Length);
                }
            }
            else if (left.Length < right.Length)
            {
                if (right.Substring(right.Length - left.Length, left.Length) == left)
                {
                    return right.Substring(0, right.Length - left.Length);
                }
                else if (right.Substring(0, left.Length) == left)
                {
                    return right.Substring(left.Length, right.Length - left.Length);
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

        private static string AddRight(string left, string right)
        {
            StringBuilder stringBuilder = new StringBuilder(right);
            stringBuilder.Append(left);

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

        // explanation of jacobi's for the left hand side of the 3x3 matrix.
        // x+y-z = 0
        // u = x
        // v = y
        // w = -z
        // [u,[v,w]]
        // aba + ab - a = aba + b = abab
        // u v w => -v -u w {swap u and v} => - v -w -u {swap u and w} => -[v,-[w,u]]
        // - [ab - [a - aba]] = -[ab - [-ab]] = -[abab] = -abab
        // u v w => u -w -v {swap v and w} => w -u -v {swap w and u} => [w,-[u,v]]
        // [a - [aba - ab]] = a - [a] = 0
        // jacobi's
        // [u,[v,w]] - [v,-[w,u]] + [w,-[u,v]] = 0
        // abab -abab + 0 = 0
        //
        // x - y - z = 0
        // u = x
        // v = -y
        // w = -z
        // [u,[v,w]]
        // abaababaabaababaababa - abaababaabaab - abaababa = 0
        // u v w => -v -u w {swap u and v} => - v -w -u {swap u and w} => -[v,-[w,u]]
        // -[abaababaabaab,-[-abaababaabaababaababa,-abaababa]] => -[abaababaabaab + abaababaabaababaababaabaababa]]
        //      => -[abaababaabaababaababaabaababaababaabaababa]] = -abaababaabaababaababaabaababaababaabaababa
        // u v w => u -w -v {swap v and w} => w -u -v {swap w and u} => [w,-[u,v]]
        // [abaababaabaababaababa + abaababaabaab + abaababa = abaababaabaababaababaabaababaabaababaababa
        // [u,[v,w]] - [v,-[w,u]] + [w,-[u,v]] = 0
        // 0 - abaababaabaababaababaabaababaabaababaababa + abaababaabaababaababaabaababaabaababaababa = 0


        public static string Equation1(string y1, string z2, string x2, string y2, string z1)
        {
            // these operations display jacobi's identity
            var cur = SubtractFromRight(y2, z1);  // this looks nice and looks like functional code
            var cur2 = AddLeft(x2, cur);  
            var cur3 = SubtractFromRight(z2, cur2);
            var cur4 = AddLeft(y1, cur3);

            return cur4;
        }

        public static string Equation2(string y1, string z2, string x2, string y2, string z1)
        {
            var cur = SubtractFromRight(y2, z1);
            var cur2 = SubtractFromRight(x2, cur);
            var cur3 = SubtractFromRight(z2, cur2);
            var cur4 = SubtractFromRight(y1, cur3);

            return cur4;
        }

        public static string Equation3(string z1, string x1, string y1, string z2, string x2)
        {
            var cur = SubtractFromRight(z2, x2);
            var cur2 = AddLeft(y1, cur);
            var cur3 = SubtractFromRight(x1, cur2);
            var cur4 = SubtractFromRight(z1, cur3);

            return cur4;
        }

        // -abaab = b - ab + a - aba + abaababa
        // -abaab = - a + a - aba + abaababa
        // -abaab = - aba + abaababa
        // -abaab = abaab <= the result is skew symmetry
        public static string Equation4(string z2, string x2, string y2, string z1, string x1)
        {
            var cur = SubtractFromRight(z2, x2);
            var cur2 = SubtractFromRight(cur, y2);
            var cur3 = SubtractFromRight(cur2, z1);
            var cur4 = SubtractFromRight(cur3, x1);

            return cur4;
        }

        // -ab = a - aba + abaababa - abaab + b
        // -ab = - ba + abaababa - abaab + b
        // -ab = abaaba - abaab + b
        // -ab = a + b
        // -ab = ab
        public static string Equation5(string y2, string z1, string x1, string y1, string z2)
        {
            var cur = SubtractFromLeft(y2, z1); // Subtract from left
            var cur2 = SubtractFromRight(cur, x1);
            var cur3 = SubtractFromRight(cur2, y1);
            var cur4 = AddLeft(cur3, z2);

            return cur4;
        }

        // you can barely make out jacobi's property
        // it's seen somehow because the determinant of the equation is 0.
        // -aba = abaababa - abaab + b - ab + a
        // -aba = aba + b - ab + a
        // -aba = abab - ab + a
        // -aba = ab + a
        // -aba = aba
        public static string Equation6(string x1, string y1, string z2, string x2, string y2)
        {
            var cur = SubtractFromRight(x1, y1);
            var cur2 = SubtractFromRight(cur, z2);
            var cur3 = SubtractFromRight(cur2, x2);
            var cur4 = AddLeft(cur3, y2);

            return cur4;
        }
    }
}
