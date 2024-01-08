using System.Collections;
using UnityEngine;
using Unity.UI;

public enum DungeonLevel
{
    Level1,
    Level2,
}

public class DungeonManager : MonoBehaviour
{
    /*public GameObject spawnerLv1;
    public GameObject spawnerLv2;*/

    public GameObject skeleton1Prefab;
    public GameObject skeleton2Prefab;
    public GameObject skeletonBossPrefab;
    public GameObject musroomPrefab;
    public GameObject cactusPrefab;
    public GameObject mushroomBossPrefab;

    public Transform Lv1_SpawnPosition1;
    public Transform Lv1_SpawnPosition2;
    public Transform Lv1_BossPosition;

    public Transform Lv2_SpawnPosition1;
    public Transform Lv2_SpawnPosition2;
    public Transform Lv2_BossPosition;

    public GameObject clearPanel;
    public GameObject diePanel;

    private PlayerData playerData;

    void Start()
    {
        if (Main.Game.Level == DungeonLevel.Level1)
        {
            ActivateDungeonLevel(DungeonLevel.Level1);
        }
        else if (Main.Game.Level == DungeonLevel.Level2)
        {
            ActivateDungeonLevel(DungeonLevel.Level2); 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            clearPanel.SetActive(true);
        }
        CheckEnemyCount();
        playerData = Main.Game.Player.GetComponent<PlayerController>().Player.PlayerData;
        if (playerData?.Hp.CurValue <= 0)
        {
            if (!diePanel.activeSelf)
            {
                diePanel.SetActive(true);
            }
        }
    }
    void CheckEnemyCount()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            ActivateGameOverPanel();
        }
    }
    void ActivateGameOverPanel()
    {
        clearPanel.SetActive(true);
        // 여기에 추가적인 게임 오버 처리 코드를 넣을 수 있음
    }
    void ActivateDungeonLevel(DungeonLevel dungeonLevel)
    {
        switch (dungeonLevel)
        {
            case DungeonLevel.Level1:
                Transform[] lv1_SpawnPosition1 = GetSpawnPositions(Lv1_SpawnPosition1);
                Transform[] lv1_SpawnPosition2 = GetSpawnPositions(Lv1_SpawnPosition2);
                Transform[] lv1_BossPosition = GetSpawnPositions(Lv1_BossPosition);
                SpawnMonsters(skeleton1Prefab, lv1_SpawnPosition1);
                SpawnMonsters(skeleton2Prefab, lv1_SpawnPosition2);
                SpawnMonsters(skeletonBossPrefab, lv1_BossPosition);
                break;
            case DungeonLevel.Level2:
                Transform[] lv2_SpawnPosition1 = GetSpawnPositions(Lv2_SpawnPosition1);
                Transform[] lv2_SpawnPosition2 = GetSpawnPositions(Lv2_SpawnPosition2);
                Transform[] lv2_BossPosition = GetSpawnPositions(Lv2_BossPosition);
                SpawnMonsters(musroomPrefab, lv2_SpawnPosition1);
                SpawnMonsters(cactusPrefab, lv2_SpawnPosition2);
                SpawnMonsters(mushroomBossPrefab, lv2_BossPosition);
                break;

            default:
                Debug.Log("Unknown dungeon level");
                break;
        }
    }
    Transform[] GetSpawnPositions(Transform parent)
    {
        Transform[] spawnPositions = new Transform[parent.childCount];

        for (int i = 0; i < parent.childCount; i++)
        {
            spawnPositions[i] = parent.GetChild(i);
        }

        return spawnPositions;
    }

    void SpawnMonsters(GameObject monsterPrefab, Transform[] spawnPositions)
    {
        foreach (Transform spawnPosition in spawnPositions)
        {
            Instantiate(monsterPrefab, spawnPosition.position, spawnPosition.rotation);
        }
    }

    public void BackToTown()
    {
        Main.Scenes.NextScene = "Viliage";
        Main.Scenes.LoadLoadingScene();
    }
}
