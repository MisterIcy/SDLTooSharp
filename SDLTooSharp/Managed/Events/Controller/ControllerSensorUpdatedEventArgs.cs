using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerSensorUpdatedEventArgs : AbstractControllerEventArgs
{

    public int SensorId { get; }
    public float[] Data { get; }
    public ControllerSensorUpdatedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerSensorUpdate )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerSensorUpdate,
                (EventType)@event.Type
            );
        }

        ControllerId = @event.CSensor.Which;
        SensorId = @event.CSensor.Sensor;
        Data = new float[3];
        unsafe
        {
            for ( int i = 0; i < 3; i++ )
            {
                Data[i] = @event.CSensor.data[i];
            }
        }
    }
}
