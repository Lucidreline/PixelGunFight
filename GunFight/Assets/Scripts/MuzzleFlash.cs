using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{

    [SerializeField] float flashTime = .1f;

    // Start is called before the first frame update
    void Start()
    {
        DeActivateFlash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateFlash()
    {
        gameObject.SetActive(true);
        Invoke("DeActivateFlash", flashTime);
    }
    void DeActivateFlash()
    {
        gameObject.SetActive(false);
    }
}
