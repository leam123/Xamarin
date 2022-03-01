using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MetroEvents.Models
{
    public class Event
    {
        public string name, description, type, status;
        public DateTime startDateTime, endDateTime;
        public int upvotes, participantsCount;

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public int Upvotes
        {
            get { return upvotes; }
            set { upvotes = value; }
        }
        public int ParticipantsCount
        {
            get { return participantsCount; }
            set { participantsCount = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
