using UnityEngine;
//������ ����. �ν��� �� �������� ������. ���ڴ� ������ �ð� �������� �ʿ� n���� ������.
//Ȯ���� ���� ����, ����ġ ������ ������, ���۽��� ��ȭ��(����)�� ���� ������.
public class ItemBox : MonoBehaviour, IDamageable //������ ���� �� ����
{
    public GameObject healPackPrefab;
    public ItemBoxSpawner boxSpawner;
    public int myNumber; //������ �ڽ� �ڽ��� ��ȣ 
    private Animator boxAnimator; //�ڽ��� �ִϸ����� ������Ʈ

    private void Awake()
    {
        boxSpawner = FindFirstObjectByType<ItemBoxSpawner>();
        boxAnimator = GetComponent<Animator>();
    }
    public void OnDamage(float damage, Vector2 hitPoint, Vector2 hitnormal)
    {
        boxAnimator.SetTrigger("Break"); //�ִϸ��̼� ���
    }

    public void SpawnHealPack()
    {
        Quaternion rotation = Quaternion.identity; //�⺻ ȸ��
        Vector2 position = transform.position; //���� ������Ʈ (����)�� ��ġ
        GameObject newHealPack = Instantiate(healPackPrefab, position, rotation); //���� ����
    }

    public void AnimEnd()//�ִϸ��̼��� ���� �� ȣ��ǵ��� ��
    {
        SpawnHealPack();
        Destroy(gameObject); //�ڽ� �ı�
    }
    public void OnDestroy() 
    {
        boxSpawner.OnBoxDestroyed(myNumber);
        Debug.Log(myNumber + "��ġ�� �ڽ� �ı�");
    }

}

