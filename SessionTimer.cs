using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Threading.Tasks;


namespace CPKIO
{ 
    class SessionTimer
    {
        public DateTime startTime;
        public DateTime endTime;
        readonly Timer timer = new Timer();
        readonly ProcatEntities userContext = new ProcatEntities();

        public SessionTimer()
        {
            timer.Interval = 1000;
            timer.Start();
            startTime = DateTime.Now;
        }
        public void SaveTimeSession(string login)
        {
            endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - startTime;
            DateTime Date = DateTime.Now;
            int idWorker = userContext.Worker.Where(c => c.Login == login).Select(c => c.IDWorker).FirstOrDefault();
            var findIDWorker = userContext.Session.Where(c => c.IDWorker == idWorker).FirstOrDefault();
            if(findIDWorker==null)
            {
                Session sessionWorker = new Session
                {
                    DateSession = Date,
                    IDWorker = idWorker,
                    TimeSession = Convert.ToString(timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds)
                };
                userContext.Session.Add(sessionWorker);
            }    
            else
            {
                findIDWorker.TimeSession = Convert.ToString(timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds);
                findIDWorker.DateSession = Date;
            }
            userContext.SaveChanges();
            timer.Stop();
        }
    }
}
