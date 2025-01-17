using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance { get; private set; } //싱글톤 할당할 전역변수 프로퍼티로 만들기
    public static bool isGameover = false; //게임 오버 상태, static 으로 사용
    [SerializeField] private GameObject mainParent;
    public GameObject gameOverCanvas;
    


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(gameOverCanvas);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

  
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title")
        {
            mainParent.SetActive(false); //제발돼라 타이틀 씬일때는 실행되지 않기 제발쩜!!!
        }
        if (scene.name == "Main") 
        {
            mainParent = GameObject.Find("mainParent"); //메인 씬의 부모를 찾고 비활성화 후 활성화
            if (mainParent != null)
            {
                StartCoroutine(ActivateMainScene());
            }
            
        }

        else
        {
            if (mainParent != null)
            {
                mainParent.SetActive(false); //메인 씬 아니면 비활성화
            }
        }
    }


    private IEnumerator ActivateMainScene()
    {
        yield return null; //한 프레임 대기 
        if (mainParent != null)
        {
            mainParent.SetActive(true);
        }
    }



    void Update()
    {
        if (isGameover)
        {
            GameOver();
        }
    }


    private void GameOver() //게임 오버 시 실행될 메서드
    {
        gameOverCanvas.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            isGameover = false;
            gameOverCanvas.SetActive(false);
            SceneManager.LoadScene("Main");

        }
    }
}
