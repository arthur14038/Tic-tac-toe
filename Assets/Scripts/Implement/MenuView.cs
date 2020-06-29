using Controller;
using UnityEngine;
using UnityEngine.UI;
using View;

public class MenuView : MonoBehaviour, IMenuView
{
    [SerializeField]
    RectTransform m_MenuRoot;
    [SerializeField]
    Button m_StartButton;
    [SerializeField]
    RectTransform m_WinnerRoot;
    [SerializeField]
    Text m_TextWinner;
    [SerializeField]
    Button m_OKButton;

    IMenuListener mMenuListener = null;

    public void HideMenu()
    {
        m_MenuRoot.gameObject.SetActive(false);
    }

    public void SetListener(IMenuListener menuListener)
    {
        mMenuListener = menuListener;
        m_StartButton.onClick.AddListener(() => { mMenuListener.OnClickStart(); });
        m_OKButton.onClick.AddListener(() => { mMenuListener.OnClickOK(); });
    }

    public void ShowStartButton()
    {
        m_MenuRoot.gameObject.SetActive(true);
        m_WinnerRoot.gameObject.SetActive(false);
        m_StartButton.gameObject.SetActive(true);
    }

    public void ShowWinner(GameLogic.Round round)
    {
        m_MenuRoot.gameObject.SetActive(true);
        m_WinnerRoot.gameObject.SetActive(true);
        m_StartButton.gameObject.SetActive(false);
        m_TextWinner.text = string.Format("{0} is Winner!", round);
    }
}
