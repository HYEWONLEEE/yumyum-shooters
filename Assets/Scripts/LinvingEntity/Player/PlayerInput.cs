using UnityEngine;
using UnityEngine.InputSystem;
//플레이어 캐릭터 조작을 위한 입력 감지 스크립트
//감지된 입력값을 사용할 수 있게 하기
public class PlayerInput : MonoBehaviour
{
    public string xInputName = "Horizontal"; //좌우이동 입력축 이름
    public string yInputName = "Vertical"; //앞뒤이동 입력축 이름
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    public float xSense { get; private set; }
    public float ySense { get; private set; }


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
 

        xSense = Input.GetAxis(xInputName);
        ySense = Input.GetAxis(yInputName);

        LRSetting();
        InputSense();


    }

    private void LRSetting()
    {
        if (xSense < 0) //왼쪽으로 이동 시
        {
            spriteRenderer.flipX = true; //좌우 반전하기
        }
        else if (xSense > 0)
        {
            spriteRenderer.flipX = false; //오른쪽으로 이동시에는 그대로 
        }
    }

    private void InputSense()
    {
        if (xSense == 0 && ySense == 0) //입력이 감지되지 않으면
        {
            playerAnimator.SetBool("Run", false); //달리기 애니메이션 실행x
        }
        else
        {
            playerAnimator.SetBool("Run", true);
        }
    }
}
 