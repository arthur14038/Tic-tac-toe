using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public interface IWellView
    {
        void SetWell(Well data);

        void SetRound(GameLogic.Round round);

        INodeView[] GetNodes();
    }
}