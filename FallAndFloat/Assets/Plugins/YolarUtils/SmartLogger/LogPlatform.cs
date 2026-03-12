using System;

namespace YolarUtils.SmartLogger
{
	[Flags]
	public enum LogPlatform
	{
		Editor = 1 << 1,
		Build = 1 << 2,
		DebugBuild = 1 << 3,
		All = Editor | Build | DebugBuild,
	}
}