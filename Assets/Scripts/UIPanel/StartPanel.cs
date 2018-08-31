using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : BasePanel
{
    Button loginButton;
    public override void OnEnter()
    {
        base.OnEnter();
        loginButton = this.transform.Find("LoginButton").GetComponent<Button>();
        loginButton.onClick.AddListener(OnClickLoginButton);
    }


    void OnClickLoginButton()
    {
        uiMng.PushPanel(UIPanelType.Login);
    }
    public override void OnPause()
    {
        base.OnPause();
        loginButton.transform.DOScale(0, 0.4f).OnComplete(() => loginButton.enabled = false);
    }
    public override void OnResume()
    {
        base.OnResume();
        loginButton.transform.DOScale(1, 0.4f).OnComplete(() => loginButton.enabled = true);
    }
}
