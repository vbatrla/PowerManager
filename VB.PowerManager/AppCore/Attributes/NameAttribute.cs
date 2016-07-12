namespace VB.PowerManager.AppCore.Attributes
{
    using System;

    public class NameAttribute : Attribute
    {
        public NameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}