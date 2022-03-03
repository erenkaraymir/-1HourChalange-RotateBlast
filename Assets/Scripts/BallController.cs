using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform _centerObj;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _rotateAngle;
    [SerializeField] private float _speed;
    private bool isTouch = false;
    private int direction = 1;
    public static BallController ballController;
    private Vector3 firstPos;
    private bool hit = false;
    public float distance;

    private bool rotate = true;
    private void Awake()
    {
        ballController = this;
    }

    private void Update()
    {
        if (rotate)
        {
            transform.RotateAround(_centerObj.position, Vector3.forward, _rotateSpeed * _rotateAngle * Time.deltaTime * direction);
        }

        if (isTouch == true)
            {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            rotate = false;
            }

        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            firstPos = transform.position;
            direction = direction * -1;
        }

        if(hit == true)
        {
            transform.position = Vector3.Lerp(transform.position, firstPos, _speed * Time.deltaTime * 2);
        
        }

        //RaycastHit2D hitX = Physics2D.Raycast(transform.position + transform.localScale,Vector2.right ,distance);

        
        //if (hitX.collider!=null)
        //{

        //    rotate = true;
        //}
        //else
        //{
        //    //ss
        //}
        //Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            //Efekt çýksýn
            //Skor artsýn
            Debug.Log("Vurdu");
            collision.gameObject.transform.tag = "Untagged";
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            TargetController.targetController.SelectTarget();
            //TargetController.targetController.ReturnBackColor();
            isTouch = false;
            hit = true;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Center"))
        {
            hit = false;
            rotate = true;
            Debug.Log("icinde");
        }
    }
}
