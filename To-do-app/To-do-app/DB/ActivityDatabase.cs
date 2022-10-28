using System.Collections.Generic;
using To_do_app.ValueObjects;

namespace To_do_app.DB
{
    internal sealed class ActivityDatabase
    {
        public IEnumerable<Activity> Activities => _activities;
        private readonly HashSet<Activity> _activities = new ();

        public ActivityDatabase() => ExampleList();
        
        public void AddActivity(Activity _activity) => _activities.Add(_activity);
        public void RemoveActivity(Activity _activity) => _activities.Remove(_activity);
        public void ClearList() => _activities.Clear();
        public void SetList(HashSet<Activity> newList)
        {
            _activities.Clear();
            foreach (var activity in newList)
                _activities.Add(activity);
        }
        private void ExampleList()
        {
            AddActivity("Walk with dog");
            AddActivity("Make homework");
            AddActivity("Clean room");
            AddActivity("Call Grandma");
            AddActivity("Watch film");
        }
    }
}