using UnityEngine;

public class positionMaths {
    public static Vector3 roundVector3ToInt(Vector3 vector){
        return new Vector3(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
    }
}