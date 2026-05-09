using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f;

    private Transform target; //발사할 대상
    private float spawnRate; //생성주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간 (타이머 역할)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //플레이어를 조준대상으로 설정
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(timeAfterSpawn >= spawnRate)
        {
            //누적된 시간 리셋
            timeAfterSpawn = 0f;

            //총알 프리팹을 생성기 위치, 각도에맞춰 스폰 (인스턴스화)
            GameObject bullet = Instantiate(bulletPrefab,transform.position, transform.rotation);
            //생성한 총알을 타겟방향으로 회전
            bullet.transform.LookAt(target);
            //다음 생성 간격 랜덤 지정
            spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        }
    }
}
