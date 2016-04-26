using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoSquishAndRotate : MonoBehaviour
{
    #region vars
    public float RotationSpeedAngle = 45f;

    public float MinSquishX = 0.5f, MaxSquishX = 1f;
    private float differenceX;

    public float MinSquishY = 0.5f, MaxSquishY = 1f;
    private float differenceY;

    private float startAngle = 0;
    #endregion
    #region init
    private void Start()
    {
        startAngle = Random.Range(0, 180);

        differenceY = (MaxSquishY - MinSquishY) * 0.5f;
        differenceX = (MaxSquishX - MinSquishX) * 0.5f;
    }
    #endregion
    #region logic
    private void Update()
    {
        transform.localScale = new Vector3(
            MinSquishX + differenceX + Mathf.Cos(startAngle + Time.time) * differenceX,
            MinSquishY + differenceY + Mathf.Sin(startAngle + Time.time) * differenceY,
            transform.localScale.z);

        transform.rotation *= Quaternion.AngleAxis(RotationSpeedAngle * Time.deltaTime, Vector3.forward);
    }
    #endregion
    #region public interface
    #endregion
    #region private interface
    #endregion
    #region events
    #endregion
}
