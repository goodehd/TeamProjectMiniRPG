using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class PopupUI : BaseUI
{
    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;
        UI.OrderLayerToCanvas(gameObject);
        return true;
    }
}
