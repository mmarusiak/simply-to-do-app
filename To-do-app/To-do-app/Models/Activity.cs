using System;

namespace To_do_app.ValueObjects
{
    public class Activity
    {
        public string ActionDescription { get; }
        public bool IsDone = false;

        public Activity(string _des)
        {
            if (string.IsNullOrEmpty(_des))
            {
                throw new ArgumentException("Action description cannot be empty!");
            }
            
            ActionDescription = _des;
        }

        public static implicit operator Activity(string _des)
            => new(_des);

        public static implicit operator string(Activity _activity)
            => _activity.ActionDescription;
    }
}