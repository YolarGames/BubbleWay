using System.Collections.Generic;
using UnityEngine;

namespace Features.Meteors
{
	[CreateAssetMenu(fileName = "meteor-config", menuName = "Fall And Float/Configs/Meteor Config")]
	internal class MeteorConfigSo : ScriptableObject
	{
		[SerializeField] private Meteor[] _meteorPrefabs;
		private Dictionary<MeteorType, Meteor> _map;

		public Meteor GetPrefabFromMeteorType(MeteorType meteorType)
		{
			_map ??= InitMapFromConfig(_meteorPrefabs);

			return _map[meteorType];
		}

		private Dictionary<MeteorType, Meteor> InitMapFromConfig(Meteor[] meteorPrefabs)
		{
			_map ??= new Dictionary<MeteorType, Meteor>();

			foreach (Meteor prefab in meteorPrefabs)
				_map.Add(prefab.MeteorType, prefab);

			return _map;
		}
	}
}