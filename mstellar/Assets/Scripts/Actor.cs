using UnityEngine;

public class Actor : MonoBehaviour, IActor
{
    #region Variables -> Serialized Protected

    [Tooltip("Actor scriptable object data")]
    [SerializeField] protected DActor   actorData   = null;

    #endregion

    #region Variables -> Protected

    protected DFloatValue   health      = null;
    protected DFloatValue   maxHealth   = null;

    protected bool          isAlive     = true;

    #endregion

    #region Variables -> Public 

    public AudioClip   hurt   = null;

    #endregion

    //public List<Collider> List; for more advanced projects reminder

    //testCollider.enabled = !testCollider.enabled;

    #region Unity - Callbacks

    public virtual void Start() {
        maxHealth = actorData.maxHealth;
        health = actorData.health;
    }

    public virtual void Update() {

    }

    #endregion

    #region Methods -> Public

    /// <summary>
    /// Reduce actor health by damage number
    /// </summary>
    public virtual void TakeDamage(float damageNumber) {
        health = health - damageNumber;
        //3d audio
        Debug.Log("ACTOR TAKE DAMAGE");
    }

    /// <summary>
    /// Return actor health
    /// </summary>
    public float GetHealth() {
        return health;
    }

    #endregion
}
