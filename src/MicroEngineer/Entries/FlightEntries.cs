﻿using MicroEngineer.Utilities;

namespace MicroEngineer.Entries;

public class FlightEntry : BaseEntry
{ }

public class Speed : FlightEntry
{
    public Speed()
    {
        Name = "Speed";
        Description = "Shows the vessel's total velocity.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        MiliUnit = "mm/s";
        BaseUnit = "m/s";
        KiloUnit = "km/s";
        MegaUnit = "Mm/s";
        GigaUnit = "Gm/s";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
        AltUnit = new AltUnit()
        {
            IsActive = false,
            Unit = "km/h",
            Factor = (60f * 60f) / 1000f
        };
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.SurfaceVelocity.magnitude;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class MachNumber : FlightEntry
{
    public MachNumber()
    {
        Name = "Mach number";
        Description = "Shows the ratio of vessel's speed and local speed of sound.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = null;
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.SimulationObject.Telemetry.MachNumber;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class GeeForce : FlightEntry
{
    public GeeForce()
    {
        Name = "G-Force";
        Description = "Measurement of the type of force per unit mass – typically acceleration – that causes a perception of weight, with a g-force of 1 g equal to the conventional value of gravitational acceleration on Earth/Kerbin.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = "g";
        NumberOfDecimalDigits = 3;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.geeForce;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class AngleOfAttack : FlightEntry
{
    public AngleOfAttack()
    {
        Name = "AoA";
        Description = "Angle of Attack specifies the angle between the chord line of the wing and the vector representing the relative motion between the aircraft and the atmosphere.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = "°";
        NumberOfDecimalDigits = 3;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = AeroForces.AngleOfAttack;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class SideSlip : FlightEntry
{
    public SideSlip()
    {
        Name = "Sideslip";
        Description = "A slip is an aerodynamic state where an aircraft is moving somewhat sideways as well as forward relative to the oncoming airflow or relative wind.";
        Category = MicroEntryCategory.Flight;
        IsDefault = false;
        BaseUnit = "°";
        NumberOfDecimalDigits = 3;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = AeroForces.SideSlip;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class Heading : FlightEntry
{
    public Heading()
    {
        Name = "Heading";
        Description = "Heading of a vessel is the compass direction in which the craft's nose is pointed.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = "°";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.Heading;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class Pitch_HorizonRelative : FlightEntry
{
    public Pitch_HorizonRelative()
    {
        Name = "Pitch";
        Description = "Lateral axis passes through an aircraft from wingtip to wingtip. Rotation about this axis is called pitch (moving up-down).";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = "°";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.Pitch_HorizonRelative;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class Roll_HorizonRelative : FlightEntry
{
    public Roll_HorizonRelative()
    {
        Name = "Roll";
        Description = "Longitudinal axis passes through the aircraft from nose to tail. Rotation about this axis is called roll (rotating left-right).";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = "°";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.Roll_HorizonRelative;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class Yaw_HorizonRelative : FlightEntry
{
    public Yaw_HorizonRelative()
    {
        Name = "Yaw";
        Description = "Vertical axis passes through an aircraft from top to bottom. Rotation about this axis is called yaw (moving left-right).";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = "°";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.Yaw_HorizonRelative;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class Zenith : FlightEntry
{
    public Zenith()
    {
        Name = "Zenith";
        Description = "The zenith is an imaginary point directly above a particular location, on the celestial sphere. \"Above\" means in the vertical direction opposite to the gravity direction.";
        Category = MicroEntryCategory.Flight;
        IsDefault = false;
        BaseUnit = "°";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.Zenith;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class TotalLift : FlightEntry
{
    public TotalLift()
    {
        Name = "Total lift";
        Description = "Shows the total lift force produced by the vessel.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        MiliUnit = "mN";
        BaseUnit = "N";
        KiloUnit = "kN";
        MegaUnit = "MN";
        GigaUnit = "GN";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = AeroForces.TotalLift;
    }

    public override string ValueDisplay
    {
        get
        {
            if (EntryValue == null)
                return "-";

            double toReturn = (double)EntryValue * 1000;
            return String.IsNullOrEmpty(base.Formatting) ? toReturn.ToString() : String.Format(base.Formatting, toReturn);
        }
    }
}

public class TotalDrag : FlightEntry
{
    public TotalDrag()
    {
        Name = "Total drag";
        Description = "Shows the total drag force exerted on the vessel.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        MiliUnit = "mN";
        BaseUnit = "N";
        KiloUnit = "kN";
        MegaUnit = "MN";
        GigaUnit = "GN";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = AeroForces.TotalDrag;
    }

    public override string ValueDisplay
    {
        get
        {
            if (EntryValue == null)
                return "-";

            double toReturn = (double)EntryValue * 1000;
            return String.IsNullOrEmpty(base.Formatting) ? toReturn.ToString() : String.Format(base.Formatting, toReturn);
        }
    }
}

public class LiftDivDrag : FlightEntry
{
    public LiftDivDrag()
    {
        Name = "Lift / Drag";
        Description = "Shows the ratio of total lift and drag forces.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        BaseUnit = null;
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = AeroForces.TotalLift / AeroForces.TotalDrag;
    }

    public override string ValueDisplay
    {
        get
        {
            if (EntryValue == null)
                return "-";

            double toReturn = (double)EntryValue * 1000;
            return String.IsNullOrEmpty(base.Formatting) ? EntryValue.ToString() : String.Format(base.Formatting, EntryValue);
        }
    }
}

public class DragCoefficient : FlightEntry
{
    public DragCoefficient()
    {
        Name = "Drag coefficient";
        Description = "Dimensionless quantity that is used to quantify the drag or resistance of an object in a fluid environment, such as air or water.";
        Category = MicroEntryCategory.Flight;
        IsDefault = false;
        BaseUnit = null;
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.DragCoefficient;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class ExposedArea : FlightEntry
{
    public ExposedArea()
    {
        Name = "Exposed area";
        Description = "The surface area that interacts with the working fluid or gas.";
        Category = MicroEntryCategory.Flight;
        IsDefault = false;
        BaseUnit = null; // TODO
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.ExposedArea;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class AtmosphericDensity : FlightEntry
{
    public AtmosphericDensity()
    {
        Name = "Atm. density";
        Description = "Shows the atmospheric density.";
        Category = MicroEntryCategory.Flight;
        IsDefault = true;
        MiliUnit = "mg/L";
        BaseUnit = "g/L";
        KiloUnit = "kg/L";
        MegaUnit = "Mg/L";
        GigaUnit = "Gg/L";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.SimulationObject.Telemetry.AtmosphericDensity;
    }

    public override string ValueDisplay => base.ValueDisplay;
}

public class SoundSpeed : FlightEntry
{
    public SoundSpeed()
    {
        Name = "Speed of sound";
        Description = "Distance travelled per unit of time by a sound wave as it propagates through the air.";
        Category = MicroEntryCategory.Flight;
        IsDefault = false;
        MiliUnit = "mm/s";
        BaseUnit = "m/s";
        KiloUnit = "km/s";
        MegaUnit = "Mm/s";
        GigaUnit = "Gm/s";
        NumberOfDecimalDigits = 2;
        Formatting = "N";
        AltUnit = new AltUnit()
        {
            IsActive = false,
            Unit = "km/h",
            Factor = (60f * 60f) / 1000f
        };
    }

    public override void RefreshData()
    {
        EntryValue = Utility.ActiveVessel.SoundSpeed;
    }

    public override string ValueDisplay => base.ValueDisplay;
}