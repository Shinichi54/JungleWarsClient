using UnityEngine;
using System.Collections;
using Common;
using System;

public class GameFacade : MonoBehaviour{

    private static GameFacade _instance;
    public static GameFacade Instance { get { return _instance; } }

    private UIManager uiMng;
    private AudioManager audioMng;
    private PlayerManager playerMng;
    private CameraManager cameraMng;
    private RequestManager requestMng;
    private ClientManager clientMng;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    {
        InitManager();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    private void InitManager()
    {
        uiMng = new UIManager(this);
        audioMng= new AudioManager(this);
        playerMng = new PlayerManager(this);
        cameraMng = new CameraManager(this);
        requestMng = new RequestManager(this);
        clientMng = new ClientManager(this);

        uiMng.OnInit();
        audioMng.OnInit();
        playerMng.OnInit();
        cameraMng.OnInit();
        requestMng.OnInit();
        clientMng.OnInit();
    }

    private void DestroyManager()
    {
        uiMng.OnDestroy();
        audioMng.OnDestroy();
        playerMng.OnDestroy();
        cameraMng.OnDestroy();
        requestMng.OnDestroy();
        clientMng.OnDestroy();
    }

    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        requestMng.AddRequest(actionCode, request);
    }
    public void RemoveRequest(ActionCode actionCode)
    {
        requestMng.RemoveRequest(actionCode);
    }
    public void HandleResponse(ActionCode actionCode, string data)
    {
        requestMng.HandleResponse(actionCode, data);
    }
    public void ShowMessage(string msg)
    {
        uiMng.ShowMessage(msg);
    }
    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        clientMng.SendRequest(requestCode, actionCode, data);
    }
}
