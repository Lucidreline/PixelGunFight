using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCoin : MonoBehaviour
{
    int shredderBounceCounter = 0;
    int bounceTimesBeforeDestroyed;
    void Start() {
        bounceTimesBeforeDestroyed = 
            FindObjectOfType<menuScreenManager>()
            .getMenuCoinShredderBounceLimmit();

    }

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Shredder") {
            shredderBounceCounter++;
            if (shredderBounceCounter >= bounceTimesBeforeDestroyed)
                Destroy(gameObject);
        }
    }
}
