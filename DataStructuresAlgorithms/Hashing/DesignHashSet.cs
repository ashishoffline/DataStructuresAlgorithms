/*
 705. Design HashSet:- https://leetcode.com/problems/design-hashset/
 */

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */

namespace DataStructuresAlgorithms
{
    public class MyHashSet
    {

        /** Initialize your data structure here. */
        private const int deleted = -1;
        const int size = 10007;
        private int[] hashTable;
        public MyHashSet()
        {
            hashTable = new int[size];
            for (int i = 0; i < size; i++)
                hashTable[i] = int.MinValue;
        }

        public void Add(int key)
        {
            int collison = -1;
            while (true)
            {
                collison += 1;
                int bucket = HashFunction(key, collison);
                if (hashTable[bucket] == int.MinValue || hashTable[bucket] == deleted || hashTable[bucket] == key)
                {
                    hashTable[bucket] = key;
                    break;
                }
            }
        }

        public void Remove(int key)
        {
            int entry = HashFunction(key, 0);
            int collison = -1;
            while (true)
            {
                collison += 1;
                int bucket = HashFunction(key, collison);
                if (hashTable[bucket] == key)
                {
                    hashTable[bucket] = deleted;
                    break;
                }
                else if (hashTable[bucket] == int.MinValue || (collison != 0 && bucket == entry))
                {
                    break;
                }
            }
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            int entry = HashFunction(key, 0);
            int collison = -1;
            while (true)
            {
                collison += 1;
                int bucket = HashFunction(key, collison);
                if (hashTable[bucket] == key)
                {
                    return true;
                }
                else if (hashTable[bucket] == int.MinValue || (collison != 0 && bucket == entry))
                {
                    return false;
                }
            }
        }

        private int HashFunction(int key, int collison = 0)
        {
            key = ((key / size) + (key % size)) % size;
            return (key + collison) % size;

            //return ((key%size)+collison) % size;
        }
    }
}
