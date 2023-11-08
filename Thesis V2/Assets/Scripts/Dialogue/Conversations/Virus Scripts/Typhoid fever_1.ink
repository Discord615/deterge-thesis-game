// Typhoid fever:
INCLUDE globalInkFunctions.ink

-> student

=== student ===
Doc, I have a high fever and abdominal pain
    + [Can you mention any additional symptoms?]
        I've been experiencing persistent diarrhea
            ++ [When did it start and how did it happen?]
                It all began after I ate at the canteen
                    +++[Possible food-related infection]
                        What should I do?
                        ++++ [Stay hydrated and get some rest]
                            Thanks doc, I'll follow your advice.
                            -> DONE
                        ++++ [Monitor your symptoms]
                            I'll monitor my symptom
                            -> DONE
                    -> DONE
                    +++ [I'll conduct some tests to rule out infections]
                            Thanks doc!
                            
                    -> DONE
                    
    + [Administer Medicine]
    ~ administerMeds("Typhoid")
    -> END
                    
    + [End Convo]
    -> END