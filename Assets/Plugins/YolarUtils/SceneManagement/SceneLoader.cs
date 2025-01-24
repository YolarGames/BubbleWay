using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using YolarUtils.AssetManagement;

namespace YolarUtils.SceneManagement
{
	[UnityEngine.Scripting.Preserve]
	public class SceneLoader : ISceneLoader
	{
		private readonly IAssetProvider _assetProvider;
		private LoadingScreen _loadingScreen;

		[UnityEngine.Scripting.Preserve]
		public SceneLoader(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public LoadingScreen LoadingScreen =>
			_loadingScreen ??= _assetProvider.Load<LoadingScreen>(Assets.LoadingScreen).Instantiate();

		public async UniTask Load(string scene) =>
			await SceneManager.LoadSceneAsync(scene).ToUniTask();
	}
}