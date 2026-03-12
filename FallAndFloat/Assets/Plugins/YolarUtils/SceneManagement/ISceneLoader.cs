using Cysharp.Threading.Tasks;

namespace YolarUtils.SceneManagement
{
	public interface ISceneLoader
	{
		LoadingScreen LoadingScreen { get; }

		UniTask Load(string scene);
	}
}