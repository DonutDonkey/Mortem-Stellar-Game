using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables -> Serialized Private

    [SerializeField] private AudioSource   audioSource      = null;

    [SerializeField] private GameObject    particleSystem   = null;

    [SerializeField] private Transform     spawnPoint       = null;

    [SerializeField] private DWeapon       weaponData       = null;

    [SerializeField] private string        fireInputName    = null;

    #endregion

    #region Variables -> Private

    private static readonly int   Attack           = Animator.StringToHash("attack");

    private List<GameObject>      projectileList   = null;

    private Animator              animator         = null;

    private Camera                modelViewCam     = null;

    private float                 cooldown         = 0.0f;

    #endregion

    #region Methods -> Unity Callbacks

    private void Awake() {
        modelViewCam = GetComponentInParent<Camera>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (particleSystem != null) particleSystem = Instantiate(particleSystem) as GameObject;
        if (weaponData.HasProjectile) ProjectilePooling();
    }

    private void Update() {
        CheckForFire1Press();
    }

    private void FixedUpdate()
    {
        var transform1 = modelViewCam.transform;
        Debug.DrawRay(transform1.position, transform1.forward, Color.green);
    }

    #endregion

    #region Methods -> Private

    private void ProjectilePooling() {
        projectileList = new List<GameObject>();
        for (int i = 0; i < 5; i++) {
            GameObject obj = Instantiate(weaponData.Projectile) as GameObject;
            obj.SetActive(false);
            projectileList.Add(obj);
        }
    }

    private void CheckForFire1Press() {
        if (Input.GetButtonDown(fireInputName) && Time.time > cooldown && animator.GetBool(Attack).Equals(false)) {
            Fire();
        }
    }

    private void Fire() {
        cooldown = Time.time + weaponData.fireRate;
        Debug.Log(cooldown);
        if (!weaponData.HasProjectile) {
            AttackRaycast();
        }
        else {
            AttackProjectile();
        }
    }

    private void AttackRaycast() {
        animator.SetBool(Attack, true);

        if (Physics.Raycast(modelViewCam.transform.position, modelViewCam.transform.forward, out RaycastHit hit, weaponData.range)) {

            Debug.Log("HIT: " + hit.transform.name); //Can hit palyer need to unfuck this
            Actor actor = hit.transform.GetComponent<Actor>();

            if (actor != null) {
                actor.TakeDamage(weaponData.damageValue);
            }

            if(particleSystem != null) {
                ActivateParticle(hit);
            }
        }
    }

    private void ActivateParticle(RaycastHit hit) {

        if (particleSystem.GetComponent<ParticleSystem>().isStopped) {
            particleSystem.transform.position = hit.point;
            particleSystem.GetComponent<ParticleSystem>().Play();
        }
    }

    private void AttackProjectile() {
        animator.SetBool(Attack, true);
        
        for(int i=0; i < projectileList.Count; i++) {
            if (!projectileList[i].activeInHierarchy) {
                SpawnProjectile(i); break;
            }
        }
    }

    private void SpawnProjectile(int i) {
        projectileList[i].transform.position = spawnPoint.transform.position;
        projectileList[i].transform.rotation = spawnPoint.transform.rotation;
        projectileList[i].SetActive(true);
    }

    /// <summary>
    /// Called by animator in game to cancel attack animation
    /// </summary>
    private void CancelAttackAnimation() {
        animator.SetBool(Attack, false);
    }

    /// <summary>
    /// Called by animator in game to play audio clip if one is attached to object
    /// </summary>
    private void PlayAudioClip() {
        if (audioSource != null) audioSource.Play();
    }
    
    #endregion
}
