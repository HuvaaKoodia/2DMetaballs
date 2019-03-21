using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    #region vars
    [FormerlySerializedAs("MetaBallPrefab")]
    public GameObject metaBallPrefab;
    [FormerlySerializedAs("Amount")]
    public int amount = 100;
    [FormerlySerializedAs("MinScale")]
    public float minScale = 1.5f;
    public Vector2 movementSpeedRange = new Vector2(0.1f, 0.2f);
    [FormerlySerializedAs("squishXRange")]
    public Vector2 squishXRange = new Vector2(1f,2f);
    [FormerlySerializedAs("squishYRange")]
    public Vector2 squishYRange = new Vector2(2f, 0.5f);
    [FormerlySerializedAs("rotationSpeedRange")]
    public Vector2 rotationSpeedRange = new Vector2(-45f, 45f);
    #endregion
    #region init
    private void Start()
    {
        //calculate world edges
        var worldEdgesMax = Camera.main.ViewportToWorldPoint(Vector3.one);
        var worldEdgesMin = Camera.main.ViewportToWorldPoint(Vector3.zero);

        for (int i = 0; i < amount; i++)
        {
            //create metaball in random position
            var randomPos = new Vector3(Random.Range(worldEdgesMin.x, worldEdgesMax.x), Random.Range(worldEdgesMin.y, worldEdgesMax.y), 0);
            var ball = Instantiate(metaBallPrefab, randomPos, Quaternion.identity) as GameObject;

            //randomize movementspeed
            var mover = ball.GetComponent<Mover>();
            mover.movementSpeed = Random.Range(movementSpeedRange.x, movementSpeedRange.y);

            //randomize squishing and rotation
            var squish = ball.GetComponent<SquishAndRotate>();

            squish.minSquishX = minScale + Random.Range(0, squishXRange.x);
            squish.maxSquishX = squish.minSquishX + Random.Range(0f, squishXRange.y);
            squish.minSquishY = minScale + Random.Range(0, squishYRange.x);
            squish.maxSquishY = squish.minSquishY + Random.Range(0, squishYRange.y);

            squish.rotationSpeedAngle = Random.Range(rotationSpeedRange.x, rotationSpeedRange.y);
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
