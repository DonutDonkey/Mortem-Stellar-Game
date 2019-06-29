using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    [SerializeField] private DWeapon   weapon   = null;

    public float   ammoNumber   = 0.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            if (weapon.AmmoNumber != weapon.MaxAmmoNumber) {
                UIFlash.FlashScreen();
                if ((float)weapon.AmmoNumber + ammoNumber > weapon.MaxAmmoNumber) {
                    ammoNumber = weapon.MaxAmmoNumber - weapon.AmmoNumber;
                }
                weapon.AmmoNumber += ammoNumber;

                Destroy(gameObject);
            }
        }
    }
}
