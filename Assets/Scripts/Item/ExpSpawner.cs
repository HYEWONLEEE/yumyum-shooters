using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

//����ġ�� ���ؼ� ����ġ ���갡 ���� ����ġ ���� ������
//�� ������ ����ġ ���갡 �����ǵ��� �� 
public class ExpSpawner : MonoBehaviour
{
    public GameObject expOrbPrefab; //����ġ ������ ������
    public Sprite[] orbSprite;
    public GameObject field; //���� ������ ��(�ʵ�)

    public float spawnInterval = 3f; //���� ����
    public int numberOfOrbsPerSpawn = 10; //�ѹ��� �����ϴ� ����
    public int maxOrbs = 100; //���� ����
    public bool isGameover = false; //���� ���� ���� 
    private int currentOrbs = 0; //���� ���� ����

    public (float value, float size, Sprite sprite)[] expOrbOptions;

    private int[] weights = { 60, 25, 15 }; //���� Ȯ�� �����ϴ� ����ġ 


    public void Start()
    {
        expOrbOptions = new (float, float, Sprite)[]
        {
        (5f, 0.4f, orbSprite[0]),
        (10f, 0.5f, orbSprite[1]),
        (25f, 0.65f, orbSprite[2]) //��, ũ���� ���� ~ ���õ� ����ġ�� ���� ��� �ɼ��� �ݿ� 
        }; //�ɼǵ��� ���� �迭
        if (SceneManager.GetActiveScene().name != "Main")
        {
            enabled = false; //���� �� Ȱ��ȭ�Ǿ����� ������ ��ũ��Ʈ ��Ȱ��ȭ
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
            }//���� ���Ѻ��� ���� ���� ����

            yield return new WaitForSeconds(spawnInterval); //���͹� ��� 
        }
    }
    private (float value, float size, Sprite sprite) GetRandomExp() //� ������ ����ġ�� ������ �����ϴ� �޼���
    {
        int totalWeight = 0;
        foreach (int weight in weights)
        {
            totalWeight += weight; //����ġ�� �� ���
        }

        int randomValue = Random.Range(0, totalWeight);

        int cumulWeight = 0; //���� ����ġ
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


    public void SpawnExpOrbs() //���� ��ġ�� ���긦 ������ 
    {
        
        Renderer fieldRenderer = field.GetComponent<Renderer>();
        Vector2 fieldSize = fieldRenderer.bounds.size;
        Vector2 fieldCenter = fieldRenderer.bounds.center; //���� ������� ��� ��ǥ �޾ƿ���

        for (int i = 0; i < numberOfOrbsPerSpawn; i++) //�ִ� ���� ��ŭ�� ����
        {
            if (currentOrbs > maxOrbs)
            {
                break;
            } //�������� ���� �������� �׸�

            float randomX = Random.Range(fieldCenter.x - fieldSize.x / 2, fieldCenter.x + fieldSize.x / 2);
            float randomY = Random.Range(fieldCenter.y - fieldSize.y / 2, fieldCenter.y + fieldSize.y / 2);

            Vector2 spawnPosition = new Vector2(randomX, randomY); //���� ���� ���� 


            var selectedOrb = GetRandomExp(); //���� �ɼ� ����

            GameObject newOrb = Instantiate(expOrbPrefab, spawnPosition, Quaternion.identity);
            newOrb.transform.localScale = Vector3.one * selectedOrb.size; //������ ����
            
            SpriteRenderer spriteRenderer = newOrb.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = selectedOrb.sprite; //��������Ʈ ����

            EXP orbScript = newOrb.GetComponent<EXP>(); //����ġ �� �Ҵ� , ����ġ 
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
