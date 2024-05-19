string x1 = "abaababa";
string y1 = "abaab";
string z1 = "aba";
string x2 = "ab";
string y2 = "a";
string z2 = "b";

Console.WriteLine("abaababa = -abaab + b - ab + a - aba");
Console.WriteLine(InferrableLanguages.InferrableLanguages.Equation1(y1, z2, x2, y2, z1) + "\n");

Console.WriteLine("-abaab = b - ab + a - aba + abaababa");
Console.WriteLine(InferrableLanguages.InferrableLanguages.Equation4(z2, x2, y2, z1, x1) + "\n");

Console.WriteLine("b = -ab + a - aba + abaababa - abaab");
Console.WriteLine(InferrableLanguages.InferrableLanguages.Equation2(x2, y2, z1, x1, y1) + "\n");

Console.WriteLine("-ab = a -aba + abaababa - abaab + b");
Console.WriteLine(InferrableLanguages.InferrableLanguages.Equation5(y2, z1, x1, y1, z2) + "\n");

Console.WriteLine("a = aba + abaababa - abaab + b - ab");
Console.WriteLine(InferrableLanguages.InferrableLanguages.Equation3(z1, x1, y1, z2, x2) + "\n");

Console.WriteLine("-aba = abaababa - abaab + b - ab + a");
Console.WriteLine(InferrableLanguages.InferrableLanguages.Equation6(x1, y1, z2, x2, y2) + "\n");
