using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading_Homework
{
    class ListItem<T>
    {
        public ListItem<T> Next { get; set; }
        public ListItem<T> Prev { get; set; }
        public T Item { get; set; }

        public ListItem(T newItem)
        {
            Item = newItem;
        }
    }
}
