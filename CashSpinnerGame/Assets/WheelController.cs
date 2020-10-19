using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
        [Header("Set in Inspector")]
        public GameObject spinner;
        [SerializeField]
        public float balance = 1000;
        float rotationalSpeed = 0;
        bool isClicked = false;
        bool isRewarded = true;
        bool finalAngleCalculated = false;
        float randomRange = 0;
        float finalAngle = 0;
        float totalAngle = 0;

        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //slows down the wheel
       if(isClicked == true){
           transform.Rotate(0,0, this.rotationalSpeed);       
        rotationalSpeed *= randomRange;
        }
    
        //stops the wheel
        if(rotationalSpeed <= .01f){
            isClicked = false;
            rotationalSpeed = 0;
        }
        
        //gets the last angle after rotated
        if(rotationalSpeed == 0){
        totalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        totalAngle = Mathf.Abs(totalAngle);
        }
        
        //checks if it lands on the line and moves it, then calcualtes final angle
        if (totalAngle >= 0 && totalAngle <= 0.5 || totalAngle >= 29.5 && totalAngle <= 30.5 || totalAngle >= 59.5 && totalAngle <= 60.5 || totalAngle > 89.5 && totalAngle < 90.5 || totalAngle >= 119.5 && totalAngle <= 120.5 || totalAngle >= 149.5 && totalAngle <= 150.5 || totalAngle >= 179.5 && totalAngle <= 180.5 || totalAngle >= 209.5 && totalAngle <= 210.5 || totalAngle >= 239.5 && totalAngle <= 240.5 || totalAngle >= 269.5 && totalAngle <= 270.5 || totalAngle >= 299.5 && totalAngle <= 300.5 || totalAngle >= 329.5 && totalAngle <= 330.5 || totalAngle >= 335.5 && totalAngle <= 359.9)
        {
            transform.Rotate (0,0,6);
            totalAngle = Mathf.RoundToInt(transform.rotation.z);          
        }
        if(finalAngleCalculated == false && rotationalSpeed == 0){
            finalAngle = totalAngle;
            finalAngleCalculated = true;
        }

        // rewards the player for the spin
        if(rotationalSpeed == 0 && isRewarded == false && finalAngleCalculated == true)
        {
            balance = rewardPlayer(finalAngle, balance);
                        
            isRewarded = true;
            Debug.Log(balance);
        }
    }

    //spins the spinner only when clicking on the transform
    void OnMouseDown(){
        if(isClicked == false){
         this.rotationalSpeed = 200;
        isClicked = true;
        }
        randomRange = RandomNumber(.98f, .99f);
        isRewarded = false;
        finalAngleCalculated = false;
    }

    //gets a random number
   public float RandomNumber(float number, float number2)
    {
        float return1 = Random.Range(number, number2);
        return return1;
        
    }

    public static int rewardPlayer(float finalAngle, float balance){
        int redSection = -100;
        int blueSection = 0;
        int greenSection = 100;
        int goldSection = 200;
        if (finalAngle >= 0 && finalAngle < 29.5){
            balance += redSection;
        }
        else if (finalAngle >= 30 && finalAngle < 59.5){
            balance += greenSection;
        }
        else if (finalAngle >= 60 && finalAngle < 89.5){
            balance += redSection;
        }
        else if (finalAngle >= 90 && finalAngle < 119.5){
            balance += goldSection;
        }
        else if (finalAngle >= 120 && finalAngle <  149.5){
            balance += blueSection;
        }
          else if (finalAngle >= 150 && finalAngle <  179.5){
            balance += greenSection;
        }
         else if (finalAngle >= 180 && finalAngle < 210.5){
            balance += goldSection;
        }
         else if (finalAngle >= 210 && finalAngle < 239.5){
            balance += blueSection;
        }
         else if (finalAngle >= 240 && finalAngle < 269.5){
            balance += redSection;
         }
         else if (finalAngle >= 270 && finalAngle < 299.5){
            balance += goldSection;} 
        else if (finalAngle >= 300 && finalAngle < 329.5){
            balance += blueSection;
        } else if (finalAngle >= 330 && finalAngle < 360){
            balance += greenSection;
        }

        return (int)balance;
    }


}