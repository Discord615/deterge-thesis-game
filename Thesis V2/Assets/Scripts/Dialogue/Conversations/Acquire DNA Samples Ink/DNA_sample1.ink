//DNA_sample
EXTERNAL getSample()
-> doctor

=== doctor ===
Doc, I was extremely unwell. Can you help me figure it out?
+ [I'll conduct tests]
        Test? How does that work?
            ++ [We need a DNA sample, usually from saliva or blood]
                 I've never done anything like this before. Is it safe?
                    +++ [Absolutely, the process is safe]
                        ~ getSample()
                         Okay, let's do it. I want to find out what's causing this.
                        -> DONE
                        
   
-> END
