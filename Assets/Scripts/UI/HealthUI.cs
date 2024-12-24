using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject player; //플레이어 게임 오브젝트
    private PlayerInform hpInform; //체력 정보 가져올 변수

    public Slider hpBar; //체력 슬라이더 UI

    public void Start()
    {
        hpInform = player.GetComponent<PlayerInform>();
        if (hpInform == null ) { return; }

        hpBar.maxValue = hpInform.entireHealth;
    }

    private void Update()
    {
        UpdateHpUI();
    }

    public void UpdateHpUI()
    {
        hpBar.value = hpInform.health;
        hpBar.maxValue = hpInform.entireHealth; 

    }
}
