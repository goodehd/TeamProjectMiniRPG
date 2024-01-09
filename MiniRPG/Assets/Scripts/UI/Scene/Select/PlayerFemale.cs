using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerFemale : PlayerDummy
{
    SelectScene _selectScene;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        GameObject _select = Main.Scenes.CurrentSceneObject;
        _selectScene = _select.GetComponent<SelectScene>();

        SetupPlayerFemale();

        return true;
    }

    private void SetupPlayerFemale()
    {
        _selectScene.SetPlayerFemale(this);
    }

    public void SetSelectTrue()
    {
        _animator.SetBool("Select", true);
    }

    public void SetSelectFalse()
    {
        _animator.SetBool("Select", false);
    }

}
