namespace Common
{
    public static class Log
    {
        public const string MDXXPATH = "../Logs/MDxx";
        public const string MD2XX = "md2xx.txt";
        public const string GENERALIZEDMD = "generalizedMD.txt";

        public const string FIBONACCIPATH = "../Logs/Fibonacci";
        public const string FIBONACCI = "fibonacci.txt";
        public const string FIBANCCIGENERATOR = "fibonacciGenerator.txt";

        public static void Create(out FileStream ostrm, out StreamWriter writer, string path, string fileName)
        {
            var filePath = Path.Combine(path, fileName);
            var errorPath = filePath.Replace(".txt", "Error.txt");

            try
            {
                Directory.CreateDirectory(path);
                File.Delete(filePath);
                File.Delete(errorPath);
                ostrm = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                ostrm = new FileStream(errorPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = new StreamWriter(ostrm);
            }

            Console.SetOut(writer);
        }
    }
}
