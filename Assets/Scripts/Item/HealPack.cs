using UnityEngine;

public class HealPack : MonoBehaviour, IItem
{
    public float healthValue = 50f;
   
    public void Use(GameObject target)
    {
        PlayerInform player = target.GetComponent<PlayerInform>();
        //타겟이 플레이어가 맞으면 체력 회복
        if (player != null) //컴포넌트 가져오기 성공 = 플레이어 맞음 
        {
            player.Healing(healthValue); //playerInform의 Healing 메서드 실행
            Debug.Log("회복되었다 : " + healthValue);
        }

        Destroy(gameObject); //사용되었으므로 자신을 파괴
    }
}
