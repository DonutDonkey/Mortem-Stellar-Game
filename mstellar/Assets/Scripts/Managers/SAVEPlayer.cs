using UnityEngine;

public class SAVEPlayer : MonoBehaviour
{
    [SerializeField] private DPlayer      dPlayer      = null;

    [SerializeField] private DWeapon      dWeapon01   = null;
    [SerializeField] private DWeapon      dWeapon02   = null;

    [SerializeField] private GameObject   player      = null;

    private IOPlayerData   IOplayerData   = null;

    private void Awake() {
        IOplayerData = new IOPlayerData();
    }

    //Will be in menu each save is different thing
    private void Update() {
        if(Input.GetKeyUp(KeyCode.F5)) {
            IOplayerData.SavePlayer(dPlayer, player.transform);
            IOplayerData.SaveWeapon(dWeapon01, "01");
            IOplayerData.SaveWeapon(dWeapon02, "02");
        }
        if (Input.GetKeyUp(KeyCode.F8)) {
            LoadPlayer();
            LoadWeapons();
        }
    }

    private void LoadPlayer() {
        player.SetActive(false);
        dPlayer.Load(IOplayerData.LoadPlayer());
        player.transform.position = IOplayerData.LoadPosition();
        player.transform.rotation = IOplayerData.LoadRotation();
        player.SetActive(true);
    }

    private void LoadWeapons() {
        player.SetActive(false);
        dWeapon01.Load(IOplayerData.LoadWeapon("01"));
        dWeapon02.Load(IOplayerData.LoadWeapon("02"));
        PlayerWeapons.activeIndex = IOplayerData.LoadActiveWeapon();
        player.SetActive(true);
    } 
}
