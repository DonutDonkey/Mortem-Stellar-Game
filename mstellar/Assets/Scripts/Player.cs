using UnityEngine;

public class Player : Actor
{
    #region Variables -> Private

    private PlayerController   controller;
    private PlayerWeapons      playerWeapons;

    private float              armor;
    private float              maxArmor;

    private int                level;

    #endregion

    #region Variables -> UnityCallbacks

    public override void Start() {
        base.Start();

        maxArmor = ((DPlayer)actorData).maxArmor;
        armor = maxArmor;

        controller = GetComponent<PlayerController>();
        controller.SetMaxSpeed(((DPlayer)actorData).maxSpeed);

        playerWeapons = GetComponent<PlayerWeapons>();
    }

    public override void Update() {
    }

    private void OnTriggerEnter(UnityEngine.Collider other) {
        if (other.tag.Contains("WEP")) WeaponPickup(other);
    }

    private void WeaponPickup(Collider other) {
        if (other.CompareTag("WEP_01")) {
            playerWeapons.PickupWeapon(1);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("WEP_02")) {
            playerWeapons.PickupWeapon(2);
            other.gameObject.SetActive(false);
        }
    }

    #endregion

    /* Debug.LogError() */
}

