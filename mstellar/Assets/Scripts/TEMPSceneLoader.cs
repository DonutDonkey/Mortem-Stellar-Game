using UnityEngine;
using UnityEngine.SceneManagement;

public class TEMPSceneLoader : MonoBehaviour
{
    public int sceneIndx;

    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter(Collider other) {
        LoadScene(sceneIndx);
    }
}
