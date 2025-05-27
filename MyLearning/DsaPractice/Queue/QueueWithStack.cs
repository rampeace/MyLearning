using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Queue
{
    internal class QueueWithStack<T> : IEnumerable<T>
    {
        Stack<T> pushStack = new();
        Stack<T> popStack = new();

        public int Count { get => pushStack.Count + popStack.Count; }

        public bool IsEmpty { get => Count == 0; }

        public void Enqueue(T item)
        {
            pushStack.Push(item);
        }

        public T Dequeue()
        {
            RefillIfNeeded();

            return popStack.Pop();
        }

        public T Peek()
        {
            RefillIfNeeded() ;

            return popStack.Peek();
        }

        private void RefillIfNeeded()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The queue is empty");

            if (popStack.Count == 0)
            {
                while (pushStack.Count > 0)
                {
                    popStack.Push(pushStack.Pop());
                }
            }
        }

        public void Clear()
        {
            pushStack.Clear();
            popStack.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = popStack.ToArray();

            for (int i = temp.Length - 1;  i >= 0; i--)
                yield return temp[i];

            temp = pushStack.ToArray();

            for (int i = 0; i < temp.Length; i++)
                yield return temp[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
