using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Hashing
{
    public class SimpleDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<List<KeyValuePair<TKey, TValue>>> buckets;
        private const double ThresHold = 0.75;
        public int Count { get; private set; }

        public SimpleDictionary(int bucketSize = 4) 
        {
            buckets = Enumerable.Range(0, bucketSize)
                .Select(_ => new List<KeyValuePair<TKey, TValue>>())
                .ToList();
        }

        private int GetBucketIndex(TKey key, int bucketCount)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % bucketCount);
        }

        public void Add(TKey key, TValue value)
        {
            if ((double)Count / buckets.Count > ThresHold)
                Resize();

            int bucketIndex = GetBucketIndex(key, buckets.Count);
            var bucket = buckets[bucketIndex];
            if (bucket.Any(kvp => kvp.Key.Equals(key)))
                throw new InvalidOperationException("The key is already found");

            buckets[bucketIndex].Add(new KeyValuePair<TKey, TValue>(key, value));
            Count++;
        }

        public void Resize()
        {
            int newBucketSize = buckets.Count * 2;
            List<List<KeyValuePair<TKey, TValue>>> newBuckets = new();

            for (int i = 0; i < newBucketSize; i++)
            {
                newBuckets.Add(new List<KeyValuePair<TKey, TValue>>());
            }

            foreach (var bucket in buckets)
            {
                foreach (var kvp in bucket)
                {
                    int newBucketIndex = GetBucketIndex(kvp.Key, newBuckets.Count);
                    newBuckets[newBucketIndex].Add(new KeyValuePair<TKey, TValue>(kvp.Key, kvp.Value));
                }
            }
            buckets = newBuckets;
        }

        public bool ContainsKey(TKey key)
        {
            int bucketIndex = GetBucketIndex(key, buckets.Count);
            return buckets[bucketIndex].Any(kvp => kvp.Key.Equals(key));
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                foreach (var kvp in bucket)
                {
                    yield return kvp;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TValue this[TKey key]
        {
            get
            {
                int bucketIndex = GetBucketIndex(key, buckets.Count);
                var bucket = buckets[bucketIndex];
                if (!bucket.Any(kvp => kvp.Key.Equals(key)))
                    throw new InvalidOperationException("Key not found");
                return bucket.First(kvp => kvp.Key.Equals(key)).Value;
            }
            set
            {
                int bucketIndex = GetBucketIndex(key, buckets.Count);
                var bucket = buckets[bucketIndex];
                if (!bucket.Any(kvp => kvp.Key.Equals(key)))
                {
                    Add(key, value);
                }
                else
                {
                    for (int i = 0; i < bucket.Count; i++)
                    {
                        if (bucket[i].Key.Equals(key))
                        {
                            bucket[i] = new KeyValuePair<TKey, TValue>(key, value);
                            return;
                        }
                    }
                }
            }
        }
    }
}
