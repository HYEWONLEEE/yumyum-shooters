using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Canvas titleCanvas;

    public void StartGame()
    {

        SceneManager.LoadScene("Main", LoadSceneMode.Single);

    }
}
