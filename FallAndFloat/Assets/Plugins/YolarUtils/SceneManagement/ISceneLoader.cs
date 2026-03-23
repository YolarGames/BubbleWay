using Cysharp.Threading.Tasks;

namespace YolarUtils.SceneManagement
{
	public interface ISceneLoader
	{
		UniTask Load(string scene);
	}
}