using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour, IDataPersistence {

	[SerializeField] private string id;

	[ContextMenu("Generate guid for id")]
	private void GenerateGuid(){
		id = System.Guid.NewGuid().ToString();
	}

	const float minPathUpdateTime = .2f;
	const float pathUpdateMoveThreshold = .5f;

	public Transform target;
	private Transform oldTarget;
	public float speed = 3.5f;
	public float turnSpeed = 3f;
	public float turnDst = 5f;
	public float stoppingDst = 2f;
	public int floor = 1;

	Path path;

	bool wallReached = false;
	Quaternion unitRotation;
	NPCAnimScript animScript;

	void Start() {
		animScript = GetComponent<NPCAnimScript>();
		oldTarget = target;
		StartCoroutine (UpdatePath ());
	}

	private void Update() {
		if (!animScript.isLayingDown){
			transform.localPosition = new Vector3(transform.localPosition.x, 1, transform.localPosition.z);
		}

		unitRotation = transform.rotation;

		unitRotation.eulerAngles = new Vector3(0, unitRotation.eulerAngles.y, 0);

		transform.rotation = unitRotation;
	}

	public void LoadData(GameData data){
		Vector3 position = new Vector3();

		data.NPCposition.TryGetValue(id, out position);

		transform.position = position;

		data.NPCTargetMap.TryGetValue(id, out target);

		data.NPCFloorMap.TryGetValue(id, out floor);
	}

	public void SaveData(ref GameData data){
		if (data.NPCposition.ContainsKey(id)){
			data.NPCposition.Remove(id);
		}
		data.NPCposition.Add(id, transform.position);

		if (data.NPCTargetMap.ContainsKey(id)){
			data.NPCTargetMap.Remove(id);
		}
		data.NPCTargetMap.Add(id, target);

		if (data.NPCFloorMap.ContainsKey(id)){
			data.NPCFloorMap.Remove(id);
		}
		data.NPCFloorMap.Add(id, floor);
	}

	public void OnPathFound(Vector3[] waypoints, bool pathSuccessful) {
		if (pathSuccessful) {
			path = new Path(waypoints, transform.position, turnDst, stoppingDst);

			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator UpdatePath() {

		if (Time.timeSinceLevelLoad < .3f) {
			yield return new WaitForSeconds (.3f);
		}
		
		switch (floor)
		{
			
			case 1:
				PathRequestManager1.RequestPath (new PathRequest1(transform.position, target.position, OnPathFound));
				break;
			case 2:
				PathRequestManager2.RequestPath (new PathRequest2(transform.position, target.position, OnPathFound));
				break;
			case 3:
				PathRequestManager3.RequestPath (new PathRequest3(transform.position, target.position, OnPathFound));
				break;
		}

		float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
		Vector3 targetPosOld = target.position;

		while (true) {
			yield return new WaitForSeconds (minPathUpdateTime);
			// print (((target.position - targetPosOld).sqrMagnitude) + "    " + sqrMoveThreshold);
			if (!gameObject.GetComponent<NPCAnimScript>().isLayingDown || !gameObject.GetComponent<NPCAnimScript>().isSitting)
			{
				if (((target.position - targetPosOld).sqrMagnitude > sqrMoveThreshold) || oldTarget != target || wallReached) {
				if (oldTarget != target) oldTarget = target;
				if (wallReached) wallReached = false;

				switch (floor)
				{
					case 1:
						PathRequestManager1.RequestPath (new PathRequest1(transform.position, target.position, OnPathFound));
						break;
					case 2:
						PathRequestManager2.RequestPath (new PathRequest2(transform.position, target.position, OnPathFound));
						break;
					case 3:
						PathRequestManager3.RequestPath (new PathRequest3(transform.position, target.position, OnPathFound));
						break;
				}
				
				targetPosOld = target.position;
			}
			}
		}
	}

	IEnumerator FollowPath() {

		bool followingPath = true;
		int pathIndex = 0;
		transform.LookAt (path.lookPoints [0]);

		float speedPercent = 1;

		while (followingPath) {
			Vector2 pos2D = new Vector2 (transform.position.x, transform.position.z);
			while (path.turnBoundaries [pathIndex].HasCrossedLine (pos2D)) {
				if (pathIndex == path.finishLineIndex) {
					followingPath = false;
					break;
				} else {
					pathIndex++;
				}
			}

			if (followingPath) {

				animScript.slowDown = false;
				animScript.stopped = false;

				if (pathIndex >= path.slowDownIndex && stoppingDst > 0) {
					speedPercent = Mathf.Clamp01 (path.turnBoundaries [path.finishLineIndex].DistanceFromPoint (pos2D) / stoppingDst);

					if (speedPercent != 1f) animScript.slowDown = true;

					if (speedPercent < 0.01f) {
						followingPath = false;
						Debug.Log("Completed path");
					}
				}

				// TODO: Add lock for when target has been changed while laying down or sitting down
				Quaternion targetRotation = Quaternion.LookRotation (path.lookPoints [pathIndex] - transform.position);
				transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
				transform.Translate (Vector3.forward * Time.deltaTime * speed * speedPercent, Space.Self);
			}

			yield return null;

		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag.Equals("walls")) {
			wallReached = true;
			Debug.Log("HIT");
		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			path.DrawWithGizmos ();
		}
	}
}
