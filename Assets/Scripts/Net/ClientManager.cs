using UnityEngine;
using System;
using System.Collections;
using System.Net.Sockets;
using Common;

/// <summary>
/// 这个是用来管理服务器端的socket连接
/// </summary>
public class ClientManager : BaseManager {
    public ClientManager(GameFacade facade) : base(facade) { }

    public const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;
    private Message msg = new Message();

    public override void OnInit()
    {
        base.OnInit();
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
        }catch(Exception e)
        {
            Debug.LogWarning("无法连接到服务器请检查您的网络！！" + e);
        }

    }

    void Start()
    {
        clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, null);
    }

    private void ReceiveCallBack(IAsyncResult asyncResult)
    {
        try
        {
            int count = clientSocket.EndReceive(asyncResult);
            msg.ReadMessage(count,OnProcessDataCallBack);
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnProcessDataCallBack(ActionCode actionCode,string data)
    {
        facade.HandleResponse(actionCode, data);
    }

    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            clientSocket.Close();
        }catch(Exception e)
        {
            Debug.LogWarning("无法关闭跟服务器端的连接！！" + e);
        }
    }
}