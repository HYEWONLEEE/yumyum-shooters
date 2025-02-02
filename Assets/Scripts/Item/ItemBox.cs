using UnityEngine;
//아이템 상자. 부숴질 때 아이템이 스폰됨. 상자는 일정한 시간 간격으로 맵에 n개씩 스폰됨.
//확률에 따라 힐팩, 경험치 모으기 아이템, 슈퍼슈퍼 강화템(무적)이 랜덤 스폰됨.
public class ItemBox : MonoBehaviour, IDamageable //데미지 입을 수 있음
{
    public GameObject healPackPrefab;
    public ItemBoxSpawner boxSpawner;
    public int myNumber; //생성된 박스 자신의 번호 
    private Animator boxAnimator; //박스의 애니메이터 컴포넌트

    private void Awake()
    {
        boxSpawner = FindFirstObjectByType<ItemBoxSpawner>();
        boxAnimator = GetComponent<Animator>();
    }
    public void OnDamage(float damage, Vector2 hitPoint, Vector2 hitnormal)
    {
        boxAnimator.SetTrigger("Break"); //애니메이션 재생
    }

    public void SpawnHealPack()
    {
        Quaternion rotation = Quaternion.identity; //기본 회전
        Vector2 position = transform.position; //현재 오브젝트 (상자)의 위치
        GameObject newHealPack = Instantiate(healPackPrefab, position, rotation); //힐팩 생성
    }

    public void AnimEnd()//애니메이션이 끝난 후 호출되도록 함
    {
        SpawnHealPack();
        Destroy(gameObject); //박스 파괴
    }
    public void OnDestroy() 
    {
        boxSpawner.OnBoxDestroyed(myNumber);
        Debug.Log(myNumber + "위치의 박스 파괴");
    }

}

