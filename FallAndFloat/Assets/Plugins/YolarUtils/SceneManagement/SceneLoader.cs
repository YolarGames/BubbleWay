using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace YolarUtils.SceneManagement
{
	[UnityEngine.Scripting.Preserve]
	public class SceneLoader : ISceneLoader
	{
		private readonly LoadingScreen _loadingScreen;

		public SceneLoader(LoadingScreen loadingScreen) =>
			_loadingScreen = loadingScreen;

		public async UniTask Load(string scene) =>
			await SceneManager.LoadSceneAsync(scene).ToUniTask();
	}
}