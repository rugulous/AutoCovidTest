# AutoCovidTest
Loads information from a database (in this case students) and uses that to auto-fill covid registration details

## What does it do?
A Windows form with a "Get started" button and a selenium firefox window are opened. Clicking "Get started" navigates to the UK Gov's Covid test registration site and fills out a few basic details.
Next, the Windows form prompts the user to enter their student ID number. This performs a lookup and then auto-fills most of the information.
Finally, the user must review all the entered data before completing the captcha and submitting it, then clicking "Get started" again to restart the process.

## Why have you written this?
I spent the best part of a morning in our Covid registration center, where we had hundreds of students coming through needing this information filling out. We also had a large number of stations so there was quite a lot of noise and, with face masks and sneeze guards, it was difficult to make out what was being said. As we already had verified information on our system, it made sense to just ask for their student ID number and let that data auto-fill, then confirm data.
This is because Yes/No answers are much easier to decipher than longer/free-er answers - e.g. "Do you still live on xxx street?" => "Yes" is easier to pick out than "What's the first line of your address?" => "I live at number xx on xxx street", "Great, now what's the postcode?" => "XXX XXX".

## How can I use this?
I've removed our student loading logic. The function `LoadStudentDetails` is used to grab these details so simply add your DB call and you should be good to go :)
