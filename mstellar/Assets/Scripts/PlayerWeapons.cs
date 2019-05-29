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

    #region Variables -> Public

    #endregion

    #region Methods -> UnityCallbacks

    private void Awake() {
        LoadPlayer();
    }

    void Update() {
        if (Input.GetButton(fireInputName)) {
            Fire();
        }

        WeaponSelection();
    }

    private void FixedUpdate() {
        CancelAttackAnimation();
    }

    #endregion

    #region Methods -> Private

    private void LoadPlayer() {
        LoadDefaultWeaponObjects(); LoadDefaultWeaponData();

        currentActiveWeapon = weaponsObjectsList[0];
        currentActiveWeapon.SetActive(true);

        if (isLoading) {
            //load
        }
    }

    private void LoadDefaultWeaponObjects() {
        foreach (GameObject go in weaponsObjectsList) {
            go.SetActive(false);
        }
    }

    private void LoadDefaultWeaponData() {
        foreach (DWeapon dw in weaponsDataList) {
            dw.IsPickedUp(false);
        }
    }

    private void Fire() {
            currentActiveWeapon.GetComponent<Animator>().SetBool("attack", true);
    }

    private void WeaponSelection() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (weaponsDataList[0].GetIsInInventory()) {
                SelectWeapon(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (weaponsDataList[1].GetIsInInventory()) {
                SelectWeapon(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (weaponsDataList[2].GetIsInInventory()) {
                SelectWeapon(2);
            }
        }
    }

    private void SelectWeapon(int Index) {
        currentActiveWeapon.SetActive(false);
        currentActiveWeapon = weaponsObjectsList[Index];
        currentActiveWeapon.SetActive(true);
    }

    private void CancelAttackAnimation() {
            currentActiveWeapon.GetComponent<Animator>().SetBool("attack", false);
    }

    #endregion

    #region Methods -> Public

    public void PickupWeapon(int index) {
        weaponsDataList[index].IsPickedUp(true);
    }

    #endregion
}
