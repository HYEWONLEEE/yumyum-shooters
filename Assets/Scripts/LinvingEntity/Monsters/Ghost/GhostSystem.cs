using UnityEngine;

public class GhostSystem : MonSystem //상속 .
{
    public MonData ghostData;

    private void OnEnable()//활성화 시 체력 초기화 처리
    {
        entireHealth = ghostData.health;
        monDamage = ghostData.damage;
        monSpeed = ghostData.speed;

        InitializeHealth(); //체력 초기화 함수
        Debug.Log("귀신의 체력은 : " + entireHealth);

    }

    private void Update()
    {
        if (dead == true)
        {
            Die();
            //return;
        }
    }

    protected override void Attack()
    {

    }

    public override void Die()
    {
        base.Die();
    }

    private void FixedUpdate()
    {
        GetTarget();
        if (target != null)
        {
            base.Move();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        BumpAttack(other);
    }
}

