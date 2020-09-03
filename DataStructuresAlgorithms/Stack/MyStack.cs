using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    public class MyStack<T>
    {
        private int top = -1;
        private IList<T> list;
        public MyStack(int capacity = 0)
        {
            list = new List<T>(capacity);
        }

        public int Count
        {
            get
            {
                return top + 1;
            }
        }
        public void Push(T item)
        {
            if (top + 1 == list.Count)
            {
                list.Add(item);
                top += 1;
            }
            else
            {
                top += 1;
                list[top] = item;
            }
        }

        public T Pop()
        {
            T temp;
            if (top < 0)
            {
                throw new InvalidOperationException("StackUnderflow : Stack is empty");
            }
            else
            {
                temp = list[top];
                top -= 1;
            }
            return temp;
        }

        public T Peek()
        {
            T temp;
            if (top < 0)
            {
                throw new InvalidOperationException("StackUnderflow : Stack is empty");
            }
            else
            {
                temp = list[top];
            }
            return temp;
        }

        public bool TryPop(out T item)
        {
            bool result;
            if (top < 0)
            {
                item = default(T);
                result = false;
            }
            else
            {
                item = list[top];
                top -= 1;
                result = true;
            }
            return result;
        }

        public bool TryPeek(out T item)
        {
            bool result;
            if (top < 0)
            {
                item = default(T);
                result = false;
            }
            else
            {
                item = list[top];
                result = true;
            }
            return result;
        }
    }
}
