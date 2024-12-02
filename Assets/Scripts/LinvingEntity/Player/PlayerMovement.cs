using UnityEngine;
//실제 움직임처리, 맵 밖으로 벗어나지 않도록 조정
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float minX = -50f;
    public float maxX = 50f;
    public float minY = -50f;
    public float maxY = 50;

    private PlayerInput playerInput;
    private Rigidbody2D playerRigidbody;
    //private Animator PlayerAnimator; 

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() //플레이어가 맵 밖으로 벗어나는 지 검사..
    { //모든 오브젝트에 대해서 적용할 수 있는 방법 필요 
        //바운더리 컨트롤러 스크립트 따로 만들기 
        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        transform.position = currentPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(playerInput.xSense, playerInput.ySense).normalized; //이동 방향 설정
        playerRigidbody.linearVelocity = moveDirection * speed; //이동 속도 
    }
}
