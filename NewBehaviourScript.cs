using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{   
    public static int score=0;
    Transform tr;
    CharacterController contr;
    float horizontalSpeed = 2.0f;
    public float speed=12f;
    float gravityValue=-9.81f;
    bool isGrounded=false;
    [SerializeField] TextMeshProUGUI text;
   
    float jumpHeight=5f;
    void Start()
    {
        tr=GetComponent<Transform>();
        contr=GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float vertical=Input.GetAxis("Vertical");

        contr.Move(tr.forward*vertical*speed*Time.deltaTime);
        contr.Move(tr.up*gravityValue*Time.deltaTime);
        tr.Rotate(0,h,0);
        if(Input.GetKeyDown("space")&& isGrounded==true){
            
            contr.Move(tr.up*jumpHeight);
        }
        isGrounded=false;



    }
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag=="ground"){
             isGrounded=true;
             print("prig");
        }
        if(col.gameObject.tag=="items"){
            score=score+1;
            text.text=score+"";
            Destroy(col.gameObject);
            if (score==18){
                print("pobeda");
            }    
        }
    }
}
