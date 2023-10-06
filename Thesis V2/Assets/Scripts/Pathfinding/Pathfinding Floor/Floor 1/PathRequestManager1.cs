using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class PathRequestManager1 : MonoBehaviour {

	Queue<PathResult1> results = new Queue<PathResult1>();

	static PathRequestManager1 instance;
	Pathfinding1 pathfinding;

	void Awake() {
		instance = this;
		pathfinding = GetComponent<Pathfinding1>();
	}

	void Update() {
		if (results.Count > 0) {
			int itemsInQueue = results.Count;
			lock (results) {
				for (int i = 0; i < itemsInQueue; i++) {
					PathResult1 result = results.Dequeue ();
					result.callback (result.path, result.success);
				}
			}
		}
	}

	public static void RequestPath(PathRequest1 request) {
		ThreadStart threadStart = delegate {
			instance.pathfinding.FindPath(request, instance.FinishedProcessingPath);
		};
		threadStart.Invoke ();
	}

	public void FinishedProcessingPath(PathResult1 result) {
		lock (results) {
			results.Enqueue (result);
		}
	}



}

public struct PathResult1 {
	public Vector3[] path;
	public bool success;
	public Action<Vector3[], bool> callback;

	public PathResult1 (Vector3[] path, bool success, Action<Vector3[], bool> callback)
	{
		this.path = path;
		this.success = success;
		this.callback = callback;
	}

}

public struct PathRequest1 {
	public Vector3 pathStart;
	public Vector3 pathEnd;
	public Action<Vector3[], bool> callback;

	public PathRequest1(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback) {
		pathStart = _start;
		pathEnd = _end;
		callback = _callback;
	}

}
