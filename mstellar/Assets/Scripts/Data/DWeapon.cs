using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Specific Objects/Weapon")]
public class DWeapon : ScriptableObject
{
    #region Variables -> Serialized Private

    [Tooltip("Tag of weapon object")]
    [SerializeField] private string       weaponTag          = null;

    [Tooltip("If true, then can't be deactivated, ONLY ACTIVATE ON WEAPON 00")]
    [SerializeField] private bool         isAlwaysEquipped   = false;
    [Tooltip("If player picks up weapon switch to true")]
    [SerializeField] private bool         isInInventory      = false;
    [Tooltip("Check if weapon has projectile object")]
    [SerializeField] private bool         hasProjectile      = false;

    [Tooltip("If weapon has projectile, spawn it during fire, otherwise stay null")]
    [SerializeField] private GameObject   projectile         = null;

    #endregion

    #region Variables -> Private

    private float   ammoNumber   = 0.0f;
    private bool    isActive     = false;

    #endregion

    #region Variables -> Public

    public float   damageValue   = 0.0f;
    public float   fireRate      = 0.0f;
    public float   range         = 0.0f;

    #endregion

    #region Properties -> Public

    public string   WeaponTag     { get { return weaponTag;     } set { weaponTag     = value; } }

    public float    AmmoNumber    { get { return ammoNumber;    } set { ammoNumber    = value; } }

    public bool     IsActive      { get { return isActive;      } set { isActive      = value; } }
    public bool     HasProjectile { get { return hasProjectile; } }
    public bool     IsInInventory { get { return isInInventory; } set { if(!isAlwaysEquipped) isInInventory = value; } }

    #endregion

    #region Methods -> Public

    #endregion
}
