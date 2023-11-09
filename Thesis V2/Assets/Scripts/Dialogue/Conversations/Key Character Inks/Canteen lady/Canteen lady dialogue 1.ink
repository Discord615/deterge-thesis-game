// Canteen lady dialogue 1
INCLUDE globalInkFunctions.ink

-> cafeteriaStaff


===cafeteriaStaff===
Good morning! Welcome to the cafeteria.
    +[Introduce as a public health and food safety doctor]
        Nice to meet you doc! need anything?
            ++[Request to inspect the kitchen for safety]
                Hold on! Are you saying my kitchen is involved? Unbelievable.
                +++[Apologize and explain the purpose of the inspection]
                    ~ startQuest()
                    Fine! If you can prove our kitchen is unsafe, we'll allow an inspection.
                    -> FinishConvo
                        
    +[End convo]
        -> FinishConvo
        
=== FinishConvo ===
-> END


