using UnityEngine;
using System.Collections.Generic;

public class MonPool : MonoBehaviour
{
    public GameObject prefab; //생성할 몬스터의 프리팹
    public int poolSize; //풀 크기

    private List<GameObject> pool = new List<GameObject>();

    public void InitializePool(GameObject prefab, int initialPoolSize) //풀 초기화 함수 
    {
        this.prefab = prefab;
        this.poolSize = initialPoolSize;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab); //게임 오브젝트 생성
            obj.SetActive(false);
            pool.Add(obj); //오브젝트 풀에 프리팹으로 생성한 게임 오브젝트 추가
        }
    }


    public GameObject GetObject() //오브젝트 풀에서 오브젝트를 꺼내오는 메서드
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy) 
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab); //풀에 여유가 없으면 새 객체 추가
        newObj.SetActive(false);
        pool.Add(newObj); //새 객체를 풀에 추가함 
        return newObj;
    }


    public void ReturnObject(GameObject obj) //오브젝트를 풀에 반환하는 메서드
    {
        obj.SetActive(false);
    }
    
}
