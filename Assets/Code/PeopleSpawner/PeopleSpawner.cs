using UnityEngine;
using Random = UnityEngine.Random;

namespace PeopleSpawner
{
	public class PeopleSpawner : MonoBehaviour
	{
		[SerializeField] private Person _personPrefab;
		[SerializeField] private Sprite[] _peopleSprites;

		private void Start()
		{
			InvokeRepeating(nameof(GeneratePerson), 0f, 3f);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(new Vector3(-2.5f, transform.position.y), new Vector3(2.5f, transform.position.y));
		}

		private void GeneratePerson()
		{
			var randomPosition = new Vector3(Random.Range(-2f, 2f), transform.position.y);
			Person person = Instantiate(_personPrefab, randomPosition, Quaternion.identity, transform);
			// person.SetSprite(_peopleSprites[Random.Range(0, _peopleSprites.Length)]);
			person.SetSprite(null);
		}
	}
}