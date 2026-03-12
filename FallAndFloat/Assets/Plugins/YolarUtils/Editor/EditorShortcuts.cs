using UnityEditor;
using UnityEngine;

namespace YolarUtils
{
	public class EditorShortcuts : MonoBehaviour
	{
		private const string ShortcutsMenuPath = "Tools/Yolar Utils/Editor Shortcuts/";
		private const string PingMenuPath = ShortcutsMenuPath + "Ping Object";
		private const string LockMenuPath = ShortcutsMenuPath + "Toggle Inspector Lock";
		private const string LockKeyShortcut = " _i";
		private const string PingKeyShortcut = " _o";

		[MenuItem(LockMenuPath + LockKeyShortcut)]
		private static void ToggleInspectorLock()
		{
			FocusInspectorWindow();
			ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
			ActiveEditorTracker.sharedTracker.ForceRebuild();
		}

		[MenuItem(PingMenuPath + PingKeyShortcut)]
		private static void PingObject()
		{
			FocusInspectorWindow();
			EditorGUIUtility.PingObject(Selection.activeObject);
		}

		private static void FocusInspectorWindow() =>
			EditorApplication.ExecuteMenuItem("Window/General/Inspector");
	}
}