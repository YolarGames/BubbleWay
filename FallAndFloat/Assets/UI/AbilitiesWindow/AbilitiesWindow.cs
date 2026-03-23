using UI.PrimitiveMvc;

namespace UI.AbilitiesWindow
{
	public class AbilitiesWindow : GameWindow<AbilitiesModel, AbilitiesView>
	{
		private void OnEnable()
		{
			View.OnButtonClick += Open;
		}

		private void OnDisable()
		{
			View.OnButtonClick -= Open;
		}

		public override void Open()
		{
			base.Open();
			Invoke(nameof(Close), Model.AutoCLoseDelay);
		}
	}
}