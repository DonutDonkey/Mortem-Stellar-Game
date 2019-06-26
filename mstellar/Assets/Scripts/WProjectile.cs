using UnityEngine;

public class WProjectile : MonoBehaviour
{
    private AudioSource   audioSource       = null;

    private Rigidbody     rigidbody         = null;

    private Vector3       originPosition    = Vector3.zero;

    public float          projectileSpeed   = 1.0f;

    public float          distance          = 100f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        rigidbody.velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);
        originPosition = transform.position;
    }

    private void Update() {
        if (CheckIfOutOfRange()) gameObject.SetActive(false);
    }

    private bool CheckIfOutOfRange() {
        return Vector3.Distance(originPosition, transform.position) > distance;
    }

    private void OnTriggerEnter(Collider other) {
        audioSource.Play();
        gameObject.SetActive(false);
    }
}
