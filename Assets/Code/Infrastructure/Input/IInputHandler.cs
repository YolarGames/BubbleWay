using System;

namespace Infrastructure.Input
{
	public interface IInputHandler
	{
		public event Action OnBack;
	}
}