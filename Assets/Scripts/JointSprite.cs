#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2‚Â‚ÌTransformŠ´‚ð•`‰æ‚·‚é‚½‚ß‚ÌSprite
/// </summary>
public class JointSprite : MonoBehaviour
{
	public Transform a;
	public Transform b;
	public float width = 0.5f;

	private void LateUpdate()
	{
		UpdateTransform();
	}

	void UpdateTransform()
	{
		if (a == default || b == default)
		{
			return;
		}

		Vector3 aPos = a.position;
		Vector3 bPos = b.position;
		Vector3 midPos = (aPos + bPos) * 0.5f;
		float length = Vector3.Distance(aPos, bPos);
		Quaternion rotation = Quaternion.AngleAxis(Vector3.SignedAngle(bPos - aPos, Vector3.right,  Vector3.back), Vector3.forward);
		transform.position = midPos;
		transform.rotation = rotation;
		transform.localScale = new Vector3(length, width, 1f);
	}

#if UNITY_EDITOR

	[CustomEditor(typeof(JointSprite))]
	class InternalEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (GUILayout.Button("Update Transform"))
			{
				(target as JointSprite).UpdateTransform();
				EditorUtility.SetDirty(target);
			}
		}
	}

#endif
}
