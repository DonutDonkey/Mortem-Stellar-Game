using UnityEngine;

public class WProjectile : MonoBehaviour
{
    #region Variables -> Private

    private Rigidbody     rigidbody        = null;

    private Vector3       originPosition   = Vector3.zero;

    #endregion

    #region Variables -> Public

    public GameObject   impact                = null;

    public float        projectileSpeed       = 1.0f;
    public float        distance              = 100f;
    public float        damageFalloffRadius   = 2.0f;

    #endregion

    #region Methods -> Unity Callbacks

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        impact = Instantiate(impact) as GameObject;
    }

    private void OnEnable() {
        rigidbody.velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);
        originPosition = transform.position;
    }

    private void OnDisable() {
        Debug.Log("SET ACTIVE FALSE");
    }

    private void Update() {
        if (CheckIfOutOfRange()) gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        AudioSource source = impact.GetComponent<AudioSource>();
        ParticleSystem particle = impact.GetComponent<ParticleSystem>();

        impact.transform.position = transform.position;
        source.Play();
        particle.Play();

        gameObject.SetActive(false);

        if(Physics.SphereCast(transform.position, damageFalloffRadius, transform.forward, out RaycastHit hit)) {
            Actor actor = hit.transform.GetComponent<Actor>();
        }
    }

    //private void OnDrawGizmos() {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, damageFalloffRadius);
    //}

    #endregion

    #region Methods -> Private

    private bool CheckIfOutOfRange() {
        return Vector3.Distance(originPosition, transform.position) > distance;
    }

    #endregion
}
