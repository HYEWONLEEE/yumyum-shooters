using UnityEngine;
using UnityEngine.SceneManagement;
//����� �Ŵ��� ��ũ��Ʈ
//BGM ���� ����
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
