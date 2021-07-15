using System;
namespace task_4
{
    public class Person:IDisposable
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Bd { get; set; }
        public string Name { get; set; }
        private bool isDisposed = false;
        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("Object is disposed");
        }

        public Person()
        {
        }
        public Person(int id,string name,string bd,string address)
        {
            Id = id;
            Name = name;
            Address = address;
            Bd = bd;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;
            if (disposing)
            {

            }
            isDisposed = true;
        }
        ~Person()
        {

            Dispose(false);
        }


    }
}
