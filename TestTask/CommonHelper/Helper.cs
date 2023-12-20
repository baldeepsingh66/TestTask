namespace TestTask.CommonHelper
{
    public static class Helper
    {
        public static bool AreNamesSimilar(string name1, string name2)
        {
            // Convert names to lowercase and split into words
            var words1 = name1.ToLower().Split(' ').OrderBy(word => word);
            var words2 = name2.ToLower().Split(' ').OrderBy(word => word);

            if(words1== words2)
                return true;
            return false;
        }
    }
}
