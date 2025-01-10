using UnityEngine;
//ī�޶��� ��踦 �����ؼ� �� ����� ������ ���� ����Ʈ�� �����ϴ� Ŭ����

public class CamBound : MonoBehaviour
{
    public static Vector3 GetRandomSpawnPoint(float offset)
    {
        Camera cam = Camera.main; //����� ī�޶� 
        float height = 2f * cam.orthographicSize; //ī�޶� ����
        float width = height * cam.aspect; //ī�޶� �ʺ�

        Vector3 spawnPoint = Vector3.zero; //��ȯ�� ���� ����Ʈ ����
        int side = Random.Range(0, 4); //���� ����

        switch (side) //���鿡���� Ư�� ��ǥ ����
        {
            case 0: //���� ���
                spawnPoint = new Vector3(Random.Range(-width / 2, width / 2), height / 2 + offset, 0); break;
            case 1://�Ʒ��� ���
                spawnPoint = new Vector3(Random.Range(-width / 2, width / 2), -height / 2 - offset, 0); break;
            case 2://���� ���
                spawnPoint = new Vector3(-width / 2 - offset, Random.Range(-height / 2, height / 2), 0); break;
            case 3://������ ���
                spawnPoint = new Vector3(width / 2 + offset, Random.Range(-height / 2, height / 2), 0); break;
        }
        return spawnPoint;
    }
}



