using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance; //싱글톤 할당할 전역변수
    public bool isGameover = false; //게임 오버 상태




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
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
