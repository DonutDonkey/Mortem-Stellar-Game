using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    [SerializeField] private DPlayer      dPlayer      = null;

    [SerializeField] private DWeapon      dWeapon01   = null;
    [SerializeField] private DWeapon      dWeapon02   = null;

    [SerializeField] private GameObject   player      = null;

    private PlayerData   playerData   = null;

    private void Awake() {
        playerData = new PlayerData();
    }

    //Will be in menu each save is different thing
    private void Update() {
        if(Input.GetKeyUp(KeyCode.F5)) {
            playerData.SavePlayer(dPlayer, player.transform);
            playerData.SaveWeapon(dWeapon01, "01");
            playerData.SaveWeapon(dWeapon02, "02");
        }
        if (Input.GetKeyUp(KeyCode.F8)) {
            LoadPlayer();
            LoadWeapons();
        }
    }

    private void LoadPlayer() {
        player.SetActive(false);
        dPlayer.Load(playerData.LoadPlayer());
        player.transform.position = playerData.LoadPosition();
        player.transform.rotation = playerData.LoadRotation();
        player.SetActive(true);
    }

    private void LoadWeapons() {
        player.SetActive(false);
        dWeapon01.Load(playerData.LoadWeapon("01"));
        dWeapon02.Load(playerData.LoadWeapon("02"));
        PlayerWeapons.activeIndex = playerData.LoadActiveWeapon();
        player.SetActive(true);
    } 
}
