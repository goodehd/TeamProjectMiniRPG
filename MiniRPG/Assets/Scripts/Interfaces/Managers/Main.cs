
using Managers;

public class Main : SingletonBehavior<Main>
{
    #region Field

    private readonly DataManager _data = new();
    private readonly GameManager _game = new();
    private readonly ItemManager _item = new();
    private readonly ResourceManager _resource = new();
    private readonly ScenesManager _scenes = new();
    private readonly SoundManager _sound = new();
    private readonly UIManager _ui = new();
    private readonly InventoryManager _inventory = new();
    private readonly QuestManager _quest = new();
    private readonly EntityManager _entity = new();

    #endregion



    #region Properties

    //public static string NextScene { get; set; }
    //public static string CurrentScene { get; set; }
    public static DataManager Data => Instance._data;
    public static GameManager Game => Instance._game;
    public static ItemManager Item => Instance._item;
    public static ResourceManager Resource => Instance._resource;
    public static ScenesManager Scenes => Instance._scenes;
    public static SoundManager Sound => Instance._sound;
    public static UIManager UI => Instance._ui;
    public static InventoryManager Inventory => Instance._inventory;
    public static QuestManager Quest => Instance._quest;
    public static EntityManager Entity => Instance._entity;

    #endregion
}
