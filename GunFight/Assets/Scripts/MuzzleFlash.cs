using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] float flashTime = .1f;

    void Start()
    {
        DeActivateFlash();
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
