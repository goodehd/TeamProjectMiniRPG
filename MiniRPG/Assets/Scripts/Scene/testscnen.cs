using Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testscnen : BaseScene
{
    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        Object eventSystem = FindObjectOfType<EventSystem>();

        Main.Resource.AllLoadResource<Object>("test", (key, loadCount, totalCount) =>
        {
            if (loadCount == totalCount)
            {
                if (eventSystem == null) Main.Resource.InstantiatePrefab("EventSystem");


                
            }
        });
        return true;
    }
}
