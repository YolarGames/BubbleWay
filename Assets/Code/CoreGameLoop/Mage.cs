using PrimeTween;
using UnityEngine;
using YolarUtils.Extension;

namespace CoreGameLoop
{
	public class Mage : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _renderer;
		private Tween _tween;

		public void CastAt(Vector3 spawnPosition)
		{
			var offset = 0.5f;
			if (IsLeftFromMage(spawnPosition))
				LookLeft();
			else
			{
				offset *= -1;
				LookRight();
			}

			if (_tween.NotNull())
				_tween.Stop();

			_tween = StartMovementTween(spawnPosition, offset);
		}

		private Tween StartMovementTween(Vector3 spawnPosition, float offset) =>
			Tween.LocalPosition(_renderer.transform, spawnPosition.SetY(0).OffsetX(offset), 0.2f, Ease.OutCubic);

		private bool IsLeftFromMage(Vector3 spawnPosition) =>
			spawnPosition.x < _renderer.transform.position.x;

		private void LookLeft() =>
			_renderer.flipX = false;

		private void LookRight() =>
			_renderer.flipX = true;
	}
}