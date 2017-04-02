//Chris Brown
//Program 3
//Due 11-21-14
//CIS 199-01

// This application calculates the earliest registration date
// and time for an undergraduate student given their credit hours
// and last name.
// Decisions based on UofL Spring 2015 Priority Registration Schedule



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prog2
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }
        //Pre-Condition: textbox must have a letter in it to verify name to check for scheduling time along with correctly selected year in school
        //Post-Condition: Date and Time of scheduling depends on year in school and last name



        private void findRegTimeBtn_Click(object sender, EventArgs e)
        {
            const string DAY1 = "November 7";  // 1st day of registration
            const string DAY2 = "November 10"; // 2nd day of registration
            const string DAY3 = "November 11"; // 3rd day of registration
            const string DAY4 = "November 12"; // 4th day of registration
            const string DAY5 = "November 13"; // 5th day of registration
            const string DAY6 = "November 14"; // 6th day of registration

            const string TIME1 = "8:30 AM";  // 1st time block
            const string TIME2 = "10:00 AM"; // 2nd time block
            const string TIME3 = "11:30 AM"; // 3rd time block
            const string TIME4 = "2:00 PM";  // 4th time block
            const string TIME5 = "4:00 PM";  // 5th time block

            string lastNameStr;       // Entered last name
            char lastNameLetterCh;    // First letter of last name, as char
            string dateStr = "Error"; // Holds date of registration
            string timeStr = "Error"; // Holds time of registration

            lastNameStr = lastNameTxt.Text;

            if (lastNameStr == "") // Empty text box
                MessageBox.Show("Please enter last name!");
            else
            {
                lastNameLetterCh = lastNameStr[0]; // As in text, p. 466-467

                if (!char.IsLetter(lastNameLetterCh)) // Is it a letter or not?
                    MessageBox.Show("Please ensure a letter is in first position of last name!");
                else
                {
                    lastNameLetterCh = char.ToUpper(lastNameLetterCh); // Ensure upper case

                    // Juniors and Seniors share same schedule but different days
                    if (juniorBtn.Checked || seniorBtn.Checked)
                    {
                        if (seniorBtn.Checked)
                            dateStr = DAY1;
                        else // Must be juniors
                            dateStr = DAY2;

                        char[] JSRangeUpperLimit = { 'D', 'I', 'O', 'R', 'Z' }; //Upper ranges for names
                        string[] timeslot = { TIME2, TIME3, TIME4, TIME5, TIME1 }; //Time slots compared to last name position

                        for (int sub = JSRangeUpperLimit.Length - 1; sub >= 0; sub--) //allows program to keep searching till found scheduling time
                        {
                            if (lastNameLetterCh <= JSRangeUpperLimit[sub])
                            {
                                timeStr = timeslot[sub]; //time of scheduling is equal to postion
                            }
                        }
                    }
                    // Sophomores and Freshmen
                    else // Must be soph/fresh
                    {
                        if (sophBtn.Checked)
                        {
                            // C-O on one day
                            if ((lastNameLetterCh >= 'E') && // >= E and
                                (lastNameLetterCh <= 'R'))   // <= R
                                dateStr = DAY4;
                            else // All other letters on previous day
                                dateStr = DAY3;
                        }
                        else // must be freshman
                        {
                            // C-O on one day
                            if ((lastNameLetterCh >= 'E') && // >= E and
                                (lastNameLetterCh <= 'R'))   // <= R
                                dateStr = DAY6;
                            else // All other letters on previous day
                                dateStr = DAY5;
                        }

                        char[] FSRangeUpperLimit = { 'B', 'D', 'F', 'I', 'L', 'O', 'R', 'T', 'V', 'Z' }; //Upper position to name ranges
                        string[] timeslot2 = { TIME4, TIME5, TIME1, TIME2, TIME3, TIME4, TIME5, TIME1, TIME2, TIME3 }; //time of scheduling matching to same position in array as name position

                        for (int sub = FSRangeUpperLimit.Length - 1; sub >= 0; sub--)
                        {
                            if (lastNameLetterCh <= FSRangeUpperLimit[sub])
                            {
                                timeStr = timeslot2[sub];
                            }
                        }
                    }

                    dateTimeLbl.Text = dateStr + " at " + timeStr;
                }
            }
        }
    }
}
