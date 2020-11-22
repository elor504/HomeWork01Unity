using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DVDBehaviour : MonoBehaviour
{
    private Rigidbody2D RB;

    public float XPush;
    public float YPush;
    [Range(0,10)]
    public float rotationSpeed = 5f;
    [SerializeField]
    Text text;

    [SerializeField]
    private Color[] Colors;
    


    int CurrentColor = 0;
    bool isClockwise;

    // Start is called before the first frame update
    void Start()
    {

		RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(XPush, YPush);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * 100f * Time.deltaTime * (isClockwise?1f:-1f));
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ScreenEdge")
		{
			Debug.Log("Touchy");
            isClockwise = !isClockwise;
			ChangeColor();
            Color inveretdColor = InvertColor(Colors[CurrentColor]);
            Camera.main.backgroundColor = inveretdColor;
            text.color = inveretdColor;
		}
	}

	void ChangeColor()
    {
		Again:
        int RandomColor = Random.Range(0, Colors.Length);
        if (CurrentColor != RandomColor)
        {
            CurrentColor = RandomColor;
            this.gameObject.GetComponent<SpriteRenderer>().color = Colors[RandomColor];
        }
        else
        {
			goto Again;
        }
    }

    Color InvertColor(Color color) {
        Color invertedColor = color;
        invertedColor.r = 1f - color.r;
        invertedColor.g = 1f - color.g;
        invertedColor.b = 1f - color.b;

        return invertedColor;
    }
}
