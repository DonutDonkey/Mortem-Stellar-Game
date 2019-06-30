using System.IO;
using UnityEngine;

public class PlayerData
{
    private string   dataPath   = null;

    private SDPlayer sDPlayer;

    private SDWeapon sDWeapon;

    //public PlayerData() {
    //    //LoadSDP();
    //}

    public void PathName (string name) {
        dataPath = Path.Combine(Application.persistentDataPath, name + ".xml");
    }

    public void SavePlayer(DPlayer DPlayer, Transform transform) {
        PathName("DPlayer");

        sDPlayer = new SDPlayer(DPlayer, transform);

        string jsonString = JsonUtility.ToJson(sDPlayer);

        using (StreamWriter streamWriter = File.CreateText(dataPath)) {
            streamWriter.Write(jsonString);
        }
    }

    public void SaveWeapon(DWeapon DWeapon, string weaponNumber) {
        PathName("DWeapon" + weaponNumber);

        sDWeapon = new SDWeapon(DWeapon);

        string jsonString = JsonUtility.ToJson(sDWeapon);

        using (StreamWriter streamWriter = File.CreateText(dataPath)) {
            streamWriter.Write(jsonString);
        }
    }

    public SDPlayer LoadPlayer() {
        PathName("DPlayer");
        using (StreamReader streamReader = File.OpenText(dataPath)) {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<SDPlayer>(jsonString);
        }
    }

    public SDWeapon LoadWeapon(string weaponNumber) {
        PathName("DWeapon" + weaponNumber);
        using (StreamReader streamReader = File.OpenText(dataPath)) {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<SDWeapon>(jsonString);
        }
    }

    public Vector3 LoadPosition() {
        sDPlayer = LoadPlayer();
        return sDPlayer.position;
    }

    public Quaternion LoadRotation() {
        return sDPlayer.rotation;
    }

    public int LoadActiveWeapon() {
        sDPlayer = LoadPlayer();
        return sDPlayer.activeIndex;
    }

}
