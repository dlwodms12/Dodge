using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody playerRigidbody; //플레이어의 리지드바디를 가리킬 변수
    public float speed = 8f;  //이동속도를 저장할 변수

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //입력감지
        if(Input.GetKey(KeyCode.UpArrow)==true)
        {
            //위쪽 방향키 = z방향
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            //아래쪽 방향키 = -z방향
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            //오른쪽 방향키 = x방향
            playerRigidbody.AddForce(speed, 0f,0f);
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            //왼쪽 방향키 = -x방향
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }

    }
}
