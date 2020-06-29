using Controller;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using View;

public class NodeView : MonoBehaviour, INodeView, IPointerClickHandler
{
    [SerializeField]
    Text m_TextIndicate;

    INodeListener mNodeListener = null;
    Node mNodeData = null;
    string mCircle = "◯";
    string mCross = "✕";

    public void OnPointerClick(PointerEventData eventData)
    {
        mNodeListener.OnClickNode(mNodeData.Index);
    }

    public void SetNode(Node data, INodeListener nodeListener)
    {
        mNodeListener = nodeListener;
        mNodeData = data;

        switch(mNodeData.ThisNodeState)
        {
            case Node.NodeState.None:
                m_TextIndicate.text = "";
                break;
            case Node.NodeState.Circle:
                m_TextIndicate.text = mCircle;
                break;
            case Node.NodeState.Cross:
                m_TextIndicate.text = mCross;
                break;
        }
        
    }
}
