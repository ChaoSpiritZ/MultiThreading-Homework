using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Homework
{
    class List<T>
    {
        public ListItem<T> First { get; protected set; }
        public ListItem<T> Last { get; protected set; }
        public int Count { get; protected set; }
        public ListItem<T> CurrentItem { get; protected set; }

        public List()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public void Add(T newItem)
        {
            ListItem<T> listItem = new ListItem<T>(newItem);
            //first on the list
            if (Last == null)
            {
                First = listItem;
            }
            //not first on the list
            else
            {
                listItem.Prev = Last;
                Last.Next = listItem;
            }
            Last = listItem;
            Count++;
        }

        public void Insert(int index, T newItem)
        {
            if (index >= 0 && index <= Count)
            {
                //first on the list
                if (Count == 0)
                {
                    Add(newItem);
                }
                //not first on the list
                else
                {
                    ListItem<T> listItem = new ListItem<T>(newItem);
                    //added as first
                    if (index == 0)
                    {
                        listItem.Next = First;
                        First.Prev = listItem;
                        First = listItem;
                    }
                    //added as last
                    else if (index == Count)
                    {
                        listItem.Prev = Last;
                        Last.Next = listItem;
                        Last = listItem;
                    }
                    //added in the middle
                    else
                    {
                        CurrentItem = First;
                        for (int i = 0; i < index; i++)
                        {
                            CurrentItem = CurrentItem.Next;
                        }

                        listItem.Prev = CurrentItem.Prev;
                        (CurrentItem.Prev).Next = listItem;
                        listItem.Next = CurrentItem;
                        CurrentItem.Prev = listItem;
                    }
                    Count++;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("INDEX IN INSERT OUT OF BOUNDS");
            }
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < Count)
            {
                //remove first
                if(index == 0)
                {
                    //if it's not the only item left
                    if (Count > 1)
                    {
                        First = First.Next;
                        (First.Prev).Next = null;
                        First.Prev = null;
                    }
                    //if it's the only item left
                    else
                    {
                        First = null;
                        Last = null;
                    }
                }
                //remove last
                else if (index == Count - 1)
                {
                    Last = Last.Prev;
                    (Last.Next).Prev = null;
                    Last.Next = null;
                }
                //remove middle
                else
                {
                    CurrentItem = First;
                    for (int i = 0; i < index; i++)
                    {
                        CurrentItem = CurrentItem.Next;
                    }

                    (CurrentItem.Prev).Next = CurrentItem.Next;
                    (CurrentItem.Next).Prev = CurrentItem.Prev;
                    CurrentItem.Next = null;
                    CurrentItem.Prev = null;
                }
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException("INDEX IN REMOVE OUT OF BOUNDS");
            }
        }
        
        public T Get(int index)
        {
            if (index >= 0 && index < Count)
            {
                CurrentItem = First;
                for (int i = 0; i < index; i++)
                {
                    CurrentItem = CurrentItem.Next;
                }
                return CurrentItem.Item;
            }
            else
            {
                throw new IndexOutOfRangeException("INDEX IN GET OUT OF BOUNDS");
            }
            
        }
    }
}
