using UnityEngine;

public class PickupArmor : MonoBehaviour
{
    public AudioClip   audioClip    = null;

    public float       armorValue   = 10.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            Player player = other.GetComponent<Player>();

            if (player != null && !player.IsFullOnArmor()) {
                player.PickupArmor(armorValue);
                ManagerAudio.Play(audioClip);
                UIFlash.ArmorFlash();
                Destroy(gameObject);
            }
        }
    }
}
