using UnityEngine;
using UnityEngine.UI;

public class UICurrentFloatValue : MonoBehaviour
{
    [SerializeField] private DFloatValue   floatValue     = null;

    private Text   text   = null;
    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        float value = floatValue;

        if(text.text != value.ToString()) {
            text.text = value.ToString();
        }
    }
}
