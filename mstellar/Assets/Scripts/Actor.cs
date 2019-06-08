using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IActor
{
    #region Variables -> Serialized Protected

    [Tooltip("Actor scriptable object data")]
    [SerializeField] protected DActor   actorData   = null;

    #endregion

    #region Variables -> Protected

    protected float   health      = 0.0f;
    protected float   maxHealth   = 0.0f;

    protected bool    isAlive     = true;

    #endregion

    //public List<Collider> List; for more advanced projects reminder

    //testCollider.enabled = !testCollider.enabled;

    #region Unity - Callbacks

    public virtual void Start() {
        maxHealth = actorData.maxHealth;

        health = maxHealth;
    }

    public virtual void Update() {

    }

    #endregion

    #region Methods -> Public

    /// <summary>
    /// Reduce actor health by damage number
    /// </summary>
    public void TakeDamage(float damageNumber) {
        health = health - damageNumber;
    }

    /// <summary>
    /// Return actor health
    /// </summary>
    public float GetHealth() {
        return health;
    }

    #endregion
}
