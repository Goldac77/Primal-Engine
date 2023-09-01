#pragma once
#include "Pointer.h"

class InputListener 
{
public:
	InputListener()
	{

	}
	~InputListener()
	{

	}

	//KEYBOARD pure virtual callback functions
	virtual void onKeyDown(int key) = 0;
	virtual void onKeyUp(int key) = 0;

	//MOUSE pure virtual callback functions
	virtual void onMouseMove(const Pointer& delta_mouse_pos) = 0;

	virtual void onLeftMouseDown(const Pointer& mouse_pos) = 0;
	virtual void onLeftMouseUp(const Pointer& mouse_pos) = 0;

	virtual void onRightMouseDown(const Pointer& mouse_pos) = 0;
	virtual void onRightMouseUp(const Pointer& mouse_pos) = 0;
};