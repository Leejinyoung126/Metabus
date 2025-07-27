using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;//점프하는 힘
    public float forwardSpeed = 3f;//전방 이동속도
    public bool isDead = false;
    float deathCooldown = 0f; //일정 시간이 지난후 죽게

    bool isFlap = false; //점프 실행 여부

    public bool godMode = false; //테스트하기 쉽게 갓모드 추가

    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>(); //하위 오브젝트에 있는 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>(); //컴포넌트 가져오기

        if (animator == null )
        {
            Debug.LogError("Not Founded Animator"); //에니메이터를 찾지 못한경우 에러문구 출력
        }

        if ( _rigidbody == null )
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
       
        
            //스페이스바나 좌클릭시 점프함
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
                isFlap = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        //점프의 힘만큼 점프시킴
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        //각도도 꺾이게 하기
        float angle = Mathf.Clamp( (_rigidbody.velocity.y * 10f), -90, 90);

        //회전시키기 x,y,z순 쿼터니언 사용
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(godMode)
        {
            return;
        }

        if (isDead)
        {
            return;
        }
        gameManager.GameOver();
        //죽으면 1초후에 부활
        isDead = true;
        deathCooldown = 1f;
        //부딪히면 IsDie가 1이되어 에니메이터에서 에니메이션 실행
        animator.SetInteger("IsDie", 1);
    }
}
