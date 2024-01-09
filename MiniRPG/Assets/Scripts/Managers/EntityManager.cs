
using System;
using JetBrains.Annotations;
using UnityEngine;

public class EntityManager
{
    #region Helpers

    public void CreatePlayer(Vector3 startingPosition, bool isDungeon)
    {
        var characterType = Main.Game.CurrentCharacterType;
        const string pathTag = "Player";

        var player = characterType switch
        {
            UI_SELECT_CHARACTER.Male => Main.Resource.InstantiatePrefab(pathTag),
            UI_SELECT_CHARACTER.Female => Main.Resource.InstantiatePrefab(pathTag),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        SetPlayer(player, startingPosition, isDungeon);
    }

    private void SetPlayer(GameObject player, Vector3 startingPosition, bool isDungeon)
    {
        if (player == null) return;

        player.transform.position = startingPosition;
        
        Main.Game.Player = player;
        
        // Camera Setup
        if (isDungeon)
            Camera.main.GetComponent<FollowCamera>().target = player.transform;
        else
            Camera.main.GetComponent<FollowCamera2>().target = player.transform;
        
        // UI Setup
        var mainSceneUI = Main.UI.SetSceneUI<MainSceneUI>();
        var playerComponent = player.GetComponent<PlayerController>().Player;
        mainSceneUI.SetPlayer(playerComponent);
    }

    #endregion
}
