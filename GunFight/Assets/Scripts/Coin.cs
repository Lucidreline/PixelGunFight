using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int bulletAmmount = 0;
    GameObject p1PlayerGun;
    GameObject p2PlayerGun;
    BulletSpawner p1GunScript;
    BulletSpawner2 p2GunScript;

    [SerializeField] int bounceTimesBeforeDestroyed = 3;
    [SerializeField] int shredCount = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        p1PlayerGun = GameObject.FindGameObjectWithTag("Gun1");
        p2PlayerGun = GameObject.FindGameObjectWithTag("Gun2");
        
        p1GunScript = p1PlayerGun.GetComponent<BulletSpawner>();
        p2GunScript = p2PlayerGun.GetComponent<BulletSpawner2>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Bullet2")
        {
            p2GunScript.AddAmmo(bulletAmmount);
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Bullet1")
        {
            p1GunScript.AddAmmo(bulletAmmount);
            Destroy(gameObject);
        }
        else if(collider.gameObject.tag == "Shredder")
        {
            shredCount++;
                if(shredCount >= bounceTimesBeforeDestroyed)
            {
                Destroy(gameObject);
            }
        }
    }
}
