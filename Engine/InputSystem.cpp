#include "pch.h"
#include "InputSystem.h"
#include <Windows.h>

InputSystem::InputSystem() 
{

}

InputSystem::~InputSystem() 
{

}

void InputSystem::Update()
{
	POINT current_mouse_pos = {};
	::GetCursorPos(&current_mouse_pos);

	if (m_first_time)
	{
		m_old_mouse_pos = Pointer(current_mouse_pos.x, current_mouse_pos.y);
		m_first_time = false;
	}

	if (current_mouse_pos.x != m_old_mouse_pos.m_x || current_mouse_pos.y != m_old_mouse_pos.m_y)
	{
		//THERE IS MOUSE MOVE EVENT
		std::unordered_set<InputListener*>::iterator it = m_set_listeners.begin();

		while (it != m_set_listeners.end())
		{
			(*it)->onMouseMove(Pointer(current_mouse_pos.x - m_old_mouse_pos.m_x, current_mouse_pos.y - m_old_mouse_pos.m_y));
			++it;
		}
	}
	m_old_mouse_pos = Pointer(current_mouse_pos.x, current_mouse_pos.y);



	if (::GetKeyboardState(m_keys_state))
	{
		for (unsigned int i = 0; i < 256; i++)
		{
			// KEY IS DOWN
			if (m_keys_state[i] & 0x80)
			{
				std::unordered_set<InputListener*>::iterator it = m_set_listeners.begin();

				while (it != m_set_listeners.end())
				{
					if (i == VK_LBUTTON)
					{
						if (m_keys_state[i] != m_old_keys_state[i])
							(*it)->onLeftMouseDown(Pointer(current_mouse_pos.x, current_mouse_pos.y));
					}
					else if (i == VK_RBUTTON)
					{
						if (m_keys_state[i] != m_old_keys_state[i])
							(*it)->onRightMouseDown(Pointer(current_mouse_pos.x, current_mouse_pos.y));
					}
					else
						(*it)->onKeyDown(i);

					++it;
				}
			}
			else // KEY IS UP
			{
				if (m_keys_state[i] != m_old_keys_state[i])
				{
					std::unordered_set<InputListener*>::iterator it = m_set_listeners.begin();

					while (it != m_set_listeners.end())
					{
						if (i == VK_LBUTTON)
							(*it)->onLeftMouseUp(Pointer(current_mouse_pos.x, current_mouse_pos.y));
						else if (i == VK_RBUTTON)
							(*it)->onRightMouseUp(Pointer(current_mouse_pos.x, current_mouse_pos.y));
						else
							(*it)->onKeyUp(i);

						++it;
					}
				}

			}

		}
		// store current keys state to old keys state buffer
		::memcpy(m_old_keys_state, m_keys_state, sizeof(unsigned char) * 256);
	}
}

void InputSystem::addListener(InputListener* listener)
{
	m_set_listeners.insert(listener);
}

void InputSystem::removeListener(InputListener* listener)
{
	m_set_listeners.erase(listener);
}

InputSystem* InputSystem::get()
{
	static InputSystem system;
	return &system;
}