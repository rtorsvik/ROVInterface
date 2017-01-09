using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectInput;

/// <summary>
/// Class handles input from one or more joysticks,
/// Get state of joystick by for instance calling JoystickHandler.joystick[1].axis[1] 
/// </summary>
class JoystickHandler
{
	//public static Joystick[] joystick;
	public TJoystick[] joystick;

	/// <summary>
	/// Constructor
	/// </summary>
	public JoystickHandler()
	{
		joystick = GetSticks();
	}

	/// <summary>
	/// Call this method to update the state of all the joysticks
	/// </summary>
	public void update()
	{
		foreach(TJoystick j in joystick)
		{
			j.update();
			Console.WriteLine(j.ToString());
		}
	}

	//initializing connected joysticks and collecting them into a Jaystick-array
	//ref.: Chris Charitidis https://www.youtube.com/watch?v=rtnLGfAj7W0
	public TJoystick[] GetSticks()
	{
		DirectInput input = new DirectInput();

		//List<SlimDX.DirectInput.Joystick> temp_sticks = new List<SlimDX.DirectInput.Joystick>();
		List<TJoystick> temp_sticks = new List<TJoystick>();
		foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
		{
			try
			{
				Joystick stick = new SlimDX.DirectInput.Joystick(input, device.InstanceGuid);
				stick.Acquire();

				TJoystick tstick = new TJoystick(stick);

                //temp_sticks.Add(stick);
				temp_sticks.Add(tstick);

			}
			catch (DirectInputException)
			{
				throw;
			}
		}

		return temp_sticks.ToArray();

	}


}

public class TJoystick
{
	private Joystick joystick;
	public int[] axis;
	public bool[] buttons;

	public TJoystick(Joystick joystick)
	{
		this.joystick = joystick;
		axis = new int[24];
		buttons = new bool[128];
	}

	/// <summary>
	/// Update state of joystick
	/// </summary>
	public void update()
	{
		//Get the state of the joystick
		JoystickState state = joystick.GetCurrentState();

		//Update axes values
		axis[0] = state.AccelerationX; //Ax
		axis[1] = state.AccelerationY; //Ay
		axis[2] = state.AccelerationZ; //Az
		axis[3] = state.AngularAccelerationX; //aAx
		axis[4] = state.AngularAccelerationY; //aAy
		axis[5] = state.AngularAccelerationZ; //aAz
		axis[6] = state.AngularVelocityX; //aVx
		axis[7] = state.AngularVelocityY; //aVy
		axis[8] = state.AngularVelocityZ; //aVz
		axis[9] = state.ForceX; //Fx
		axis[10] = state.ForceY; //Fy
		axis[11] = state.ForceZ; //Fz
		axis[12] = state.RotationX; //Rx
		axis[13] = state.RotationY; //Ry
		axis[14] = state.RotationZ; //Rz
		axis[15] = state.TorqueX; //Tx
		axis[16] = state.TorqueY; //Ty
		axis[17] = state.TorqueZ; //Tz
		axis[18] = state.VelocityX; //Vx
		axis[19] = state.VelocityY; //Vy
		axis[20] = state.VelocityZ; //Vz
		axis[21] = state.X; //x
		axis[22] = state.Y; //y
		axis[23] = state.Z; //z

		//Update button values
		buttons = state.GetButtons();
	}
}

