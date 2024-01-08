using Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ViliageScene : BaseScene
{
    private Vector3 _startPos = new Vector3(71f, 22.1f, 37f);

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        CreateEnviorment();
        CreateNPC();
        CreatePlayer();

        return true;
    }

    private void CreateEnviorment()
    {
        //for(int i = 0; i < Literals.ViliagePrefabNames.Length; ++i)
        //{
        //    Main.Resource.InstantiatePrefab(Literals.ViliagePrefabNames[i]);
        //}
        Main.Resource.InstantiatePrefab("Map");
        Main.Resource.InstantiatePrefab("Sky");
    }

    private void CreateNPC()
    {
        for (int i = 0; i < Literals.ViliageNPCNames.Length; ++i)
        {
            Main.Resource.InstantiatePrefab(Literals.ViliageNPCNames[i]);
        }
    }

    private void CreatePlayer()
    {
        UI_SELECT_CHARACTER type = Main.Game.CurrentCharacterType;
        GameObject player = null;
        switch (type)
        {
            case UI_SELECT_CHARACTER.Male:
                player = Main.Resource.InstantiatePrefab("MaleTest");
                break;
            case UI_SELECT_CHARACTER.Female:
                player = Main.Resource.InstantiatePrefab("FemaleTest");
                break;
        }
        player.transform.position = _startPos;
        Main.Game.Player = player;
    }
}
