using UnityEngine;

public class Player : Actor
{
    #region Variables -> Private

    private PlayerController   controller;
    private PlayerWeapons      weapons;

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

        weapons = GetComponent<PlayerWeapons>();
    }

    public override void Update() {
    }

    private void OnTriggerEnter(UnityEngine.Collider other) {
        if(other.tag == "WEP_02") {
            weapons.PickupWeapon(2);
            other.gameObject.SetActive(false);
        }
    }

    #endregion

    /* Debug.LogError() */
}

