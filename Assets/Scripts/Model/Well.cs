using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Well
    {
        public Well(int size)
        {
            Nodes = new Node[size*size];
            for(int i = 0; i < Nodes.Length; ++i)
            {
                Nodes[i] = new Node(i, size);
            }
            Size = size;
        }

        public int Size { get; private set; }

        public Node[] Nodes { get; private set; }
    }
}
