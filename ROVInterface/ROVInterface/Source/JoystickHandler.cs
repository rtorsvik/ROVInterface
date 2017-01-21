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
static class JoystickHandler
{

	public static TJoystick[] joystick;	//A list of the connected joysticks



	/// <summary>
	/// Initialize joystickhandler (Acquire joysticks)
	/// </summary>
	public static void Init()
	{
		joystick = GetSticks();
		TJoystick.JOYSTICKNUM = 0;	//Reset joystick counter		
	}

	/// <summary>
	/// Call this method to update the state of all the joysticks
	/// </summary>
	public static void Update()
	{
		foreach(TJoystick j in joystick)
		{
			j.Update();
		}
	}



	//initializing connected joysticks and collecting them into a Jaystick-array
	//ref.: Chris Charitidis https://www.youtube.com/watch?v=rtnLGfAj7W0
	public static TJoystick[] GetSticks()
	{
		DirectInput input = new DirectInput();

		//For each connected device of type GameController, get the device and add it to a list of joysticks
		List<TJoystick> temp_sticks = new List<TJoystick>();
		foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
		{
			try
			{
				//get joystick device
				Joystick stick = new SlimDX.DirectInput.Joystick(input, device.InstanceGuid);
				stick.Acquire();

				
				//set max and min values of each axis
                foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                {
                    if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                    {
                        stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-32768, 32767);
                    }

                }
                
				//add joystick to list    
				TJoystick tstick = new TJoystick(stick);
				temp_sticks.Add(tstick);

			} catch (DirectInputException) { throw;	}
		}

		return temp_sticks.ToArray();

	}


}

public class TJoystick
{
	private Joystick joystick;
	private int joystickNumber;
	public int[] axis_raw;			//TEMP Should contain the raw value from the joystick
	public int[] axis;				//contains the value from each axis of the joystick, TEMP should contain scaled value of axis
	public bool[] button;

	public static int JOYSTICKNUM = 0;


	/// <summary>
	/// Construct a new TJoystick
	/// </summary>
	/// <param name="joystick">The SlimDX joystick to handle</param>
	public TJoystick(Joystick joystick)
	{
		this.joystick = joystick;
		axis = new int[24];
		button = new bool[128];

		joystickNumber = JOYSTICKNUM++;
	}



	/// <summary>
	/// Update state of joystick
	/// </summary>
	public void Update()
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
		button = state.GetButtons();
	}



	/// <summary>
	/// Returns the joystick number
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return "Joystick " + joystickNumber;
	}
}

