using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.DelegatesEvents
{
    public class ActionExercise
    {
        public void Example()
        {
            List<Action> actions = new();

            for (int i = 0; i < 10; i++)
            {
                int copy = i; // fix this will create a new variable each time in new memory address

                actions.Add(() => Console.WriteLine(copy));
            }

            actions.ForEach(action => action?.Invoke());
        }
    }
}
