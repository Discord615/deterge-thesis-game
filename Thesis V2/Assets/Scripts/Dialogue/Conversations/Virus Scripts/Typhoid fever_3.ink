// Typhoid fever:
INCLUDE globalInkFunctions.ink
-> student

=== student ===
Doc, I have a high fever and severe fatigue
    + [What other symptoms are you experiencing?]
        I've also had abdominal pain and diarrhea
            ++ [When did it started? what have you eaten?]
                I've just had my lunch in the cafeteria.
                    +++[Your food seems contaminated]
                        Oh no, what should I do?
                            ++++ [Drink plenty of water]
                                Thanks doc, I'll follow your advice
                            -> DONE
                            ++++ [Take a rest]
                                Thanks doc, I'll follow your advice
                            -> DONE
                    +++[I'll conduct tests and provide treatment]
                            Thanks doc!
                    -> DONE
                    
    + [Administer Medicine]
    ~ administerMeds("Typhoid")
    -> END
                    
    + [End Convo]
    -> END