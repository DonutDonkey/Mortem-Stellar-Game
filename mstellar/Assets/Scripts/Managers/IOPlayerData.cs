using System.IO;
using UnityEngine;

public class IOPlayerData
{
    private SDPlayer   sDPlayer;

    private SDWeapon   sDWeapon;

    private string     dataPath   = null;

    public void PathName (string name) {
        dataPath = Path.Combine(Application.persistentDataPath, name + ".xml");
    }

    public void SavePlayer(DPlayer DPlayer, Transform transform) {
        PathName("DPlayer");

        sDPlayer = new SDPlayer(DPlayer, transform);

        Save(sDPlayer);
    }

    public void SaveWeapon(DWeapon DWeapon, string weaponNumber) {
        PathName("DWeapon" + weaponNumber);

        sDWeapon = new SDWeapon(DWeapon);

        Save(sDWeapon);
    }

    private void Save(object data) {
        if (data is SDPlayer || data is SDWeapon) {
            string jsonString = JsonUtility.ToJson(data);

            using (StreamWriter streamWriter = File.CreateText(dataPath)) {
                streamWriter.Write(jsonString);
            }
        } else {
            throw new System.ArgumentException("Parametr must be of type SDPlayer or SDWeapon", "data");
        }
    }

    public SDPlayer LoadPlayer() {
        PathName("DPlayer");
        using (StreamReader streamReader = File.OpenText(dataPath)){ 
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

    public object ReturnTest(object obj) {
        return obj;
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
