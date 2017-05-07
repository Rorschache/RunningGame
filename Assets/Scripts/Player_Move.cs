using UnityEngine;
using System.Collections;

public enum PlayerMoveStatus
{
	Run,
	Jump,
	DoubleJump,
	Die
};

public class Player_Move : MonoBehaviour
{
	
	public float Jump_Power;
	public PlayerMoveStatus status;
	public Sprite_Animation _SA;
	public Sound_Player _SP;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		KEYBOARD ();
		TOUCH ();
		GetComponent<Rigidbody>().WakeUp ();
	}
	
	void RUN ()
	{
		status = PlayerMoveStatus.Run;
		if (_SA != null)
			_SA.Run_Play ();
	}
	
	void JUMP ()
	{
		
		status = PlayerMoveStatus.Jump;
		GetComponent<Rigidbody>().AddForce (0, Jump_Power * 1.5f, 0);//œÚ…œÃ¯
		
		
		if (_SA != null)
			_SA.Jump_Play ();
		
		if (_SP != null)
			_SP.SoundPlay (0);
		
	}
	
	void DOUBLEJUMP ()
	{
		
		status = PlayerMoveStatus.DoubleJump;
		GetComponent<Rigidbody>().AddForce (0, Jump_Power, 0);
		
		if (_SA != null)
			_SA.D_Jump_Play ();
		
		if (_SP != null)
			_SP.SoundPlay (0);
	}
	
	void KEYBOARD ()
	{
		
			
		
		if (Input.GetButtonDown ("Jump"))
        {
			if (status == PlayerMoveStatus.Jump)
            {
				DOUBLEJUMP ();
			}
			
			if (status == PlayerMoveStatus.Run)
            {
				JUMP ();
			}
		}
	}
	
	void OnCollisionEnter (Collision Get)
	{
		if (status != PlayerMoveStatus.Die)
			RUN ();
	}
	
	void TOUCH ()
	{
			
		if (Input.touchCount > 0)
        {                               
			if (Input.GetTouch (0).phase == TouchPhase.Began)
            {
				
				if (status == PlayerMoveStatus.Jump) {
					DOUBLEJUMP ();
				}
				
				if (status == PlayerMoveStatus.Run) {
					JUMP ();
				}
			}
			
			
		}	
	}
	
	
}
