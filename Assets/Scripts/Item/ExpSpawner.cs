using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

//가중치를 통해서 경험치 오브가 가질 경험치 값을 결정함
//맵 전역에 경험치 오브가 생성되도록 함 
public class ExpSpawner : MonoBehaviour
{
    public GameObject expOrbPrefab; //경험치 오브의 프리팹
    public Sprite[] orbSprite;
    public GameObject field; //오브 생성할 맵(필드)

    public float spawnInterval = 3f; //생성 간격
    public int numberOfOrbsPerSpawn = 10; //한번에 생성하는 개수
    public int maxOrbs = 100; //생성 제한
    public bool isGameover = false; //게임 오버 상태 
    private int currentOrbs = 0; //현재 오브 개수

    public (float value, float size, Sprite sprite)[] expOrbOptions;

    private int[] weights = { 60, 25, 15 }; //출현 확률 결정하는 가중치 


    public void Start()
    {
        expOrbOptions = new (float, float, Sprite)[]
        {
        (5f, 0.4f, orbSprite[0]),
        (10f, 0.5f, orbSprite[1]),
        (25f, 0.65f, orbSprite[2]) //값, 크기을 매핑 ~ 선택된 가중치에 따라 모든 옵션이 반영 
        }; //옵션들을 담을 배열
        if (SceneManager.GetActiveScene().name != "Main")
        {
            enabled = false; //메인 씬 활성화되어있지 않으면 스크립트 비활성화
            return;
        }
        StartCoroutine(CheckOrbCount());
    }

    private IEnumerator CheckOrbCount()
    {
        while(!isGameover)
        {
            if (currentOrbs < maxOrbs)
            {
                SpawnExpOrbs();
            }//생성 제한보다 적을 때만 생성

            yield return new WaitForSeconds(spawnInterval); //인터벌 대기 
        }
    }
    private (float value, float size, Sprite sprite) GetRandomExp() //어떤 값으로 경험치를 만들지 결정하는 메서드
    {
        int totalWeight = 0;
        foreach (int weight in weights)
        {
            totalWeight += weight; //가중치의 합 계산
        }

        int randomValue = Random.Range(0, totalWeight);

        int cumulWeight = 0; //누적 가중치
        for (int i = 0; i < expOrbOptions.Length; i++)
        {
            cumulWeight += weights[i];
            if (randomValue < cumulWeight)
            {
                return expOrbOptions[i];
            }
        }

        return expOrbOptions[0];
    }


    public void SpawnExpOrbs() //스폰 위치에 오브를 생성함 
    {
        
        Renderer fieldRenderer = field.GetComponent<Renderer>();
        Vector2 fieldSize = fieldRenderer.bounds.size;
        Vector2 fieldCenter = fieldRenderer.bounds.center; //맵의 사이즈랑 가운데 좌표 받아오깅

        for (int i = 0; i < numberOfOrbsPerSpawn; i++) //최대 개수 만큼만 생성
        {
            if (currentOrbs > maxOrbs)
            {
                break;
            } //생성제한 보다 많아지면 그만

            float randomX = Random.Range(fieldCenter.x - fieldSize.x / 2, fieldCenter.x + fieldSize.x / 2);
            float randomY = Random.Range(fieldCenter.y - fieldSize.y / 2, fieldCenter.y + fieldSize.y / 2);

            Vector2 spawnPosition = new Vector2(randomX, randomY); //스폰 지점 정함 


            var selectedOrb = GetRandomExp(); //값과 옵션 선택

            GameObject newOrb = Instantiate(expOrbPrefab, spawnPosition, Quaternion.identity);
            newOrb.transform.localScale = Vector3.one * selectedOrb.size; //사이즈 변경
            
            SpriteRenderer spriteRenderer = newOrb.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = selectedOrb.sprite; //스프라이트 변경

            EXP orbScript = newOrb.GetComponent<EXP>(); //경험치 값 할당 , 경험치 
            if (orbScript != null)
            {
                orbScript.expValue = selectedOrb.value;
                orbScript.expSpawner = this;
            }

            currentOrbs++;
        }
    }

    public void OnOrbDestroyed()
    {
        currentOrbs--;
    }
}
