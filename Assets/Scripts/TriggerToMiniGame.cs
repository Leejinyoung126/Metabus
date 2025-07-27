using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerToMiniGame : MonoBehaviour
{

    private bool isPlayerInTrigger = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanEnterMiniGame())
        {
            Debug.Log("Enter to MiniGame");
            SceneManager.LoadScene("PlaneScene");
        }
    }

    private bool CanEnterMiniGame()
    {
        // 플레이어가 트리거 안에 있고, 게임 오버 상태가 아니면 입장 가능
        if (!isPlayerInTrigger)
        {
            return false;
        }

        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null && uiManager.GetIsGameOver())
        {
            return false;
        }
            

        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("E to Enter MiniGame");
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Leave the Player");
            isPlayerInTrigger = false;
        }
    }
}
