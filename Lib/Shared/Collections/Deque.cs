using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Lib.Shared.Collections;

public enum FullMode
{
	DropOldest,
	DropNewest,
	DropItem
}

public class Deque<T>
{
	private const int DefaultCapacity = 4;
	
	private T[] _items = [];
	private int _head;
	private int _tail;
	private int _size;

	public Deque() { }
	
	public Deque(int capacity)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(capacity);
		
		if (capacity == 0) return;
		
		try
		{
			capacity = checked((int)BitOperations.RoundUpToPowerOf2((uint)capacity)); // max capacity is 2^30
		}
		catch (OverflowException)
		{
			throw new OutOfMemoryException();
		}
		
		_items = new T[capacity];
	}
	
	public int Count => _size;
	
	public int Capacity => _items.Length;
	
	public bool IsEmpty => _size == 0;
	
	public bool IsFull => _size == _items.Length;
	
	public T this[int index] 
	{
		get
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if ((uint)index >= (uint)_size)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}
			
			return _items[(_head + index) & (_items.Length - 1)];
		}
	}
	
	public void AddLast(T item)
	{
		if (IsFull) Grow();
		
		_items[_tail] = item;
		_size++;
		
		if (++_tail == _items.Length)
		{
			_tail = 0;
		}
	}
	
	public void AddLast(T item, FullMode mode)
	{
		if (IsFull)
		{
			switch (mode)
			{
			case FullMode.DropOldest:
				RemoveFirst();
				break;
			case FullMode.DropNewest:
				RemoveLast();
				break;
			case FullMode.DropItem: return;
			default: throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
			}
		}
		
		AddLast(item);
	}
	
	public void AddFirst(T item)
	{
		if (IsFull) Grow();
		
		if (--_head == -1)
		{
			_head = _items.Length - 1;
		}
		
		_items[_head] = item;
		_size++;
	}
	
	public T RemoveFirst()
	{
		ThrowIfEmpty();
		
		T item = _items[_head];
		_items[_head] = default!;
		
		if (++_head == _items.Length)
		{
			_head = 0;
		}
		
		_size--;
		return item;
	}
	
	public T RemoveLast()
	{
		ThrowIfEmpty();
		
		if (--_tail == -1)
		{
			_tail = _items.Length - 1;
		}
		
		T item = _items[_tail];
		_items[_tail] = default!;
		
		_size--;
		return item;
	}
	
	public void Clear()
	{
		if (_size > 0)
		{
			if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
			{
				// TODO: clear the existing items only
				Array.Clear(_items);
			}
			_head = _tail = _size = 0;
		}
	}
	
	private bool IsContiguous() => _head + _size <= _items.Length;

	private void Grow()
	{
		Debug.Assert(_size == _items.Length);
		Debug.Assert(_head == _tail);
		
		if (_size == 0)
		{
			_items = new T[DefaultCapacity];
			return;
		}
		
		Debug.Assert((_size & (_size - 1)) == 0);
		
		int capacity;
		try
		{
			capacity = checked(_size * 2); // max capacity is 2^30
		}
		catch (OverflowException)
		{
			throw new OutOfMemoryException();
		}
		
		T[] items = new T[capacity];
		
		if (_head == 0)
		{
			Array.Copy(_items, items, _size);
		}
		else
		{
			Array.Copy(_items, _head, items, 0, _size - _head);
			Array.Copy(_items, 0, items, _size - _head, _head);
		}
		
		_items = items;
		_head = 0;
		_tail = _size;
	}
	
	private void ThrowIfEmpty()
	{
		if (_size == 0) throw new Exception("Collection is empty");
	}
}
