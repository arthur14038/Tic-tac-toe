using Controller;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public interface INodeView
    {
        void SetNode(Node data, INodeListener nodeListener);
    }
}