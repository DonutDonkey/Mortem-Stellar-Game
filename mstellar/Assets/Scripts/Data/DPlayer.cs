using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Game Specific Objects/Player")]
public class DPlayer : DActor
{
    public float armor;

    public float maxArmor;

    public float maxSpeed;

    public DPlayer() {
        maxHealth = 100.0f;
        maxArmor = 50.0f;
        maxSpeed = 10.0f;

        health = maxHealth;
        armor = 0.0f;
    }
}
