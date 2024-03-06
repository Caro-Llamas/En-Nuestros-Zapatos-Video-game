[System.Serializable]
public class GameData
{
    public float[] position = new float[3];
    public bool[] hasSituationEnded = new bool[11];
    public bool[] minigamesStatus = new bool[6];
    public bool hasCharBeenSelected;

    public string actualScene;
    public string selectedChar;
    
    public GameData(GameManager gameData)
    {
        actualScene = gameData.sceneName;
        selectedChar = gameData.characterSelected;
        hasCharBeenSelected = gameData.hasCharBeenSelected;

        position[0] = gameData.player.transform.position.x;
        position[1] = gameData.player.transform.position.y;
        position[2] = gameData.player.transform.position.z;

        for (int i = 0; i < 11; i++)
        {
            hasSituationEnded[i] = gameData.hasSituationEnded[i];
        }

        for(int y = 0; y < 6; y++)
        {
            minigamesStatus[y] = gameData.minigameActivated[y];
        }
    }

}
