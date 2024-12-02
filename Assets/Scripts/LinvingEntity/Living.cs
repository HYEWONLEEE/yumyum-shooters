using System;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class Living : MonoBehaviour, IDamageable
{
    public float entireHealth { get; protected set; } //시작 체력 
    public float health { get; protected set; } //현 체력
    public bool dead { get; protected set; } //사망 상태
    public event Action onDeath; //사망 시 이벤트
     //활성화 될 때 실행, 초기화 처리
  
    protected virtual void InitializeHealth()//피통을 초기화하는 메서드
    {
        dead = false; //사망 == false
        health = entireHealth; //현재 체력을 시작 체력으로
    }
    public virtual void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        //데미지를 받았을 때 처리
        health -= damage; //받은 데미지만큼 체력 감소
        if (health <= 0 && !dead) //체력이 0 이하&& 아직 안 죽었으면
        {
            Die(); //죽음
        }
    }

    public virtual void Healing(float newHealth)
    {
        if (dead)
        {
            return;
        }

        //회복 처리
        health += newHealth; //회복량만큼 체력 증가
        if (health > entireHealth) //피통보다 체력이 커지면 최대 체력으로
        {
            health = entireHealth;
        }

    }

    public virtual void Die()
    {
        //죽음 처리
        if (onDeath != null) //onDeath 이벤트에 등록된 메서드 있으면 실행
        {
            onDeath();
        }

        dead = true;

    }
}
