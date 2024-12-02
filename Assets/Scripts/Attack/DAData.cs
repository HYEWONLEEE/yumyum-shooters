using UnityEngine;
//DA의 데이터 저장하는 스크립터블 오브젝트
[CreateAssetMenu(menuName = "Scriptable/DAData", fileName = "DAData")]
public class DAData : ScriptableObject
{
    public AudioClip shotClip; //DA 발사 소리

    public float damage = 20; //DA의 기본 공격력
    public float timeBetShot = 2.0f; //DA의 기본 발사 간격 
}
