using Unity.VisualScripting;
using UnityEngine;


//몬스터에 이동에 관한 구현, 공격과 몸빵을 추상메서드로 각 몬스터 오브젝트가 상속하도록
public class MonSystem : Living //Living이 MonoBehaviour를 이미 상속하므로 표시할 필요 x
{
    //2d이며 지형지물이 없으므로 내비매시 없이 추적 구현 가능

    public GameObject target; //추적할 대상, 플레이어
    protected Rigidbody2D monRigidbody; //몬스터들의 리지드바디 컴포넌트
    public float monSpeed { get; protected set; } //몬스터의 이동 속도
    public float monDamage { get ; protected set; } //몬스터의 공격력
    protected float attackCoolTime = 1f; //몸빵 공격이 이루어질 쿨타임(간격)
    protected float lastAttackTime; //마지막 몸빵 공격 시점
    

    protected void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player"); //플레이어 태그 가진 게임 오브젝트를 타겟에 할당
        if (target == null)
        {
            Debug.Log("타겟 없음!");
            return;
        }
        monRigidbody = GetComponent<Rigidbody2D>(); //몬스터의 리지드바디 컴포넌트를 가져오기    
    }

    protected virtual void Move()
    {
        if(target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized; //몬스터가 이동하려는 방향
            monRigidbody.linearVelocity = moveDirection * monSpeed;
        }
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        //죽으면서 가중치에 따라 아이템 드랍하는 로직 추가
    }

    public override void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
        Debug.Log("아야");
    }

    protected virtual void Attack() //몬스터의 공격 스킬, 플레이어만 공격하길
    {

    }

    protected virtual void BumpAttack(Collider2D other)
    {
        if (Time.time - lastAttackTime < attackCoolTime) //쿨타임이 지났는지 검사
        {
            return;
        }
        Vector2 hitPoint = other.ClosestPoint(transform.position);
        Vector2 hitNormal = (hitPoint - (Vector2)transform.position).normalized;

        PlayerInform player = other.GetComponent<PlayerInform>(); //충돌 대상이 플레이어인지 검사
        if (player != null) 
        {
            player.OnDamage(monDamage, hitPoint, hitNormal);
            lastAttackTime = Time.time;
        }

    }


}
