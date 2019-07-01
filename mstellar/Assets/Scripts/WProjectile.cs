using System;
using UnityEngine;

public class WProjectile : MonoBehaviour
{
    #region Variables -> Private

    private Rigidbody     rigidbody        = null;

    private Vector3       originPosition   = Vector3.zero;

    #endregion

    #region Variables -> Public

    public GameObject    impact                = null;

    public DFloatValue   damage                = null;

    public float         projectileSpeed       = 1.0f;
    public float         distance              = 100f;
    public float         damageFalloffRadius   = 2.5f;

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
        AudioSource source; ParticleSystem particle;

        GetImpactComponents(out source, out particle);
        SpawnImpactParticles(source, particle);

        gameObject.SetActive(false);

        Collider[] hit = Physics.OverlapSphere(transform.position, damageFalloffRadius);

        foreach (Collider i in hit) {
            DamageActorsIfHit(i);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageFalloffRadius);
    }

    #endregion

    #region Methods -> Private

    private bool CheckIfOutOfRange() {
        return Vector3.Distance(originPosition, transform.position) > distance;
    }

    private void GetImpactComponents(out AudioSource source, out ParticleSystem particle) {
        source = impact.GetComponent<AudioSource>();
        particle = impact.GetComponent<ParticleSystem>();
    }

    private void SpawnImpactParticles(AudioSource source, ParticleSystem particle) {
        impact.transform.position = transform.position;
        source.Play();
        particle.Play();
    }

    private void DamageActorsIfHit(Collider i) {
        Actor actor = i.transform.GetComponent<Actor>();

        if (actor != null) {
            float calculatedDamage = CalculateDamageFalloff(actor);
            Debug.Log(calculatedDamage);
            actor.TakeDamage(calculatedDamage);
        }
    }

    private float CalculateDamageFalloff(Actor actor) {
        if (DamageCalculation(actor) > 100) {
            return 100;
        } else {
            return DamageCalculation(actor);
        }
    }

    private float DamageCalculation(Actor actor) {
        return (float)Math.Round(damage / (float)Math.Round(Vector3.Distance(transform.position, actor.transform.position)));
    }

    #endregion
}
