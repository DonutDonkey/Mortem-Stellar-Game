using UnityEngine;

public class UIFlash : MonoBehaviour
{
    private static Animator   animator   = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Stop() {
        animator.SetBool("NotActive", true);
    }

    public static void FlashScreen() {
        animator.SetBool("NotActive", false);
    }
}
