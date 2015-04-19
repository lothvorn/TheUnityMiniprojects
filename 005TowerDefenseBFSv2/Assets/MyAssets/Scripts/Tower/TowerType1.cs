using UnityEngine;
using System.Collections;


[System.Serializable]
public class TowerType1 : Tower {
	//references to tower components
	public LineRenderer ray;


	public Color c1 = Color.yellow;
	public Color c2 = Color.red;


	public void Start(){

		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		ray = projectile.GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.SetVertexCount(2);
	}

	public void Update(){
		base.Update();

		//LineRenderer lineRenderer = GetComponent<LineRenderer>();
		LineRenderer = projectile.GetComponent<LineRenderer>();
		int i = 0;
		lineRenderer.SetPosition(0, cannonMuzzle.transform.position);
		lineRenderer.SetPosition(1, target.transform.position);

		/*
		while (i < lengthOfLineRenderer) {
			Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
			lineRenderer.SetPosition(i, pos);
			i++;
*/
	}


	// Update is called once per frame
	public override void LaunchAttack(){
		/*
		ray.SetPosition (0,cannonMuzzle.transform.position);
		ray.SetPosition (1,target.transform.position);

		Debug.Log ("draw ray");
		*/
	}
}
