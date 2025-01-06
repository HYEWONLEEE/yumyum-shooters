using UnityEngine;
//�Ͻ������� �����ϴ� �̱��� ��ü
public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;
    public GameObject pausePanel; //�Ͻ����� UI �г�
    private bool isPaused = false;

    private void Awake() //�̱��� �Ҵ�
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); //esc ��ư���� ��� 
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused; //�Ͻ����� ���� ���
        if (isPaused) //�Ͻ����� ���¿��� �� ���
            PauseGame(); //�Ͻ����� �޼��� ����
        else
            ResumeGame(); //�Ͻ����� ������ ��E�Ǹ� ���� �簳
    }

    public void PauseGame() //���� �Ͻ����� �޼���
    {
        Time.timeScale = 0f; //���� ����
        pausePanel.SetActive(true); //�Ͻ����� �г� ǥ��
    }

    public void ResumeGame() //���� �簳 �޼���
    {
        Time.timeScale = 1f; //���� �簳
        pausePanel.SetActive(false); //�Ͻ����� �г� �����
    }

    public void PauseForLevelUp() //������ ��Ȳ���� ���� �Ͻ������ϴ� �޼���
    {
        Time.timeScale = 0;
    }
}
