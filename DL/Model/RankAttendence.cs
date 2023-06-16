using DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
    public class RankAttendence : IComparable<RankAttendence>
    {
        public string? Location { get; set; }
        public long Attendence { get; set; }
        public string? AwayTeamCountry { get; set; }
        public string? HomeTeamCountry { get; set; }

        public int CompareTo(RankAttendence? other) => -Attendence.CompareTo(other?.Attendence);
    }
}
