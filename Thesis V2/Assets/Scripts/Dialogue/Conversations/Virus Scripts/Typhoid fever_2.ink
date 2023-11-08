// Typhoid fever:
INCLUDE globalInkFunctions.ink
-> student

=== student ===
I've had a persistent high fever and stomach discomfort
    + [Can you mention any additional symptoms?]
        I felt extremely thirsty and dehydrated
            ++ [When did it started? what have you eaten?]
                I ate cafeteria meals recently
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