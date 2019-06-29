using UnityEngine;
using UnityEngine.UI;

public class UICurrentAmmoSettings : MonoBehaviour
{
    [SerializeField] private DFloatValue   ammo     = null;

    [SerializeField] private DWeapon       weapon   = null;

    private Text   text   = null;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        float value = ammo;
        if (text.text != value.ToString()) {
            if(AmmoPercentile(value) > 50) {
                UpdateColors(Color.green);
            } else if (AmmoPercentile(value) > 25) {
                UpdateColors(Color.yellow);
            } else if (AmmoPercentile(value) < 25) {
                UpdateColors(Color.blue);
            }
            text.text = value.ToString();
        }
    }

    private float AmmoPercentile(float value) {
        return (value /weapon.MaxAmmoNumber) * 100;
    }

    private void UpdateColors(Color color) {
        text.color = color;
    }
}
