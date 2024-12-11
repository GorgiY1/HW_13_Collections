using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13_Collections
{
    class QueuePrint
    {
        SortedList<int, Docum> sl = new SortedList<int, Docum>(3);
        public QueuePrint()
        {
            sl.Add(2, new Docum { name = "John", IDNumber = "1111" });
            sl.Add(5, new Docum { name = "Alma", IDNumber = "2222" });
            sl.Add(1, new Docum { name = "Nuela", IDNumber = "3333" });
        }
        public QueuePrint(string inputName, string inputID, int inputPriorityNumber)
        {
            sl.Add(inputPriorityNumber, new Docum { name = inputName, IDNumber = inputID });        
        }
        public void Enqueue(string inputName, string inputID, int inputPriorityNumber)
        {
            sl.Add(inputPriorityNumber, new Docum { name = inputName, IDNumber = inputID });
            Console.WriteLine("Document added");
        }
        public Docum Dequeue()
        {
            if (sl.Capacity > 0)
            {
                foreach (int key in sl.Keys)
                {
                    Docum temp = sl[key];
                    sl.RemoveAt(0);
                    Console.WriteLine("Document printed!");
                    return temp;
                }
            }
            throw new IndexOutOfRangeException("The index was outside the bounds of the queue");
        }
        public Docum Peek()
        {
            if (sl.Capacity > 0)
            {
                foreach (int key in sl.Keys)
                {
                    return sl[key];
                }
            }
            throw new IndexOutOfRangeException("The index was outside the bounds of the queue");
        }
        public void ShowAllQueue()
        {
            if (sl.Count > 0)
            {
                foreach (int key in sl.Keys)
                {
                    Console.WriteLine($"Priority key: {key}\tDocument: {sl[key]}");
                }
            }
            else throw new Exception("This queue is Empty!");
        }
        public void Clear()
        {
            sl.Clear();
            Console.WriteLine("The queue is cleared!");
        }
    }

    internal class Docum
    {
        public string name { get; set; }
        public string IDNumber { get; set; }

        public override string ToString()
        {
            return $"name: {name}, IDNumber: {IDNumber}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Разработать класс очереди печати сотрудников. Предусмотреть в классе методы: 
             * помещение документа в очередь печати, извлечение следующего документа из очереди печати, 
             * проверка наличия документов в очереди. При помещении документа задается его приоритет, 
             * извлекаются в первую очередь документы с более высоким приоритетом.
             */

            QueuePrint queuePrint = new QueuePrint();

            Random random = new Random();
            int menu = 0;

            string name = null;
            string ID = null;
            int priority = 0;
            do
            {
                Console.WriteLine("\n========================================================");
                Console.WriteLine($"\n   Select an operation: ");
                Console.WriteLine($"1. (Enqueue)\tAdd new Document to print queue: ");
                Console.WriteLine($"2. (Dequeue)\tPrint the first document in the queue and remove it from the queue: ");
                Console.WriteLine($"3. (Peek)\tReturns the object (Docum rype) at the beginning of the Queue without removing it: ");
                Console.WriteLine($"4. (Show)\tShow all Documents queue: ");
                Console.WriteLine($"5. (Clear)\tClear all queue: ");
                
                Console.WriteLine($"0. Exit: ");
                Console.WriteLine("========================================================\n");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:

                        do
                        {
                            try
                            {
                                Console.WriteLine("Input Employee name: ");
                                name = Console.ReadLine();
                                Console.WriteLine("Input Employee ID: ");
                                ID = Console.ReadLine();
                                priority = random.Next(1, 10);
                                Console.WriteLine("Priority is random! ");

                                queuePrint.Enqueue(name, ID, priority);
                                Console.WriteLine();
                                queuePrint.ShowAllQueue();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("\nGo To continue generating fractions, press the Enter key, in the Go menu, input something");

                        } while (Console.ReadLine() == "");

                        break;

                    case 2:

                        do
                        {
                            try
                            {
                                queuePrint.ShowAllQueue();
                                Console.WriteLine();
                                Console.WriteLine(queuePrint.Dequeue());
                                Console.WriteLine();
                                queuePrint.ShowAllQueue();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("\nGo To continue generating fractions, press the Enter key, in the Go menu, input something");

                        } while (Console.ReadLine() == "");
                        break;

                    case 3:

                        try
                        {
                            queuePrint.ShowAllQueue();
                            Console.WriteLine();
                            Console.WriteLine(queuePrint.Peek());
                            Console.WriteLine();
                            queuePrint.ShowAllQueue();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:

                        try
                        {
                            Console.WriteLine();
                            queuePrint.ShowAllQueue();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:

                        try
                        {
                            queuePrint.ShowAllQueue();
                            Console.WriteLine();
                            queuePrint.Clear();
                            Console.WriteLine();
                            queuePrint.ShowAllQueue();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        break;
                }

            } while (menu != 0);

            Console.ReadKey();
        }
    }
}
