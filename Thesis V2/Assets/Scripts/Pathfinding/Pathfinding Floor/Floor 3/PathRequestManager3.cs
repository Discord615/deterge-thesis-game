using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class PathRequestManager3 : MonoBehaviour {

	Queue<PathResult3> results = new Queue<PathResult3>();

	static PathRequestManager3 instance;
	Pathfinding3 pathfinding;

	void Awake() {
		instance = this;
		pathfinding = GetComponent<Pathfinding3>();
	}

	void Update() {
		if (results.Count > 0) {
			int itemsInQueue = results.Count;
			lock (results) {
				for (int i = 0; i < itemsInQueue; i++) {
					PathResult3 result = results.Dequeue ();
					result.callback (result.path, result.success);
				}
			}
		}
	}

	public static void RequestPath(PathRequest3 request) {
		ThreadStart threadStart = delegate {
			instance.pathfinding.FindPath (request, instance.FinishedProcessingPath);
		};
		threadStart.Invoke ();
	}

	public void FinishedProcessingPath(PathResult3 result) {
		lock (results) {
			results.Enqueue (result);
		}
	}



}

public struct PathResult3 {
	public Vector3[] path;
	public bool success;
	public Action<Vector3[], bool> callback;

	public PathResult3 (Vector3[] path, bool success, Action<Vector3[], bool> callback)
	{
		this.path = path;
		this.success = success;
		this.callback = callback;
	}

}

public struct PathRequest3 {
	public Vector3 pathStart;
	public Vector3 pathEnd;
	public Action<Vector3[], bool> callback;

	public PathRequest3(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback) {
		pathStart = _start;
		pathEnd = _end;
		callback = _callback;
	}

}
