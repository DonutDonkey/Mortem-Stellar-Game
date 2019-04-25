using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IActor
{
    [SerializeField]
    protected DActor actorData = null;

    protected float health = 0.0f;

    protected float maxHealth = 0.0f;

    //public List<Collider> List; for more advanced projects reminder

    public virtual void Start() {
        maxHealth = actorData.maxHealth;

        health = maxHealth;
    }

    public void TakeDamage(float damageNumber) {
        health = health - damageNumber;
    }

    public float GetHealth() {
        return health;
    }
}
