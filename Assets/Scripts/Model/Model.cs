using System.Collections.Generic;

namespace Model
{
    public class Model
    {
        static Well mWellData = null;
        static Node[] mNodes = null;

        public static void ClearNodesState()
        {
            for (int i = 0; i < mNodes.Length; ++i)
                mNodes[i].ThisNodeState = Node.NodeState.None;
        }

        public static Well GetWell(int wellSize)
        {
            if(mWellData == null || mWellData.Size != wellSize)
            {
                mWellData = new Well(wellSize);
            }
            mNodes = mWellData.Nodes;

            return mWellData;
        }

        public static Node GetNode(int index)
        {
            return mNodes[index];
        }

        public static Node GetNode(int x, int y)
        {
            return mNodes[y*mWellData.Size + x];
        }

        public static Node[] GetRowNodes(int Y)
        {
            List<Node> RowNodes = new List<Node>();
            for(int i = 0; i < mWellData.Size; i++)
                RowNodes.Add(GetNode(i, Y));
            return RowNodes.ToArray();
        }

        public static Node[] GetColumnNodes(int X)
        {
            List<Node> ColumnNodes = new List<Node>();
            for (int i = 0; i < mWellData.Size; i++)
                ColumnNodes.Add(GetNode(X, i));
            return ColumnNodes.ToArray();
        }

        public static bool IsOblique(int index, out Node[] leftObliqueNodes, out Node[] rightObliqueNodes)
        {
            bool isOblique = false;
            var node = GetNode(index);
            leftObliqueNodes = null;
            rightObliqueNodes = null;

            if (node.X == node.Y)
            {
                List<Node> LONodes = new List<Node>();
                for (int i = 0; i < mWellData.Size; i++)
                    LONodes.Add(GetNode(i, i));
                leftObliqueNodes = LONodes.ToArray();
                isOblique = true;
            }

            if(node.X + node.Y == mWellData.Size - 1)
            {
                List<Node> RONodes = new List<Node>();
                for (int i = 0; i < mWellData.Size; i++)
                    RONodes.Add(GetNode(i, mWellData.Size-1-i));
                rightObliqueNodes = RONodes.ToArray();
                isOblique = true;
            }

            return isOblique;
        }
    }
}