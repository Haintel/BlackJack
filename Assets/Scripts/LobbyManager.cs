using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviour
{
    public GameObject createRoomPanel;  // 방 생성 창
    public GameObject roomListPanel;    // 방 검색 창

    public Dropdown playerCountDropdown; // 2인 / 3인 / 4인 선택
    public InputField roomNameInput;     // 방 이름 입력
    public InputField passwordInput;     // 방 비밀번호 입력

    public Button createRoomButton;      // 방 생성 버튼
    public Button searchRoomButton;      // 방 검색 버튼
    public Button closeCreatePanelButton;// 방 생성 창 닫기
    public Button closeRoomListButton;   // 방 검색 창 닫기

    public Transform roomListContent;    // 방 목록이 표시될 Scroll View의 Content
    public GameObject roomListItemPrefab;// 방 목록 UI 프리팹

    private List<RoomInfo> roomList = new List<RoomInfo>(); // 현재 존재하는 방 목록

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
            Debug.Log("방 이름을 입력하세요!");
            return;
        }

        RoomInfo newRoom = new RoomInfo(roomName, password, maxPlayers);
        roomList.Add(newRoom);
        Debug.Log($"방 생성됨: {roomName} (최대 {maxPlayers}인)");

        createRoomPanel.SetActive(false); // 창 닫기
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

// 방 정보를 저장하는 클래스
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
