//DNA_sample
EXTERNAL getSample()
-> doctor

=== doctor ===
Doc, I've been really sick. Can you help me diagnose the issue?
+ [I'll run some tests]
        Test? How does that work?
            ++ [We require a DNA sample, often from saliva or blood]
                 I've never done this before. Is it safe?
                    +++ [Yes, the process is safe]
                        ~ getSample()
                         Okay, let's proceed. I want to get to the bottom of this.
                        -> DONE
                        
   
-> END
