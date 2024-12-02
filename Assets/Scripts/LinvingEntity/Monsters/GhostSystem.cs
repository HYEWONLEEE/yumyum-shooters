using UnityEngine;

public class GhostSystem : MonSystem //��� .
{
    public MonData ghostData;

    private void OnEnable()//Ȱ��ȭ �� ü�� �ʱ�ȭ ó��
    {
        entireHealth = ghostData.health;
        monDamage = ghostData.damage;
        monSpeed = ghostData.speed;

        InitializeHealth(); //ü�� �ʱ�ȭ �Լ�
        Debug.Log("�ͽ��� ü���� : " + entireHealth);

    }


    protected override void Attack()
    {

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
