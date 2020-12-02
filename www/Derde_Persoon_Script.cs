using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derde_Persoon_Script : MonoBehaviour
{

//dit is het stuur van het object dat beweegt, je zal het stuur vertellen welke kant het op moet kunnen gaan
 public CharacterController controller;

                       //100f = default van de muis
 public float snelheid = 6f;
 public float smoothing = 0.1f;
        float smoothingVelociteit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        float horizontal = Input.GetAxisRaw("Mouse X");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //-1 = links pijl of keyboard A
        // 0 = rechts pijl of D
        
        //Vector3 zal opslaan waar je naar toe gaat
                                                   //Y-as           wanneer twee toetsen worden ingedrukt en je diagonaal beweegt, dan ga je niet sneller dan je zou moeten
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //bekijk de input voor het lopen

        if (direction.magnitude >= 0.1f){
         //Atan2 return de hoekwaarde tussen de x-asis en de vector die start vanaf nul en eindigt bij x, y
         float ActueelHoek = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
         float hoek = Mathf.SmoothDampAngle(transform.eulerAngles.y, ActueelHoek, ref smoothingVelociteit, smoothing);
         transform.rotation = Quaternion.Euler(0f, hoek, 0f);



         Vector3 moveDir = Quaternion.Euler(0f, ActueelHoek, 0f) * Vector3.forward;


          //beweeg die kant op wanneer de input waarde
                                                 //roteer, buiten de klokcycli van de core instructie,       (Time.deltaTime) = tijd die voorbij is gegaan, na het oproepen van de Update functie
                                                 //Wanneer de framerate dus hoog is, zal je niet sneller updaten, dan wanneer de framerate lages is
          controller.Move(moveDir.normalized * snelheid * Time.deltaTime);
        }

    }
}
