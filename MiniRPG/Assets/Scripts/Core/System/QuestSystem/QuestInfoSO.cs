using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1 )]
public class QuestInfoSO : ScriptableObject
{
    [field : SerializeField] public string id { get; private set; }

    [Header("General")]
    public string DisPlayName;

    [Header("Requirements")]
    public int LevelRequirement;
    public QuestInfoSO[] QuestPrerequisites;

    [Header("Steps")]
    public GameObject[] QuestStepPrefabs;

    [Header("Rewards")]
    public int Gold;
    public int Experience;

    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
