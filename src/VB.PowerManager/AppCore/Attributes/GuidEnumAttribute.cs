namespace VB.PowerManager.AppCore.Attributes
{
    using System;

    public class GuidEnumAttribute : Attribute
    {
        public GuidEnumAttribute(string guid)
        {
            Guid = new Guid(guid);
        }

        public Guid Guid { get; set; }
    }
}