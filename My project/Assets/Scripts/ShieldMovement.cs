using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ShieldMovement : MonoBehaviour
{

    private float RadiusFromFish = 1;

    private Transform tf;
    private Vector2 mousePos;

    [SerializeField] private GameObject UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - 0, mousePos.x - 0);
        tf.position = new Vector2(RadiusFromFish * Mathf.Cos(angleRad), RadiusFromFish * Mathf.Sin(angleRad));
        tf.rotation =  Quaternion.Euler(0, 0, Mathf.Rad2Deg*angleRad + 90);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Fish"){
            Destroy(col.gameObject);
            UI.GetComponent<UIWriter>().IncreaseScore();
        }
    }
}
