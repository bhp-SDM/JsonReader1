using Newtonsoft.Json;
using System.Diagnostics;

namespace JsonReader1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("../../../../ratings.json"))
            {
                Console.Write("Converting Json file to objects... ");
                
                Stopwatch sw = Stopwatch.StartNew();
                
                List<BEReview>? items = JsonConvert.DeserializeObject<List<BEReview>>(r.ReadToEnd());
                if (items == null)
                    items = new List<BEReview>();

                sw.Stop();
                
                Console.WriteLine($"Time = {sw.Elapsed.TotalSeconds:f4} sec.");
                Console.WriteLine($"Review Count = {items.Count:N0}");
                Console.WriteLine("First Reviewer = " + items[0].Reviewer);
                Console.WriteLine("Last Reviewer  = " + items[items.Count - 1].Reviewer);
            }
        }
    }
}
