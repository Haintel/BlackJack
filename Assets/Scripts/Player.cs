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

    // ? 준비 상태 변경 (클라이언트 → 서버 요청)
    [Command]
    public void CmdSetReadyState(bool readyState)
    {
        isReady = readyState;
        networkManager.CheckAllPlayersReady();
    }

    // ?? UI 업데이트 (준비 상태 변경 시 실행)
    void OnReadyStateChanged(bool oldValue, bool newValue)
    {
        Debug.Log($"플레이어 준비 상태 변경됨: {oldValue} → {newValue}");
    }
}

