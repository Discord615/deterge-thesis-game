//Cure_medicine
EXTERNAL administerMeds()
-> doctor

=== doctor ===
Hey there!
+ [How's it going?]
        I've been feeling unwell
            ++ [I might have something to help]
                 Really? What is it?
                    +++ [It's a cure for your condition]
                        Thanks a lot!
                        ~ administerMeds()
                        -> DONE
                        
   
-> END
