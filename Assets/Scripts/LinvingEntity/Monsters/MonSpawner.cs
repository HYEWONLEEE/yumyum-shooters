using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
//ī�޶� ��� �ٱ����� ���Ͱ� �����ǵ��� �ϴ� ��ũ��Ʈ
//������Ʈ Ǯ�� ���
public class MonSpawner : MonoBehaviour
{
    public MonPool monsterPool; //Ǯ. 
    public GameObject monsterPrefab;
    public GameObject player; //�÷��̾��� ��ġ�� �޾ƿ��� ����
    private float offset = 2f;
    private float spawnInterval = 2f; //���� �ֱ�
    public int initialPoolSize = 30; //�ʱ� Ǯ ������ //

    private float timer = 0;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            enabled = false; //���� �� Ȱ��ȭ�Ǿ����� ������ ��ũ��Ʈ ��Ȱ��ȭ
            return;
        }
        monsterPool.InitializePool(monsterPrefab, initialPoolSize);

    }

    public void Update()
    {
        timer += Time.deltaTime; //�ð� ����

        if (timer > spawnInterval)
        { 
            SpawnMonster();
            timer = 0;
        }
    }

    public void SpawnMonster()
    {
        GameObject monster = monsterPool.GetObject(); //Ǯ���� ������Ʈ �޾ƿ��� 
        monster.transform.position = CamBound.GetRandomSpawnPoint(offset); //CamBound�� static ���� �����߱� ������ �ٷ� ��� ����
        //���� ������Ʈ�� Enable �� �� ������ �ʱ�ȭ �ϴϱ� �ʱ�ȭ�� ����
    }

}
