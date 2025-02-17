using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnReadyStateChanged))]
    public bool isReady = false;

    private CustomNetworkManager networkManager;

    private void Start()
    {
        networkManager = CustomNetworkManager.Instance;
    }

    // ? �غ� ���� ���� (Ŭ���̾�Ʈ �� ���� ��û)
    [Command]
    public void CmdSetReadyState(bool readyState)
    {
        isReady = readyState;
        networkManager.CheckAllPlayersReady();
    }

    // ?? UI ������Ʈ (�غ� ���� ���� �� ����)
    void OnReadyStateChanged(bool oldValue, bool newValue)
    {
        Debug.Log($"�÷��̾� �غ� ���� �����: {oldValue} �� {newValue}");
    }
}

