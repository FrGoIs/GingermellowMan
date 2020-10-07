using UnityEngine;
using System.Collections;

public class Insects : MonoBehaviour {
	[Range(0, 20)]
	public int TheNumberCockroach = 0;
	[Range(0.1f, 1f)]
	public float  Size = 1f;
	public bool SpawnEqualsSize;
	[Range(0.01f, 10f)]
	public float SpeedMove;
	[Header("Mode 0 - chaotic")]
	[Header("Mode 1 - looping")]
	[Header("Mode 2 - replacement")]
	[Range(0, 2)]
	public int Mode;
	public float MinX, MaxX, MinZ, MaxZ;
	[Header("Cockroach lenght = maxRange TheNumberCockroach")]
	public GameObject[] Cockroach;
	public GameObject CockroachPrefab;
	private int ZapTheNumberCockroach, rsz;
	private float ZapSize;
	public bool RandomSize;
	public float MinSize, MaxSize;
	public float TimeDestroy;
	private float tm;
	// Use this for initialization
	void Start () {
		ZapTheNumberCockroach = TheNumberCockroach;
		ZapSize = Size;
		for (int i = 0; i < TheNumberCockroach; i ++) {
			Cockroach[i] = Instantiate(CockroachPrefab, new Vector3(Random.Range(MinX, MaxX), this.transform.position.y, Random.Range(MinZ, MaxZ)), CockroachPrefab.transform.rotation) as GameObject;
			Cockroach[i].GetComponent<InsetChild>()._Insects = this.GetComponent<Insects>();
			Cockroach[i].transform.localScale = new Vector3(Size,Size,Size);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ZapTheNumberCockroach != TheNumberCockroach) {
			if (TheNumberCockroach < ZapTheNumberCockroach) {
				for (int i = Cockroach.Length-1; i > TheNumberCockroach; i --) {
					print (i);
					Destroy (Cockroach [i]);
				}
			} else {
				for (int i = 0; i < TheNumberCockroach; i ++) {
					if (Cockroach [i] == null) {
						int n = 0;
						if(RandomSize == true)
						{
							Cockroach [i] = Instantiate (CockroachPrefab, new Vector3 (Random.Range (MinX, MaxX), this.transform.position.y, Random.Range (MinZ, MaxZ)), CockroachPrefab.transform.rotation) as GameObject;
							Cockroach[i].GetComponent<InsetChild>()._Insects = this.GetComponent<Insects>();
							float rand = Random.Range(MinSize, MaxSize);
							Cockroach [i].transform.localScale = new Vector3 (rand, rand, rand);
							n = 1;
						}
						if(n == 0)
						{
							if(SpawnEqualsSize == false)
							{
								Cockroach [i] = Instantiate (CockroachPrefab, new Vector3 (Random.Range (MinX, MaxX), this.transform.position.y, Random.Range (MinZ, MaxZ)), CockroachPrefab.transform.rotation) as GameObject;
								Cockroach[i].GetComponent<InsetChild>()._Insects = this.GetComponent<Insects>();
							}
							if(SpawnEqualsSize == true)
							{
								Cockroach [i] = Instantiate (CockroachPrefab, new Vector3 (Random.Range (MinX, MaxX), this.transform.position.y, Random.Range (MinZ, MaxZ)), CockroachPrefab.transform.rotation) as GameObject;
								Cockroach[i].GetComponent<InsetChild>()._Insects = this.GetComponent<Insects>();
								Cockroach [i].transform.localScale = new Vector3(Size, Size, Size);
							}
						}
					}
				}
			}
			ZapTheNumberCockroach = TheNumberCockroach;
		}
		if (RandomSize == false) {
			if(rsz == 1)
			{
				for (int i = 0; i < Cockroach.Length; i ++) {
					if (Cockroach [i] != null) {
						Cockroach [i].transform.localScale = new Vector3 (Size, Size, Size);
					}
					ZapSize = Size;
				}
				rsz = 0;
			}
			if (ZapSize != Size) {
				for (int i = 0; i < Cockroach.Length; i ++) {
					if (Cockroach [i] != null) {
						Cockroach [i].transform.localScale = new Vector3 (Size, Size, Size);
					}
					ZapSize = Size;
				}
			}
		} else {
			if(rsz == 0)
			{
				for (int i = 0; i < Cockroach.Length; i ++) {
					if (Cockroach [i] != null) {
						float rand = Random.Range(MinSize, MaxSize);
						Cockroach [i].transform.localScale = new Vector3 (rand, rand, rand);
					}
					rsz = 1;
				}
			}
		}
		
		if (Mode == 2) {
			tm += Time.deltaTime;
			if(tm >= TimeDestroy)
			{
				int rand = Random.Range(0, TheNumberCockroach);
				Destroy(Cockroach[rand]);
				Cockroach [rand] = Instantiate (CockroachPrefab, new Vector3 (Random.Range (MinX, MaxX), this.transform.position.y, Random.Range (MinZ, MaxZ)), CockroachPrefab.transform.rotation) as GameObject;
				Cockroach[rand].GetComponent<InsetChild>()._Insects = this.GetComponent<Insects>();
				tm = 0;
			}
		}
	}
	void FixedUpdate () {
		
	}
}
