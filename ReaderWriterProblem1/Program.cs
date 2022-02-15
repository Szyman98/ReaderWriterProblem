using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ReaderWriterProblem1
{
    internal class Program
    {
        static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
    
        static void Main(string[] args)
        {

            Thread writer1 = new Thread(() =>
           {
               Write();
           });

            Thread writer2 = new Thread(() =>
            {
                Write();
            });

            Thread reader1 = new Thread(() =>
            {
                Read();
            });
            Thread reader2 = new Thread(() =>
            {
                Read();
            });
            Thread reader3 = new Thread(() =>
            {
                Read();
            });
            Thread reader4 = new Thread(() =>
            {
                Read();
            });
            Thread reader5 = new Thread(() =>
            {
                Read();
            });





            reader1.Start();
            reader2.Start();
            reader3.Start();
            reader4.Start();
            reader5.Start();

            writer1.Start();
            writer2.Start();




        }





        static void Read()
        {

            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} reader || tries to read");
                _rw.EnterReadLock();
                try
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} reader || IS READING");
                  
                }
                finally
                {
                   
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} reader || LEAVES");
                    _rw.ExitReadLock();
                    Thread.Sleep(100);
                }
                
                
                
            }



        }


        static void Write()
        {
            while (true)
            {
                
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} WRITER|| TRIES TO ENTER");
                    _rw.EnterWriteLock();
                try
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} WRITER|| IS Writing");
                
                }

                finally
                {
                   
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} WRITER|| leaves");
                    _rw.ExitWriteLock();
                    Thread.Sleep(200);


                }
         
                  
               
            }
                
            


        }

    }
}
