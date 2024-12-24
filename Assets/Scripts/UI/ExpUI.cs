using UnityEngine;
using UnityEngine.UI;
using TMPro;
//경험치 바, 텍스트와 연동하는 처리 수행 
public class ExpUI : MonoBehaviour
{
    public GameObject player; //플레이어 오브젝트
    private PlayerInform expInform; //경험치 정보 가져올 변수
    
    public Slider expBar; //경험치 슬라이더 UI
    public TextMeshProUGUI levelText; //레벨 텍스트 UI, TextMeshPro를 이용하므로 이렇게 선언
    public TextMeshProUGUI expText; //경험치 텍스트 UI
    public void Start()
    {
        expInform = player.GetComponent<PlayerInform>();
        if (expInform == null) { return; }
        expBar.maxValue = expInform.entireExp;
        
    }

    private void Update()
    {
        UpdateExpUI();
    }

    public void UpdateExpUI()
    {
        expBar.value = expInform.exp;
        expBar.maxValue = expInform.entireExp; //경험치바의 최댓값도 같이 갱신해줘야대.

        expText.text = expInform.exp + " / " + expInform.entireExp;
        levelText.text = "LV : " + expInform.level.ToString();
    }
}
