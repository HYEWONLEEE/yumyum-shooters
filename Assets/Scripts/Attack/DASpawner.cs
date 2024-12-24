using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class DASpawner : MonoBehaviour
{   //DA생성 / DA 발사 방향 설정 / 실제 발사 처리
    public GameObject daPrefab;
    public DAData daData;
    
    //발사 지점 = spawner오브젝트의 transform.position
     
   
    private float timeAfterShot; //마지막 발사 이후 지난 시간


    void Strat()
    {
        timeAfterShot = 0f;
       
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            enabled = false; //메인 씬 활성화되어있지 않으면 스크립트 비활성화
            return;
        }

        timeAfterShot += Time.deltaTime; 

        if(timeAfterShot >= daData.timeBetShot)
        {
            timeAfterShot = 0f; //다시 초기화

            //카메라 관점의 마우스 좌표를 스크린 좌표로 반환
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 direction = (mousePos - transform.position).normalized; //방향 구하기

            transform.up = direction; 
            GameObject da = Instantiate(daPrefab, transform.position, transform.rotation);
            
        }
        
    }

}

