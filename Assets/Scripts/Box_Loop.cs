using UnityEngine;
using System.Collections;

public class Box_Loop : MonoBehaviour {
	
	public GameObject[] Box;//�ϰ���

	public GameObject A_Zone;
	public GameObject B_Zone;
	
	public float Speed = 5f;
	
	void Update () {
	
			MOVE();
	}
	
	
	public void MAKE(){
		
		B_Zone=A_Zone;
		int a = Random.Range(0,5);
        A_Zone = Instantiate(Box[a], new Vector3(30,0,0),
            transform.rotation/*��Ԫ��*/) as GameObject;
		
	}

	
	public void MOVE(){
		
        //Translate��ʾƽ��
		A_Zone.transform.Translate(Vector3.left * Speed *Time.deltaTime,
            Space.World/*�������ϵ*/);
		B_Zone.transform.Translate(Vector3.left * Speed *Time.deltaTime,
            Space.World);
			
		if(A_Zone.transform.position.x<=0){
				DEATH();
		}
	}
	
	
	public void DEATH(){
		Destroy(B_Zone);
		MAKE();
			
	}
}
