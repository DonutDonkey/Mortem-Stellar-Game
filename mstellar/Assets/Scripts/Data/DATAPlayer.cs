using System;
using UnityEngine;

[Serializable]
public struct SDPlayer {
    public Quaternion   rotation;
    public Vector3      position;

    public float        health;
    public float        maxHealth;
    public float        armor;
    public float        maxArmor;
    public float        maxSpeed;

    public bool         isAlive;

    public int          activeIndex;

    public SDPlayer(DPlayer dPlayer, Transform transform) {
        health = dPlayer.health;
        maxHealth = dPlayer.maxHealth;
        armor = dPlayer.armor;
        maxArmor = dPlayer.maxArmor;
        maxSpeed = dPlayer.maxSpeed;
        isAlive = dPlayer.isAlive;
        position = transform.position;
        rotation = transform.rotation;
        activeIndex = PlayerWeapons.activeIndex;
    }
}

[Serializable]
public struct SDWeapon {
    public float   ammoNumber;

    public bool    isInInventory;

    public SDWeapon(DWeapon dWeapon) {
        ammoNumber = dWeapon.AmmoNumber;
        isInInventory = dWeapon.IsInInventory;
    }
}
