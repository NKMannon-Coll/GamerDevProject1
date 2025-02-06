using UnityEngine;

public class PlayerBall : MonoBehaviour
{
      void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Fish"){
            Destroy(col.gameObject);
            GameManager.Instance.ResetGame();
        }
    }
}
