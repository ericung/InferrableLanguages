namespace GrammarSystem.Test
{
    [TestClass]
    public class D0LSystemTests
    {
        [TestMethod]
        public void HappyPath()
        {
            D0LSystem system = new D0LSystem();
            string[] derivations = new string[]
            {
                "a",
                "ab",
                "aba",
                "abaab",
                "abaababa",
                "abaababaabaab"
            };

            string next = system.GenerateNext(derivations);

            Assert.Equals(next, "abaababaabaab");
        }
    }
}