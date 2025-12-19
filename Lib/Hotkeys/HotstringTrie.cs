using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Lib.Shared.Collections;

namespace Lib.Hotkeys;

internal class HotstringTrie
{
	private readonly TrieNode _root = new();
	
	internal void Add(string entry, Func<Hotstring> func)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(entry);
		var current = _root;
		
		for (int i = entry.Length-1; i >= 0; i--)
		{
			var ch = entry[i];
			
			ref var node = ref CollectionsMarshal.GetValueRefOrAddDefault(current.Children, ch, out _);
			node ??= new TrieNode();
			
			current = node;
		}
		
		if (current.IsWord)
		{
			throw new Exception($"Duplicate hotstring: '{entry}'");
		}
		
		current.Entry = entry;
		current.Func = func;
		current.IsWord = true;
	}
	
	internal bool TryFind(Deque<char> input, [MaybeNullWhen(false)] out string entry, [MaybeNullWhen(false)] out Func<Hotstring> func)
	{
		entry = null; func = null;
		var current = _root;
		
		for (int i = input.Count-1; i >= 0; i--)
		{
			if (!current.Children.TryGetValue(input[i], out var node)) break;
			
			if (node.IsWord)
			{
				entry = node.Entry;
				func = node.Func;
			}
			
			current = node;
		}
		
		return entry != null;
	}
	
	internal class TrieNode
	{
		public string? Entry { get; internal set; }
		public Func<Hotstring>? Func { get; internal set; }
		
		[MemberNotNullWhen(true, nameof(Entry), nameof(Func))]
		public bool IsWord { get; internal set; }
		
		public Dictionary<char, TrieNode> Children { get; } = [];
	}
}
