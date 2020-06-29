using Controller;
using Model;
using System.Collections;
using UnityEngine;
using View;

public class GameLogic : MonoBehaviour, IController, INodeListener, IMenuListener
{
    public enum Round
    {
        Circle,
        XX,
    }

    [SerializeField]
    WellView m_WellView = null;
    [SerializeField]
    MenuView m_MenuView = null;
    Round mCurrentRound = Round.Circle;
    INodeView[] mNodesView = null;
    int mWellSize = 3;
    int mClickedNodeCount = 0;

    private IEnumerator Start()
    {
        yield return StartCoroutine(Init());
    }

    public IEnumerator Init()
    {
        m_WellView.SetWell(Model.Model.GetWell(mWellSize));
        yield return null;
        mNodesView = m_WellView.GetNodes();
        for (int i = 0; i < mNodesView.Length; ++i)
        {
            mNodesView[i].SetNode(Model.Model.GetNode(i), this);
        }
        m_MenuView.SetListener(this);
        m_MenuView.ShowStartButton();
    }

    public void OnClickNode(int index)
    {
        if (Model.Model.GetNode(index).ThisNodeState != Node.NodeState.None)
            return;

        Model.Model.GetNode(index).ThisNodeState = mCurrentRound == Round.Circle ? Node.NodeState.Circle : Node.NodeState.Cross;
        mNodesView[index].SetNode(Model.Model.GetNode(index), this);
        CheckWinner(index);
    }

    void CheckWinner(int index)
    {
        ++mClickedNodeCount;
        bool someoneWin = false;

        var changedNode = Model.Model.GetNode(index);
        var checkSide = changedNode.ThisNodeState;

        //檢查橫排
        var rowNodes = Model.Model.GetRowNodes(changedNode.Y);
        bool rowLink = true;
        for(int i = 0; i < rowNodes.Length; ++i)
        {
            if (rowNodes[i].ThisNodeState != checkSide)
            {
                rowLink = false;
                break;
            }
        }
        if (rowLink)
        {
            HaveWinner();
            return;
        }

        //檢查縱行
        var columnNodes = Model.Model.GetColumnNodes(changedNode.X);
        bool columnLink = true;
        for (int i = 0; i < columnNodes.Length; ++i)
        {
            if (columnNodes[i].ThisNodeState != checkSide)
            {
                columnLink = false;
                break;
            }
        }
        if (columnLink)
        {
            HaveWinner();
            return;
        }

        //檢查是否是斜向格
        Node[] leftObliqueNodes;
        Node[] rightObliqueNodes;
        if(Model.Model.IsOblique(index, out leftObliqueNodes, out rightObliqueNodes))
        {
            bool leftObliqueLink = true;
            if (leftObliqueNodes != null)
            {
                for (int i = 0; i < leftObliqueNodes.Length; ++i)
                {
                    if (leftObliqueNodes[i].ThisNodeState != checkSide)
                    {
                        leftObliqueLink = false;
                        break;
                    }
                }
            }
            else
            {
                leftObliqueLink = false;
            }
            if (leftObliqueLink)
            {
                HaveWinner();
                return;
            }

            bool rightObliqueLink = true;
            if (rightObliqueNodes != null)
            {
                for (int i = 0; i < rightObliqueNodes.Length; ++i)
                {
                    if (rightObliqueNodes[i].ThisNodeState != checkSide)
                    {
                        rightObliqueLink = false;
                        break;
                    }
                }
            }
            else
            {
                rightObliqueLink = false;
            }
            if (rightObliqueLink)
            {
                HaveWinner();
                return;
            }
        }

        if (!someoneWin)
        {
            if(mClickedNodeCount == mWellSize*mWellSize)
                m_MenuView.ShowStartButton();
            else
                NextRound();
        }
    }

    void NextRound()
    {
        mCurrentRound = mCurrentRound == Round.Circle ? Round.XX : Round.Circle;
    }

    void HaveWinner()
    {
        m_MenuView.ShowWinner(mCurrentRound);
    }

    public void OnClickStart()
    {
        m_MenuView.HideMenu();
        Model.Model.ClearNodesState();
        for (int i = 0; i < mNodesView.Length; ++i)
        {
            mNodesView[i].SetNode(Model.Model.GetNode(i), this);
        }
        mClickedNodeCount = 0;
    }

    public void OnClickOK()
    {
        m_MenuView.ShowStartButton();
    }
}
