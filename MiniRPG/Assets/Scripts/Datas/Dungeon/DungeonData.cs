
public class DungeonData 
{
    public string PrivewImageKey;

    public string DungeonName;
    public string DungeonDescripts;

    public string DungeonSceneName;

    public DungeonData(string privewImageKey, string dungeonName, string dungeonDescripts)
    {
        PrivewImageKey = privewImageKey;
        DungeonName = dungeonName;
        DungeonDescripts = dungeonDescripts;
    }

    public DungeonData() { }
}
