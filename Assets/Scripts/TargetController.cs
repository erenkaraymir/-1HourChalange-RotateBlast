using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] List<GameObject> targetCircles = new List<GameObject>();
    [SerializeField] private Transform _centerObj;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _rotateAngle;
    private int direction = 1;
    public bool isMove = false;
    private SpriteRenderer spriteRenderer;
    private GameObject target;
    public static TargetController targetController;

    private void Awake()
    {
        targetController = this;
    }

    private void Start()
    {
        SelectTarget();
    }

    private void Update()
    {
        if(isMove == true)
            transform.RotateAround(_centerObj.position,direction * Vector3.forward, _rotateSpeed * _rotateAngle * Time.deltaTime);
    }


    public void SelectTarget()
    {
        int randomTarget = Random.Range(0, targetCircles.Count - 1);
        target = targetCircles[randomTarget];
        target.transform.tag = "Target";
        spriteRenderer = target.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;
        //spriteRenderer.GetComponent<Color>().a = 255f;
        Debug.Log(randomTarget);
    }

    public void ReturnBackColor()
    {
        target.transform.tag = "Untagged";
        //spriteRenderer.color = Color.white;
       // spriteRenderer.color.a = 255f;
    }
}
