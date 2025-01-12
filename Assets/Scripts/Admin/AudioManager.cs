using UnityEngine;
using UnityEngine.SceneManagement;
//오디오 매니저 스크립트
//BGM 실행 관리
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Main")
        {
            audioSource.enabled = true;
        }

        else 
            audioSource.enabled = false;
    }

}
