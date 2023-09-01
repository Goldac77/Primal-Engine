#pragma once
#include "InputListener.h"
#include "Pointer.h"
#include <map>
#include <unordered_set>

class InputSystem
{
public:
	InputSystem();
	~InputSystem();

	void addListener(InputListener* listener);
	void removeListener(InputListener* listener);
	void Update();

public:
	static InputSystem* get();

private:
	std::unordered_set<InputListener*> m_set_listeners;
	unsigned char m_keys_state[256] = {};
	unsigned char m_old_keys_state[256] = {};
	Pointer m_old_mouse_pos;
	bool m_first_time = true;
};

