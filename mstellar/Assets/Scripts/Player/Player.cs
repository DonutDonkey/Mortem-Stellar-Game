using UnityEngine;

public class Player : Actor
{
    #region Variables -> Private

    private PlayerController   controller;
    private PlayerWeapons      playerWeapons;

    private DFloatValue        armor;
    private DFloatValue        maxArmor;

    private int                level;

    #endregion

    #region Variables -> Public

    public AudioClip   weapon01pickup   = null;
    public AudioClip   weapon02pickup   = null;

    #endregion

    #region Variables -> UnityCallbacks

    public override void Start() {
        base.Start();

        maxArmor = ((DPlayer)actorData).maxArmor;
        armor = ((DPlayer)actorData).armor;

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
            UIFlash.PickupFlash(); ManagerAudio.Play(weapon01pickup);
        }

        if (other.CompareTag("WEP_02")) {
            playerWeapons.PickupWeapon(2);
            other.gameObject.SetActive(false);
            UIFlash.PickupFlash(); ManagerAudio.Play(weapon02pickup);
        }
    }

    public override void TakeDamage(float value) {
        HealthDamage(value);
        ArmorDamage(value);

        ManagerAudio.Play(hurt);
        UIFlash.HurtFlash();
    }

    private void HealthDamage(float value) {
        health -= value - armor;
        if (health < 0) health -= health;
    }

    private void ArmorDamage(float value) {
        armor -= value;
        if (armor < 0) armor -= armor;
    }

    #endregion

    /* Debug.LogError() */
}

