using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImageFillSetter : MonoBehaviour
{
    [SerializeField]
    private DFloatValue fillAmount = null;

    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }
    private void Update() {
        image.fillAmount = fillAmount;
    }
}
