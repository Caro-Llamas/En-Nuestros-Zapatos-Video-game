using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SaveGameData(GameManager gameManagerData)
    {
        GameData gameData = new GameData(gameManagerData);
        string dataPath = Application.persistentDataPath + "/game.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();
    }

    public static GameData LoadGameData()
    {
        string dataPath = Application.persistentDataPath + "/game.save";

        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            GameData gameData = (GameData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return gameData;
        }
        else
        {
            return null;
        }
    }

    public static void DeleteAllData()
    {
        string dataPath = Application.persistentDataPath + "/game.save";

        if (File.Exists(dataPath))
        {
            File.Delete(dataPath);            
        }
        else
        {
            Debug.LogError("No hay archivo para borrar");
        }
    }
}
