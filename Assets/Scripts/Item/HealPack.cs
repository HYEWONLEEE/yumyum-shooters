using UnityEngine;

public class HealPack : MonoBehaviour, IItem
{
    public float healthValue = 50f;
    private SpriteRenderer spriteRenderer; //��������Ʈ ������ ������Ʈ ��������
    public Sprite[] healPackSprite; //���� ��������Ʈ �迭

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SwitchingSprite(SelectSprite());
    }

    public void Use(GameObject target)
    {
        PlayerInform player = target.GetComponent<PlayerInform>();
        //Ÿ���� �÷��̾ ������ ü�� ȸ��
        if (player != null) //������Ʈ �������� ���� = �÷��̾� ���� 
        {
            player.Healing(healthValue); //playerInform�� Healing �޼��� ����
            Debug.Log("ȸ���Ǿ��� : " + healthValue);
        }

        Destroy(gameObject); //���Ǿ����Ƿ� �ڽ��� �ı�
    }
    private Sprite SelectSprite()
    {
        int i = Random.Range(0, 10);
        Sprite selectedSprite = healPackSprite[i];
        return selectedSprite;
    }
    private void SwitchingSprite(Sprite selectedSprite)//��������Ʈ�� �����ϰ� �ٲ��ִ� �Լ�
    {
        spriteRenderer.sprite = selectedSprite;
    }
}
