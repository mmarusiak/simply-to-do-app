using System.Collections.Generic;
using System.Linq;
using To_do_app.DB;
using To_do_app.ValueObjects;

namespace To_do_app.Services
{
    public class ActivityServices
    {
        private readonly ActivityDatabase _activityDatabase = new ActivityDatabase();

        public IEnumerable<Activity> Activities => _activityDatabase.Activities;

        public void AddActivity(string activityDes)
        {
            _activityDatabase.AddActivity(activityDes);
        }

        public void RemoveActivity(Activity activity)
        {
            _activityDatabase.RemoveActivity(activity);
        }
    }
}