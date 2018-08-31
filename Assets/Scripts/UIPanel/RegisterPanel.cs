using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class RegisterPanel : BasePanel
{
    private InputField usernameIF;
    private InputField passwordIF;
    private InputField repasswordIF;
    private Button registerButton;
    private Button cancelButton;

    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.localPosition = new Vector3(0, 500, 0);
        transform.DOScale(1, 0.8f);
        transform.DOLocalMove(Vector3.zero, 0.4f, false).OnComplete(() => {
            transform.DOShakePosition(0.5f, 50);
        });

        usernameIF = transform.Find("UsernameLabel/UsernameInput").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordLabel/PasswordInput").GetComponent<InputField>();
        repasswordIF = transform.Find("RePasswordLabel/RePasswordInput").GetComponent<InputField>();
        registerButton = transform.Find("RegisterButton").GetComponent<Button>();
        cancelButton = transform.Find("CloseButton").GetComponent<Button>();

        registerButton.onClick.AddListener(OnClickRegisterButn);
        cancelButton.onClick.AddListener(OnClickCancelButn);
    }

    private void InitIFText()
    {
        usernameIF.text = "";
        passwordIF.text = "";
        repasswordIF.text = "";
    }

    private void OnClickCancelButn()
    {
        uiMng.PushPanel(UIPanelType.Login);
    }

    private void OnClickRegisterButn()
    {
        
    }

    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
