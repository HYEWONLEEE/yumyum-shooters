using UnityEngine;
//�÷��̾��� ü��, ����ġ ����
public class PlayerInform : Living
{
    public float entireExp = 100f; //����ġ �� 
    
    public float exp { get; protected set; } //���� ����ġ ȹ�淮
    public int level { get; protected set; } //����

    private PlayerMovement playerMovement;
    private DASpawner daSpawner;

    private void Awake() //����� ������Ʈ �������� 
    {
        playerMovement = GetComponent<PlayerMovement>();
        daSpawner = GetComponentInChildren<DASpawner>(); //daspawner�� �ڽĿ�����Ʈ�� ������Ʈ
    }
    public void OnEnable()
    {
        entireHealth = 100f; //���� ����
        InitializeHealth();
        level = 1;

        playerMovement.enabled = true;
        daSpawner.enabled = true;
    }
    //������ ���� ó��
    public override void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
    }

    //���� ó��
    public override void Die()
    {
        base.Die();

        playerMovement.enabled = false;
        daSpawner.enabled = false;
    }

    //ȸ�� ó��
    public override void Healing(float newHealth)
    {
        base.Healing(newHealth);
    }

    //����ġ ó��
    public void GetExp(float newExp)
    {
        if (!dead) //���� �ʾ��� ���� ����ġ �� 
        {
            this.exp += newExp; //���� ����ġ �縸ŭ ����
            if (this.exp >= entireExp) //����ġ �� ũ�⺸�� ���� ����ġ�� ��������
            {
                LevelUp();  //������ ó��
            }
        }

    }

    public void LevelUp()
    {
        {
            this.exp -= entireExp; //�� ����ġ - ����ġ�� ũ��� ���� 
            level++; //���� ��
            entireExp += 50f; //����ġ �� Ű��� 
            entireHealth += 50f; //���� Ű���
            health = entireHealth; //���� �� ä���
            //������ ���� ��ų ���׷��̵�, �ɷ�ġ ���� ���� ó�� �� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  //�����۰� �浹 �� ������ ��� 
        if (!dead)
        {
            IItem item = other.GetComponent<IItem>();
            if (item != null)
            {
                item.Use(gameObject);
            }
        }
    }
}