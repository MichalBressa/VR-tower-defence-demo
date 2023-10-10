using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Hands : MonoBehaviour
{
   
    private Animator HandAnimator;

    public InputActionReference triggerValue;
    public InputActionReference gripValue;


    public ActionBasedController Controller;
    public GameObject Hand;


    private void Start()
    {
        HandAnimator = Hand.GetComponent<Animator>();
        
        triggerValue.action.performed += TriggerPressedDown;
        triggerValue.action.canceled += TriggerPressedDown;

        gripValue.action.performed += GripPressedDown;
        gripValue.action.canceled += GripPressedDown;


    }

    void TriggerPressedDown(InputAction.CallbackContext context)
    {
        float triggerVal = context.ReadValue<float>();

        if (triggerVal > 0)
        {
            HandAnimator.SetFloat("TriggerValue", triggerVal);
        }
        else
        {
            HandAnimator.SetFloat("TriggerValue", 0);
        }


        if (triggerVal > 0.5f)
        {
            Controller.SendHapticImpulse(0.1f, 0.1f);
        }  
    }

    void GripPressedDown(InputAction.CallbackContext context)
    {
        float gripVal = context.ReadValue<float>();

        if (gripVal > 0)
        {
            HandAnimator.SetFloat("GripValue", gripVal);
        }
        else
        {
            HandAnimator.SetFloat("GripValue", 0);
        }

        if (gripVal > 0.5f)
        {
            Controller.SendHapticImpulse(0.1f, 0.1f);
        }
    }


    void Update()
    {


            

        
    }



    }
