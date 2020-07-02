using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public interface IMenuView
    {
        void HideMenu();

        void SetListener(IMenuListener menuListener);

        void ShowStartButton();

        void ShowWinner(GameLogic.Round round);

        void ShowTie();
    }
}