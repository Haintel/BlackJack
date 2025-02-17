using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    public Text roomNameText;
    public Button joinButton;

    private RoomInfo roomInfo;

    public void Setup(RoomInfo room)
    {
        roomInfo = room;
        roomNameText.text = $"{room.roomName} ({room.maxPlayers}인)";

        joinButton.onClick.AddListener(JoinRoom);
    }

    void JoinRoom()
    {
        Debug.Log($"'{roomInfo.roomName}' 방에 참가 시도 중...");
        // 방 참가 기능 구현 예정 (네트워크 접속)
    }
}
