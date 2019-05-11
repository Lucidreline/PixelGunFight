using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] int shotsUntilBroken = 3;

    int timesShot;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Bullet1" || collider.gameObject.tag == "Bullet2")
        {
            timesShot++;
            if(timesShot >= shotsUntilBroken)
                Destroy(gameObject); 

        }  
    }
}
