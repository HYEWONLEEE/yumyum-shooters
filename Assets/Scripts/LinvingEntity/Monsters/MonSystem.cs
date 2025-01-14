using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;


//���Ϳ� �̵��� ���� ����, ���ݰ� ������ �߻�޼���� �� ���� ������Ʈ�� ����ϵ���
public class MonSystem : Living //Living�� MonoBehaviour�� �̹� ����ϹǷ� ǥ���� �ʿ� x
{
    //2d�̸� ���������� �����Ƿ� ����Ž� ���� ���� ���� ����

    public MonPool monsterPool; //���� Ǯ 
    public GameObject target; //������ ���, �÷��̾�
    protected Rigidbody2D monRigidbody; //���͵��� ������ٵ� ������Ʈ
    private Animator monAnimator;
    private SpriteRenderer spriteRenderer;

    public float monSpeed { get; protected set; } //������ �̵� �ӵ�
    public float monDamage { get ; protected set; } //������ ���ݷ�
    protected float attackCoolTime = 1f; //���� ������ �̷���� ��Ÿ��(����)
    protected float lastAttackTime; //������ ���� ���� ����


    //���Ͱ� �ǰ� �� ��¦ �������� �����
    private Color originalColor; //���� ����
    public float hitFlashDuration = 0.2f; //������ �ð�
    public float alpha = 0.4f; //����

    public Vector2 moveDirection;

    public void Awake()
    {
        monAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        
    }
    protected void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player"); //�÷��̾� �±� ���� ���� ������Ʈ�� Ÿ�ٿ� �Ҵ�
        if (target == null)
        {
            Debug.Log("Ÿ�� ����!");
            return;
        }
        monRigidbody = GetComponent<Rigidbody2D>(); //������ ������ٵ� ������Ʈ�� ��������    
    }

    protected virtual void Move()
    {
        if (target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized; //���Ͱ� �̵��Ϸ��� ����
            monRigidbody.linearVelocity = moveDirection * monSpeed;
            LRSetting();
        }
     }
    

    public override void Die()
    {
        monsterPool = FindFirstObjectByType<MonPool>();
        monsterPool.ReturnObject(gameObject); //���� �� Ǯ�� ��ȯ��
        //�����鼭 ����ġ�� ���� ������ ����ϴ� ���� �߰�
    }

    public override void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
        //Debug.Log("�ƾ�");
        if (gameObject.activeSelf)
        {
            StartCoroutine(FlashRed());
        }
    }

    protected virtual void Attack() //������ ���� ��ų, �÷��̾ �����ϱ�
    {

    }

    protected virtual void BumpAttack(Collider2D other)
    {
        if (Time.time - lastAttackTime < attackCoolTime) //��Ÿ���� �������� �˻�
        {
            return;
        }
        Vector2 hitPoint = other.ClosestPoint(transform.position);
        Vector2 hitNormal = (hitPoint - (Vector2)transform.position).normalized;

        PlayerInform player = other.GetComponent<PlayerInform>(); //�浹 ����� �÷��̾����� �˻�
        if (player != null) 
        {
            player.OnDamage(monDamage, hitPoint, hitNormal);
            lastAttackTime = Time.time;
        }

    }

    private System.Collections.IEnumerator FlashRed()
    {
        if (!gameObject.activeSelf)
        {
            yield break;
        }

        spriteRenderer.color = new Color(1f, 0f, 0f, alpha); //��� ������ ���ϱ�
        yield return new WaitForSeconds(hitFlashDuration); //��� ���
        if (gameObject.activeSelf)
        {
            spriteRenderer.color = originalColor;
        }//����
        }

    private void LRSetting()
    {
        if (moveDirection.x < 0) //�������� �̵� ��
        {
            spriteRenderer.flipX = true; //�¿� �����ϱ�
        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false; //���������� �̵��ÿ��� �״�� 
        }
    }


}
