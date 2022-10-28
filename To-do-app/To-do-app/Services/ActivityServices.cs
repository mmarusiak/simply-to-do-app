using System.Collections.Generic;
using To_do_app.DB;
using To_do_app.ValueObjects;

namespace To_do_app.Services
{
    public class ActivityServices
    {
        private readonly ActivityDatabase _activityDatabase = new ActivityDatabase();

        public IEnumerable<Activity> Activities => _activityDatabase.Activities;
        public void AddActivity(string activityDes) => _activityDatabase.AddActivity(activityDes);

        public void RemoveActivity(Activity activity) => _activityDatabase.RemoveActivity(activity);
        
        public void ClearList() => _activityDatabase.ClearList();
        public void SetList(HashSet<Activity> newList) => _activityDatabase.SetList(newList);
    }
}