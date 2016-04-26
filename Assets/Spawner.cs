using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    #region vars
    public GameObject MetaBallPrefab;
    public int MetaBallAmount = 100;
    #endregion
    #region init
    private void Start()
    {
        //calculate world edges
        var worldEdgesMax = Camera.main.ViewportToWorldPoint(Vector3.one);
        var worldEdgesMin = Camera.main.ViewportToWorldPoint(Vector3.zero);

        for (int i = 0; i < MetaBallAmount; i++)
        {
            //create metaball in random position
            var randomPos = new Vector3(Random.Range(worldEdgesMin.x, worldEdgesMax.x), Random.Range(worldEdgesMin.y, worldEdgesMax.y), 0);
            var ball = Instantiate(MetaBallPrefab, randomPos, Quaternion.identity) as GameObject;

            //randomize movementspeed
            var mover = ball.GetComponent<AutoMover>();
            mover.MovementSpeed = Random.Range(0.1f, 0.5f);

            //randomize squishing and rotation
            var squish = ball.GetComponent<AutoSquishAndRotate>();
            float size = 1.5f;
            squish.MinSquishX = size + Random.Range(0, 1f);
            squish.MaxSquishX = squish.MinSquishX + Random.Range(0f, 2f);
            squish.MinSquishY = size + Random.Range(1, 2f);
            squish.MaxSquishY = squish.MinSquishY + Random.Range(0, 0.5f);

            squish.RotationSpeedAngle = Random.Range(-45, 45);
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
