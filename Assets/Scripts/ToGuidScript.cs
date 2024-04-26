using System;
using UnityEngine.XR.ARSubsystems;

public static class TrackableIdExtensions
{
    public static Guid ToGuid(this TrackableId trackableId)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(trackableId.GetHashCode()).CopyTo(bytes, 0);
        return new Guid(bytes);
    }
}
