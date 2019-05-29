using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    #region Variables -> Serialized Private

    [SerializeField] private List<GameObject>   weaponsObjectsList   = null;
    [SerializeField] private List<DWeapon>      weaponsDataList      = null;

    [SerializeField] private string             fireInputName        = null;

    #endregion

    #region Variables -> Private

    private GameObject   currentActiveWeapon   = null;
    private bool         isLoading             = false;
    
    #endregion

    #region Methods -> UnityCallbacks

    void Start() {
        if (isLoading) LoadPlayer();
    }

    private void Awake() {

    }

    void Update() {
        if (Input.GetButton(fireInputName)) {
            Fire();
        }
    }

    private void FixedUpdate() {
        CancelAttackAnimation();
    }

    #endregion

    #region Methods -> Private

    private void LoadPlayer() {
        Debug.Log("LOAD PLAYER");
    }

    private void Fire() {
            currentActiveWeapon.GetComponent<Animator>().SetBool("attack", true);
    }

    private void CancelAttackAnimation() {
            currentActiveWeapon.GetComponent<Animator>().SetBool("attack", false);
    }

    #endregion

    #region Methods -> Public

    #endregion
}
