using Unity.VisualScripting;
using UnityEngine;
//탄알의 생성, 동작, 소멸 처리
public class DAAction : MonoBehaviour
{
    //컴포넌트들
    
    private Rigidbody2D daRigidbody;

    private float speed = 10f; //탄환의 발사 속력
    private float distance = 20f; //사정거리
    
    public DAData daData; //현재 DA의 정보

    public void Awake()
    {   //탄환이 태어날 때 마우스 포인터를 바라보면서 태어나니까 앞쪽으로 이동만 하면 됨
        daRigidbody = GetComponent<Rigidbody2D>(); //리지드바디 컴포넌트 할당(이동에 사용)
        
        daRigidbody.linearVelocity = transform.up.normalized * speed; //** transform*right 는 마우스 포인터 좌표로 바꿔줘야 함 
        Destroy(gameObject, (distance/speed)); //2초 이후 사거리 끝에 도달 -> 파괴
        
    }

    public void OnTriggerEnter2D(Collider2D other) //충돌 처리 메서드 
    {
        IDamageable target = other.GetComponent<IDamageable>();
        //몬스터, 벽하고만 충돌하게하고 몬스터에게만 데미지 입힘
        //탄환, 스킬, 플레이어는 충돌 무시

        Vector2 hitPoint = other.ClosestPoint(transform.position);
        Vector2 hitNormal = (hitPoint - (Vector2)transform.position).normalized;
        if (target != null && other.tag != "Player") //충돌 대상이 플레이어가 아니면 데미지 입히기
        {
            target.OnDamage(daData.damage, hitPoint, hitNormal);
            Destroy(gameObject);
        }
        if (other.CompareTag("Obstacle")) //충동 대상이 장애물 태그를 가지고 있을 때 탄환 파괴하기
        {
            Destroy(gameObject);
        }


    }

}

