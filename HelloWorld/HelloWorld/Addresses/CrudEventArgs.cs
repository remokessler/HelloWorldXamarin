using System;

namespace HelloWorld.Addresses
{
    public class CrudEventArgs : EventArgs
    {
        public Change Change;
        public CrudEventArgs(Change c)
        {
            Change = c;
        }
    }
    public enum Change
    {
        Create,
        Read,
        Update,
        Delete
    }
}
