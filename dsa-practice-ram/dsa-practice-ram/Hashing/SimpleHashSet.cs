using System.Collections;

namespace DsaPractice.Hashing
{
    public class SimpleHashSet<T> : IEnumerable<T>
    {
        private List<List<T>> buckets;

        public int Count { get; private set; }

        private const double ThresHold = 0.75;
        public SimpleHashSet(int bucketSize = 4)
        {
            buckets = Enumerable.Range(0, bucketSize)
                .Select(_ => new List<T>())
                .ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                foreach (var key in bucket)
                {
                    yield return key;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetBucketIndex(T item, int bucketSize)
        {
            int hash = item.GetHashCode();
            return Math.Abs(hash % bucketSize);
        }

        public void Add(T item)
        {
            if ((double)Count / buckets.Count > ThresHold)
                Resize();

            int bucketIndex = GetBucketIndex(item, buckets.Count);
            var bucket = buckets[bucketIndex];
            if (!bucket.Any(x => item.Equals(x)))
            {
                bucket.Add(item);
                Count++;
            }
        }

        private void Resize()
        {
            int newSize = buckets.Count * 2;
            List<List<T>> newBuckets = Enumerable.Range(0, newSize)
                .Select(_ => new List<T>())
                .ToList();

            foreach (var bucket in buckets)
            {
                foreach (var item in bucket)
                {
                    int newBucketIndex = GetBucketIndex(item, newBuckets.Count);
                    newBuckets[newBucketIndex].Add(item);
                }
            }
            buckets = newBuckets;
        }
        public bool Contains(T item)
        {
            int bucketIndex = GetBucketIndex(item, buckets.Count);
            var bucket = buckets[bucketIndex];
            return bucket.Any(x => x.Equals(item));
        }
    }
}
