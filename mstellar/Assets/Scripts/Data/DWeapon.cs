using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Specific Objects/Weapon")]
public class DWeapon : ScriptableObject
{
    #region Variables -> Serialized Private

    [Tooltip("Tag of weapon object")]
    [SerializeField] private string       weaponTag             = null;
    [Tooltip("If player picks up weapon switch to true")]
    [SerializeField] private bool         isInInventory         = false;

    [Tooltip("If weapon has projectile, spawn it during fire, otherwise stay null")]
    [SerializeField] private GameObject   projectile            = null;

    [Tooltip("Check if weapon has projectile object")]
    [SerializeField] private bool         hasProjectile         = false;

    #endregion

    #region Variables -> Private

    private float   damageValue   = 0.0f;
    private float   fireRate      = 0.0f;

    private bool    isActive      = false;

    #endregion

    #region Properties -> Public

    public string WeaponTag { get { return weaponTag; }
                              set { weaponTag = value; } }

    #endregion

    #region Methods -> Public

    public bool GetIsInInventory() {
        return isInInventory;
    }

    public void IsPickedUp() {
        isInInventory.Equals(true);
    }

    #endregion
}
