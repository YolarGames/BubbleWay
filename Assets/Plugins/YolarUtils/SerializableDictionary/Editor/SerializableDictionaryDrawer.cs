using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace YolarUtils.SerializableDictionary
{
	[CustomPropertyDrawer(typeof(SerializableDictionary<,>), true)]
	public class SerializableDictionaryDrawer : PropertyDrawer
	{
		private const float RemoveButtonWidth = 20f;
		private readonly GUIContent _minusIcon = EditorGUIUtility.IconContent("Toolbar Minus");
		private MethodInfo _addNewValueMethod;
		private MethodInfo _containsKeyMethod;
		private object _dictionaryObject;
		private SerializedProperty _keys;
		private SerializedProperty _values;
		private SerializedProperty _newKey;
		private SerializedProperty _newValue;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (!IsDictionaryValid())
				return EditorGUIUtility.singleLineHeight;

			int lines = _keys.arraySize + 5;
			return EditorGUIUtility.singleLineHeight * lines;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			_dictionaryObject = fieldInfo.GetValue(property.serializedObject.targetObject);
			_addNewValueMethod = GetMethodInfo("AddNewValues");
			_containsKeyMethod = GetMethodInfo("ContainsNewKey");
			_keys = property.FindPropertyRelative("_keys");
			_values = property.FindPropertyRelative("_values");
			_newKey = property.FindPropertyRelative("_newKey");
			_newValue = property.FindPropertyRelative("_newValue");

			if (!IsDictionaryValid())
			{
				EditorGUI.LabelField(position, "Invalid SerializableDictionary");
				return;
			}

			position.height = EditorGUIUtility.singleLineHeight;

			DrawFieldName(ref position, label);
			DrawNewEntryLine(ref position);
			DrawAddButton(ref position, property);
			DrawDictionaryHeader(ref position);
			DrawDictionaryContent(ref position);

			EditorGUI.EndProperty();
		}

		private static void DrawFieldName(ref Rect position, GUIContent label)
		{
			EditorGUI.LabelField(position, label);
			position.y += EditorGUIUtility.singleLineHeight;
		}

		private void DrawNewEntryLine(ref Rect position)
		{
			EditorGUI.PropertyField(GetNewLineKeyRect(position), _newKey, GUIContent.none);
			EditorGUI.PropertyField(GetNewLineValueRect(position), _newValue, GUIContent.none);

			position.y += EditorGUIUtility.singleLineHeight;
		}

		private void DrawAddButton(ref Rect position, SerializedProperty property)
		{
			bool keyExists = KeyExists();
			string buttonName = keyExists ? "Key already exists" : "Add Entry";

			if (keyExists)
				GUI.enabled = false;

			if (GUI.Button(position, buttonName) && !keyExists)
				AddNewValues(property);

			GUI.enabled = true;

			position.y += EditorGUIUtility.singleLineHeight;
		}

		private static void DrawDictionaryHeader(ref Rect position)
		{
			var headerStyle = new GUIStyle(EditorStyles.label)
			{
				alignment = TextAnchor.MiddleCenter,
			};

			position.y += EditorGUIUtility.singleLineHeight;

			EditorGUI.LabelField(GetDictionaryKeyRect(position), "Key", headerStyle);
			EditorGUI.LabelField(GetDictionaryValueRect(position), "Value", headerStyle);

			position.y += EditorGUIUtility.singleLineHeight;
		}

		private void DrawDictionaryContent(ref Rect position)
		{
			for (var i = 0; i < _keys.arraySize; i++)
			{
				EditorGUI.PropertyField(GetDictionaryKeyRect(position), _keys.GetArrayElementAtIndex(i),
					GUIContent.none);
				EditorGUI.PropertyField(GetDictionaryValueRect(position), _values.GetArrayElementAtIndex(i),
					GUIContent.none);

				if (GUI.Button(GetRemoveEntryButtonRect(position), _minusIcon))
				{
					_keys.DeleteArrayElementAtIndex(i);
					_values.DeleteArrayElementAtIndex(i);
				}

				position.y += EditorGUIUtility.singleLineHeight;
			}
		}

		private MethodInfo GetMethodInfo(string methodName)
		{
			return _dictionaryObject.GetType()
				.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
		}

		private bool IsDictionaryValid()
		{
			return _dictionaryObject != null
			       && _keys != null
			       && _values != null
			       && _newKey != null
			       && _newValue != null
			       && _addNewValueMethod != null
			       && _containsKeyMethod != null;
		}

		private static Rect GetNewLineValueRect(Rect position) =>
			new(position.x + position.width / 2, position.y, position.width / 2,
				position.height);

		private static Rect GetNewLineKeyRect(Rect position) =>
			new(position.x, position.y, position.width / 2, position.height);

		private static Rect GetRemoveEntryButtonRect(Rect position) =>
			new(position.x + position.width - RemoveButtonWidth, position.y,
				RemoveButtonWidth, position.height);

		private static Rect GetDictionaryKeyRect(Rect position) =>
			new(position.x, position.y, position.width / 2 - RemoveButtonWidth / 2,
				position.height);

		private static Rect GetDictionaryValueRect(Rect position) =>
			new(position.x + position.width / 2 - RemoveButtonWidth / 2, position.y,
				position.width / 2 - RemoveButtonWidth / 2, position.height);

		private void AddNewValues(SerializedProperty property)
		{
			_addNewValueMethod.Invoke(_dictionaryObject, null);
			property.serializedObject.Update();
		}

		private bool KeyExists()
		{
			return (bool)_containsKeyMethod.Invoke(_dictionaryObject, null);
		}
	}
}