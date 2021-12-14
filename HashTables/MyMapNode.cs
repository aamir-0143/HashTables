﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables 
{
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] map;
        public MyMapNode(int size)
        {
            this.size = size;
            this.map = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedList = map[position];
            foreach (KeyValue<K, V> map in LinkedList)
            {
                if (map.key.Equals(key))
                {
                    return map.value;
                }
            }
            return default(V);
        }
       
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedList = GetLinkedList(position);
            KeyValue<K, V> map = new KeyValue<K, V>() { key = key, value = value };
            LinkedList.AddLast(map);

        }

        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedList = GetLinkedList(position);
            bool mapfound = false;
            KeyValue<K, V> foundmap = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> map in LinkedList)
            {
                if (map.key.Equals(key))
                {
                    mapfound = true;
                    foundmap = map;

                }
            }
            if (mapfound)
            {
                LinkedList.Remove(foundmap);
            }
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> LinkedList = map[position];
            if (LinkedList == null)
            {
                LinkedList = new LinkedList<KeyValue<K, V>>();
                map[position] = LinkedList;

            }
            return LinkedList;
        }


        public struct KeyValue<K, V>
        {
            public K key { get; set; }
            public V value { get; set; }
        }
    }
}