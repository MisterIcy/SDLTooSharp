using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerSensorUpdatedEventArgs : AbstractControllerEventArgs
{

    private int _sensorId;
    private float[] _data;
    public ControllerSensorUpdatedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerSensorUpdate )
        {
            throw new InvalidEventTypeException(
                "ControllerSensorUpdate",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _which = @event.CSensor.Which;
        _sensorId = @event.CSensor.Sensor;
        _data = new float[3];
        unsafe
        {
            for ( int i = 0; i < 3; i++ )
            {
                _data[i] = @event.CSensor.data[i];
            }
        }
    }

    public int GetSensorID() => _sensorId;

    public float[] GetData() => _data;
}
