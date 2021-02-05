using System;
using System.Linq;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
  public static class DatabaseHelperMethods
  {
    public static int CreateNewParticipant()
    {
      using (var db = new DatabaseContext())
      {
        int participantId;
        do
        {
          participantId = Guid.NewGuid().GetHashCode();
        } while (db.Participants.Any(p => p.Id == participantId)
        ); // Continue generating until it's unique (low chance for repeat)

        // Add the participant to the Participants table
        db.Participants.Add(new Participants {Id = participantId});
        db.SaveChanges();

        return participantId;
      }
    }
  }
}