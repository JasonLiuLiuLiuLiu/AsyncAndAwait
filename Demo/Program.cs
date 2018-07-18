using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
       static void Main(string[] args)
        {
            var  pro=new  Program();
            Console.WriteLine("index:"+pro.Index());
            Console.WriteLine("indexAsync:"+pro.IndexAsync().Result);
            Console.ReadKey();
        }

        public long Index()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var content = service.GetContent();
            var count = service.GetCount();
            var name = service.GetName();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }


        public async Task<long> IndexAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var contentTask = service.GetContentAsync();
            var countTask = service.GetCountAsync();
            var nameTask = service.GetNameAsync();

            var content = await contentTask;
            var count = await countTask;
            var name = await nameTask;
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
