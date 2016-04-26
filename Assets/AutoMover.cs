using UnityEngine;
using System.Collections;

public class AutoMover : MonoBehaviour
{
    #region vars
    private bool moving = false;
    public float MovementSpeed = 3f;
    #endregion
    #region init
    IEnumerator Start()
    {
        //calculate world coordinates
        var worldEdgesMax = Camera.main.ViewportToWorldPoint(Vector3.one);
        var worldEdgesMin = Camera.main.ViewportToWorldPoint(Vector3.zero);

        //first random movement direction based on area around the mover -> looks better
        Vector3 movementDirection = Random.insideUnitCircle.normalized;
        moving = true;

        while (true)
        {
            //move transform
            while (moving)
            {
                transform.position += movementDirection * MovementSpeed * Time.deltaTime;
                yield return null;
            }

            //random movement direction to a position on the map
            movementDirection = new Vector3(Random.Range(worldEdgesMin.x, worldEdgesMax.x), Random.Range(worldEdgesMin.y, worldEdgesMax.y), 0) - transform.position;
            movementDirection.Normalize();
            moving = true;

            yield return null;
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
    void OnBecameInvisible()
    {
        moving = false;
    }
    #endregion
}
