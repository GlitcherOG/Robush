using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerSaveToBinary
{
    
    public static void SavePlayerData(PlayerHandler player)
    {
        //Refernce a binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //location to save
        string path = Application.persistentDataPath + "/" + "Random" + ".txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        //What data to write to the file
        PlayerToSave data = new PlayerToSave(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerToSave LoadData(PlayerHandler player)
    {
        string path = Application.persistentDataPath + "/" + "Random" + ".txt";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerToSave data = formatter.Deserialize(stream) as PlayerToSave;
            stream.Close();
            return data;
        }
        return null;
    }
}
