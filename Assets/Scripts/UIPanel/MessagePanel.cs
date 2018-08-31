using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessagePanel : BasePanel
{
    private Text text;
    private float showTime = 1;
    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        uiMng.InjectMsgPanel(this);
    }

    public void ShowMessage(string msg)
    {
        text.text = msg;
        text.CrossFadeAlpha(1, 1, false);
        text.enabled = true;
        Invoke("FadeAlpha", showTime);
    }

    public void FadeAlpha()
    {
        text.CrossFadeAlpha(0, 1, false);
        Invoke("Hide", showTime);
    }
    public void Hide()
    {
        text.enabled = false;
    }

}
