using UnityEngine;

public class Star : MonoBehaviour
{
    GameObject gameManager;
    GameManager gameManagerScript;
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Bullet1")
        {
            gameManagerScript.StarDestroyed(1);
            Destroy(gameObject);
            //give P1 a point
        }
        if (collider.gameObject.tag == "Bullet2")
        {
            gameManagerScript.StarDestroyed(2);
            Destroy(gameObject);
            //give P2 a point
        }
        // i didnt use 'else if' just incase they both hit the star 
        // at the same time i dont want p1 to automaticly get the star
    }
}
