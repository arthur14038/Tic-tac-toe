using Model;
using UnityEngine;
using UnityEngine.UI;
using View;

public class WellView : MonoBehaviour, IWellView
{
    [SerializeField]
    GridLayoutGroup m_GridLayoutGroup;
    [SerializeField]
    NodeView m_NodeView;

    INodeView[] nodeViews = null;

    public INodeView[] GetNodes()
    {
        return nodeViews;
    }

    public void SetRound(GameLogic.Round round)
    {

    }

    public void SetWell(Well data)
    {
        nodeViews = new INodeView[data.Nodes.Length];
        for(int i = 0; i < nodeViews.Length; ++i)
        {
            nodeViews[i] = GetNode();
        }
        m_NodeView.gameObject.SetActive(false);
    }

    NodeView GetNode()
    {
        return Instantiate(m_NodeView, m_GridLayoutGroup.transform);
    }
}
