﻿using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour, IDataPersistence
{

	[SerializeField] private string id;

	[ContextMenu("Generate guid for id")]
	private void GenerateGuid()
	{
		id = System.Guid.NewGuid().ToString();
	}

	const float minPathUpdateTime = .2f;
	const float pathUpdateMoveThreshold = .5f;

	public Vector3 target;
	private Vector3 oldTarget;
	public float speed = 3.5f;
	public float turnSpeed = 3f;
	public float turnDst = 5f;
	public float stoppingDst = 2f;
	public int floor;
	public bool wantToTeleport = false;

	Path path;

	bool wallReached = false;
	Quaternion unitRotation;
	NPCAnimScript animScript;

	private Rigidbody unitRB;

	void Start()
	{
		unitRB = GetComponent<Rigidbody>();
		animScript = GetComponent<NPCAnimScript>();

		StartCoroutine(UpdatePath());
	}

	private void Update()
	{
		if ((target == Vector3.zero || (animScript.stopped && !DialogueManager.instance.dialogueIsPlaying) || unitRB.IsSleeping()) && !animScript.isSitting && !animScript.isLayingDown)
		{
			if (animScript.isSick && animScript.goingToBed)
			{
				if (floor == 1){
					try
					{
						target = UnitTargetManager.GetInstance().getBedTarget(floor, gameObject);
					}
					catch (System.Exception)
					{
						target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(floor, gameObject);
					}
				} else {
					wantToTeleport = true;
					target = UnitTargetManager.GetInstance().getTeleportTarget(floor);
				}
				animScript.stopped = false;
			}
			else
			{
				target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(floor, gameObject);
				animScript.stopped = false;
			}
		}

		target = new Vector3(target.x, 0, target.z);

		if (!animScript.isLayingDown)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, 1, transform.localPosition.z);
		}

		unitRotation = transform.rotation;

		unitRotation.eulerAngles = new Vector3(0, unitRotation.eulerAngles.y, 0);

		transform.rotation = unitRotation;
	}

	public void LoadData(GameData data) // ? Subject to change because I can't tell what TryGetValue returns if id does not exist
	{
		// Load Unit Floor
		if (!data.NPCFloorMap.TryGetValue(id, out floor)) floor = 1;

		// Load Unit Target
		Vector3 targetOut;
		if (data.NPCTargetMap.TryGetValue(id, out targetOut))
		{
			if (targetOut == Vector3.zero) target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(floor, gameObject);
			else target = targetOut;
		}

		// Load NPC position
		Vector3 position;
		if (data.NPCposition.TryGetValue(id, out position)) this.transform.position = position;
	}

	public void SaveData(ref GameData data)
	{
		// Store Floor Number of Unit/NPC
		if (data.NPCFloorMap.ContainsKey(id))
		{
			data.NPCFloorMap.Remove(id);
		}
		data.NPCFloorMap.Add(id, floor);

		// Store Target of Unit/NPC
		if (data.NPCTargetMap.ContainsKey(id))
		{
			data.NPCTargetMap.Remove(id);
		}
		data.NPCTargetMap.Add(id, target);

		// Store NPC position
		if (data.NPCposition.ContainsKey(id))
		{
			data.NPCposition.Remove(id);
		}
		data.NPCposition.Add(id, this.transform.position);
	}

	public void OnPathFound(Vector3[] waypoints, bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = new Path(waypoints, transform.position, turnDst, stoppingDst);

			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator UpdatePath()
	{

		if (Time.timeSinceLevelLoad < .3f)
		{
			yield return new WaitForSeconds(.3f);
		}

		switch (floor)
		{

			case 1:
				PathRequestManager1.RequestPath(new PathRequest1(transform.position, target, OnPathFound));
				break;
			case 2:
				Vector3 NPCTransformWithOffset = new Vector3(transform.position.x - 850, transform.position.y, transform.position.z);
				PathRequestManager2.RequestPath(new PathRequest2(NPCTransformWithOffset, target, OnPathFound));
				break;
		}

		float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
		Vector3 targetPosOld = target;

		while (true)
		{
			yield return new WaitForSeconds(minPathUpdateTime);
			// print (((target.position - targetPosOld).sqrMagnitude) + "    " + sqrMoveThreshold);
			if (!gameObject.GetComponent<NPCAnimScript>().isLayingDown || !gameObject.GetComponent<NPCAnimScript>().isSitting)
			{
				if (((target - targetPosOld).sqrMagnitude > sqrMoveThreshold) || oldTarget == target || wallReached)
				{
					if (wallReached) wallReached = false;

					switch (floor)
					{
						case 1:
							PathRequestManager1.RequestPath(new PathRequest1(transform.position, target, OnPathFound));
							break;
						case 2:
							PathRequestManager2.RequestPath(new PathRequest2(transform.position - new Vector3(850, 0, 0), target, OnPathFound));
							break;
					}

					targetPosOld = target;
				}
			}
		}
	}

	IEnumerator FollowPath()
	{

		bool followingPath = true;
		int pathIndex = 0;
		if (!animScript.isSitting) transform.LookAt(path.lookPoints[0]);

		float speedPercent = 1;

		while (followingPath)
		{
			Vector2 pos2D = new Vector2(transform.position.x, transform.position.z);
			while (path.turnBoundaries[pathIndex].HasCrossedLine(pos2D))
			{
				if (pathIndex == path.finishLineIndex)
				{
					followingPath = false;
					break;
				}
				else
				{
					pathIndex++;
				}
			}

			if (followingPath && !animScript.isLayingDown && !animScript.isSitting)
			{

				animScript.slowDown = false;
				animScript.stopped = false;

				if (pathIndex >= path.slowDownIndex && stoppingDst > 0)
				{
					speedPercent = Mathf.Clamp01(path.turnBoundaries[path.finishLineIndex].DistanceFromPoint(pos2D) / stoppingDst);

					if (speedPercent != 1f) animScript.slowDown = true;

					if (speedPercent < 0.01f)
					{
						if (oldTarget != target) oldTarget = target;
						followingPath = false;

						animScript.stopped = true;
					}
				}

				if (!animScript.isSitting && !((gameObject == PlayerInteracting.instance.NPC) && DialogueManager.instance.dialogueIsPlaying))
				{
					Quaternion targetRotation = Quaternion.LookRotation(path.lookPoints[pathIndex] - transform.position);
					unitRB.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed));
				}

				if (!((gameObject == PlayerInteracting.instance.NPC) && DialogueManager.instance.dialogueIsPlaying))
					unitRB.MovePosition(transform.position + (transform.forward * speed * speedPercent * Time.deltaTime));
				else
				{
					animScript.stopped = true;
					transform.position = transform.position;
					transform.LookAt(GameObject.Find("Player").transform);
				}
			}

			yield return null;

		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("walls"))
		{
			wallReached = true;
			Debug.Log("HIT");
		}
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			path.DrawWithGizmos();
		}
	}
}