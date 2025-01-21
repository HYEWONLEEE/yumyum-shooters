using UnityEngine;
using UnityEngine.InputSystem;
//�÷��̾� ĳ���� ������ ���� �Է� ���� ��ũ��Ʈ
//������ �Է°��� ����� �� �ְ� �ϱ�
public class PlayerInput : MonoBehaviour
{
    public string xInputName = "Horizontal"; //�¿��̵� �Է��� �̸�
    public string yInputName = "Vertical"; //�յ��̵� �Է��� �̸�
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
        if (xSense < 0) //�������� �̵� ��
        {
            spriteRenderer.flipX = true; //�¿� �����ϱ�
        }
        else if (xSense > 0)
        {
            spriteRenderer.flipX = false; //���������� �̵��ÿ��� �״�� 
        }
    }

    private void InputSense()
    {
        if (xSense == 0 && ySense == 0) //�Է��� �������� ������
        {
            playerAnimator.SetBool("Run", false); //�޸��� �ִϸ��̼� ����x
        }
        else
        {
            playerAnimator.SetBool("Run", true);
        }
    }
}
 