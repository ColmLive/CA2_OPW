using OPWProject1.Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPWProject_database
{
    class Program
    {
        static void Main(string[] args)
        {
            Authorisation U1 = new Authorisation("John Lee", "Password1", User_Company.DEASP, User_Section.Admin);
            Authorisation U2 = new Authorisation("Ciara Murphy", "Password2", User_Company.OPW, User_Section.Elective_Works);
            Authorisation U3 = new Authorisation("Eddie Jones", "Password3", User_Company.DEASP, User_Section.Accommodation);
            Authorisation U4 = new Authorisation("Peter Byrne", "Password4", User_Company.DEASP, User_Section.Accommodation);
            Authorisation U5 = new Authorisation("Peter Byrne", "Password5", User_Company.OPW, User_Section.MandE_Works);

            Building_Works W1 = new Building_Works(1231, "B0034", 2, "ELE", "Fix Toilets in AMD", 2000, Status.Pending_Approval);
            Building_Works W2 = new Building_Works(1232, "B1942", 2, "MC4", "Fix locks on main door in Kilbarrack",950, Status.Pending_Approval);
            Building_Works W3 = new Building_Works(1233, "B3380", 2, "000", "Install new electrical points", 25000,Status.Pending_Approval);
            Building_Works W4 = new Building_Works(1234, "B5183", 2, "MC5", "Fix leaking sink", 1000,Status.Pending_Approval);
            Building_Works W5 = new Building_Works(1235, "B8078", 2, "GN2", "Install Generator in Dundalk", 2000,Status.Pending_Approval);

            Property P1 = new Property(5501, "B0034", "AMD_Store Street", "Dublin 1", Property_Type.DEASP, "V4000", Property_Team.Team_North);
            Property P2= new Property(5502, "B1942", "Kilbarrack Intreo office","Dublin 11",Property_Type.DEASP, "V3410", Property_Team.Team_North);
            Property P3= new Property(5503, "B3380", "Sligo Gov office Cranmore", "Sligo", Property_Type.DEASP, "V3785", Property_Team.Team_North);
            Property P4= new Property(5504, "B5183", "Waterford Gov Office", "Waterford", Property_Type.DEASP, "V4056", Property_Team.Team_North);
            Property P5= new Property(5505, "B8078", "Dundalk Gov Offices", "Dundalk", Property_Type.DEASP, "V4421", Property_Team.Team_North);

            OPWProjectContext OPWContext = new OPWProjectContext();
            OPWContext.AuthorisationContext.Add(U1);
            OPWContext.AuthorisationContext.Add(U2);
            OPWContext.AuthorisationContext.Add(U3);
            OPWContext.AuthorisationContext.Add(U4);
            OPWContext.AuthorisationContext.Add(U5);
            OPWContext.WorksContext.Add(W1);
            OPWContext.WorksContext.Add(W2);
            OPWContext.WorksContext.Add(W3);
            OPWContext.WorksContext.Add(W4);
            OPWContext.WorksContext.Add(W5);
            OPWContext.PropertyContext.Add(P1);
            OPWContext.PropertyContext.Add(P2);
            OPWContext.PropertyContext.Add(P3);
            OPWContext.PropertyContext.Add(P4);
            OPWContext.PropertyContext.Add(P5);
            OPWContext.SaveChanges();

        }
    }
}
