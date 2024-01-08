using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonNPC : MonoBehaviour, IInteractable
{
    public void OnInteractionEnter()
    {
        
    }

    public void OnInteractable()
    {
        //test
        DungeonData data = new DungeonData("DungeonImage", "해골들의 던전", "해골이 짱 많아요 ! 다른 레벨에 가면 귀여운 선인장과 버섯도 볼 수 있어요 !", "Dungeon");

        DungeonIntroUI DungeonUI = Main.UI.OpenPopup<DungeonIntroUI>();
        DungeonUI.SetDungeonData(data);
    }
}
