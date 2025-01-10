using UnityEngine;

public class GhostSystem : MonSystem //��� .
{
    public MonData ghostData;
    private bool initialized;

    private void OnEnable()//Ȱ��ȭ �� ü�� �ʱ�ȭ ó��,
    {
        if (!initialized)
        {
            entireHealth = ghostData.health;
            monDamage = ghostData.damage;
            monSpeed = ghostData.speed;
            GetTarget();

            InitializeHealth(); //ü�� �ʱ�ȭ �Լ�
                                //Debug.Log("�ͽ��� ü���� : " + entireHealth);

            initialized = true;
        }

    }

    private void Update()
    {
        if (dead == true)
        {
            Die();
            
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

