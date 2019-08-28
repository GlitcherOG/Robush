using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerSaveToBinary : MonoBehaviour
{
    
    public static void SavePlayerData(PlayerHandler player)
    {
        //Refernce a binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //location to save
        string path = Application.persistentDataPath + "/" + "Random" + ".txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        //What data to write to the file
        PlayerDataToSave.data = new PlayerDataToSave(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerDataToSave LoadData(PlayerHandler player)
    {
        string path = Application.persistentDataPath + "/" + "Random" + ".txt";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerDataToSave data = formatter.Deserialize(stream) as PlayerDataToSave;
            stream.Close();
            return data;
        }
    }
}
