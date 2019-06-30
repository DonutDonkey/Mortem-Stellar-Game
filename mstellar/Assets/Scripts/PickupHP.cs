using UnityEngine;

public class PickupHP : MonoBehaviour
{
    public AudioClip   audioClip    = null;

    public float       hpValue      = 10.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            Player player = other.GetComponent<Player>();

            if (player != null && !player.IsFullOnHP()) {
                player.PickupHP(hpValue);
                ManagerAudio.Play(audioClip);
                UIFlash.HpFlash();
                Destroy(gameObject);
            }
        }
    }
}
