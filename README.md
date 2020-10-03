# GoldBadge-Challenge
Steven Grootaert: Gold Badge Challenges for SD-62. I remade this Git Repository when I was doing some trouble shooting when having problems pushing up to Git. Long story short I deleted the previous Git Repo remade this Git Repo before I figured out all I had to do was 'git pull origin master' to add the Readme Github generated to my local computer before when pushing up. 

In this Solution file are 3 Challenges:

    1. Challenge 1: Cafe - Komodo Cafe 
    2. Challenge 2: Claims - Komodo Claims Department
    3. Challenge 3: Badges - Komodo Insurance

The files are orgainzed as follows:

    01_Cafe_Console: the console app for the user
    01_Cafe_Menu: the class library for the repository methods
    01_Cfae_Tests: the unit tests for the repository methods

    02_Claims_Console: the console app for the user
    02_Claims_Department: the class library for the repository methods
    02_Claims_Tests: the unit tests for the repository methods

    03_Badges_Console: the unit tests for the repository methods
    03_Badges_Vault: the class library for the repository methods
    03_Badges_Tests: the unit tests for the repository methods

I have left commented code where I attempted certain things and/or other ways to accomplish the same task. 
    For example, in the claims console I had a method to let the user determine if the claim was valid (within 30 days of the incident date) but later decided to make this a calculation based on subtracting the claim date from the incident date and evaluating if the claim date was less than 30 days.    

I have also left comments for things that if I had more time I would do differenlty or add to functionality to the program. 
    For example, exception handling if the claim queue has nothing in it the process next claim method no longer works. I aslo began writing the code for an Update Claim method but realized that this was not nessesary when I re-read the prompt. 

I hope that grading these solutions isn't too tedious. I imagine it's a tremendous ammount of work. Thank you for all your efforts to teach this wildly difficult thing called 'coding'! 


