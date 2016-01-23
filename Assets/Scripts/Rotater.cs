using UnityEngine;

public class Rotater : MonoBehaviour
{
	//----------------------------------------------------------------------
	#region Class members
	
	public float m_Speed = 0.3f;
	public bool m_OnlyY = false;
	
	#endregion
	
	
	//----------------------------------------------------------------------
	#region Private update method
	
	private void Update()
	{
		// Check the only y member value
		if(this.m_OnlyY == false)
		{
			// Rotate the object
			this.transform.Rotate(this.m_Speed * Time.deltaTime, this.m_Speed * Time.deltaTime, this.m_Speed * Time.deltaTime);
		}
		else
		{
			// Rotate the object
			this.transform.Rotate(0, this.m_Speed, 0);
		}
	}
	
	#endregion
}