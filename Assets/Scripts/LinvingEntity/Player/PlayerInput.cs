using UnityEditor.Build.Content;
using UnityEngine;
//플레이어 캐릭터 조작을 위한 입력 감지 스크립트
//감지된 입력값을 사용할 수 있게 하기
public class PlayerInput : MonoBehaviour
{
    public string xInputName = "Horizontal"; //좌우이동 입력축 이름
    public string yInputName = "Vertical"; //앞뒤이동 입력축 이름

    public float xSense {  get; private set; }
    public float ySense { get; private set; }

    private void Update()
    {
        //if (GameManager.instance != null && GameManager.instance.isGameover) 
        //{
            //게임오버 상태이거나 게임 매니저가 없을 때 입력 감지하지 x
           // xSense = 0;
           // ySense = 0;
           // return;
       // }

        xSense = Input.GetAxis(xInputName);
        ySense = Input.GetAxis(yInputName);
    }
}
 