using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class MainMenu : MonoBehaviour
{
    public Button createRoomButton;
    public Button joinRoomButton;
    public Button quitButton;
    public Button optionButton; // �ɼ� ��ư
    public GameObject optionPanel; // �ɼ� â (UI �г�)
    public Button closeButton; // �ɼ� â ������ Close ��ư

    private void Start()
    {
        createRoomButton.onClick.AddListener(CreateRoom);
        joinRoomButton.onClick.AddListener(JoinRoom);
        quitButton.onClick.AddListener(QuitGame);
        optionButton.onClick.AddListener(OpenOptions); // �ɼ� ����
        closeButton.onClick.AddListener(CloseOptions); // �ɼ� �ݱ�
    }

    void CreateRoom()
    {
        CustomNetworkManager.Instance.StartHost(); // ȣ��Ʈ ����

    }

    void JoinRoom()
    {
        CustomNetworkManager.Instance.StartClient(); // Ŭ���̾�Ʈ ����
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void OpenOptions()
    {
        optionPanel.SetActive(true); // �ɼ� â Ȱ��ȭ
    }

    void CloseOptions()
    {
        optionPanel.SetActive(false); // �ɼ� â ��Ȱ��ȭ
    }
}
