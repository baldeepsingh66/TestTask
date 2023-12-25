using Newtonsoft.Json;

namespace TestTask.CommonHelper
{
    public static class Helper
    {
        public static bool AreNamesSimilar(string name1, string name2)
        {
            // Convert names to lowercase and split into words
            var words1 = name1.ToLower().Split(' ').OrderBy(word => word).ToList();
            var words2 = name2.ToLower().Split(' ').OrderBy(word => word).ToList();

            if(ObjectsAreEqual<List<string>>(words1, words2))
                return true;
            return false;
        }
        public static bool ObjectsAreEqual<T>(T obj1, T obj2)
        {
            var obj1Serialized = JsonConvert.SerializeObject(obj1);
            var obj2Serialized = JsonConvert.SerializeObject(obj2);

            return obj1Serialized == obj2Serialized;
        }
    }
}
