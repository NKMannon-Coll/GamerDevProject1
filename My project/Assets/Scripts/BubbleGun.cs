using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BubbleGun : MonoBehaviour
{
    private Vector2 mousePos;

    [SerializeField] private ParticleSystem bubblePart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bubblePart = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var shape = bubblePart.shape;
            shape.rotation = new Vector3(0, angleToMouse() + 90,  0);
            bubblePart.Play();
        }
        else 
        {
            bubblePart.Stop();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("hello");
        Instantiate(bubblePart, transform.position, Quaternion.Euler(0, 0, Mathf.Rad2Deg * angleToMouse()));
    }

    private float angleToMouse() 
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - 0, mousePos.x - 0);
        return (Mathf.Rad2Deg * angleRad);
    }
}
