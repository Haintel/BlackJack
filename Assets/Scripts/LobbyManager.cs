using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviour
{
    public GameObject createRoomPanel;  // �� ���� â
    public GameObject roomListPanel;    // �� �˻� â

    public Dropdown playerCountDropdown; // 2�� / 3�� / 4�� ����
    public InputField roomNameInput;     // �� �̸� �Է�
    public InputField passwordInput;     // �� ��й�ȣ �Է�

    public Button createRoomButton;      // �� ���� ��ư
    public Button searchRoomButton;      // �� �˻� ��ư
    public Button closeCreatePanelButton;// �� ���� â �ݱ�
    public Button closeRoomListButton;   // �� �˻� â �ݱ�

    public Transform roomListContent;    // �� ����� ǥ�õ� Scroll View�� Content
    public GameObject roomListItemPrefab;// �� ��� UI ������

    private List<RoomInfo> roomList = new List<RoomInfo>(); // ���� �����ϴ� �� ���

    private void Start()
    {
        createRoomPanel.SetActive(false);
        roomListPanel.SetActive(false);

        createRoomButton.onClick.AddListener(OpenCreateRoomPanel);
        searchRoomButton.onClick.AddListener(SearchRooms);
        closeCreatePanelButton.onClick.AddListener(() => createRoomPanel.SetActive(false));
        closeRoomListButton.onClick.AddListener(() => roomListPanel.SetActive(false));
    }

    void OpenCreateRoomPanel()
    {
        createRoomPanel.SetActive(true);
    }

    public void CreateRoom()
    {
        string roomName = roomNameInput.text;
        string password = passwordInput.text;
        int maxPlayers = int.Parse(playerCountDropdown.options[playerCountDropdown.value].text);

        if (string.IsNullOrEmpty(roomName))
        {
            Debug.Log("�� �̸��� �Է��ϼ���!");
            return;
        }

        RoomInfo newRoom = new RoomInfo(roomName, password, maxPlayers);
        roomList.Add(newRoom);
        Debug.Log($"�� ������: {roomName} (�ִ� {maxPlayers}��)");

        createRoomPanel.SetActive(false); // â �ݱ�
    }

    void SearchRooms()
    {
        roomListPanel.SetActive(true);
        UpdateRoomListUI();
    }

    void UpdateRoomListUI()
    {
        foreach (Transform child in roomListContent)
        {
            Destroy(child.gameObject);
        }

        foreach (RoomInfo room in roomList)
        {
            GameObject roomItem = Instantiate(roomListItemPrefab, roomListContent);
            roomItem.GetComponent<RoomListItem>().Setup(room);
        }
    }
}

// �� ������ �����ϴ� Ŭ����
public class RoomInfo
{
    public string roomName;
    public string password;
    public int maxPlayers;

    public RoomInfo(string roomName, string password, int maxPlayers)
    {
        this.roomName = roomName;
        this.password = password;
        this.maxPlayers = maxPlayers;
    }
}
