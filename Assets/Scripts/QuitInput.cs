using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitInput : MonoBehaviour 
{
#region variables
#endregion
#region initialization
	void Start () 
    {
		
	}
#endregion
#region logic
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
#endregion
#region public interface
#endregion
#region private interface
#endregion
#region events
#endregion
}
