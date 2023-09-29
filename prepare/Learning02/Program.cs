using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Lead Programmer";
        job1._company = "Aggro Crab";
        job1._startYear = 2019;
        job1._endYear = 2023;
        Job job2 = new Job();
        job2._jobTitle = "Character Designer";
        job2._company = "Team Cherry";
        job2._startYear = 2015;
        job2._endYear = 2019;
        Resume myResume = new Resume();
        myResume._name = "Cade Holtry";
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job1);
        myResume.Display();
    }
}