using UnityEngine;
using System.Collections;

public class InsetChild : MonoBehaviour {
	public Insects _Insects;
	private Vector3 PosTarg; 
	private Vector3 ZapStartPos, ZapEndPos;
	private int Mode, mode2;
	public float SpeedRotate, DistanceStop;
	public string NameParametrIdle, TagAnimationIdle;
	private int idleAnim;
	public Animator _Animator;
	private AnimatorStateInfo ASI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		idleAnim = 0;
		ASI = _Animator.GetCurrentAnimatorStateInfo (0);
		if (!ASI.IsTag (TagAnimationIdle)) {
			if (_Insects.Mode == 0 || _Insects.Mode == 2) {
				mode2 = 0;
				if (Mode == 0) {
					PosTarg = new Vector3 (Random.Range (_Insects.MinX, _Insects.MaxX), this.transform.position.y, Random.Range (_Insects.MinZ, _Insects.MaxZ));
					Mode = 1;
				}
				if (Mode == 1) {
					this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (PosTarg - this.transform.position), SpeedRotate * Time.deltaTime);
					this.transform.position += transform.forward * _Insects.SpeedMove * Time.deltaTime;
					if (Vector3.Distance (PosTarg, this.transform.position) <= DistanceStop) {
						idleAnim = 1;
						Mode = 0;
					}
				}
			}
		}
		if (_Insects.Mode == 1) {
			if (mode2 == 0) {
				ZapStartPos = new Vector3 (Random.Range (_Insects.MinX, _Insects.MaxX), this.transform.position.y, Random.Range (_Insects.MinZ, _Insects.MaxZ));
				ZapEndPos = new Vector3 (Random.Range (_Insects.MinX, _Insects.MaxX), this.transform.position.y, Random.Range (_Insects.MinZ, _Insects.MaxZ));
				mode2 = 1;
			}
			if (mode2 == 1) {
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (ZapStartPos - this.transform.position), SpeedRotate * Time.deltaTime);
				this.transform.position += transform.forward * _Insects.SpeedMove * Time.deltaTime;
				if (Vector3.Distance (ZapStartPos, this.transform.position) <= DistanceStop) {
					//idleAnim = 1;
					mode2 = 2;
				}
			}
			if (mode2 == 2) {
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (ZapEndPos - this.transform.position), SpeedRotate * Time.deltaTime);
				this.transform.position += transform.forward * _Insects.SpeedMove * Time.deltaTime;
				if (Vector3.Distance (ZapEndPos, this.transform.position) <= DistanceStop) {
					//idleAnim = 1;
					mode2 = 1;
				}
			}
		}
		
	}
	
	void FixedUpdate () {
		_Animator.SetInteger (NameParametrIdle, idleAnim);
		
		
	}
}
