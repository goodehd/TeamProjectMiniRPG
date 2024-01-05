using System.Collections;
using UnityEngine;

public enum DungeonLevel
{
    Level1,
    Level2,
}

public class DungeonManager : MonoBehaviour
{
    public GameObject spawnerLv1;
    public GameObject spawnerLv2;

    public GameObject skeleton1Prefab; // 몬스터 프리팹
    public GameObject skeleton2Prefab;
    public GameObject musroomPrefab;
    public GameObject cactusPrefab;

    public Transform[] spawnPositionsLv1; // 레벨 1 몬스터 스폰 위치 배열

    void Start()
    {
        // 예시로 Level1을 활성화하고 싶다면 아래와 같이 호출
        ActivateDungeonLevel(DungeonLevel.Level1);
    }

    void ActivateDungeonLevel(DungeonLevel dungeonLevel)
    {
        switch (dungeonLevel)
        {
            case DungeonLevel.Level1:
                StartCoroutine(SpawnMonsters(spawnerLv1, spawnPositionsLv1));
                break;
            case DungeonLevel.Level2:
                // Handle Level2 activation here
                break;
            // Add more cases for additional levels

            default:
                Debug.LogError("Unknown dungeon level");
                break;
        }
    }

    IEnumerator SpawnMonsters(GameObject spawner, Transform[] spawnPositions)
    {
        spawner.SetActive(true);

        foreach (Transform spawnPosition in spawnPositions)
        {
            Instantiate(skeleton1Prefab, spawnPosition.position, spawnPosition.rotation);
            yield return new WaitForSeconds(0.5f); // Adjust delay between spawns if needed
        }

        spawner.SetActive(false);
    }
}
