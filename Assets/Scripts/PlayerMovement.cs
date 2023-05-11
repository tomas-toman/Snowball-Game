using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject Arrow;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float arrowScale = 0.01f;
    [SerializeField]
    public GameObject failedPanel;
    [SerializeField]
    private int scene;

    private Rigidbody2D rb;
    private bool played = false;
    private Scene currentScene;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        failedPanel.SetActive(false);
        Time.timeScale = 1;
        currentScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePosition2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

        // Rotation
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Arrow Scaling
        mousePosition2.z = 0f;
        float distance = Vector2.Distance(Arrow.transform.position, mousePosition2);
        Arrow.transform.localScale = new Vector3(distance * arrowScale, distance * arrowScale, Arrow.transform.localScale.z);

        // Movement
        if (Input.GetKeyDown(KeyCode.Mouse0) && played == false)
        {
            Vector2 force = offset * speed;
            rb.AddForce(-force);
            Arrow.SetActive(false);
            played = true;
        }
        if (played == true)
        {
            transform.localScale += new Vector3(0.075f * Time.deltaTime, 0.075f * Time.deltaTime, 0.075f * Time.deltaTime);
        }

        // Scale Control
        if (transform.localScale.x > 0.43)
        {
            Time.timeScale = 0;
            played = false;
            failedPanel.SetActive(true);
        }

        // Keybinds
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(currentScene.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowman")){ 
            if (transform.localScale.x >= 0.25 && transform.localScale.x <= 0.43)
            {
                SceneManager.LoadScene(scene);
            }
            else
            {
                failedPanel.SetActive(true);
            }
        }
    }
}