using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    #region vars
    public GameObject MetaBallPrefab;
    public int Amount = 100;
    public float MinScale = 1.5f;
    public Vector2 SquishXLimits = new Vector2(1f,2f);
    public Vector2 SquishYLimits = new Vector2(2f, 0.5f);
    public Vector2 RotationSpeedLimits = new Vector2(-45f, 45f);
    #endregion
    #region init
    private void Start()
    {
        //calculate world edges
        var worldEdgesMax = Camera.main.ViewportToWorldPoint(Vector3.one);
        var worldEdgesMin = Camera.main.ViewportToWorldPoint(Vector3.zero);

        for (int i = 0; i < Amount; i++)
        {
            //create metaball in random position
            var randomPos = new Vector3(Random.Range(worldEdgesMin.x, worldEdgesMax.x), Random.Range(worldEdgesMin.y, worldEdgesMax.y), 0);
            var ball = Instantiate(MetaBallPrefab, randomPos, Quaternion.identity) as GameObject;

            //randomize movementspeed
            var mover = ball.GetComponent<Mover>();
            mover.movementSpeed = Random.Range(0.1f, 0.5f);

            //randomize squishing and rotation
            var squish = ball.GetComponent<SquishAndRotate>();

            squish.minSquishX = MinScale + Random.Range(0, SquishXLimits.x);
            squish.maxSquishX = squish.minSquishX + Random.Range(0f, SquishXLimits.y);
            squish.minSquishY = MinScale + Random.Range(0, SquishYLimits.x);
            squish.maxSquishY = squish.minSquishY + Random.Range(0, SquishYLimits.y);

            squish.rotationSpeedAngle = Random.Range(RotationSpeedLimits.x, RotationSpeedLimits.y);
        }
    }
    #endregion
    #region logic
    #endregion
    #region public interface
    #endregion
    #region private interface
    #endregion
    #region events
    #endregion
}
