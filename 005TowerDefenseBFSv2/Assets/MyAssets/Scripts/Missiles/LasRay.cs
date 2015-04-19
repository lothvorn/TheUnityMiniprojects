using UnityEngine;
using System.Collections;

[System.Serializable]
public class LasRay : DamageDealer {

	//references to external
	public GameObject origin;

	//to hide
	public float persistenceTime = 1;
	public LineRenderer lineRenderer;

	void Start (){
		lineRenderer = GetComponent<LineRenderer>();
		//init ray
		lineRenderer.useWorldSpace = true;
		lineRenderer.SetPosition(0,origin.transform.position);
		lineRenderer.SetPosition (1, target.transform.localPosition);

		DamageAllAffectedEnemies();

		Destroy (gameObject,1);
	}

	// Update is called once per frame
	void Update () {
		DrawRay();


	
	}

	private void DrawRay(){
		if (target == null)
			return;
		lineRenderer.SetPosition(0,origin.transform.position);
		lineRenderer.SetPosition (1, target.transform.localPosition);



	}
	private void DamageAllAffectedEnemies(){
		RaycastHit []hits;
		Vector3 rayDirection = target.transform.position - origin.transform.position;

		  

		hits = Physics.RaycastAll (origin.transform.position, rayDirection, rayDirection.magnitude);

		foreach (RaycastHit go in hits){
			if (go.transform.tag == "Enemy"){
				DamageDeal (go.transform.gameObject);
			}
		}
	}


}
