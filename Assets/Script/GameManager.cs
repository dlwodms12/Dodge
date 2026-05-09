using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameoverText; //게임 오버 시 활성화할 텍스트 오브젝트
    public Text timeText;
    public Text recordText;

    private float surviveTime; //생존시간
    private bool isGameover; //게임 오버 상태

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        //경과 시간 표시(게임 오버가 아닌 동안)
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
        //게임 오버 상태에서 R키를 누름
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //씬을 다시 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //현재 게임을 게임오버 상태로 변경하는 메소드
    public void EndGame()
    {
        //현재 게임 상태를 게임 오버로 전환
        isGameover = true;

        //게임 오버 텍스트 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 이전까지의 최고 기록을 가져옴
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //최고기록을 갱신했다면
        if (surviveTime > bestTime) 
        {
            //갱신
            bestTime = surviveTime;
            //저장
            PlayerPrefs.SetFloat("BestTime", bestTime);   
        }
        recordText.text = "Best Time : " + (int)bestTime;
    }
}
