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

    // 플레이어가 접속하면 리스트에 추가
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        players.Add(conn);
    }

    // 플레이어가 나가면 리스트에서 제거
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        players.Remove(conn);
        base.OnServerDisconnect(conn);
    }

    // 모든 플레이어가 준비되면 게임 시작
    [Server]
    public void CheckAllPlayersReady()
    {
        bool allReady = true;

        foreach (var conn in players)
        {
            if (conn.identity == null) continue; // null 체크 추가

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

