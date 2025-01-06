using UnityEngine;
//일시정지를 관리하는 싱글톤 객체
public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;
    public GameObject pausePanel; //일시정지 UI 패널
    private bool isPaused = false;

    private void Awake() //싱글톤 할당
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
            TogglePause(); //esc 버튼으로 토글 
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused; //일시정지 상태 토글
        if (isPaused) //일시정지 상태여야 할 경우
            PauseGame(); //일시정지 메서드 실행
        else
            ResumeGame(); //일시정지 해제로 토긂되면 게임 재개
    }

    public void PauseGame() //게임 일시정지 메서드
    {
        Time.timeScale = 0f; //게임 정지
        pausePanel.SetActive(true); //일시정지 패널 표시
    }

    public void ResumeGame() //게임 재개 메서드
    {
        Time.timeScale = 1f; //게임 재개
        pausePanel.SetActive(false); //일시정지 패널 숨기기
    }

    public void PauseForLevelUp() //레벨업 상황에서 강제 일시정지하는 메서드
    {
        Time.timeScale = 0;
    }
}
