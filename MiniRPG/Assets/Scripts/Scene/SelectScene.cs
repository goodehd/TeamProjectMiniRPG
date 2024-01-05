using Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectScene : BaseScene
{
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

            }
        });


        return true;
    }
}
