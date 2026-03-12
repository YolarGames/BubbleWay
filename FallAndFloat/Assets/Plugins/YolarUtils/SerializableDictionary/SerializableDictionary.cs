using System;
using System.Collections.Generic;
using UnityEngine;

namespace YolarUtils.SerializableDictionary
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField, HideInInspector] private List<TKey> _keys;
		[SerializeField, HideInInspector] private List<TValue> _values;
		[SerializeField, HideInInspector] private TKey _newKey;
		[SerializeField, HideInInspector] private TValue _newValue;

		public void OnBeforeSerialize()
		{
			_keys.Clear();
			_values.Clear();

			foreach (KeyValuePair<TKey, TValue> pair in this)
			{
				_keys.Add(pair.Key);
				_values.Add(pair.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			Clear();

			if (_keys.Count != _values.Count)
				throw new Exception($"Keys count {_keys.Count} does not match values count {_values.Count}");

			for (var i = 0; i < _keys.Count; i++)
				Add(_keys[i], _values[i]);
		}

		private void AddNewValues()
		{
			Add(_newKey, _newValue);
		}

		private bool ContainsNewKey()
		{
			return ContainsKey(_newKey);
		}
	}
}