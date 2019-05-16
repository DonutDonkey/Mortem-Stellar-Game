using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex;

    public void PlayButton() {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
