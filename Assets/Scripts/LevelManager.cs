using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{



    public void Play()
    {
        SceneManager.LoadScene("Rafli");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
