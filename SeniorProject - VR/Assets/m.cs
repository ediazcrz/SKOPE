using UnityEngine;

public class m : MonoBehaviour
{
    public float speed = 3.0f;
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
          if(Input.GetKey("left shift"))
        {
            z = Input.GetAxis("Vertical") * Time.deltaTime *2* speed;
        }
       

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    

    }
}