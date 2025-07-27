using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;

    //장애물 최대배치범위 조정
    public float highPosY = 1f;
    public float lowPosY = -1f;

    // 탑과 바텀 사이 공간 조정
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    //오브젝트 배치 사이 폭 지정
    public float widthPadding = 4f;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    //장애물 랜덤 위치 배치
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        //구멍 크기 Min~Max 사이로 랜덤
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        //구멍 크기를 반으로 나누어 두 오브젝트를 벌려줌
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        //제일 마지막에 놓인 오브젝트 뒤에 배치
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);

        placePosition.y = Random.Range(lowPosY, highPosY);

        //장애물의 위치를 새로운 위치로 설정
        transform.position = placePosition;

        //새로 설정한 위치 반환
        return placePosition;
    }

    //벗어날때 호출됨
    private void OnTriggerExit2D(Collider2D other)
    {
        //플레이어 지정
        PlanePlayer player = other.GetComponent<PlanePlayer>();
        if (player != null)
        {
            gameManager.AddScore(1);
        }
    }

}
