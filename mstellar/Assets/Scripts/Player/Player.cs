﻿using System;
using UnityEngine;

public class Player : Actor
{
    #region Variables -> Private

    private PlayerController   playerController;

    private PlayerWeapons      playerWeapons;

    private PlayerCamera       playerCamera;

    private DFloatValue        armor;
    private DFloatValue        maxArmor;

    private Transform          transform;

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

        playerController = GetComponent<PlayerController>();
        playerController.SetMaxSpeed(((DPlayer)actorData).maxSpeed);

        playerWeapons = GetComponent<PlayerWeapons>();
        playerCamera = GetComponent<PlayerCamera>();

        transform = GetComponent<Transform>();
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


    private void ArmorDamage(ref float value) {
        if (armor > 0) {
            armor -= (float)Math.Round(value / 2);
            if (armor < 0) armor.SetValue(0);
            value = (float)Math.Round(value / 2);
        }
        else return;
    }

    private void HealthDamage(float value) {
        health -= value;
        if (health < 0) health.SetValue(0);
    }

    public override void TakeDamage(float value) {
        ArmorDamage(ref value);
        HealthDamage(value);

        ManagerAudio.Play(hurt);
        UIFlash.HurtFlash();
    }

    public void PickupHP(float value) {
        health += value;
        if (health > maxHealth) health.SetValue(maxHealth);
    }

    public void PickupArmor(float value) {
        armor += value;
        if (armor > maxArmor) armor.SetValue(maxArmor);
    }

    public bool IsFullOnHP() {
        return health.IsEqual(maxHealth);
    }

    public bool IsFullOnArmor() {
        return armor.IsEqual(maxArmor);
    }

    #endregion

    /* Debug.LogError() */
}

