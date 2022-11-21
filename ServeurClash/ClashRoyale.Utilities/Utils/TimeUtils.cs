using System;

namespace ClashRoyale.Utilities.Utils
{
    public class TimeUtils
    {
        private static readonly int year;

        public static int GetSecondsUntilNextMonth
        {
            get
            {
                var now = DateTime.UtcNow;

                if (now.Month != 12)
                    return (int)(new DateTime(now.Year, now.Month + 1, 1, now.Hour,
                                      now.Minute, now.Second) - now).TotalSeconds;

                return (int)(new DateTime(now.Year + 1, 1, 1, now.Hour,
                                  now.Minute, now.Second) - now).TotalSeconds;
            }
        }

        public static int GetSecondsUntilTomorrow
        {
            get
            {
                var now = DateTime.UtcNow;
                var tomorrow = now.AddDays(1).Date;

                return (int)(tomorrow - now).TotalSeconds;
            }
        }
        public static int LeaderboardTimer
        {
            get
            {
                DateTime moment = DateTime.Now;
                int month = moment.Month;
                var seconds = (int)2678400;
                switch (month)
                {
                    case 1:
                        seconds = (int)2764800;
                        break;
                    case 2:
                        if (DateTime.IsLeapYear(year))
                        {
                            seconds = (int)2592000;
                        }
                        else
                        {
                            seconds = (int)2505600;
                        }
                        break;
                    case 3:
                        seconds = (int)2764800;
                        break;
                    case 4:
                        seconds = (int)2678400;
                        break;
                    case 5:
                        seconds = (int)2764800;
                        break;
                    case 6:
                        seconds = (int)2678400;
                        break;
                    case 7:
                        seconds = (int)2764800;
                        break;
                    case 8:
                        seconds = (int)2764800;
                        break;
                    case 9:
                        seconds = (int)2678400;
                        break;
                    case 10:
                        seconds = (int)2764800;
                        break;
                    case 11:
                        seconds = (int)2678400;
                        break;
                    case 12:
                        seconds = (int)2764800;
                        break;

                }
                int day = moment.Day * 86400 + moment.Hour * 3600 + moment.Minute * 60 + moment.Second - 600;
                return (int)(seconds - day);
            }
        }

        public static int CurrentUnixTimestamp => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}