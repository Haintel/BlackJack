using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class LobbyUI : MonoBehaviour
{
    public Button readyButton;
    private Player player;

    private void Start()
    {
        player = NetworkClient.localPlayer.GetComponent<Player>();
        readyButton.onClick.AddListener(ToggleReady);
    }

    void ToggleReady()
    {
        player.CmdSetReadyState(!player.isReady);
    }
}

