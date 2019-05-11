using UnityEngine;
using UnityEngine.UI;

public class DBugDeltaTime : MonoBehaviour
{
    private float time;

    public Text text;

    private void Update() {
        time += Time.deltaTime;
        text.text = time.ToString();
    }
}
