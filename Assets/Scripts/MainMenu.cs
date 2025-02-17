using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class MainMenu : MonoBehaviour
{
    public Button createRoomButton;
    public Button joinRoomButton;
    public Button quitButton;
    public Button optionButton; // 옵션 버튼
    public GameObject optionPanel; // 옵션 창 (UI 패널)
    public Button closeButton; // 옵션 창 내부의 Close 버튼

    private void Start()
    {
        createRoomButton.onClick.AddListener(CreateRoom);
        joinRoomButton.onClick.AddListener(JoinRoom);
        quitButton.onClick.AddListener(QuitGame);
        optionButton.onClick.AddListener(OpenOptions); // 옵션 열기
        closeButton.onClick.AddListener(CloseOptions); // 옵션 닫기
    }

    void CreateRoom()
    {
        CustomNetworkManager.Instance.StartHost(); // 호스트 생성

    }

    void JoinRoom()
    {
        CustomNetworkManager.Instance.StartClient(); // 클라이언트 접속
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void OpenOptions()
    {
        optionPanel.SetActive(true); // 옵션 창 활성화
    }

    void CloseOptions()
    {
        optionPanel.SetActive(false); // 옵션 창 비활성화
    }
}
