using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDBehaviour : MonoBehaviour
{
    private Rigidbody2D RB;

    public float XPush;
    public float YPush;

    [SerializeField]
    private Color[] Colors;

    int LastColor = 0;

    // Start is called before the first frame update
    void Start()
    {
		RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(XPush, YPush);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ScreenEdge")
		{
			Debug.Log("Touchy");

			ChangeColor();
		}
	}

	void ChangeColor()
    {
		Again:
        int RandomColor = Random.Range(0, Colors.Length);
        if (LastColor != RandomColor)
        {
            LastColor = RandomColor;
            this.gameObject.GetComponent<SpriteRenderer>().color = Colors[RandomColor];
        }
        else
        {
			goto Again;
        }
    }
}
