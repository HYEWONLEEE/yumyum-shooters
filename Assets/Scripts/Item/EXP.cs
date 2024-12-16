using JetBrains.Annotations;
using UnityEngine;
//경험치 오브젝트의 스폰과 사용에 관한 처리
public class EXP : MonoBehaviour, IItem
{
    public float expValue;
    public ExpSpawner expSpawner;

    private bool hasBeenUsed = false;

  
    public void Use(GameObject target)
    { 
        if (hasBeenUsed) return;
        
        PlayerInform player = target.GetComponent<PlayerInform>();
        //타겟이 플레이어가 맞으면 경험치 증가
        if (player != null) //컴포넌트 가져오기 성공 = 플레이어 맞음 
        {
            player.GetExp(expValue); //playerInform의 경험치 획득 메서드 수행
            Debug.Log("경험치 겟" + expValue);
        }

        hasBeenUsed = true;

        Destroy(gameObject); //사용되었으므로 자신을 파괴

    }

    public void OnDestroy()
    {
        expSpawner.OnOrbDestroyed();
    }
}
