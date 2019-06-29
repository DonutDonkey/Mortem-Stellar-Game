using UnityEngine;
using UnityEngine.UI;

public class UIFlash : MonoBehaviour
{
    private static Animator   animator   = null;

    private static Image      image     = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }
    
    private void Stop() {
        animator.SetBool("NotActive", true);
    }

    public static void PickupFlash() {
        image.color = Color.yellow;
        animator.SetBool("NotActive", false);
    }

    public static void HurtFlash() {
        image.color = Color.red;
        animator.SetBool("NotActive", false);
    }
}
