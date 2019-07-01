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
            CheckIfWeaponIsEquippedAndNotCurrentlyActive(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            CheckIfWeaponIsEquippedAndNotCurrentlyActive(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            CheckIfWeaponIsEquippedAndNotCurrentlyActive(2);
        }
    }

    private void CheckIfWeaponIsEquippedAndNotCurrentlyActive(int index) {
        if (weaponsDataList[index].IsInInventory.Equals(true) && WeaponIsNotSelected(index)) {
            SelectWeapon(index);
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
