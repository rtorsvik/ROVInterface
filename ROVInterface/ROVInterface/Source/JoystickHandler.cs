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
		TJoystick.JOYSTICKNUM = 0;  //Reset joystick counter
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
	public int[] axis;              //contains the value from each axis of the joystick, TEMP should contain scaled value of axis
	public int[] axisPrev;
	public string[] axisLabels;
	public bool[] button;
	public bool[] buttonPrev;

	public static int JOYSTICKNUM = 0;


	/// <summary>
	/// Construct a new TJoystick
	/// </summary>
	/// <param name="joystick">The SlimDX joystick to handle</param>
	public TJoystick(Joystick joystick)
	{
		this.joystick = joystick;

		axis = new int[24
			+ joystick.GetCurrentState().GetAccelerationSliders().Length
			+ joystick.GetCurrentState().GetForceSliders().Length
			+ joystick.GetCurrentState().GetSliders().Length
			+ joystick.GetCurrentState().GetVelocitySliders().Length];

		axisPrev = new int[axis.Length];

		axisLabels = new string[24
			+ joystick.GetCurrentState().GetAccelerationSliders().Length
			+ joystick.GetCurrentState().GetForceSliders().Length
			+ joystick.GetCurrentState().GetSliders().Length
			+ joystick.GetCurrentState().GetVelocitySliders().Length];

		List<string> al = new List<string>() {
			"ARx",	"ARy",	"ARz",
			"AX",	"AY",	"AZ",
			"FRx",	"FRy",	"FRz",
			"FX",	"FY",	"FZ",
			"RX",	"RY",	"RZ",
			"VRx",	"VRy",	"VRz",
			"VX",	"VY",	"VZ",
			"X",	"Y",	"Z"};

		//add sliders as axes
		int[] sliders = joystick.GetCurrentState().GetAccelerationSliders();
		for (int i = 0; i < sliders.Length; i++)
		{
			al.Add("Acceleration slider " + i);
		}

		//add sliders as axes
		sliders = joystick.GetCurrentState().GetForceSliders();
		for (int i = 0; i < sliders.Length; i++)
		{
			al.Add("Force slider " + i);
		}

		//add sliders as axes
		sliders = joystick.GetCurrentState().GetVelocitySliders();
		for (int i = 0; i < sliders.Length; i++)
		{
			al.Add("Velocity slider " + i);
		}

		//add sliders as axes
		sliders = joystick.GetCurrentState().GetSliders();
		for (int i = 0; i < sliders.Length; i++)
		{
			al.Add("Slider " + i);
		}

		axisLabels = al.ToArray();



		button = new bool[joystick.GetCurrentState().GetButtons().Length
			+ joystick.GetCurrentState().GetPointOfViewControllers().Length * 4];

		buttonPrev = new bool[button.Length];

		joystickNumber = JOYSTICKNUM++;
	}



	//TEMP
	int[] aslidersPrev;
	int[] fslidersPrev;
	int[] povPrev;
	int[] slidersPrev;
	int[] vslidersPrev;


	/// <summary>
	/// Update state of joystick
	/// </summary>
	public void Update()
	{
		//Get the state of the joystick
		JoystickState state = joystick.GetCurrentState();

		//Save prev values for autodetection of axis
		Array.Copy(axis, axisPrev, axis.Length);

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

		int asl = state.GetAccelerationSliders().Length;
		int fsl = state.GetForceSliders().Length;
		int vsl = state.GetVelocitySliders().Length;
		int sl = state.GetSliders().Length;

		Array.Copy(state.GetAccelerationSliders(),	0, axis, 24,					asl);
		Array.Copy(state.GetForceSliders(),			0, axis, 24 + asl,				fsl);
		Array.Copy(state.GetVelocitySliders(),		0, axis, 24 + asl + fsl,		vsl);
		Array.Copy(state.GetForceSliders(),			0, axis, 24 + asl + fsl + vsl,	sl);

		//Save previous
		Array.Copy(button, buttonPrev, button.Length);



		//Update button values

		//first, convert powController into boolean array to represent them as buttons
		int[] pov = state.GetPointOfViewControllers();
		int povl = pov.Length;
		bool[] povButton = new bool[povl * 4];
		for (int i = 0; i < povl; i += 4)
		{
			int povValue = pov[i/4];
			if (povValue == -1)
			{
				povButton[i + 0] = false;
				povButton[i + 1] = false;
				povButton[i + 2] = false;
				povButton[i + 3] = false;
				continue;
			}

			//north
			if (povValue >= 31500 || povValue <= 4500)
				povButton[i + 0] = true;

			//east
			if (povValue >= 4500 && povValue <= 13500)
				povButton[i + 1] = true;

			//south
			if (povValue >= 13500 && povValue <= 22500)
				povButton[i + 2] = true;

			//west
			if (povValue >= 22500 && povValue <= 31500)
				povButton[i + 3] = true;

		}

		int bl = state.GetButtons().Length;
		Array.Copy(state.GetButtons(), 0, button, 0, bl);
		Array.Copy(povButton, 0, button, bl, povButton.Length);






		//TEMP for debugging of joystick input
		/*
		if (povPrev == null)
		{
			aslidersPrev = state.GetAccelerationSliders();
			fslidersPrev = state.GetForceSliders();
			povPrev = state.GetPointOfViewControllers();
			slidersPrev = state.GetSliders();
			vslidersPrev = state.GetVelocitySliders();
		}

		int[] asliders = state.GetAccelerationSliders();
		int[] fsliders = state.GetForceSliders();
		int[] povC = state.GetPointOfViewControllers();
		int[] sliders = state.GetSliders();
		int[] vsliders = state.GetVelocitySliders();

		for(int i = 0; i < asliders.Length; i++)
		{
			if (asliders[i] != aslidersPrev[i])
				Console.WriteLine(asliders[i]);
		}
		aslidersPrev = asliders;

		for (int i = 0; i < fsliders.Length; i++)
		{
			if (fsliders[i] != fslidersPrev[i])
				Console.WriteLine(fsliders[i]);
		}
		fslidersPrev = fsliders;

		for (int i = 0; i < pov.Length; i++)
		{
			if (povC[i] != povPrev[i])
				Console.WriteLine(povC[i]);
		}
		povPrev = povC;

		for (int i = 0; i < sliders.Length; i++)
		{
			if (sliders[i] != slidersPrev[i])
				Console.WriteLine(sliders[i]);
		}
		slidersPrev = sliders;

		for (int i = 0; i < vsliders.Length; i++)
		{
			if (vsliders[i] != vslidersPrev[i])
				Console.WriteLine(vsliders[i]);
		}
		vslidersPrev = vsliders;
		*/
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

