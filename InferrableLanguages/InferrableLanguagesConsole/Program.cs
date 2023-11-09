using Common;

#region generalizedMD

bool generalizedMD(int y)
{
    if (y == 0)
    {
        return true;
    }

    var s = y;

    while (s >= 0)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (s == 0 && (j == 0 || j == 2) && i == 0)
                {
                    return true;
                }
                else if (s < 0)
                {
                    return false;
                }
                s -= 1;
            }
        }
    }

    return true;
}

#endregion generalizedMD

#region generator

int[] Generator(int max)
{
    int[] result = new int[max + 1];
    int x = 0;
    int negatives = 0;
    int i = 0;

    while (x < max + 1)
    {
        int num = 2 * (Convert.ToInt32(Math.Pow(x, 2)));

        if (generalizedMD(i))
        {
            if (num == i)
            {
                Console.WriteLine(negatives);
                Console.WriteLine("f(" + x + ") = " + i);
                result[x] = i;

                x++;
                negatives = 0;
            }
            else
            {
                negatives++;
            }
        }
        i++;
    }

    return result;
}

#endregion generator

#region md2xx

bool MonomialDecider2xx(int y)
{
    var total = 0;
    var hits = 0;
    var diff = 1;
    var isEven = 0;
    var s = 0;

    while (s <= y)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    if ((i == 0) && (j == 0 || j == 1) && (k == 0))
                    {
                        if (hits == total)
                        {
                            if (s == y)
                            {
                                Console.WriteLine(new String(s + ": Hits: " + total + ""));
                                return true;
                            }
                            else if (s > y)
                            {
                                return false;
                            }

                            total += diff;
                            isEven++;
                            if (isEven % 3 == 2)
                            {
                                isEven = 0;
                                diff += 2;
                            }
                        }

                        hits++;
                    }
                    s++;
                }
            }
        }
    }

    return false;
}

#endregion md2xx

#region generalizedRun

FileStream ostrmGMD;
StreamWriter writerGMD;
Common.Log.Create(out ostrmGMD, out writerGMD, Log.MDXXPATH, Log.GENERALIZEDMD);

Console.WriteLine("Using the general decider to get the number of hits in the monomial decider.");
Console.WriteLine("\n\nGenerator Function Output");

var res = Generator(22);

for (int x = 0; x < res.Length; x++)
{
    Console.WriteLine(new String("f(" + x + ") = " + res[x] + ""));
}

writerGMD.Close();
ostrmGMD.Close();

#endregion generatorRun

#region mdLogRun

FileStream ostrmMD;
StreamWriter writerMD;
Common.Log.Create(out ostrmMD, out writerMD, Log.MDXXPATH, Log.MD2XX);

Console.WriteLine("Monomial Decider 2xx deciding");

var ys = 0;

for (int i = 0; i < 1000; i++)
{
    if (MonomialDecider2xx(i))
    {
        ys++;
    }
}

Console.WriteLine("Number of y's accepted between 0 and 999: " + ys);
Console.WriteLine(new String("2,000,000 in f(x)? " + MonomialDecider2xx(2000000)));

writerMD.Close();
ostrmMD.Close();

#endregion mdLogRun

