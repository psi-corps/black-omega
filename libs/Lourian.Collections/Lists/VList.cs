using System.Collections;
using System.Collections.Generic;

namespace Lourian.Collections.Lists
{
    public class VList<T> : IList<T>, IReadOnlyList<T>
    {
        private class Segment
        {
            public Segment Next;
            
            public 
        }
        
        
        
        
        
        
        private int _count;
        private int _count1;

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        int ICollection<T>.Count => _count;

        public bool IsReadOnly { get; }
        public int IndexOf(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        int IReadOnlyCollection<T>.Count => _count1;
    }
}