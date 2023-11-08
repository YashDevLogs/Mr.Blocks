using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    public GameObject GameWonPanel;
    public GameObject GameLostPanel;
    private bool isGameOver = false;
    public CameraShake camerashake;
    public ParticleSystem particleSystem;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");





        if (isGameOver == true)
        {
            return;
        }

        if (horizontalInput > 0)
        {
            rigidbody2D.velocity = new Vector2(speed, 0f);
        }
        else if (horizontalInput < 0)
        {
            rigidbody2D.velocity = new Vector2(-speed, 0f);
        }
        else if (verticalInput > 0)
        {
            rigidbody2D.velocity = new Vector2(0f, speed);
        }
        else if (verticalInput < 0)
        {
            rigidbody2D.velocity = new Vector2(0f, -speed);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Completed!");
            GameWonPanel.SetActive(true);
            isGameOver = true;

        }
        if (other.tag == "Enemy")
        {
            Debug.Log("Level Lost!");
            GameLostPanel.SetActive(true);
            StartCoroutine(camerashake.Shake(.20f, 0.6f));
            isGameOver = true;

        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Level Restarted");

    }


    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Next Level Loaded");
        }
    }
}