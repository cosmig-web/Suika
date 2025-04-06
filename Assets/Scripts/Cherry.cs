using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cherry : MonoBehaviour
{
    public int PointsWhenDestroyed = 0;
    public GameObject NextStage;
    public float height = 1;
    public string TagName = "";

    private Rigidbody2D rg;
    //private bool Fail;
    private bool IsFalling  = true;
    private bool isLoose = false;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.gravityScale = 0;
        if (gameObject.transform.position.y >= 2.27)
        {
            IsFalling = false;
        }
    }

    void Update()
    {
        if (!IsFalling)
        {
            var MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            transform.position = new Vector2(MousePos.x, height);
            if (Input.GetMouseButtonUp(0))
            {
                IsFalling = true;
            }
        }

        if (gameObject.transform.position.y > 2.50 && IsFalling)
        {
            isLoose = true;
            Points.instance.GameOver(isLoose);
        }
        else
        {
            rg.gravityScale = 1;
            
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagName))
        {
            Points.instance.IncreaseScore(PointsWhenDestroyed);
            if (gameObject.transform.position.y > other.gameObject.transform.position.y)
            {
                Vector3 middlePos = (transform.position + other.gameObject.transform.position) / 2f;
                var go = Instantiate(NextStage,middlePos, Quaternion.identity);
                
            }

            Destroy(gameObject);
            Destroy(other.gameObject);
            //scoreText.text += 10.ToString("D2");

        }

        if (other.gameObject.CompareTag("Watermelon"))
        {

            Destroy(gameObject);
            Destroy(other.gameObject);
            //scoreText.text += 100.ToString("D3");
        }
    }

    
}
