using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody playerRigidbody; //플레이어의 리지드바디를 가리킬 변수
    public float speed = 8f;  //이동속도를 저장할 변수

    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동속도를 입력값과 이동속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;  

        //Vector3 속도를 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //리지드바디의 속도에 newVelocity 할당
        playerRigidbody.linearVelocity = newVelocity;


    }
    //외부에서 접근해서 실행할 수 있도록 public 으로 선언
    public void Die()
    {
        //현재 이 스크립트가 가리키고 있는 오브젝트를 비활성화 == 죽음
        gameObject.SetActive(false);

        //씬에 존재하는 게임 매니저 오브젝트를 찾아서 가져옴
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        //가져온 게임 매니저의 EndGame() 메서드 실행
        gameManager.EndGame();
    }
}
