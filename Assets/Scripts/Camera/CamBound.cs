using UnityEngine;
//카메라의 경계를 선택해서 그 경계의 랜덤한 스폰 포인트를 지정하는 클래스

public class CamBound : MonoBehaviour
{
    public static Vector3 GetRandomSpawnPoint(float offset)
    {
        Camera cam = Camera.main; //사용할 카메라 
        float height = 2f * cam.orthographicSize; //카메라 높이
        float width = height * cam.aspect; //카메라 너비

        Vector3 spawnPoint = Vector3.zero; //반환할 스폰 포인트 변수
        int side = Random.Range(0, 4); //경계면 선택

        switch (side) //경계면에서의 특정 좌표 선택
        {
            case 0: //위쪽 경계
                spawnPoint = new Vector3(Random.Range(-width / 2, width / 2), height / 2 + offset, 0); break;
            case 1://아래쪽 경계
                spawnPoint = new Vector3(Random.Range(-width / 2, width / 2), -height / 2 - offset, 0); break;
            case 2://왼쪽 경계
                spawnPoint = new Vector3(-width / 2 - offset, Random.Range(-height / 2, height / 2), 0); break;
            case 3://오른쪽 경계
                spawnPoint = new Vector3(width / 2 + offset, Random.Range(-height / 2, height / 2), 0); break;
        }
        return spawnPoint;
    }
}

