using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice
{
    public class LRUCache
    {
        private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _cache;
        private readonly LinkedList<(int key, int value)> _list;

        public int Capacity { get; }

        public LRUCache(int capacity)
        {
            Capacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
            _list = new LinkedList<(int key, int value)>();
        }

        public int Get(int key)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _list.Remove(node);
                _list.AddFirst(node);

                return node.Value.value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                node.Value = (key, value);

                _list.Remove(node);
                _list.AddFirst(node);

                return;
            }

            if (_cache.Count == Capacity)
            {
                var lruNode = _list.Last;

                int keyToRemove = lruNode.Value.key;

                _list.RemoveLast();
                _cache.Remove(keyToRemove);
            }

            var newNode = new LinkedListNode<(int key, int value)>((key, value));

            _list.AddFirst(newNode);
            _cache[key] = newNode;
        }
    }
}
