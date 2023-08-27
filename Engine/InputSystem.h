#pragma once
#include "InputListener.h"
#include <map>

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
	std::map<InputListener*, InputListener*> m_map_listeners;
	unsigned char m_keys_state[256] = {};
	unsigned char m_old_keys_state[256] = {};
};

