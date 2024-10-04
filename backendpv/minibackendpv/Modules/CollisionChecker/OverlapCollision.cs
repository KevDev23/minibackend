using System.Diagnostics;


namespace backendpv.Modules.CollisionChecker
{
    public class OverlapCollision
    {
        /* vars labled 1 are new dates corresponding to a new reservation
         * vars labled 2 are old dates corresponding to a old reservation
         * 
         */

        public bool ResOverlapCheck(DateOnly cid1, DateOnly cod1, DateOnly cid2, DateOnly cod2)
        {
           /* Debug.WriteLine("IN ResOverlapCheck");
            Debug.WriteLine("cid1,cod1,", cid1);
            Debug.WriteLine("cid2, cod2", cid2);*/

            //if any of these are found true then we cannot make a reservation
            if (cid1 >= cid2 && cid1 < cod2)    //new res start >= old res start, excepted when new cid is younger than old checkout date
                
                return false; 

            if (cod1 > cid2 && cod1 <= cod2)    //new res end > old res start
                
                return false;

            else return true;

        }
    }
}
