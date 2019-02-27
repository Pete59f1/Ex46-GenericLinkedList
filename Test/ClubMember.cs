using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public enum Gender { Male, Female };
    public class ClubMember: IComparable<ClubMember>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        public int CompareTo(ClubMember obj)
        {
            //Cast
            //ClubMember cm = (ClubMember)(obj);
            return this.FirstName.CompareTo(obj.FirstName);
        }
        public class SortClubMembersAfterLastName : IComparer<ClubMember>
        {
            public int Compare(ClubMember first, ClubMember second)
            {
                return first.LastName.CompareTo(second.LastName);
            }
        }
        public class SortClubMembersAfterGenderAndLastName : IComparer<ClubMember>
        {
            public int Compare(ClubMember first, ClubMember second)
            {
                if (first.Gender == second.Gender)
                {
                    return first.LastName.CompareTo(second.LastName);
                }
                else if (first.Gender == Gender.Male)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} ({Gender}, {Age} years)";
        }
    }
}
