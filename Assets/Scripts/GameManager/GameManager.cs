using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance { get; private set; } //싱글톤 할당할 전역변수 프로퍼티로 만들기
    public bool isGameover = false; //게임 오버 상태
    [SerializeField] private GameObject mainParent;
    


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            mainParent.SetActive(false);
            
        }

        else
        {
            Destroy(gameObject);
            return;
        }

  
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main") 
        {
            StartCoroutine(DelayActivation()); //메인 씬 로드될 때 활성화
        }
    }

    private IEnumerator DelayActivation()
    {
        yield return null; 
        ActivateMainScene();
    }

    private void ActivateMainScene()
    {
        
        if (mainParent != null)
        {
            mainParent.SetActive(true);
        }
    }



    void Update()
    {
        if (isGameover)
        {

        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
    }
}
