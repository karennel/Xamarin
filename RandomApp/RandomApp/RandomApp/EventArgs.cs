using System;

namespace RandomApp
{
	public class EventArgs<T> : EventArgs
	{
		public T Value { get; private set; }

		public EventArgs(T value)
		{
			Value = value;
		}
	}
}
