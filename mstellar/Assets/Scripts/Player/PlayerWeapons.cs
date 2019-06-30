using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    #region Variables -> Serialized Private

    [SerializeField] private List<GameObject>   weaponsObjectsList   = null;

    [SerializeField] private List<DWeapon>      weaponsDataList      = null;

    #endregion

    #region Variables -> Private

    private GameObject   currentActiveWeapon   = null;

    public static int    activeIndex           = 0;

    #endregion

    #region Methods -> UnityCallbacks

    private void Awake() {
        LoadPlayer();
    }

    private void OnEnable() {
        SelectWeapon(activeIndex);
    }

    void Update() {
        WeaponSelection();
    }

    #endregion

    #region Methods -> Private

    private void LoadPlayer() {
        LoadWeaponObjects();
        LoadDefaultWeaponData();

        currentActiveWeapon = weaponsObjectsList[0];
        currentActiveWeapon.SetActive(true);
        activeIndex = 0;
    }

    private void LoadWeaponObjects() {
        foreach (GameObject go in weaponsObjectsList) {
            go.SetActive(false);
        }
    }

    private void LoadDefaultWeaponData() {
        foreach (DWeapon dw in weaponsDataList) {
            dw.IsInInventory = false;

            if(dw.AmmoNumber != null) dw.AmmoNumber.SetValue(0);
        }
    }

    private void WeaponSelection() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (weaponsDataList[0].IsInInventory.Equals(true) && WeaponIsNotSelected(0)) {
                SelectWeapon(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (weaponsDataList[1].IsInInventory.Equals(true) && WeaponIsNotSelected(1)) {
                SelectWeapon(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (weaponsDataList[2].IsInInventory.Equals(true) && WeaponIsNotSelected(2)) {
                SelectWeapon(2);
            }
        }
    }

    private bool WeaponIsNotSelected(int index) {
        return currentActiveWeapon != weaponsObjectsList[index];
    }

    private void SelectWeapon(int index) {
        currentActiveWeapon.SetActive(false);
        currentActiveWeapon = weaponsObjectsList[index];
        currentActiveWeapon.SetActive(true);

        activeIndex = index;
    }

    #endregion

    #region Methods -> Public

    public void PickupWeapon(int index) {
        weaponsDataList[index].IsInInventory = true; SelectWeapon(index);
    }

    #endregion
}
