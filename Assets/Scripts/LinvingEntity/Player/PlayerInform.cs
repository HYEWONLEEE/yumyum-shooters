using UnityEngine;
//플레이어의 체력, 경험치 관리
public class PlayerInform : Living
{
    public float entireExp = 100f; //경험치 바 
    
    public float exp { get; protected set; } //현재 경험치 획득량
    public int level { get; protected set; } //레벨

    private PlayerMovement playerMovement;
    private DASpawner daSpawner;

    private void Awake() //사용할 컴포넌트 가져오기 
    {
        playerMovement = GetComponent<PlayerMovement>();
        daSpawner = GetComponentInChildren<DASpawner>(); //daspawner는 자식오브젝트의 컴포넌트
    }
    public void Start()
    {
        entireHealth = 100f; //피통 설정
        exp = 0; //처음에 0으로 설정
        InitializeHealth();
        level = 1;

        playerMovement.enabled = true;
        daSpawner.enabled = true;
    }
    //데미지 입음 처리
    public override void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
    }

    //죽음 처리
    public override void Die()
    {
        base.Die();

        playerMovement.enabled = false;
        daSpawner.enabled = false;
    }

    //회복 처리
    public override void Healing(float newHealth)
    {
        base.Healing(newHealth);
    }

    //경험치 처리
    public void GetExp(float newExp)
    {
        if (!dead) //죽지 않았을 때만 경험치 겟 
        {
            this.exp += newExp; //얻은 경험치 양만큼 갱신
            if (this.exp >= entireExp) //경험치 바 크기보다 현재 경험치가 많아지면
            {
                LevelUp();  //레벨업 처리
            }
        }

    }

    public void LevelUp()
    {
        {
            this.exp -= entireExp; //현 경험치 - 경험치바 크기로 조정 
            level++; //레벨 업
            entireExp += 50f; //경험치 통 키우기 
            entireHealth += 50f; //피통 키우기
            health = entireHealth; //피통 꽉 채우기

            
            //레벨업 이후 스킬 업그레이드, 능력치 조정 등의 처리 할 예정
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  //아이템과 충돌 시 아이템 사용 
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
