#pragma once

class Pointer
{
public:
	Pointer() :m_x(0), m_y(0)
	{
	}
	Pointer(int x, int y) :m_x(x), m_y(y)
	{
	}
	Pointer(const Pointer& pointer) :m_x(pointer.m_x), m_y(pointer.m_y)
	{
	}
	~Pointer()
	{
	}
public:
	int m_x = 0, m_y = 0;
};