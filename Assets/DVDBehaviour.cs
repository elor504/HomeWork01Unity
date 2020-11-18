using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RB;

    public float XPush;
    public float YPush;

    [SerializeField]
    private Color[] Colors;

    int LastColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB.velocity = new Vector2(XPush, YPush);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor()
    {
        int RandomColor = Random.Range(0, Colors.Length);
        if (LastColor != RandomColor)
        {
            LastColor = RandomColor;
            this.gameObject.GetComponent<SpriteRenderer>().color = Colors[RandomColor];
        }
        else
        {
            ChangeColor();
        }
    }



  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ScreenEdge")
        {
            Debug.Log("Touchy");

            ChangeColor();


        }
    }
}
