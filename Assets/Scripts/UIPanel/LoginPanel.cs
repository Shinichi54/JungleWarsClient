using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class LoginPanel : BasePanel
{

    private Button CloseButn;
    private InputField usernameIF;
    private InputField passwordIF;
    private Button loginButton;
    private Button registerButton;

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.localPosition = new Vector3(0, 500, 0);
        transform.DOScale(1, 0.8f);
        transform.DOLocalMove(Vector3.zero, 0.4f, false).OnComplete(() => {
            transform.DOShakePosition(0.5f, 50);
        });

        usernameIF = transform.Find("UsernameLabel/UsernameInput").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordLabel/PasswordInput").GetComponent<InputField>();
        loginButton = transform.Find("LoginButton").GetComponent<Button>();
        registerButton = transform.Find("RegisterButton").GetComponent<Button>();
        CloseButn = transform.Find("CloseButton").GetComponent<Button>();

        loginButton.onClick.AddListener(OnClickLoginButn);
        registerButton.onClick.AddListener(OnClickRegisterButn);
        CloseButn.onClick.AddListener(OnCLickCloseButn);
    }

    private void OnClickRegisterButn()
    {
        uiMng.PushPanel(UIPanelType.Rigster);
    }

    private void OnClickLoginButn()
    {
        if(usernameIF.text != null && passwordIF.text.Length > 3 && passwordIF.text.Length < 9){
            
        }else{
            uiMng.ShowMessage("用户名或密码格式错误");
        }
    }

    void OnCLickCloseButn()
    {
        transform.DOScale(0, 0.2f);
        transform.DOLocalMove(new Vector3(0, 500, 0), 0.2f).OnComplete(() =>
        {
            uiMng.PopPanel();
        });
    }

    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
