using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.Collections
{
    public class Stack<T> : IEnumerable<T>
    {
        private int top = -1;
        private T[] list;

        public Stack()
        {
            list = new T[4];
        }
        public Stack(int capacity)
        {
            list = new T[capacity];
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
            top += 1;
            if (top == list.Length)
            {
                Array.Resize<T>(ref list, list.Length * 2);
            }
            list[top] = item;
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

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = Count - 1; i >= 0; i--)
            //{
            //    yield return list[i];
            //}
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //return GetEnumerator();
            return new Enumerator(this);
        }

        #region IEnumerator implementation
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            int currentIndex;
            Stack<T> stack;
            private T current;
            public Enumerator(Stack<T> stack)
            {
                this.stack = stack;
                currentIndex = stack.Count;
                current = default(T);
            }
            public object Current => current;

            T IEnumerator<T>.Current => current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (--currentIndex >= 0)
                {
                    current = stack.list[currentIndex];
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
