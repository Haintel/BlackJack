using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class CustomNetworkManager : NetworkManager
{
    public static CustomNetworkManager Instance { get; private set; }

    public List<NetworkConnectionToClient> players = new List<NetworkConnectionToClient>();

    public override void Awake() 
    {
        if (Instance == null)
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // �÷��̾ �����ϸ� ����Ʈ�� �߰�
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        players.Add(conn);
    }

    // �÷��̾ ������ ����Ʈ���� ����
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        players.Remove(conn);
        base.OnServerDisconnect(conn);
    }

    // ��� �÷��̾ �غ�Ǹ� ���� ����
    [Server]
    public void CheckAllPlayersReady()
    {
        bool allReady = true;

        foreach (var conn in players)
        {
            if (conn.identity == null) continue; // null üũ �߰�

            Player player = conn.identity.GetComponent<Player>();
            if (player == null || !player.isReady)
            {
                allReady = false;
                break;
            }
        }


        if (allReady)
        {
            ServerChangeScene("GameRoomScene");
        }
    }
}

