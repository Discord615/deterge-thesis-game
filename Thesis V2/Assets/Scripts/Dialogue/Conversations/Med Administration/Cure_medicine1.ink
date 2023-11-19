//Cure_medicine
EXTERNAL administerMeds()
-> doctor

=== doctor ===
Hi doc!
+ [ How are you feeling today?]
        Not great doc, everything hurts
            ++ [I have something that might help]
                 Really? What is it?
                    +++ [It's a cure for your condition]
                        Thanks doc!
                        ~ administerMeds()
                        -> DONE
                        
   
-> END
