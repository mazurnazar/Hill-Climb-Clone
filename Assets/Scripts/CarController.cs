using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float speed = 0;
    public int maxSpeed = 20;
    public bool move;
    public Rigidbody2D backWheel, frontWheel, carController;
    public bool press;
    [SerializeField] WheelJoint2D fr, bk;
    [SerializeField]  JointMotor2D jmfront, jmback;
    [SerializeField]UIController UIController;
    private int fuel = 60;
    public int fuelCapacity;
    private int distanceToFuel;

    [SerializeField] private List<GameObject> fuels;
    // Start is called before the first frame update
    void Start()
    {
        jmfront = fr.motor;
        jmback = bk.motor;
        fuelCapacity = fuel;
    }


    private void FixedUpdate()
    {
        if (speed != 0&&fuelCapacity>0)
         {
           fr.useMotor = true;
            bk.useMotor = true;
            jmback.motorSpeed = speed * 1000;
            jmfront.motorSpeed = speed * 1000;
            backWheel.AddForce(Vector2.right * speed);
            frontWheel.AddForce(Vector2.right * speed);
            DistanceToFuel();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fuel"))
        {
            UIController.RestoreFuel();
            fuelCapacity = fuel;
            fuels.RemoveAt(0);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Finish")
        {
            carController.constraints = RigidbodyConstraints2D.FreezeAll;
            UIController.GameOver();
        }
    }
    void DistanceToFuel()
    {
        distanceToFuel = (int)(fuels[0].transform.position.x - transform.position.x);
        if ( distanceToFuel< 50)
        {
            UIController.ShowDistance(distanceToFuel);
        }

    }
}
