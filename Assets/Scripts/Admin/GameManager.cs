using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance { get; private set; } //�̱��� �Ҵ��� �������� ������Ƽ�� �����
    public bool isGameover = false; //���� ���� ����
    [SerializeField] private GameObject mainParent;
    


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
            mainParent.SetActive(false); //���ߵŶ� Ÿ��Ʋ ���϶��� ������� �ʱ� ������!!!
        }
        if (scene.name == "Main") 
        {
            mainParent = GameObject.Find("mainParent"); //���� ���� �θ� ã�� ��Ȱ��ȭ �� Ȱ��ȭ
            if (mainParent != null)
            {
                StartCoroutine(ActivateMainScene());
            }
        }

        else
        {
            if (mainParent != null)
            {
                mainParent.SetActive(false); //���� �� �ƴϸ� ��Ȱ��ȭ
            }
        }
    }


    private IEnumerator ActivateMainScene()
    {
        yield return null; //�� ������ ��� 
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
