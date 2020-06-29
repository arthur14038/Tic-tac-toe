using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Node
    {
        public Node(int index, int wellSize)
        {
            Index = index;
            X = index % wellSize;
            Y = index / wellSize;
            ThisNodeState = NodeState.None;
        }

        public enum NodeState
        {
            None,
            Cross,
            Circle,
        }

        public int Index { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public NodeState ThisNodeState;
    }
}
