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
        roomNameText.text = $"{room.roomName} ({room.maxPlayers}��)";

        joinButton.onClick.AddListener(JoinRoom);
    }

    void JoinRoom()
    {
        Debug.Log($"'{roomInfo.roomName}' �濡 ���� �õ� ��...");
        // �� ���� ��� ���� ���� (��Ʈ��ũ ����)
    }
}
