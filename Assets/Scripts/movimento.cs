using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidade = 10f;
    public float pulo = 100f;
    public Transform groundCheck;
    public LayerMask ground;
    Vector3 vetorPulo;
    Vector3 movimentacao;
    bool isGrounded;


    // Start is called before the first frame update
    void Awake()
    {
        movimentacao = new Vector3(0f, 0f, 0f);
        vetorPulo = new Vector3(0f, pulo, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        movimentacao.z = -Input.GetAxisRaw("Horizontal") * velocidade;
        movimentacao.x = Input.GetAxisRaw("Vertical") * velocidade;

        //verificar se ta pulando
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(vetorPulo, ForceMode.Impulse);
        }

        movimentacao.y = rb.velocity.y;

        rb.velocity = movimentacao;
    }

    private void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, ground);
     
    }


}
