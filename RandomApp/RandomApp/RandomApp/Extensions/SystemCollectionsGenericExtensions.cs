using System.Diagnostics;
using System.Linq;

namespace System.Collections.Generic
{
	public static class SystemCollectionsGenericExtensions
	{
		[DebuggerStepThrough]
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
		{
			return source == null || !source.Any();
		}

		/// <summary>
		/// Finds the index of the first item matching an expression in an <see cref="System.Collections.Generic.IEnumerable{T}"/>.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="Generic.IEnumerable{T}"/> to search.</param>
		/// <param name="predicate">The expression to test the items against.</param>
		/// <returns>The index of the first matching item, or -1 if no items match.</returns>
		[DebuggerStepThrough]
		public static int FindIndex<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var index = 0;

			foreach (var item in source)
			{
				if (predicate(item))
					return index;

				index++;
			}

			return -1;
		}

		[DebuggerStepThrough]
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			if (source.IsNullOrEmpty())
				return source;

			foreach (var s in source)
				action(s);

			return source;
		}

		[DebuggerStepThrough]
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			if (source.IsNullOrEmpty())
				return source;

			var i = 0;

			foreach (var s in source)
				action(s, i++);

			return source;
		}

		[DebuggerStepThrough]
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			var random = new Random();
			return source.OrderBy(item => random.Next());
		}

		[DebuggerStepThrough]
		public static void RemoveLast<T>(this List<T> source)
		{
			if (source.IsNullOrEmpty())
				return;

			source.RemoveAt(source.Count - 1);
		}

		[DebuggerStepThrough]
		public static bool AnyEx<T>(this IEnumerable<T> source)
		{
			return source == null ? false : source.Any();
		}

		[DebuggerStepThrough]
		public static bool AnyEx<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return source == null ? false : source.Any(predicate);
		}

		[DebuggerStepThrough]
		public static List<TSource> ToListEx<TSource>(this IEnumerable<TSource> source)
		{
			return source?.ToList();
		}

		[DebuggerStepThrough]
		public static int CountEx<TSource>(this IEnumerable<TSource> source)
		{
			return source.AnyEx() ? source.Count() : 0;
		}

		[DebuggerStepThrough]
		public static int CountEx<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return source.AnyEx() ? source.Count(predicate) : 0;
		}

		public static bool IsIn<T>(this T @this, params T[] values)
		{
			return values.Contains(@this);
		}
	}
}
