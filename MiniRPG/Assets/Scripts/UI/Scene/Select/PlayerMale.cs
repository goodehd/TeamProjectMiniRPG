using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMale : PlayerDummy
{
    SelectScene _selectScene;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        GameObject _select = Main.Scenes.CurrentSceneObject;
        _selectScene = _select.GetComponent<SelectScene>();

        SetupPlayerMale();

        return true;
    }

    private void SetupPlayerMale()
    {
        _selectScene.SetPlayerMale(this);
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
