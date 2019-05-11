using UnityEngine;
using TMPro;

public class Player2 : MonoBehaviour
{

    [SerializeField] GameObject gameManager;

    [Header("Position")]
    float xMin;
    [SerializeField] float xMax = -6f;
    float yMin;
    float yMax;
    [SerializeField] float Ypadding = .5f;
    [SerializeField] float Xpadding = 1f;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 10f;

    [Header("Other")]
    float health = 100;
    [SerializeField] TextMeshProUGUI healthText;
    float bulletDamage = 20;

    void Start()
    {
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
        moveSpeed = gameManagerScript.GetMovementSpeed();
        health = gameManagerScript.GetPlayerHealth();
        bulletDamage = gameManagerScript.GetBulletDamage();

        setUpMoveBoundries();
    }

    void Update()
    {
        
        healthText.text = health.ToString();
    }

    

    void FixedUpdate()
    {
        Move();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, .1f);
    }

    private void Move()
    {
        

        var deltaX = Input.GetAxis("Horizontal2") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical2") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Bullet1")
        {
            affectHealth(-bulletDamage);
            moveSpeed *= (health / 100);
        }
    }

    void affectHealth(float healthChange)
    {
        health += healthChange;
        if(health <= 0)
        {
            health = 0;
            //Doesntly allow health to fall under 0
        }
    }

    private void setUpMoveBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = 6f;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + Xpadding;
        
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Ypadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Ypadding;
    }
}
