using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonLook : MonoBehaviour
{
    private PlayerInput p;

    void OnEnable()
    {
        p  = new PlayerInput();
        
        p.Enable();
        p.Newactionmap.Look.performed += ctx =>  getValue(ctx.ReadValue<Vector2>());
    }

    void OnDisable()
    {
        p.Newactionmap.Look.performed -= ctx =>  getValue(ctx.ReadValue<Vector2>());
        p.Disable();
    }
    
    Vector2 _look = Vector2.zero;

    void Update()
    {
        transform.rotation *= (Quaternion.AngleAxis(_look.x, Vector3.up));
        // transform.rotation *= Quaternion.AngleAxis(_look.y, Vector3.right);
        _look = Vector2.zero;



        if (transform.localEulerAngles.x > 180 && transform.localEulerAngles.x < 340)
        {
            transform.localEulerAngles = new Vector3(340, transform.localEulerAngles.y, transform.localEulerAngles.z);
            
        }
        else if (transform.localEulerAngles.x < 180 && transform.localEulerAngles.x > 40)
        {
            transform.localEulerAngles = new Vector3(40, transform.localEulerAngles.y, transform.localEulerAngles.z);

        }
    }


    void getValue(Vector2 value)
    {
        _look = value;
    }
}
