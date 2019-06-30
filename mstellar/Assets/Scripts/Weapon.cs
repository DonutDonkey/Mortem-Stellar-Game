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

    private static readonly string   HandWep          = "WEP_00";

    private static readonly int      Attack           = Animator.StringToHash("attack");

    private List<GameObject>         projectileList   = null;

    private Animator                 animator         = null;

    private Camera                   modelViewCam     = null;

    private float                    cooldown         = 0.0f;

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
        if (CheckForAmmo() || weaponData.WeaponTag == HandWep) {
            if (Input.GetButtonDown(fireInputName) && Time.time > cooldown && animator.GetBool(Attack).Equals(false)) {
                Fire();
            }
        }
    }

    private bool CheckForAmmo() {
        if (weaponData.AmmoNumber != null) return weaponData.AmmoNumber > 0;
        else return true;
    }

    private void Fire() {
        cooldown = Time.time + weaponData.fireRate;
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

            Debug.Log("HIT: " + hit.transform.name);
            Actor actor = hit.transform.GetComponent<Actor>();

            if (actor != null) {
                actor.TakeDamage(weaponData.damageValue);
            }

            if(particleSystem != null) {
                ActivateParticle(hit);
            }
        }

        TakeAmmo();
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

        TakeAmmo();
    }

    private void SpawnProjectile(int i) {
        projectileList[i].transform.position = spawnPoint.transform.position;
        projectileList[i].transform.rotation = spawnPoint.transform.rotation;
        projectileList[i].SetActive(true);
    }

    private void TakeAmmo() {
        if (weaponData.WeaponTag == HandWep) return;
        weaponData.AmmoNumber--;
    }

    #endregion

    #region Methods -> Animator Called

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
