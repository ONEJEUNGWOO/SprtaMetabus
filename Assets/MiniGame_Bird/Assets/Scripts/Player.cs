using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;
    
    public UnityEngine.UI.Button restartButton;
    public UnityEngine.UI.Button returnButton;

    public UIManagerBird uiManagerBird;
    public Canvas gameOverCanvas;
    public Canvas gameWinCanvas;
    public Canvas scoreCanvas;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("에니메이터없음");
       
        if (_rigidbody == null)
            Debug.Log("리지드바디없음");

        restartButton.onClick.AddListener(OnButtonRestart);     //UI버튼 누르면 실행할 함수
        returnButton.onClick.AddListener(OnButtonReturn);

    }

    void OnButtonRestart()      //급하게 제작한거 UI누르면 실행할 함수
    {
        gameManager.RestartGame();
    }
    void OnButtonReturn()
    {

        StartCoroutine(ShowCanvasAndReturn());

    }

    private IEnumerator ShowCanvasAndReturn()
    {
        if (uiManagerBird.BestScore >= 30)
            gameWinCanvas.gameObject.SetActive(true);
        else
            gameOverCanvas.gameObject.SetActive(true);         
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainScene");
        yield return new WaitForSeconds(2f);
        gameOverCanvas.gameObject.SetActive(false);
        gameWinCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                //{
                //    gameManager.RestartGame();
                //}
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0,0, angle);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();

    }
}
