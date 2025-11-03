using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Library<T>
    {
        public List<T> Items { get; }
        public string Name { get; }

        public Library(string name)
        {
            Name = name;
            Items = new List<T>();
        }

        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine("Əlavə edildi");
        }

        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public int Count()
        {
            return Items.Count;
        }

        public T FindByIndex(int index)
        {
            if (index < 0 || index >= Items.Count)
                return default;
            return Items[index];
        }
    }
}
