using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    float xMin;
    [SerializeField] float xMax = -6f;
    float yMin;
    float yMax;
    [SerializeField] float Ypadding = .5f;
    [SerializeField] float Xpadding = 1f;

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBoundries();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
        
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal1") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical1") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    

    private void setUpMoveBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Xpadding;
        //xMax = -6f;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Ypadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Ypadding;

    }
}
