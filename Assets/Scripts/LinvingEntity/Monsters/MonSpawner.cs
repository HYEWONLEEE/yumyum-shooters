using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
//카메라 경계 바깥에서 몬스터가 스폰되도록 하는 스크립트
//오브젝트 풀링 사용
public class MonSpawner : MonoBehaviour
{
    public MonPool monsterPool; //풀. 
    public GameObject monsterPrefab;
    public GameObject player; //플레이어의 위치를 받아오기 위함
    private float offset = 2f;
    private float spawnInterval = 2f; //스폰 주기
    public int initialPoolSize = 30; //초기 풀 사이즈 //

    private float timer = 0;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            enabled = false; //메인 씬 활성화되어있지 않으면 스크립트 비활성화
            return;
        }
        monsterPool.InitializePool(monsterPrefab, initialPoolSize);

    }

    public void Update()
    {
        timer += Time.deltaTime; //시간 갱신

        if (timer > spawnInterval)
        { 
            SpawnMonster();
            timer = 0;
        }
    }

    public void SpawnMonster()
    {
        GameObject monster = monsterPool.GetObject(); //풀에서 오브젝트 받아오기 
        monster.transform.position = CamBound.GetRandomSpawnPoint(offset); //CamBound는 static 으로 선언했기 때문에 바로 사용 가능
        //몬스터 오브젝트가 Enable 될 때 스스로 초기화 하니까 초기화는 생략
    }

}
