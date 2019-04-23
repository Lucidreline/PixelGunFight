using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] int ammoCount = 3;

    [SerializeField] TextMeshProUGUI ammoCountText;
    [SerializeField] int bulletReplenishTime = 8;
    bool bulletLoop = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoCountText.text = ammoCount.ToString();
        fire();

        if (bulletLoop)
        {
            StartCoroutine(AddBulletsEveryXSeconds());
        }
        
    }

    IEnumerator AddBulletsEveryXSeconds()
    {
        bulletLoop = false;
        yield return new WaitForSeconds(bulletReplenishTime);
        bulletLoop = true;
        AddAmmo(1);
        
    }

    public void AddAmmo(int howMuchAmmo)
    {
        ammoCount += howMuchAmmo;
        if (ammoCount < 0)
        {
            ammoCount = 0;
        }
    }

    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(ammoCount > 0)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                ammoCount--;
            }
            
        }
    }
}
