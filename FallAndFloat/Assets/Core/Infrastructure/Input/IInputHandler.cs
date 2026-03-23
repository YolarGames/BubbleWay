using System;

namespace Core.Infrastructure.Input
{
	public interface IInputHandler
	{
		public event Action OnBack;
	}
}