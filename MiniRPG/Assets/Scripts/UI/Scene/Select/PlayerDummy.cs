using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using System;

public class PlayerDummy : BaseUI
{
    protected Animator _animator;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;
        SetupAnimator();
        return true;
    }

    private void SetupAnimator()
    {
        _animator = GetComponentInChildren<Animator>();
    }
}
