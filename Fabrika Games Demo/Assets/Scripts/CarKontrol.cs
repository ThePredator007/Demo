using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.Effects;
using UnityStandardAssets.CrossPlatformInput;

public class CarKontrol : MonoBehaviour
{
    float moveHorizontal, moveVertical;
    Rigidbody rigidbody;
    public int speed;

    public Animator anim;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
        
    }
    void FixedUpdate()
    {
        moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");


        rigidbody.velocity = transform.forward * (moveVertical * speed);

        transform.Rotate(0, moveHorizontal*1.6f, 0);

        anim.SetFloat("Blend", moveHorizontal);

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Players")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(350, 450));
            CameraEffects.ShakeOnce(0.5f,3,new Vector3(2,2,2));
        }

    }
}
