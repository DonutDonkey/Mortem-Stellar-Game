using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    [SerializeField] private DWeapon   weapon   = null;

    public AudioClip   audioClip    = null;

    public float       ammoNumber   = 0.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            if (weapon.AmmoNumber != weapon.MaxAmmoNumber) {
                UIFlash.PickupFlash();
                ManagerAudio.Play(audioClip);
                if ((float)weapon.AmmoNumber + ammoNumber > weapon.MaxAmmoNumber) {
                    ammoNumber = weapon.MaxAmmoNumber - weapon.AmmoNumber;
                }
                weapon.AmmoNumber += ammoNumber;

                Destroy(gameObject);
            }
        }
    }
}
