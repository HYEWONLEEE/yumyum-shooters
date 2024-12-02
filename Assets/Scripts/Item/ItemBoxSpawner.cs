using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using Unity.VisualScripting;

//아이템박스가 맵 고정 위치에 일정 시간이 지날 때마다 스폰되게 함
//고정 위치 10개 중 랜덤한 3 위치에 생성 됨 


public class ItemBoxSpawner : MonoBehaviour
{   
     
    public GameObject itemBoxPrefab; //아이템 박스 프리팹
    
    public Transform parentOfPoints; //스폰 포인트들의 부모 오브젝트, 이미 할당 되어 있음
    public Transform[] spawnPoints; //스폰 포인트 배열 
    public static HashSet<int> activePoints = new HashSet<int>();//활성화된 포인트를 저장하는 해시셋
    //static으루 만드는 이유: 부숴질때도 참조해서 값 비워줘야 함요 
    public float spawnInterval = 30f; //박스 생성 간격
    public int numberOfBoxSpawn = 3; //한 번에 생성하는 박스 개수
    public int maxBox = 16; //최대 생성 제한
    public bool isGameover = false; //게임 오버 상태

    private int currentBox = 0; //현재 맵에 있는 박스 수

    private void Awake() //스폰 포인트들을 배열에 자동 할당해줌
    {
        if (parentOfPoints != null)
        {
            spawnPoints = parentOfPoints.GetComponentsInChildren<Transform>();
            spawnPoints = System.Array.FindAll(spawnPoints, t => t != parentOfPoints); //부모 오브젝트 제외
            //Debug.Log("총 스폰 포인트 :" + spawnPoints.Length); 할당 ok
        
        }
    }

    private void Start()
    {
        StartCoroutine(CheckBoxCount());
    }

    private IEnumerator CheckBoxCount()
    {
        while (!isGameover)
        {
            if (currentBox < maxBox) //박스가 최대 갯수보다 적을 때만 스폰
            {
                SpawnItemBox();
            }
            yield return new WaitForSeconds(spawnInterval); //인터벌 대기
        }
    }

    public void SpawnItemBox() //박스 생성함
    {
        
        int[] selectedPositiontValues = GeneratreRandInts(0, spawnPoints.Length, numberOfBoxSpawn); //0부터 15까지 랜덤한 값 3개를 생성
        //Debug.Log("선택된 포인트 수: " + selectedPositiontValues.Length); 할당 ok
        //받아온 정수값에 해당하는 스폰포인트 포지션에 박스 생성
        foreach (int i in selectedPositiontValues)
        {
            if (currentBox >= maxBox) { 
                break;
            }

            //Debug.Log("선택된 자리 : " + i); ㅇㅋ
            Transform spawnPosition = spawnPoints[i]; //위치 값 받아오기, 여기서 i는 selectedPositionValues[i]와 같다
            GameObject newBox = Instantiate(itemBoxPrefab, spawnPosition.position, Quaternion.identity); //생성조@지기

            ItemBox box = newBox.GetComponent<ItemBox>(); //스크립트 접근하게 가져오고
            box.myNumber = i; //생성되는 박스에 번호 부여 
            currentBox++;
        }

    }
    
    public int[] GeneratreRandInts(int min, int max, int count) //랜덤 정수 3개 만들어 배열로 반환하는 메서드
    {
        HashSet<int> selectedPositions = new HashSet<int>(); //선택된 값을 받을 해시셋

        while (selectedPositions.Count < count)
        {
            int randNumber = UnityEngine.Random.Range(min,max); //랜덤한 수 생성
            if (!activePoints.Contains(randNumber)) //활성화된 포인트 그룹에 있으면 선택하지 않음 
            {
                selectedPositions.Add(randNumber); //선택 배열에 추가
                activePoints.Add(randNumber); //활성화 포인트에 추가
            }
           
        }

        return selectedPositions.ToArray();
    }

    public void OnBoxDestroyed(int boxNumber)
    {
        currentBox--; //현재 박스 갯수 감소
        activePoints.Remove(boxNumber); //활성화 포인트 콜렉션에서 해당 번호 삭제
    }
  

}
