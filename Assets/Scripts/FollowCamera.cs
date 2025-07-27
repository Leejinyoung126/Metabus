using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //카메라가 따라갈 대상 지정
    public Transform target;
    //카메라와 대상 사이의 X축 오프셋
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        //타겟이 없으면 카메라는 따라가지않음
        if (target == null)
            return;

        //카메라의 현재 위치와 대상 X위치 차이를 오프셋으로 저장시킴
        offsetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
            return;

        //현재 카메라 위치 저장
        Vector3 pos = transform.position;
        //카메라의 위치를 대상 X위치에 오프셋을 더해줌
        pos.x = target.position.x + offsetX;
        //계산된 새 위치로 카메라가 이동한다
        transform.position = pos;
    }
}
