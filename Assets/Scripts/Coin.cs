using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int coinValue;
    UIController uiController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {
        float i = 0;
        Color color = spriteRenderer.color;
        while(i<=1)
        {
            transform.position = Vector3.Lerp(transform.position, direction, i);
            color.a = 1 - i;
            i += 0.1f;
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(.1f);
        }
        uiController.ShowCoin(coinValue);
        Destroy(gameObject);
    }
    private void Start()
    {
        direction = transform.position - new Vector3(2, -2,0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
    }
    
}
