using UnityEngine;
 
 public class DestroyWhenCollisionBottom : MonoBehaviour
 {
     private void OnTriggerEnter2D(Collider2D other)
     {
         Debug.Log("Collision triger!");
         if(other.GetComponent<Bottom>() != null)
             Destroy(this.gameObject);
     }
 }