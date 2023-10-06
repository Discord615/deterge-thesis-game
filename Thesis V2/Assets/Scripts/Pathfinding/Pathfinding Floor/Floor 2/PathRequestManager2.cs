using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class PathRequestManager2 : MonoBehaviour {

	Queue<PathResult2> results = new Queue<PathResult2>();

	static PathRequestManager2 instance;
	Pathfinding2 pathfinding;

	void Awake() {
		instance = this;
		pathfinding = GetComponent<Pathfinding2>();
	}

	void Update() {
		if (results.Count > 0) {
			int itemsInQueue = results.Count;
			lock (results) {
				for (int i = 0; i < itemsInQueue; i++) {
					PathResult2 result = results.Dequeue ();
					result.callback (result.path, result.success);
				}
			}
		}
	}

	public static void RequestPath(PathRequest2 request) {
		ThreadStart threadStart = delegate {
			instance.pathfinding.FindPath (request, instance.FinishedProcessingPath);
		};
		threadStart.Invoke ();
	}

	public void FinishedProcessingPath(PathResult2 result) {
		lock (results) {
			results.Enqueue (result);
		}
	}



}

public struct PathResult2 {
	public Vector3[] path;
	public bool success;
	public Action<Vector3[], bool> callback;

	public PathResult2 (Vector3[] path, bool success, Action<Vector3[], bool> callback)
	{
		this.path = path;
		this.success = success;
		this.callback = callback;
	}

}

public struct PathRequest2 {
	public Vector3 pathStart;
	public Vector3 pathEnd;
	public Action<Vector3[], bool> callback;

	public PathRequest2(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback) {
		pathStart = _start;
		pathEnd = _end;
		callback = _callback;
	}

}
