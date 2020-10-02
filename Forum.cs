using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Advanced_Programming_C2
{
    class Forum
    {
        static void Main(string[] args)
        {
            Forum f = new Forum();
            int choice = 0;

            do
            {
                Console.WriteLine("1.Create Post ");
                Console.WriteLine("2.Update Post ");
                Console.WriteLine("3.Remove Post ");
                Console.WriteLine("4.Show Post ");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Please select an item: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        f.CreatePost();
                        break;

                    case 2:
                        f.UpdatePost();
                        break;
                    case 3:
                        f.RemovePost();
                        break;
                    case 4:
                        f.ShowPost();
                        break;
                    case 5:
                        return;
                }

            } while (choice != 6);
        }
        int count = 0;
        SortedList sl = new SortedList();

        public void CreatePost()
        {
            Post post = new Post();
            post.ID = count;
            Console.WriteLine("Input Title :");
            post.Title = Console.ReadLine();
            Console.WriteLine("Input Content :");
            post.Content = Console.ReadLine();
            Console.WriteLine("Input Author :");
            post.Author = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input Rate :");
                post.Rates[i] = int.Parse(Console.ReadLine());
            }
            post.CalculatorRate();
            sl.Add(count, post);
            count++;
        }
        public void UpdatePost()
        {
            bool search = false;
            Console.Write("Enter the ID of the Post you want to update : ");
            int id = int.Parse(Console.ReadLine());
            foreach (Post item in sl.Values)
            {
                if (id.Equals(item.ID))
                {
                    search = true;
                    Post post = new Post();
                    post.ID = id;
                    Console.WriteLine("Input Title :");
                    post.Title = Console.ReadLine();
                    Console.WriteLine("Input Content :");
                    post.Content = Console.ReadLine();
                    Console.WriteLine("Input Anuthor :");
                    post.Author = Console.ReadLine();
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Input Rate :");
                        post.Rates[i] = int.Parse(Console.ReadLine());
                    }
                    post.CalculatorRate();
                    sl.Remove(id);
                    sl.Add(id, post);
                    
                    break;
                }
            }
            if (search == true)
                Console.WriteLine("Update Sucessful!");
            else
                Console.WriteLine("Not Found!");
        }
        public void RemovePost()
        {
            bool search = false;
            Console.Write("Enter the ID of the post you want to delete : ");
            int id = int.Parse(Console.ReadLine());
            foreach (Post item in sl.Values)
            {
                if (id.Equals(item.ID))
                {
                    search = true;
                    sl.Remove(id);
                    break;
                }
            }
            if (search == true)
                Console.WriteLine("Remove Successful!");
            else
                Console.WriteLine("Not Found!");
        }
        public void ShowPost()
        {
            foreach (Post item in sl.Values)
            {
                item.Display();
            }
        }


    }
}
