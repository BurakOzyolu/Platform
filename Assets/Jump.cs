using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] private float radius;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //Force:Roketin u�usunu simule etmek gibi - Impulse: O g�c� an�nda verir.
        }
        Gravity();
    }
    private bool IsGrounded()
    {
        //OverlapCircle: Bana bir obje ver, Kontrol edilecek bir layerMask(Ground) ver. Bu ground'da de�ilse z�plama i�lemi yapmas�n
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);   
    }
    //GravityScale: Yer �ekimi �l�e�i
    void Gravity() //yer�ekimi
    {
        if (rb.velocity.y >= 0 )
        {
            //Velocity obje yukar�ya ��karken zaman pozitif duruma gelir.
            rb.gravityScale = gravityScale; 
        }
        else if (rb.velocity.y < 0)
        {
            //Velocity obje a�a��ya d��t��� zaman negatif duruma gelir.
            rb.gravityScale = fallGravityScale;
        }
    }
}
