using UnityEngine;
using System.Collections;
using Common;

public class LoginRequest : BaseRequest
{
    private void Start()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
    }

    public void SendRequest(string username,string password)
    {
        string data = username + "," + password;
        base.SendRequest(data);
    }
}
