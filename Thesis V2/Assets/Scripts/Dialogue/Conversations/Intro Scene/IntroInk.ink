INCLUDE globalInk.ink

-> start

=== start ===
	This is the hospital, We've got a report of a possible virus situation, and we're short-staffed. Determine the cause of the virus spread and manage the situation accordingly.

    We'll assist you. The school you're heading to has a top-notch medical lab kiosk that can guide you in handling the virus. Good luck!
    
    But before you go, I noticed you seem a bit groggy. Would you like to do a quick test before heading to the school?
    + [Sure (Start Tutorial)]
        ~ startTutorial()
        Well, let's head on over to the platform.
        -> END
        
    + [No, Thank You (Skip Tutorial)]
        Okay then.
        ->END