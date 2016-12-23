using UnityEngine;
using System.Collections;

public class txtGenerator : MonoBehaviour 

{
 public Transform _prefab;
 public float _radius = 10;
 public Transform Canevas;
 public GameObject Cible;
 private Vector3 positionUp;
 private Vector3 positionDown;
 public Transform[] smsPrefabs ;
 private Transform topSMS;
 private Transform downSMS;
 public  int nextScene;

 private int compteur = 0;
 public Animator questionAnimator;
 public GameObject colliderClick;
 public QuestionManager qManager;

 public bool waitForQuestion = false;
 int nextSkip = 0;


 void Start(){

    positionUp = new Vector3(-625,247,0);
    positionDown = new Vector3(-625,-269,0);

    
 }

  
 // Update is called once per frame
 void Update () 
 {
  if ( Input.GetMouseButtonDown(0) )
  {
    
   if (compteur >= smsPrefabs.Length )
    {
      print("load");
       Application.LoadLevel(nextScene);
    }


    Vector3  myPos = positionDown;


    if (compteur == 0)
   {
     myPos= positionUp; 

   }
   
  int sms = qManager.receivedAnswer;
  if (sms != 0) {
    compteur += sms;
    if (sms == 1) {
      nextSkip = 4;
    } else {
      nextSkip = 3 - sms;
    }
    waitForQuestion = false;
    qManager.receivedAnswer = 0;
  }

   if (smsPrefabs[compteur] == null && !waitForQuestion) {
        // activate Question
      questionAnimator.SetBool("needCanvas", true);
      waitForQuestion = true;
   }

   if (waitForQuestion) {
    if (!questionAnimator.GetBool("needCanvas")) {
      waitForQuestion = false;
    }
    return;
   }


   //Create a random position.
   //The insideUnitSphere return a random position inside a sphere of radius 1.
   //Vector3 rndPos = Random.insideUnitSphere * _radius;
    
  
   
   //Instantiate a new object at a random position with a random rotation.

   Transform newGameObj = Instantiate( smsPrefabs[compteur],myPos, Quaternion.identity ) as Transform;
   newGameObj.SetParent(Canevas);
   newGameObj.localScale = Vector3.one;
   newGameObj.localPosition = myPos;

   if (compteur == 0) {
    downSMS = newGameObj;
   }
   if (compteur==1){
    downSMS =newGameObj;

   }
   if (compteur>1)
   {
    if (topSMS) {
      Destroy(topSMS.gameObject);
    }
    topSMS= downSMS;
    topSMS.localPosition= positionUp;
    downSMS= newGameObj;

   }



   
   
  compteur += 1 + nextSkip;
  nextSkip = 0;
  }
 }
}
