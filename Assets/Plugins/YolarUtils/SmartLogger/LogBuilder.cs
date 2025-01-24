using System;
using UnityEngine;

namespace YolarUtils.SmartLogger
{
	public struct LogBuilder
	{
		public static event Action<string> OnLog;
		private readonly LogSender _sender;
		private LogType _logType;
		private string _text;
		private string _message;
		private string _cleanMessage;
		private string _eventMessage;

		public LogBuilder(LogSender sender)
		{
			_sender = sender;
			_logType = LogType.Log;
			_text = null;
			_message = null;
			_cleanMessage = null;
			_eventMessage = null;
		}

		public LogBuilder WithText(object message)
		{
			_text = message.ToString();
			_message = null;
			return this;
		}

		public LogBuilder OfType(LogType type)
		{
			_logType = type;
			return this;
		}

		public void Log()
		{
			if (CanLog())
				SendLog();
		}

		private void SendLog()
		{
			_message ??= _sender.Name + " " + _text;
			_cleanMessage ??= _message.ClearStyles();
			_eventMessage ??= $"[{_logType.ToString()}] {_cleanMessage}";

			OnLog?.Invoke(_eventMessage);

			switch (_logType)
			{
				case LogType.Log:
					Debug.Log(_message);
					break;

				case LogType.Warning:
					Debug.LogWarning(_message);
					break;

				case LogType.Assert:
					Debug.LogAssertion(_message);
					break;

				case LogType.Error:
					Debug.LogError(_message);
					break;
			}
		}

		private bool CanLog() =>
			PlatformAvailable(_sender.Platform) && _logType != LogType.Exception;

		private static bool PlatformAvailable(LogPlatform platform)
		{
			return IsEditorFlagMatch(platform)
			       || BuildFlagMatch(platform)
			       || DebugBuildFlagMatch(platform);
		}

		private static bool BuildFlagMatch(LogPlatform platform) =>
			!Debug.isDebugBuild && !Application.isEditor && platform.HasFlag(LogPlatform.Build);

		private static bool DebugBuildFlagMatch(LogPlatform platform) =>
			Debug.isDebugBuild && !Application.isEditor && platform.HasFlag(LogPlatform.DebugBuild);

		private static bool IsEditorFlagMatch(LogPlatform platform) =>
			Application.isEditor && platform.HasFlag(LogPlatform.Editor);
	}
}