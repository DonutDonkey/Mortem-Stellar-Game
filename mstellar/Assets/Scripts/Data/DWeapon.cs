using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Specific Objects/Weapon")]
public class DWeapon : ScriptableObject
{
    #region Variables -> Serialized Private

    [Tooltip("Current carried armor")]
    [SerializeField] private DFloatValue   ammoNumber         = null;

    [Tooltip("If weapon has projectile, spawn it during fire, otherwise stay null")]
    [SerializeField] private GameObject    projectile         = null;

    [Tooltip("Tag of weapon object")]
    [SerializeField] private string        weaponTag          = null;

    [Tooltip("Max cappacity of player carried armor")]
    [SerializeField] private float         maxAmmoNumber      = 0.0f;

    [Tooltip("If true, then can't be deactivated, ONLY ACTIVATE ON WEAPON 00")]
    [SerializeField] private bool          isAlwaysEquipped   = false;
    [Tooltip("If player picks up weapon switch to true")]
    [SerializeField] private bool          isInInventory      = false;
    [Tooltip("Check if weapon has projectile object")]
    [SerializeField] private bool          hasProjectile      = false;

    #endregion

    #region Variables -> Private

    private bool    isActive     = false;

    #endregion

    #region Variables -> Public

    public DFloatValue   damageValue   = null;

    public float         fireRate      = 0.0f;
    public float         range         = 0.0f;

    #endregion

    #region Properties -> Public

    public DFloatValue   AmmoNumber      { get { return ammoNumber;    } set { ammoNumber    = value; } }

    public GameObject    Projectile      { get { return projectile; } }

    public string        WeaponTag       { get { return weaponTag;     } set { weaponTag     = value; } }

    public float         MaxAmmoNumber   { get { return maxAmmoNumber; }}

    public bool          HasProjectile   { get { return hasProjectile; } }
    public bool          IsActive        { get { return isActive;      } set { isActive      = value; } }
    public bool          IsInInventory   { get { return isInInventory; } set { if(!isAlwaysEquipped) isInInventory = value; } }

    #endregion

    #region Methods -> Public

    public void Load(SDWeapon sDWeapon) {
        isInInventory = sDWeapon.isInInventory;
        ammoNumber.SetValue(sDWeapon.ammoNumber);
    }

    #endregion
}
