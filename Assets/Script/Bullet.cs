using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;

        //3초 뒤 파괴
        Destroy(gameObject, 3f);
    }

    //Is Trigger 가 체크된 트리거 콜라이더이므로 OnTriggerEnter()를 작성
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 오브젝트가 player라면
        if(other.tag == "Player")
        {
            //충돌한 오브젝트에서 playerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                //상대방 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
