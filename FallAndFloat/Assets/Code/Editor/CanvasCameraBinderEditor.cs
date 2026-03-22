using UI;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(CanvasCameraBinder))]
	public class CanvasCameraBinderEditor : UnityEditor.Editor
	{
		private CanvasCameraBinder _canvasCameraBinder;

		private void OnEnable() =>
			_canvasCameraBinder = (CanvasCameraBinder)target;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (!_canvasCameraBinder.TryGetComponent(out Canvas _))
				EditorGUILayout.HelpBox("Canvas component not found", MessageType.Error);
		}
	}
}