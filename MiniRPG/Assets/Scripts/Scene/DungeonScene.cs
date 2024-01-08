
using Scene;
using UnityEngine;

public class DungeonScene : BaseScene
{
    #region Fields

    private readonly Vector3 _StartPosition = Vector3.zero;

    #endregion



    #region Init

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        Main.Entity.CreatePlayer(_StartPosition, true);

        return true;
    }

    #endregion
}
