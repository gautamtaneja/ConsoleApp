int interval = 45;
TimeOnly INTStartTime = TimeOnly.Parse("9:00 Am ");
TimeOnly StartTime = TimeOnly.Parse("9:00 Am ");
TimeOnly EndTime = TimeOnly.Parse("5:00 pm "); ;
TimeOnly StartBlockTime = TimeOnly.Parse("2:00 pm "); ;
TimeOnly EndBlockTime = TimeOnly.Parse("3:00 pm "); ;

//Console.WriteLine("Enter Interval");
//interval = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter Start Time");
//StartTime = TimeOnly.Parse(Console.ReadLine());
//Console.WriteLine("Enter End Time");
//EndTime = TimeOnly.Parse(Console.ReadLine());
//Console.WriteLine("Do ypu want to Block any Time");
//var chk = bool.Parse(Console.ReadLine());
//if (chk)
//{
//    Console.WriteLine("Enter Start Block Time");
//    StartBlockTime = TimeOnly.Parse(Console.ReadLine());   
//    Console.WriteLine("Enter End Block Time");
//    EndBlockTime = TimeOnly.Parse(Console.ReadLine());    
//}


var timeSlots = new List<TimeOnly>();
timeSlots.Add(StartTime);

while (StartTime != EndTime && StartTime < EndTime)
{
    StartTime = AddMinutes(StartTime, interval);
    if (StartTime.IsBetween(StartBlockTime, EndBlockTime))
    {
        Console.WriteLine($"{StartTime}: Blocked (BT:{StartBlockTime})");
    }
    else
    {
        if (!StartTime.AddMinutes(interval).IsBetween(StartBlockTime, EndBlockTime))
        {
            if ((StartTime < EndTime))
            {
                timeSlots.Add(StartTime);
            }

        }
        else
        {
            if (StartTime.AddMinutes(interval) == StartBlockTime)
            {
                if (!(StartTime < EndTime))
                {

                    timeSlots.Add(StartTime);
                }
            }
            Console.WriteLine($"{StartTime}: Blocked (BT:{StartBlockTime})");
        }
    }

}
int slotss = 0;
Console.WriteLine($"count:%{timeSlots.Count}");
foreach (var item in timeSlots)
{
    if(item.AddMinutes(interval).IsBetween(INTStartTime, EndTime.AddMinutes(1)) && !(item.AddMinutes(interval).IsBetween(StartBlockTime, EndBlockTime.AddMinutes(1))))
    {
        Console.WriteLine($"{item} - {item.AddMinutes(interval)}");
        slotss++;
    }
   
}

Console.WriteLine($"Total Avaliable Slots : {slotss}");
static TimeOnly AddMinutes(TimeOnly time, int intervals)
{
    return time.AddMinutes(intervals);
}

