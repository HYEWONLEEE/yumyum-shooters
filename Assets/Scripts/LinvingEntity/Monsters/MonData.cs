using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/MonData", fileName = "MonData")]
public class MonData : ScriptableObject
{
    public float health = 100f; //체력
    public float damage = 20f; //공격력
    public float speed = 2f; //이동속도
    
}
