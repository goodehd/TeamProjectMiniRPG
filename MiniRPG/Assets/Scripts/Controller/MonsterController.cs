using UnityEngine;
using UnityEngine.AI;
// 권오태 작업
public class MonsterController : MonoBehaviour
{
    private Animator anim;
    private Transform playerTransform;
    private NavMeshAgent nav;
    private PlayerData playerData;

    //[SerializeField]
    protected int maxHealth = 20;
    protected int curHealth;
    protected int enemyPower = 5;
    protected float followDis = 10f;
    protected float enemyAttackCoolTime = 0.5f;

    protected HealthPoint healthPoint;
    protected FinalDamage finalDamage;

    // 위 몬스터 요소는 추후 SO형식으로 바꿀 예정
    // speed는 적 컴포넌트 nevmeshAgent 컴포넌트에서 설정할 수 있습니다.

    private bool isAttacking;
    private bool isDead;

    void Start()
    {
        DefaultSetting();
    }

    private void DefaultSetting()
    {
        isAttacking = false;
        isDead = false;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        curHealth = maxHealth;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerData = Main.Game.Player.GetComponent<PlayerController>().Player.PlayerData;
    }

    void Update()
    {
        if (!isDead)
        {
            FollowProcess();
        }
    }

    private void FollowProcess()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= followDis)
        {
            if (!anim.GetBool("IsWalking"))
            {
                nav.isStopped = false;
                anim.SetBool("IsWalking", true);
            }
            transform.LookAt(playerTransform);
            nav.SetDestination(playerTransform.position);
        }
        else
        {
            if (anim.GetBool("IsWalking"))
            {
                nav.isStopped = true;
                anim.SetBool("IsWalking", false); 
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        CollisionProcess(other);
    }

    private void CollisionProcess(Collision other)
    {
        if (other.gameObject.tag == "Player" && !isAttacking)
        {
            MonsterAttack(other);
        }
    }

    private void MonsterAttack(Collision other) // 몬스터가 공격하는 부분
    {
        playerData.Hp.SubValue(50);
        Main.UI.SceneUI.GetComponent<MainSceneUI>().SetPlayerInfo();
        isAttacking = true;
        nav.isStopped = true;
        anim.SetTrigger("IsAttack");
        Invoke("ResetAttack", enemyAttackCoolTime);
    }

    private void ResetAttack()
    {
        isAttacking = false;
        nav.isStopped = false;
    }

    public void MonsterAttacked(int damage) // 몬스터가 공격받는 부분
    {
        curHealth -= (int)damage;

        if (!isDead)
        {
            if (curHealth > 0)
            {
                Debug.Log("몬스터가 공격 받았습니다.");
                // anim.SetTrigger("damage"); => 빨개지게 하는 애니메이션 추가예정
                // 넉백함수 추가예정
            }
            else
            {
                Die();
                Debug.Log("몬스터가 죽었습니다.");
            }
        }
    }

    private void Die()
    {
        // 죽는 사운드 호출
        anim.SetTrigger("IsDie");
        isDead = true;
        nav.isStopped = true;

        Collider monsterCollider = GetComponent<Collider>();
        if (monsterCollider != null)
        {
            monsterCollider.enabled = false;
        }

        Invoke("DestroyObject", 2f);
        Debug.Log("몬스터가 죽었습니다..");

        Main.Quest.OnMonsterDieIventInvoke(this);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}