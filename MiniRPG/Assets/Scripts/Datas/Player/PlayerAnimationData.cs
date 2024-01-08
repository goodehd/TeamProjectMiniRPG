
using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    #region Fields

    [SerializeField] private string _LocomotionName = "Locomotion";

    [SerializeField] private string _Speed = "Speed";

    [SerializeField] private string _GroundName = "@Ground";
    
    [SerializeField] private string _IdleName = "Idle";
    [SerializeField] private string _WalkName = "Walk";
    [SerializeField] private string _RunName = "Run";
    
    [SerializeField] private string _Attack01Name = "Attack01";
    [SerializeField] private string _Attack02Name = "Attack02";
    [SerializeField] private string _Attack03Name = "Attack03";

    public bool IsInit;

    #endregion



    #region Getter (Properties)
    
    public int LocomotionHash { get; private set; }
    
    public int Speed { get; private set; }

    public int GroundHash { get; private set; }
    
    public int IdleHash { get; private set; }
    public int WalkHash { get; private set; }
    public int RunHash { get; private set; }
    
    public int Attack01Hash { get; private set; }
    public int Attack02Hash { get; private set; }
    public int Attack03Hash { get; private set; }

    #endregion



    #region Initialize

    public void Initialize()
    {
        LocomotionHash = Animator.StringToHash(_LocomotionName);

        Speed = Animator.StringToHash(_Speed);
        
        GroundHash = Animator.StringToHash(_GroundName);
        
        IdleHash = Animator.StringToHash(_IdleName);
        WalkHash = Animator.StringToHash(_WalkName);
        RunHash = Animator.StringToHash(_RunName);

        Attack01Hash = Animator.StringToHash(_Attack01Name);
        Attack02Hash = Animator.StringToHash(_Attack02Name);
        Attack03Hash = Animator.StringToHash(_Attack03Name);

        IsInit = true;
    }

    #endregion
}
