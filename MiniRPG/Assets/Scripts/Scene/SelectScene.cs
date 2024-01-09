using Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectScene : BaseScene
{
    private PlayerMale _playerMale;
    private PlayerFemale _playerFemale;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        Object eventSystem = FindObjectOfType<EventSystem>();

        Main.Resource.AllLoadResource<Object>("Select", (key, loadCount, totalCount) =>
        {
            if (loadCount == totalCount)
            {
                if (eventSystem == null) Main.Resource.InstantiatePrefab("EventSystem");

                UI.SetSceneUI<Select_UI>();
                _playerFemale =  UI.SetSceneUI<PlayerFemale>();
                _playerMale = UI.SetSceneUI<PlayerMale>();
            }
        });

        return true;
    }


    public void SetPlayerMale(PlayerMale playerMale)
    {
        _playerMale = playerMale;
    }

    public PlayerMale GetPlayerMale()
    {
        return _playerMale;
    }

    public void SetPlayerFemale(PlayerFemale playerFemale)
    {
        _playerFemale = playerFemale;
    }

    public PlayerFemale GetPlayerFemale()
    {
        return _playerFemale;
    }
}
