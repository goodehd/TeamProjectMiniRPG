
public class Player
{
    #region Fields
    
    // Member (Data)
    private PlayerData _playerData;
    private PlayerAnimationData _playerAnimationData;
    

    // Player Data Reference
    public PlayerData PlayerData => _playerData;
    
    // Animation Data
    public PlayerAnimationData AnimationData => _playerAnimationData;

    #endregion



    #region Constructor

    public Player()
    {
        InitializePlayer();
    }

    #endregion



    #region Initialize

    private void InitializePlayer()
    {
        // Player Data Init
        _playerData = new PlayerData();
        _playerAnimationData = new PlayerAnimationData();
        
        // Animation Data Init
        if (!AnimationData.IsInit)
        {
            AnimationData.Initialize();
        }
    }
    
    #endregion
}
