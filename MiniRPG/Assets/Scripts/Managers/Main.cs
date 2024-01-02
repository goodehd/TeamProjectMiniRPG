using Managers;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region Singleton

    private static Main _instance;
    private static bool _initialize;

    public static Main Instance
    {
        get
        {
            if (_initialize) {return _instance;}
            _initialize = true;
            GameObject main = GameObject.Find("@Main");
            if (main != null) return _instance;
            main = new GameObject { name = "@Main" };
            main.AddComponent<Main>();
            DontDestroyOnLoad(main);
            _instance = main.GetComponent<Main>();
            return _instance;
        }
    }
    #endregion

    #region Field

    private readonly DataManager _data = new();
    private readonly GameManager _game = new();
    private readonly ItemManager _item = new();
    private readonly ResourceManager _resource = new();
    private readonly ScenesManager _scenes = new();
    private readonly SoundManager _sound = new();
    private readonly UIManager _ui = new();

    #endregion

    #region Properties

    public static DataManager Data => _instance._data;
    public static GameManager Game => _instance._game;
    public static ItemManager Item => _instance._item;
    public static ResourceManager Resource => _instance._resource;
    public static ScenesManager Scenes => _instance._scenes;
    public static SoundManager Sound => _instance._sound;
    public static UIManager UI => _instance._ui;

    #endregion
}
